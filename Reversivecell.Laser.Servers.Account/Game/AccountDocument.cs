namespace Reversivecell.Laser.Servers.Account.Game
{
    using Microsoft.Extensions.ObjectPool;
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Titan.Math;

    internal class AccountDocument
    {
        public LogicLong Id { get; set; }
        public string PassToken { get; set; }
        public int SessionCount { get; set; }
        public int AccountCreationTime { get; set; }

        public AccountDocument(LogicLong id, string passToken)
        {
            Id = id;
            PassToken = passToken;
        }

        public AccountDocument()
        {
            ;
        }

        public void SessionStarted()
        {
            SessionCount++;
        }

        public string Save()
        {
            JObject obj = new JObject();
            obj["id_hi"] = Id.GetHigherInt();
            obj["id_lo"] = Id.GetLowerInt();
            obj["pass_token"] = PassToken;
            obj["session_c"] = SessionCount;
            obj["creation_t"] = AccountCreationTime;
            return obj.ToString();
        }

        public void Load(string json)
        {
            JObject obj = JObject.Parse(json);
            Id = new LogicLong((int)obj["id_hi"], (int)obj["id_lo"]);
            PassToken = (string)obj["pass_token"];
            SessionCount = (int)obj["session_c"];
            AccountCreationTime = (int)obj["creation_t"];
        }
    }
}
