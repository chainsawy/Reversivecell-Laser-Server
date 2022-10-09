namespace Reversivecell.Laser.Servers.Proxy.Network
{
    using Reversivecell.Laser.Logic.Message;
    using Reversivecell.Laser.Servers.Proxy.Logic.Message;
    using Reversivecell.Laser.Servers.Proxy.Network.Security;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Titan;
    using Reversivecell.Laser.Titan.Library.Blake;
    using Reversivecell.Laser.Titan.Libs.NaCl;
    using Reversivecell.Laser.Titan.Message;
    using System;
    using System.Collections.Concurrent;

    internal class NetworkMessaging
    {
        private bool _destructed;
        private bool _scrambled;
        private int _pepperState;
        private byte[] _clientPublicKey;
        private byte[] _clientNonce;
        private byte[] _serverNonce;
        private byte[] _pepperSecretKey;

        private StreamEncrypter _sendEncrypter;
        private StreamEncrypter _receiveEncrypter;
        private LogicMessageFactory _messageFactory;
        private ConcurrentQueue<PiranhaMessage> _sendMessageQueue;
        private ConcurrentQueue<PiranhaMessage> _receiveMessageQueue;

        /// <summary>
        ///     Gets the <see cref="NetworkConnection"/> instance.
        /// </summary>
        internal NetworkConnection Connection { get; }

        /// <summary>
        ///     Gets the <see cref="NetworkClient"/> instance.
        /// </summary>
        internal NetworkClient Client { get; private set; }

        /// <summary>
        ///     Gets the <see cref="Game.Message.MessageManager"/> instance.
        /// </summary>
        internal MessageManager MessageManager { get; }

        /// <summary>
        ///     Gets or Sets the scrambler seed.
        /// </summary>
        internal int ScramblerSeed { get; set; }

        /// <summary>
        ///     Gets or Sets the messaging id.
        /// </summary>
        internal long MessagingId { get; set; }

        /// <summary>
        ///     Gets the server nonce for 20100.
        /// </summary>
        internal byte[] SessionToken { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkMessaging"/> class.
        /// </summary>
        internal NetworkMessaging(NetworkConnection connection)
        {
            this._pepperState = -1;
            this.MessagingId = -1;
            this.Connection = connection;
            this.Client = new NetworkClient(this);
            this.MessageManager = new MessageManager(this);
            this._sendMessageQueue = new ConcurrentQueue<PiranhaMessage>();
            this._receiveMessageQueue = new ConcurrentQueue<PiranhaMessage>();
            this._messageFactory = LogicLaserMessageFactory.Instance;
        }

        /// <summary>
        ///     Destructs this instance.
        /// </summary>
        internal void Destruct()
        {
            this._destructed = true;
            
            if (this.Client != null)
            {
                this.Client.Destruct();
                this.Client = null;
            }
            this._messageFactory = null;
        }

        /// <summary>
        ///     Sets the encrypters.
        /// </summary>
        internal void SetEncrypters(StreamEncrypter receiveEncrypter, StreamEncrypter sendEncrypter)
        {
            this._receiveEncrypter = receiveEncrypter;
            this._sendEncrypter = sendEncrypter;
        }

        /// <summary>
        ///     Reads the received data.
        /// </summary>
        internal int OnReceive(byte[] buffer, int length)
        {
            if (length >= 7)
            {
                length -= 7;

                int messageType = buffer[0] << 8 | buffer[1];
                int messageLength = buffer[2] << 16 | buffer[3] << 8 | buffer[4];
                int messageVersion = buffer[5] << 8 | buffer[6];

                if (messageLength <= length)
                {
                    int encodingLength = messageLength;
                    byte[] encodingByteArray = new byte[encodingLength];

                    Array.Copy(buffer, 7, encodingByteArray, 0, encodingLength);

                    if (this._receiveEncrypter == null)
                    {
                        if (this._pepperState == -1)
                        {
                            if (messageType == 10101)
                            {
                                return -1;
                            }
                            else if (messageType == 10100)
                            {
                                this.ReceivePepperAuthentification(ref encodingByteArray, ref encodingLength);
                            }
                        }
                        else
                        {
                            if (this._pepperState == 1)
                            {
                                if (messageType == 10101)
                                {
                                    this.HandlePepperLogin(ref encodingByteArray, ref encodingLength);
                                }
                                else
                                {
                                    return messageLength + 7;
                                }
                            }
                        }
                    }
                    else
                    {
                        int overheadEncryption = this._receiveEncrypter.GetOverheadEncryption();

                        byte[] encryptedData = encodingByteArray;
                        byte[] decryptedData = new byte[encodingLength - overheadEncryption];

                        this._receiveEncrypter.Decrypt(encryptedData, decryptedData, encodingLength);

                        encodingByteArray = decryptedData;
                        encodingLength -= overheadEncryption;
                    }

                    PiranhaMessage message = this._messageFactory.CreateMessageByType(messageType);

                    if (message != null)
                    {
                        message.SetMessageVersion(messageVersion);
                        message.GetByteStream().SetByteArray(encodingByteArray, encodingLength);

                        try
                        {
                            message.Decode();

                            if (!message.IsServerToClientMessage())
                            {
                                this._receiveMessageQueue.Enqueue(message);
                            }
                        }
                        catch (Exception exception)
                        {
                            Logging.Warning("NetworkMessaging::receive exception while the decode of message type " + messageType + ", trace: " + exception);
                        }
                        finally
                        {
                            Logging.Print("NetworkMessaging::receive message " + message.GetType().Name + " received");
                        }
                    }
                    else
                    {
                        Logging.Warning("NetworkMessaging::receive ignoring message of unknown type " + messageType);
                    }

                    return messageLength + 7;
                }
                else
                {
                    if (messageLength >= 0x3F0000)
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        ///     Receives the pepper authentification.
        /// </summary>
        internal void HandlePepperLogin(ref byte[] buffer, ref int length)
        {
            this._pepperState = 2;

            this._clientPublicKey = buffer.Take(32).ToArray();

            Blake2BHasher hasher = new Blake2BHasher();
            hasher.Update(this._clientPublicKey);
            hasher.Update(PepperKey.SERVER_PK);
            byte[] nonce = hasher.Finish();

            buffer = TweetNaCl.CryptoBoxOpen(buffer.Skip(32).ToArray(), nonce, PepperKey.SERVER_PK, PepperKey.CLIENT_SK);

            if (!SessionToken.SequenceEqual(buffer.Take(24).ToArray()))
            {
                buffer = new byte[0];
                length = 0;
                return;
            }

            _clientNonce = buffer.Skip(24).Take(24).ToArray();
            buffer = buffer.Skip(48).ToArray();
            length = buffer.Length;
        }

        /// <summary>
        ///     Receives the pepper authentification.
        /// </summary>
        internal void ReceivePepperAuthentification(ref byte[] buffer, ref int length)
        {
            this._pepperState = 1;
            this.SessionToken = this.GenerateSessionToken();
        }

        /// <summary>
        ///     Adds the specified <see cref="PiranhaMessage"/> to the send queue.
        /// </summary>
        internal void Send(PiranhaMessage message)
        {
            if (message.IsServerToClientMessage())
            {
                if (this.Connection.IsConnected())
                {
                    this._sendMessageQueue.Enqueue(message);
                }
            }
        }

        internal int GetPepperState()
        {
            return _pepperState;
        }

        /// <summary>
        ///     Generates a nonce.
        /// </summary>
        private byte[] GenerateSessionToken()
        {
            byte[] nonce = new byte[24];

            for (int i = 0; i < 24; i += 4)
            {
                int rnd = ServerCore.Random.Rand(0x7fffffff);

                nonce[i] = (byte) (rnd);
                nonce[i + 1] = (byte) (rnd >> 8);
                nonce[i + 2] = (byte) (rnd >> 16);
                nonce[i + 3] = (byte) (rnd >> 24);
            }

            return nonce;
        }

        /// <summary>
        ///     Called for send all messages in send queue.
        /// </summary>
        internal void OnWakeup()
        {
            while (this._sendMessageQueue.TryDequeue(out PiranhaMessage message))
            {
                this.OnWakeup(message);
            }
        }

        /// <summary>
        ///     Sends the specified <see cref="PiranhaMessage"/> to client.
        /// </summary>
        internal void OnWakeup(PiranhaMessage message)
        {
            if (message.GetServiceNodeType() == 1 && message.GetEncodingLength() == 0)
            {
                message.Encode();
            }

            int encodingLength = message.GetEncodingLength();
            byte[] messageByteArray = message.GetByteStream().GetByteArray();

            if (this._sendEncrypter != null)
            {
                byte[] decryptedByteArray = messageByteArray;
                byte[] encryptedByteArray = new byte[this._sendEncrypter.GetOverheadEncryption() + encodingLength];

                int encryptionResult = this._sendEncrypter.Encrypt(decryptedByteArray, encryptedByteArray, encodingLength);

                if (encryptionResult != 0)
                {
                    Logging.Error("NetworkMessaging::onWakeup encryption failure, code: " + encryptionResult);
                }

                messageByteArray = encryptedByteArray;
                encodingLength += this._sendEncrypter.GetOverheadEncryption();
            }
            else if (_pepperState == 2)
            {
                _pepperState = 3;

                Blake2BHasher hasher = new Blake2BHasher();
                hasher.Update(_clientNonce);
                hasher.Update(_clientPublicKey);
                hasher.Update(PepperKey.SERVER_PK);
                byte[] nonce = hasher.Finish();

                _pepperSecretKey = new byte[32];
                _serverNonce = new byte[24];

                TweetNaCl.RandomBytes(_pepperSecretKey);
                TweetNaCl.RandomBytes(_serverNonce);

                byte[] buffer = new byte[encodingLength + 24 + 32];
                
                Buffer.BlockCopy(_serverNonce, 0, buffer, 0, 24);
                Buffer.BlockCopy(_pepperSecretKey, 0, buffer, 24, 32);
                Buffer.BlockCopy(messageByteArray, 0, buffer, 56, encodingLength);

                messageByteArray = TweetNaCl.CryptoBox(buffer, nonce, PepperKey.SERVER_PK, PepperKey.CLIENT_SK);
                encodingLength = messageByteArray.Length;

                _receiveEncrypter = new PepperEncrypter(_pepperSecretKey, _clientNonce);
                _sendEncrypter = new PepperEncrypter(_pepperSecretKey, _serverNonce);

                if (message.GetMessageType() == 20104)
                    this.Client.State = 6;
            }

            byte[] packet = new byte[encodingLength + 7];
            Array.Copy(messageByteArray, 0, packet, 7, encodingLength);
            this.WriteHeader(message, packet, encodingLength);
            this.Connection.SendData(packet, encodingLength + 7);

            Logging.Print("NetworkMessaging::onWakeup message " + message.GetType().Name + " sent");
        }

        /// <summary>
        ///     Writes the message header.
        /// </summary>
        private void WriteHeader(PiranhaMessage message, byte[] stream, int length)
        {
            int messageType = message.GetMessageType();
            int messageVersion = message.GetMessageVersion();

            stream[1] = (byte) messageType;
            stream[0] = (byte) (messageType >> 8);
            stream[4] = (byte) length;
            stream[3] = (byte) (length >> 8);
            stream[2] = (byte) (length >> 16);
            stream[6] = (byte) messageVersion;
            stream[5] = (byte) (messageVersion >> 8);

            if (length > 0xFFFFFF)
            {
                Logging.Error("NetworkMessaging::writeHeader trying to send too big message, type " + messageType);
            }
        }

        /// <summary>
        ///     Gets the next <see cref="PiranhaMessage"/> in receive queue.
        /// </summary>
        internal bool NextMessage(out PiranhaMessage message)
        {
            return this._receiveMessageQueue.TryDequeue(out message);
        }

        /// <summary>
        ///     Gets if this instance is destructed.
        /// </summary>
        internal bool IsDestructed()
        {
            return this._destructed;
        }
    }
}