namespace Reversivecell.Laser.Logic.Message.Account
{
    using Reversivecell.Laser.Titan.Message;

    public class ClientCapabilitiesMessage : PiranhaMessage
    {
        public int Ping { get; set; }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteVInt(Ping);
        }

        public override void Decode()
        {
            base.Decode();

            Ping = Stream.ReadVInt();
        }

        public override int GetMessageType()
        {
            return 10107;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }
    }
}
