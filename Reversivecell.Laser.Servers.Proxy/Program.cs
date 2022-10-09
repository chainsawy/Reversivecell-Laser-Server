namespace Reversivecell.Laser.Server
{
    using Reversivecell.Laser.Servers.Proxy.Network;
    using Reversivecell.Laser.Servers.Proxy.Network.Message;
    using Reversivecell.Laser.Servers.Proxy.Session;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Network.Utils;

    internal class Program
    {
        private static void Main(string[] args)
        {
            ServerCore.Init(new ProxyMessageManager(), NetUtil.SERVICE_NODE_PROXY, args);

            ProxySessionManager.Init();
            NetworkManager.Initialize();
            NetworkMessagingManager.Initialize();

            Logging.HudPrint("Proxy Server started!");
        }
    }
}