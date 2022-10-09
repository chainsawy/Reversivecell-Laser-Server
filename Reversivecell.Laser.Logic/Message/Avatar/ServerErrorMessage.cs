namespace Reversivecell.Laser.Logic.Message.Avatar
{
    using Reversivecell.Laser.Titan.Message;

    public class ServerErrorMessage : PiranhaMessage
    {
        public int ErrorCode { get; set; }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteInt(ErrorCode);
        }

        public override void Decode()
        {
            base.Decode();

            ErrorCode = Stream.ReadInt();
        }

        public override int GetMessageType()
        {
            return 24115;
        }

        public override int GetServiceNodeType()
        {
            return 9;
        }
    }
}
