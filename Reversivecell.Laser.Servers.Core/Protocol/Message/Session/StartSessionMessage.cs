namespace Reversivecell.Laser.Servers.Core.Protocol.Message.Session
{
    using Reversivecell.Laser.Titan.Math;

    public class StartSessionMessage : NetMessage
    {
        public LogicLong AccountId { get; set; }

        public override void Decode()
        {
            AccountId = Stream.ReadLong();
        }

        public override void Encode()
        {
            Stream.WriteLong(AccountId);
        }

        public override int GetMessageType()
        {
            return 10000;
        }
    }
}
