namespace Reversivecell.Laser.Logic.Message.Account
{
    using Reversivecell.Laser.Titan.Message;

    public class UdpConnectionInfoMessage : PiranhaMessage
    {
        public static int ServerPort { get; set; }
        public static string ServerHost { get; set; }
        public static byte[] SessionId { get; set; }

        public UdpConnectionInfoMessage() : base()
        {
            ;
        }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteVInt(ServerPort);
            Stream.WriteString(ServerHost);
            Stream.WriteBytes(SessionId, 10);
            Stream.WriteIntToByteArray(0);
        }

        public override int GetMessageType()
        {
            return 24112;
        }

        public override int GetServiceNodeType()
        {
            return 27;
        }
    }
}
