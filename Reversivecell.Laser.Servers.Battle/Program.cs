namespace Reversivecell.Laser.Servers.Battle
{
    using Reversivecell.Laser.Servers.Battle.Network.Message;
    using Reversivecell.Laser.Servers.Core;

    internal class Program
    {
        static void Main(string[] args)
        {
            ServerCore.Init(new BattleMessageManager(), 27, args);
            ServerBattle.Init();

            Logging.HudPrint("Battle Server started!");
        }
    }
}