namespace Reversivecell.Laser.Servers.Home.Game
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Logic.Avatar;
    using Reversivecell.Laser.Logic.Home;
    using Reversivecell.Laser.Titan.Math;

    internal class HomeDocument
    {
        public int DocumentLastActionTime { get; set; }

        public LogicLong Id { get; set; }

        public LogicClientHome ClientHome { get; private set; }
        public LogicClientAvatar ClientAvatar { get; private set; }

        public HomeDocument()
        {
            Id = -1;

            ClientHome = new LogicClientHome();
            ClientAvatar = new LogicClientAvatar();
        }

        public void Init(LogicLong id)
        {
            Id = id;
            ClientAvatar = LogicClientAvatar.GetDefaultAvatar();
            ClientAvatar.SetId(id);
            ClientAvatar.SetAccountId(id);
            ClientAvatar.SetHomeId(id);

            ClientHome = new LogicClientHome();
            ClientHome.SetHomeId(id);
        }

        public JObject Save()
        {
            JObject json = new JObject();

            json["id_hi"] = Id.GetHigherInt();
            json["id_lo"] = Id.GetLowerInt();
            json["home"] = ClientHome.Save();
            json["avatar"] = ClientAvatar.Save();

            return json;
        }

        public void Load(JObject json)
        {
            Id = new LogicLong((int)json["id_hi"], (int)json["id_lo"]);

            ClientHome = new LogicClientHome();
            ClientHome.Load((JObject)json["home"]);

            ClientAvatar = new LogicClientAvatar();
            ClientAvatar.Load((JObject)json["avatar"]);
        }
    }
}
