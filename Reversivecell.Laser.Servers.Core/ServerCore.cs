namespace Reversivecell.Laser.Servers.Core
{
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Servers.Core.Network;
    using Reversivecell.Laser.Servers.Core.Network.Utils;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Settings;
    using Reversivecell.Laser.Titan.Math;

    public static class ServerCore
    {
        public static string Environment { get; private set; }
        public static int ServiceNode { get; private set; }
        public static NetServerSocket[] ServiceNodes { get; private set; }
        public static LogicRandom Random { get; private set; }

        public static void Init(NetMessageManager messageManager, int serviceNode, string[] args)
        {
            ServerCore.ServiceNode = serviceNode;
            string name = NetUtil.GetNodeName(serviceNode);

            ServerCore.Environment = "dev";

            Console.Title = $"BrawlStars - {name}";
            Console.SetOut(new PrefixedOutput(Console.Out));
            Console.ForegroundColor = ConsoleColor.Red;

            Logging.HudPrint($"Reversivecell.Laser {name} server is now starting...");

            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
            Logging.Init();
            Random = new LogicRandom((int)DateTime.Now.Ticks);
            ServerConfiguration.Init();
            LogicDataTables.Initialize();

            ServiceNodes = new NetServerSocket[30];

            ServiceNodes[1] = new NetServerSocket(10000 + 1);
            ServiceNodes[2] = new NetServerSocket(10000 + 2);
            ServiceNodes[9] = new NetServerSocket(10000 + 9);
            ServiceNodes[10] = new NetServerSocket(10000 + 10);
            ServiceNodes[27] = new NetServerSocket(10000 + 27);

            NetMessaging.Init(messageManager);

            NetListenSocket.Listen(10000 + serviceNode);
        }
    }
}