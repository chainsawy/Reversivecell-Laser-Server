namespace Reversivecell.Laser.Logic.Message.Home
{
    using Reversivecell.Laser.Titan.Message;

    public class AskForBattleEndMessage : PiranhaMessage
    {
        public override void Decode()
        {
            base.Decode();
        }

        public override int GetMessageType()
        {
            return 14110;
        }

        public override int GetServiceNodeType()
        {
            return 10;
        }
    }
}
