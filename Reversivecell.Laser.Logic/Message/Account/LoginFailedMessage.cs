namespace Reversivecell.Laser.Logic.Message.Account
{
    using Reversivecell.Laser.Titan.Message.Account;

    public class LoginFailedMessage : TitanLoginFailedMessage
    {
        public int ErrorCode { get; set; }
        public string ResourceFingerprintContent { get; set; }
        public string RedirectDomain { get; set; }
        public string ContentUrl { get; set; }
        public string UpdateUrl { get; set; }
        public string Reason { get; set; }
        public int SecondsUntilMaintenanceEnd { get; set; }

        public LoginFailedMessage() : base()
        {
            ;
        }

        public override void Decode()
        {
            base.Decode();

            ErrorCode = Stream.ReadInt();
        }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteInt(ErrorCode);
            Stream.WriteString(ResourceFingerprintContent);
            Stream.WriteString(RedirectDomain);
            Stream.WriteString(ContentUrl);
            Stream.WriteString(UpdateUrl);
            Stream.WriteString(Reason);
            Stream.WriteInt(SecondsUntilMaintenanceEnd);

            Stream.WriteBoolean(false);
            Stream.WriteInt(0); // bytes

            Stream.WriteInt(-1);

            Stream.WriteInt(0);
            Stream.WriteInt(0);
            Stream.WriteString(null);
            Stream.WriteInt(0);
            Stream.WriteBoolean(false);
            Stream.WriteBoolean(false);

            // ByteStream::isAtEnd()
        }
    }
}
