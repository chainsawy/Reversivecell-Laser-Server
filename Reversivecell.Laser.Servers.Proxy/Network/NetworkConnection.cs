namespace Reversivecell.Laser.Servers.Proxy.Network
{
    using System.Net;
    using System.Net.Sockets;
    using Reversivecell.Laser.Servers.Proxy.Network.ServerSocket;

    internal class NetworkConnection
    {
        private bool _destructed;
        private NetworkBuffer _buffer;

        /// <summary>
        ///     Gets the client socket instance.
        /// </summary>
        internal Socket Socket { get; }

        /// <summary>
        ///     Gets the client socket read event.
        /// </summary>
        internal SocketAsyncEventArgs ReadEvent { get; private set; }

        /// <summary>
        ///     Gets the messaging instance.
        /// </summary>
        internal NetworkMessaging Messaging { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkConnection"/> class.
        /// </summary>
        internal NetworkConnection(Socket socket, SocketAsyncEventArgs readEvent)
        {
            this.Socket = socket;
            this.ReadEvent = readEvent;

            this._buffer = new NetworkBuffer();
            this.Messaging = new NetworkMessaging(this);
        }

        /// <summary>
        ///     Destructs this instance.
        /// </summary>
        internal void Destruct()
        {
            this._destructed = true;

            if (this.Messaging != null)
            {
                this.Messaging.Destruct();
                this.Messaging = null;
            }

            if (this._buffer != null)
            {
                this._buffer.Destruct();
                this._buffer = null;
            }

            if (this.Socket != null)
            {
                this.Socket.Close();
            }

            this.ReadEvent = null;
        }

        /// <summary>
        ///     Gets if the connection is destructed.
        /// </summary>
        internal bool IsDestructed()
        {
            return this._destructed;
        }

        /// <summary>
        ///     Tries to receive the available data on the socket.
        /// </summary>
        internal bool TryReceive()
        {
            int rcv = this.ReadEvent.BytesTransferred;

            if (this._buffer.CanWrite(this.ReadEvent.Buffer, rcv))
            {
                this._buffer.Write(this.ReadEvent.Buffer, rcv);
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Gets if the client connected.
        /// </summary>
        internal bool IsConnected()
        {
            return this.Socket.Connected;
        }

        /// <summary>
        ///     Gets the client address.
        /// </summary>
        internal string GetAddress()
        {
            return ((IPEndPoint) this.Socket.RemoteEndPoint).Address.ToString();
        }

        /// <summary>
        ///     Processes the available data.
        /// </summary>
        internal bool Process()
        {
            int read = this.Messaging.OnReceive(this._buffer.GetBuffer(), this._buffer.GetLength());

            if (read != -1)
            {
                if (read != 0)
                {
                    this._buffer.Remove(read);

                    if (this._buffer.GetLength() > 0)
                    {
                        return this.Process();
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        ///     Sebds the specified buffer to client.
        /// </summary>
        internal void SendData(byte[] buffer, int length)
        {
            NetworkTcpServerGateway.Send(buffer, length, this);
        }
    }
}