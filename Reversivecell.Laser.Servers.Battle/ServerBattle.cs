namespace Reversivecell.Laser.Servers.Battle
{
    using Reversivecell.Laser.Servers.Battle.Network.ServerSocket;
    using Reversivecell.Laser.Servers.Battle.Session;

    public static class ServerBattle
    {
        public static void Init()
        {
            BattleSessionManager.Init();
            NetworkUdpServerGateway.Init(9449);
        }
    }
}
