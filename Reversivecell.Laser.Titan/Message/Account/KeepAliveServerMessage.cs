namespace Reversivecell.Laser.Titan.Message.Account
{
    public class KeepAliveServerMessage : PiranhaMessage
    {
        public override int GetMessageType()
        {
            return 20108;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }
    }
}
