namespace Reversivecell.Laser.Servers.Proxy.Session
{
    using Reversivecell.Laser.Servers.Proxy.Network;
    using Reversivecell.Laser.Servers.Core.Network.Session;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Session;
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Util;

    internal class ProxySession : NetSession
    {
        public NetworkClient Client { get; }
        public LogicArrayList<int> BoundServers { get; }

        public ProxySession(NetworkClient client, LogicLong sessionId, LogicLong accountId) : base(sessionId, accountId)
        {
            Client = client;
            BoundServers = new LogicArrayList<int>();
        }

        internal void SetAccountId(LogicLong accountId)
        {
            this.AccountId = accountId;
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
