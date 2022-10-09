namespace Reversivecell.Laser.Servers.Core.Settings
{
    using Newtonsoft.Json.Linq;

    public static class ServerConfiguration
    {
        public static string BattleServer { get; private set; }
        public static string DatabaseUrl { get; private set; }
        public static string DatabaseUser { get; private set; }
        public static string DatabasePasswd { get; private set; }

        internal static void Init()
        {
            JObject obj = JObject.Parse(File.ReadAllText("data/settings/configuration.json"));

            BattleServer = (string)obj["battle_server"];

            JObject db = (JObject)obj["database"];
            DatabaseUrl = (string)db["url"];
            DatabaseUser = (string)db["user"];
            DatabasePasswd = (string)db["passwd"];
        }
    }
}
