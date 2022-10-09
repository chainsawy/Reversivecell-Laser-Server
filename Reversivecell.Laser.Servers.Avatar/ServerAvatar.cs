namespace Reversivecell.Laser.Servers.Avatar
{
    using Reversivecell.Laser.Servers.Avatar.Game;
    using Reversivecell.Laser.Servers.Avatar.Session;

    internal static class ServerAvatar
    {
        public static void Init()
        {
            AvatarManager.Init();
            AvatarSessionManager.Init();
        }
    }
}
