namespace Reversivecell.Laser.Servers.Core.Network.Utils
{
    public static class NetUtil
    {
        public const int SERVICE_NODE_PROXY = 1;
        public const int SERVICE_NODE_ACCOUNT = 2;
        public const int SERVICE_NODE_AVATAR = 9;
        public const int SERVICE_NODE_HOME = 10;

        public static string GetNodeName(int serviceNode)
        {
            return serviceNode switch
            {
                1 => "Proxy",
                2 => "Account",
                9 => "Avatar",
                10 => "Home",
                27 => "Battle",
                _ => "Unknown Node",
            };
        }
    }
}
