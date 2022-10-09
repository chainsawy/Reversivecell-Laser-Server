namespace Reversivecell.Laser.Servers.Proxy.Network.ServerSocket
{
    using System.Net;
    using System.Net.Sockets;

    internal class NetworkServerGateway
    {
        protected readonly Socket _listener;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkServerGateway"/> class.
        /// </summary>
        internal NetworkServerGateway(int port)
        {
            this._listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._listener.Bind(new IPEndPoint(IPAddress.Any, port));
            this._listener.Listen(500);
        }
    }
}