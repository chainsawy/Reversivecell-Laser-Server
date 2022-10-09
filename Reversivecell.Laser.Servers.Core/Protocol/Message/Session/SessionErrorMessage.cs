namespace Reversivecell.Laser.Servers.Core.Protocol.Message.Session
{
    public class SessionErrorMessage : NetMessage
    {
        public int ErrorCode { get; set; }

        public override void Decode()
        {
            ErrorCode = Stream.ReadVInt();
        }

        public override void Encode()
        {
            Stream.WriteVInt(ErrorCode);
        }

        public override int GetMessageType()
        {
            return 20003;
        }
    }
}
