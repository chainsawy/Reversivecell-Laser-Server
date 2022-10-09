namespace Reversivecell.Laser.Logic.Message.Account
{
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Message;

    public class LoginOkMessage : PiranhaMessage
    {
        public LogicLong AccountId { get; set; }
        public LogicLong HomeId { get; set; }
        public string PassToken { get; set; }
        public string FacebookId { get; set; }
        public string GamecenterId { get; set; }
        public int MajorVersion { get; set; }
        public int BuildVersion { get; set; }
        public string ServerEnvironment { get; set; }
        public int SessionCount { get; set; }
        public int PlayTimeSeconds { get; set; }
        public int DaysSinceStartedPlaying { get; set; }
        public string FacebookAppId { get; set; }

        public LoginOkMessage() : base()
        {
            ;
        }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteLong(AccountId);
            Stream.WriteLong(HomeId);
            Stream.WriteString(PassToken);
            Stream.WriteString(FacebookId);
            Stream.WriteString(GamecenterId);
            Stream.WriteInt(MajorVersion);
            Stream.WriteInt(BuildVersion);
            Stream.WriteInt(0);
            Stream.WriteString(ServerEnvironment);
            Stream.WriteInt(SessionCount);
            Stream.WriteInt(PlayTimeSeconds);
            Stream.WriteInt(DaysSinceStartedPlaying);
            Stream.WriteString(FacebookAppId);
        }

        public override void Decode()
        {
            base.Decode();

            AccountId = Stream.ReadLong();
            HomeId = Stream.ReadLong();
            PassToken = Stream.ReadString();
            FacebookId = Stream.ReadString();
            GamecenterId = Stream.ReadString();
            MajorVersion = Stream.ReadInt();
            BuildVersion = Stream.ReadInt();
            _ = Stream.ReadInt();
            ServerEnvironment = Stream.ReadString();
        }

        public override int GetMessageType()
        {
            return 20104;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }
    }
}
