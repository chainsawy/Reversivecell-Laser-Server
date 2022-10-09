namespace Reversivecell.Laser.Servers.Core.Protocol.Message.Session
{
    public class StopSessionMessage : NetMessage
    {
        public override void Decode()
        {
            ;
        }

        public override void Encode()
        {
            ;
        }

        public override int GetMessageType()
        {
            return 10001;
        }
    }
}
