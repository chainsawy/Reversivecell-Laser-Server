namespace Reversivecell.Laser.Titan.Message.Account
{
    public class KeepAliveMessage : PiranhaMessage
    {
        public override int GetMessageType()
        {
            return 10108;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }
    }
}
