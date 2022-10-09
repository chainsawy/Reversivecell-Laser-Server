namespace Reversivecell.Laser.Servers.Home
{
    using Reversivecell.Laser.Servers.Home.Network.Message;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Network.Utils;

    internal class Program
    {
        static void Main(string[] args)
        {
            ServerCore.Init(new HomeMessageManager(), NetUtil.SERVICE_NODE_HOME, args);
            ServerHome.Init();

            Logging.HudPrint("Home Server started!");
        }
    }
}