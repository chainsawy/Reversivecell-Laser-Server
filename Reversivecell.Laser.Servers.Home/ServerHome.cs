namespace Reversivecell.Laser.Servers.Home
{
    using Reversivecell.Laser.Servers.Home.Game;
    using Reversivecell.Laser.Servers.Home.Session;

    internal static class ServerHome
    {
        public static void Init()
        {
            HomeManager.Init();
            HomeSessionManager.Init();
        }
    }
}
