namespace Reversivecell.Laser.Servers.Core.Protocol.Message.Account
{
    using Reversivecell.Laser.Titan.Math;

    public class AuthenticationRequestMessage : NetMessage
    {
        public LogicLong AccountId { get; set; }
        public string PassToken { get; set; }
        public string Device { get; set; }

        public override void Decode()
        {
            AccountId = Stream.ReadLong();
            PassToken = Stream.ReadString();
            Device = Stream.ReadString();
        }

        public override void Encode()
        {
            Stream.WriteLong(AccountId);
            Stream.WriteString(PassToken);
            Stream.WriteString(Device);
        }

        public override int GetMessageType()
        {
            return 10101;
        }
    }
}
