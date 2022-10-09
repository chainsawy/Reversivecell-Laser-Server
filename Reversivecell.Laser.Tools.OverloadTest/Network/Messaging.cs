namespace Reversivecell.Laser.Tools.OverloadTest.Network
{
    using Reversivecell.Laser.Logic.Message;
    using Reversivecell.Laser.Logic.Message.Account;
    using Reversivecell.Laser.Titan;
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Library.Blake;
    using Reversivecell.Laser.Titan.Libs.NaCl;
    using Reversivecell.Laser.Titan.Message;
    using Reversivecell.Laser.Titan.Message.Account;
    using Reversivecell.Laser.Titan.Message.Security;
    using Reversivecell.Laser.Tools.OverloadTest.Network.Security;

    internal class Messaging
    {
        private ServerConnection _connection;
        private MessageManager _messageManager;

        private StreamEncrypter _sendEncrypter;
        private StreamEncrypter _receiveEncrypter;

        private int _state;

        private byte[] _clientNonce;
        private byte[] _serverNonce;
        private byte[] _secretKey;

        private byte[] _sessionToken;

        public Messaging(ServerConnection connection)
        {
            _connection = connection;
            _state = 2;

            _messageManager = new MessageManager(this);
        }

        public void SendPepperAuthentication(ClientHelloMessage clientHello)
        {
            _state = 2;
            Send(clientHello);
        }

        public void SendPepperLogin(ServerHelloMessage serverHello, TitanLoginMessage loginMessage)
        {
            _sessionToken = serverHello.RemoveSessionToken();
            Send(loginMessage);
        }

        public void Send(PiranhaMessage message)
        {
            if (message.GetEncodingLength() == 0) message.Encode();
            byte[] encodingBytes = message.GetByteStream().GetByteArray();
            int encodingLength = message.GetEncodingLength();

            switch (_state)
            {
                case 3: // 10101
                    _clientNonce = new byte[24];
                    TweetNaCl.RandomBytes(_clientNonce);

                    byte[] toEncrypt = new byte[encodingLength + 48];

                    Buffer.BlockCopy(_sessionToken, 0, toEncrypt, 0, 24);
                    Buffer.BlockCopy(_clientNonce, 0, toEncrypt, 24, 24);
                    Buffer.BlockCopy(encodingBytes, 0, toEncrypt, 48, encodingLength);

                    Blake2BHasher hasher = new Blake2BHasher();
                    hasher.Update(PepperKey.CLIENT_PK);
                    hasher.Update(PepperKey.SERVER_PK);
                    byte[] nonce = hasher.Finish();

                    byte[] encrypted = TweetNaCl.CryptoBox(toEncrypt, nonce, PepperKey.SERVER_PK, PepperKey.CLIENT_SK);

                    encodingBytes = new byte[encrypted.Length + 32];
                    Buffer.BlockCopy(PepperKey.CLIENT_PK, 0, encodingBytes, 0, 32);
                    Buffer.BlockCopy(encrypted, 0, encodingBytes, 32, encrypted.Length);
                    encodingLength = encodingBytes.Length;

                    _state = 4;
                    break;
                case 5: // after pepper auth complete
                    byte[] data = new byte[encodingLength + _sendEncrypter.GetOverheadEncryption()];
                    _sendEncrypter.Encrypt(encodingBytes, data, encodingLength);
                    encodingBytes = data;
                    encodingLength += _sendEncrypter.GetOverheadEncryption();
                    break;
            }

            byte[] packet = new byte[encodingLength + 7];
            Messaging.WriteHeader(message, packet, encodingLength);
            Buffer.BlockCopy(encodingBytes, 0, packet, 7, encodingLength);

            _connection.Write(packet, encodingLength + 7);
        }

        public int OnReceive(byte[] buffer, int size)
        {
            if (size >= 7)
            {
                size -= 7;

                int messageType = buffer[0] << 8 | buffer[1];
                int messageLength = buffer[2] << 16 | buffer[3] << 8 | buffer[4];
                int messageVersion = buffer[5] << 8 | buffer[6];

                int n = messageLength;

                if (size >= messageLength)
                {
                    byte[] payload = buffer.Skip(7).Take(messageLength).ToArray();
                    
                    switch (_state)
                    {
                        case 2:
                            _state = 3;
                            break;
                        case 4:
                            Blake2BHasher hasher = new Blake2BHasher();

                            hasher.Update(_clientNonce);
                            hasher.Update(PepperKey.CLIENT_PK);
                            hasher.Update(PepperKey.SERVER_PK);
                            byte[] nonce = hasher.Finish();

                            byte[] decrypted = TweetNaCl.CryptoBoxOpen(payload, nonce, PepperKey.SERVER_PK, PepperKey.CLIENT_SK);

                            _serverNonce = decrypted.Take(24).ToArray();
                            _secretKey = decrypted.Skip(24).Take(32).ToArray();
                            payload = decrypted.Skip(56).ToArray();
                            messageLength = payload.Length;

                            _sendEncrypter = new PepperEncrypter(_secretKey, _clientNonce);
                            _receiveEncrypter = new PepperEncrypter(_secretKey, _serverNonce);

                            _state = 5;

                            Task.Run(() =>
                            {
                                while (true)
                                {
                                    Send(new KeepAliveMessage());
                                    Thread.Sleep(250);
                                }
                            });
                            break;
                        case 5:
                            byte[] data = new byte[messageLength - _receiveEncrypter.GetOverheadEncryption()];
                            if (_receiveEncrypter.Decrypt(payload, data, messageLength) != 0)
                            {
                                Debugger.Error($"Crypto error, message type: {messageType}");
                                return -1;
                            }
                            payload = data;
                            messageLength -= _receiveEncrypter.GetOverheadEncryption();
                            break;
                    }

                    PiranhaMessage message = LogicLaserMessageFactory.Instance.CreateMessageByType(messageType);
                    if (message != null)
                    {
                        message.GetByteStream().SetByteArray(payload, messageLength);
                        message.Decode();
                        _messageManager.ReceiveMessage(message);
                    }
                    else
                    {
                        Debugger.Warning($"Ignoring message of unknown type {messageType}");
                    }

                    return 7 + n;
                }
            }

            return 0;
        }

        /// <summary>
        ///     Writes the message header.
        /// </summary>
        private static void WriteHeader(PiranhaMessage message, byte[] stream, int length)
        {
            int messageType = message.GetMessageType();
            int messageVersion = message.GetMessageVersion();

            stream[1] = (byte)messageType;
            stream[0] = (byte)(messageType >> 8);
            stream[4] = (byte)length;
            stream[3] = (byte)(length >> 8);
            stream[2] = (byte)(length >> 16);
            stream[6] = (byte)messageVersion;
            stream[5] = (byte)(messageVersion >> 8);

            if (length > 0xFFFFFF)
            {
                Debugger.Error("NetworkMessaging::writeHeader trying to send too big message, type " + messageType);
            }
        }
    }
}
