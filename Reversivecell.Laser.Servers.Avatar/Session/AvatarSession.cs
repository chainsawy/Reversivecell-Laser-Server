namespace Reversivecell.Laser.Servers.Avatar.Session
{
    using Reversivecell.Laser.Servers.Avatar.Logic.Message;
    using Reversivecell.Laser.Servers.Core.Game;
    using Reversivecell.Laser.Servers.Core.Network.Session;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Session;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Util;

    internal class AvatarSession : NetSession
    {
        public AvatarEntry AvatarEntry { get; set; }
        public LogicMessageManager MessageManager { get; }
        public LogicArrayList<int> BoundServers { get; }

        public AvatarSession(AvatarEntry entry, LogicLong sessionId, LogicLong accountId) : base(sessionId, accountId)
        {
            AvatarEntry = entry;

            MessageManager = new LogicMessageManager(this);
            BoundServers = new LogicArrayList<int>();
        }

        public void Init()
        {
            ;
        }

        internal void UnbindServer(int serviceNode)
        {
            BoundServers.Add(serviceNode);

            StopSessionMessage stopSessionMessage = new StopSessionMessage();
            NetMessageManager.Send(stopSessionMessage, serviceNode, SessionId);
        }

        internal void BindServer(int serviceNode)
        {
            BoundServers.Add(serviceNode);
            
            StartSessionMessage startSessionMessage = new StartSessionMessage();
            startSessionMessage.AccountId = AccountId;
            NetMessageManager.Send(startSessionMessage, serviceNode, SessionId);
        }

        internal void UnbindAllServers()
        {
            for (int i = 0; i < BoundServers.Count; i++)
            {
                NetMessageManager.Send(new StopSessionMessage(), BoundServers[i], SessionId);
            }

            BoundServers.Clear();
        }
    }
}
