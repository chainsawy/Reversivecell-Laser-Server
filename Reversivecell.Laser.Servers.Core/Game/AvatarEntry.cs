namespace Reversivecell.Laser.Servers.Core.Game
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Logic.Avatar;
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Helper;
    using Reversivecell.Laser.Logic.Home;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Math;

    public class AvatarEntry
    {
        public string Name { get; set; }
        public bool NameSet { get; set; }
        public int Score { get; set; }
        public LogicPlayerThumbnailData PlayerThumbnail { get; set; }
        public int Experience { get; set; }

        public AvatarEntry()
        {
            Name = "Brawler";
            PlayerThumbnail = LogicDataTables.GetPlayerThumbnailByName("base1");
        }

        public void LoadData(LogicClientAvatar avatar, LogicClientHome home)
        {
            Name = avatar.GetName();
            NameSet = avatar.GetNameSetByUser();
            Score = avatar.GetScore();

            if (home != null)
            {
                PlayerThumbnail = home.GetDailyData().GetPlayerThumbnail();
            }
            else
            {
                PlayerThumbnail = (LogicPlayerThumbnailData)LogicDataTables.GetDataById(28000000);
            }
        }

        public void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteString(Name);
            encoder.WriteBoolean(NameSet);
            encoder.WriteVInt(Score);
            ByteStreamHelper.WriteDataReference(encoder, PlayerThumbnail);
            encoder.WriteVInt(Experience);
        }

        public void Decode(ByteStream stream)
        {
            Name = stream.ReadString();
            NameSet = stream.ReadBoolean();
            Score = stream.ReadVInt();
            PlayerThumbnail = (LogicPlayerThumbnailData)ByteStreamHelper.ReadDataReference(stream);
            Experience = stream.ReadVInt();
        }

        public JObject Save()
        {
            JObject json = new JObject();

            
            json["name"] = Name;
            json["name_set"] = NameSet;
            json["score"] = Score;

            json["thumbnail"] = PlayerThumbnail.GetGlobalID();
            json["exp"] = Experience;

            return json;
        }

        public void Load(JObject json)
        {
            Name = (string)json["name"];
            NameSet = (bool)json["name_set"];
            Score = (int)json["score"];

            PlayerThumbnail = (LogicPlayerThumbnailData)LogicDataTables.GetDataById((int)json["thumbnail"]);
            Experience = (int)json["exp"];
        }
    }
}
