namespace Reversivecell.Laser.Servers.Core.Network
{
    using NetMQ;
    using NetMQ.Sockets;
    using Reversivecell.Laser.Servers.Core.Protocol;

    public static class NetListenSocket
    {
        private static NetMQSocket _socket;
        private static Thread _thread;

        public static void Listen(int port)
        {
            _socket = new PullSocket($"@tcp://127.0.0.1:{port}");
            _thread = new Thread(Update);
            _thread.Start();
        }

        private static void Update()
        {
            while (true)
            {
                NetMQMessage message = _socket.ReceiveMultipartMessage();
                NetListenSocket.ReadNewMessages(message);
            }
        }

        private static void ReadNewMessages(NetMQMessage message)
        {
            while (!message.IsEmpty)
            {
                NetMessaging.ProcessReceive(message.Pop().Buffer);
            }
        }
    }
}
