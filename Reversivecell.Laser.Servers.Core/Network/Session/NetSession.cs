namespace Reversivecell.Laser.Servers.Core.Network.Session
{
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Session;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Message;

    public class NetSession
    {
        public LogicLong SessionId { get; }
        public LogicLong AccountId { get; protected set; }

        public NetSession(LogicLong sessionId, LogicLong accountId)
        {
            SessionId = sessionId;
            AccountId = accountId;
        }

        public void SendMessage(NetMessage message, int serviceNode)
        {
            NetMessageManager.Send(message, serviceNode, SessionId);
        }

        public void ForwardPiranhaMessage(PiranhaMessage message, int serviceNode)
        {
            ForwardPiranhaMessage forwardPiranhaMessage = new ForwardPiranhaMessage();
            forwardPiranhaMessage.SetPiranhaMessage(message);
            NetMessageManager.Send(forwardPiranhaMessage, serviceNode, SessionId);
        }
    }
}
