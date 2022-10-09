namespace Reversivecell.Laser.Servers.Core.Protocol
{
    using Reversivecell.Laser.Titan.DataStream;

    public static class NetMessaging
    {
        private static NetMessageManager _messageManager;

        public static void ProcessReceive(byte[] data)
        {
            ByteStream stream = new ByteStream(data, data.Length);

            NetMessage message = NetMessageFactory.DecodeMessage(stream);
            if (message != null)
            {
                _messageManager.ReceiveMessage(message);
            }
        }

        public static void Init(NetMessageManager messageManager)
        {
            _messageManager = messageManager;
        }
    }
}
