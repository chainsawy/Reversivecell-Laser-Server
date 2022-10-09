namespace Reversivecell.Laser.Titan.Message.Account
{
    public class TitanLoginFailedMessage : PiranhaMessage
    {
        public override int GetMessageType()
        {
            return 20103;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }
    }
}
