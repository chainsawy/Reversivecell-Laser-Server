namespace Reversivecell.Laser.Logic.Message.Home
{
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Message;

    public class GetPlayerProfileMessage : PiranhaMessage
    {
        private LogicLong _accountId;

        public GetPlayerProfileMessage() : base()
        {
            ;
        }

        public override void Decode()
        {
            base.Decode();

            _accountId = Stream.ReadLong();
        }

        public LogicLong GetAccountId()
        {
            return _accountId;
        }

        public void SetAccountId(LogicLong id)
        {
            _accountId = id;
        }

        public override int GetMessageType()
        {
            return 14113;
        }

        public override int GetServiceNodeType()
        {
            return 10;
        }
    }
}
