namespace Reversivecell.Laser.Logic.Message.Home
{
    using Reversivecell.Laser.Titan.Message;

    public class GoHomeFromOfflinePractiseMessage : PiranhaMessage
    {
        public override int GetMessageType()
        {
            return 14109;
        }

        public override int GetServiceNodeType()
        {
            return 10;
        }
    }
}
