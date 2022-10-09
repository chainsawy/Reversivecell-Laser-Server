namespace Reversivecell.Laser.Servers.Avatar
{
    using Reversivecell.Laser.Servers.Avatar.Network.Message;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Network.Utils;

    internal class Program
    {
        static void Main(string[] args)
        {
            ServerCore.Init(new AvatarMessageManager(), NetUtil.SERVICE_NODE_AVATAR, args);
            ServerAvatar.Init();

            Logging.HudPrint("Avatar Server started!");
        }
    }
}