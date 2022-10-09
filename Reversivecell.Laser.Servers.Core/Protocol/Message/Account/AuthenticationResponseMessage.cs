namespace Reversivecell.Laser.Servers.Core.Protocol.Message.Account
{
    using Reversivecell.Laser.Titan.Math;

    public class AuthenticationResponseMessage : NetMessage
    {
        public int Status { get; set; }
        public LogicLong AccountId { get; set; }
        public string PassToken { get; set; }
        public int SessionCount { get; set; }
        public int PlayTimeSeconds { get; set; }
        public int DaysSinceStartedPlaying { get; set; }

        public AuthenticationResponseMessage() : base()
        {
            AccountId = -1;
        }

        public override void Decode()
        {
            Status = Stream.ReadVInt();
            AccountId = Stream.ReadLong();
            PassToken = Stream.ReadString();
            SessionCount = Stream.ReadVInt();
            PlayTimeSeconds = Stream.ReadVInt();
            DaysSinceStartedPlaying = Stream.ReadVInt();
        }

        public override void Encode()
        {
            Stream.WriteVInt(Status);
            Stream.WriteLong(AccountId);
            Stream.WriteString(PassToken);
            Stream.WriteVInt(SessionCount);
            Stream.WriteVInt(PlayTimeSeconds);
            Stream.WriteVInt(DaysSinceStartedPlaying);
        }

        public override int GetMessageType()
        {
            return 20101;
        }
    }
}
