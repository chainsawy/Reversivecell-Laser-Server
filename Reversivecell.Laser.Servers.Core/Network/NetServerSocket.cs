namespace Reversivecell.Laser.Servers.Core.Network
{
    using NetMQ;
    using NetMQ.Sockets;

    public class NetServerSocket
    {
        private NetMQSocket _socket;

        public NetServerSocket(int port)
        {
            _socket = new PushSocket($">tcp://127.0.0.1:{port}");
        }

        public void Send(byte[] data)
        {
            _socket.SendFrame(data);
        }
    }
}
