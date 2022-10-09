namespace Reversivecell.Laser.Titan.Message.Security
{
    public class ServerHelloMessage : PiranhaMessage
    {
        private byte[] _sessionToken { get; set; }

        public ServerHelloMessage() : base()
        {
            ;
        }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteBytes(_sessionToken, _sessionToken.Length);
        }

        public override void Decode()
        {
            base.Decode();

            int length = Stream.ReadBytesLength();
            _sessionToken = Stream.ReadBytes(length, 2000);
        }

        public void SetSessionToken(byte[] token)
        {
            _sessionToken = token;
        }

        public byte[] RemoveSessionToken()
        {
            byte[] t = _sessionToken;
            _sessionToken = null;
            return t;
        }

        public override int GetMessageType()
        {
            return 20100;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }
    }
}
