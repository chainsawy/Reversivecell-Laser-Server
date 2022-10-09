namespace Reversivecell.Laser.Logic.Message.Account
{
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Message.Account;

    public class LoginMessage : TitanLoginMessage
    {
        public LogicLong AccountId { get; set; }
        public string PassToken { get; set; }
        public int ClientMajor { get; set; }
        public int ClientBuild { get; set; }
        public string ResourceSha { get; set; }
        public string UDID { get; set; }
        public string Device { get; set; }

        public LoginMessage() : base()
        {
            SetMessageVersion(10);
        }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteLong(AccountId);
            Stream.WriteString(PassToken);
            Stream.WriteInt(ClientMajor);
            Stream.WriteInt(0);
            Stream.WriteInt(ClientBuild);
            Stream.WriteString(ResourceSha);
            Stream.WriteString(UDID);
            Stream.WriteString(Device);

            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteInt(0);
        }

        public override void Decode()
        {
            base.Decode();

            AccountId = Stream.ReadLong();
            PassToken = Stream.ReadString();
            ClientMajor = Stream.ReadInt();
                          Stream.ReadInt();
            ClientBuild = Stream.ReadInt();
            ResourceSha = Stream.ReadString();
            UDID = Stream.ReadString();
            Device = Stream.ReadString();
        }
    }
}
