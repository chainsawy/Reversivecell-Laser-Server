namespace Reversivecell.Laser.Servers.Core.Protocol
{
    using Reversivecell.Laser.Titan.Math;

    public abstract class NetMessageManager
    {
        public static void Send(NetMessage message, int serviceNode, LogicLong sessionId)
        {
            message.ServiceNode = ServerCore.ServiceNode;
            message.SessionId = sessionId;

            byte[] data = NetMessageFactory.EncodeMessage(message);
            ServerCore.ServiceNodes[serviceNode].Send(data);
        }

        public abstract void ReceiveMessage(NetMessage message);
    }
}
