namespace Reversivecell.Laser.Servers.Avatar.Game
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Servers.Core.Game;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Util;

    internal class AvatarDocument
    {
        public int DocumentLastActionTime { get; set; }

        public LogicLong Id { get; set; }
        public AvatarEntry AvatarEntry { get; set; }

        public AvatarDocument()
        {
            AvatarEntry = new AvatarEntry();
        }

        public JObject Save()
        {
            JObject json = new JObject();

            json["id_hi"] = Id.GetHigherInt();
            json["id_lo"] = Id.GetLowerInt();
            json["avatar_entry"] = AvatarEntry.Save();

            return json;
        }

        public void Load(JObject json)
        {
            this.DocumentLastActionTime = LogicTimeUtil.GetTimestamp();

            Id = new LogicLong((int)json["id_hi"], (int)json["id_lo"]);

            AvatarEntry = new AvatarEntry();
            AvatarEntry.Load((JObject)json["avatar_entry"]);
        }
    }
}
