namespace Reversivecell.Laser.Titan.Message.Account
{
    public class TitanDisconnectedMessage : PiranhaMessage
    {
        private int _reason;

        public TitanDisconnectedMessage() : base()
        {
            ;
        }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteInt(_reason);
        }

        public override void Decode()
        {
            base.Decode();

            _reason = Stream.ReadInt();
        }

        public int GetReason()
        {
            return _reason;
        }

        public void SetReason(int reason)
        {
            _reason = reason;
        }

        public override int GetMessageType()
        {
            return 25892;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }
    }
}
