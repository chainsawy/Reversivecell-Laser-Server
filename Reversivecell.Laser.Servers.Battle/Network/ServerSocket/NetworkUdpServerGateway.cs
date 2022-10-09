namespace Reversivecell.Laser.Servers.Battle.Network.ServerSocket
{
    using System.Net;
    using System.Net.Sockets;
    using Reversivecell.Laser.Servers.Core;

    internal static class NetworkUdpServerGateway
    {
        private const int BufferSize = 2048;

        /// <summary>
        ///     Gets the udp socket port.
        /// </summary>
        internal static int Port { get; private set; }

        /// <summary>
        ///     Gets the socket listener instance.
        /// </summary>
        internal static Socket Listener { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkUdpServerGateway"/> class.
        /// </summary>
        public static void Init(int port)
        {
            NetworkUdpServerGateway.Port = port;

            NetworkUdpServerGateway.Listener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            NetworkUdpServerGateway.Listener.Bind(new IPEndPoint(IPAddress.Any, port));

            Logging.Print("NetworkUdpServerGateway::ctor listening on udp port " + port);

            SocketAsyncEventArgs receiveEvent = new SocketAsyncEventArgs();

            receiveEvent.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            receiveEvent.Completed += NetworkUdpServerGateway.ReceiveCompleted;
            receiveEvent.UserToken = NetworkUdpServerGateway.Listener;
            receiveEvent.SetBuffer(new byte[NetworkUdpServerGateway.BufferSize], 0, NetworkUdpServerGateway.BufferSize);

            if (!NetworkUdpServerGateway.Listener.ReceiveFromAsync(receiveEvent))
            {
                NetworkUdpServerGateway.ReceiveCompleted(null, receiveEvent);
            }
        }

        /// <summary>
        ///     Called when the receive event has been completed.
        /// </summary>
        private static void ReceiveCompleted(object sender, SocketAsyncEventArgs receiveEvent)
        {
            Logging.Print("Receives UDP packet from " + receiveEvent.RemoteEndPoint + ".");

            if (!NetworkUdpServerGateway.Listener.ReceiveFromAsync(receiveEvent))
            {
                NetworkUdpServerGateway.ReceiveCompleted(null, receiveEvent);
            }
        }

        /// <summary>
        ///     Called when the send event has been completed.
        /// </summary>
        private static void SendCompleted(object sender, SocketAsyncEventArgs sendEvent)
        {
            sendEvent.Dispose();
        }

        /// <summary>
        ///     Sends the buffer to specified endpoint.
        /// </summary>
        internal static void Send(byte[] buffer, int length, EndPoint endPoint)
        {
            SocketAsyncEventArgs sendEvent = new SocketAsyncEventArgs();

            sendEvent.Completed += NetworkUdpServerGateway.SendCompleted;
            sendEvent.RemoteEndPoint = endPoint;
            sendEvent.SetBuffer(buffer, 0, length);

            if (!NetworkUdpServerGateway.Listener.SendToAsync(sendEvent))
            {
                NetworkUdpServerGateway.SendCompleted(null, sendEvent);
            }
        }
    }
}
