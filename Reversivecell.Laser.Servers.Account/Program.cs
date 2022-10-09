namespace Reversivecell.Laser.Servers.Account
{
    using Reversivecell.Laser.Servers.Account.Network.Message;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Network.Utils;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            ServerCore.Init(new AccountMessageManager(), NetUtil.SERVICE_NODE_ACCOUNT, args);
            ServerAccount.Init();
            Logging.HudPrint("Account Server started!");
        }
    }
}