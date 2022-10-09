namespace Reversivecell.Laser.Titan.Message.Security
{
    public class ClientHelloMessage : PiranhaMessage
    {
        public int Protocol { get; set; }
        public int KeyVersion { get; set; }
        public int ClientMajor { get; set; }
        public int ClientBuild { get; set; }
        public string ResourceSha { get; set; }
        public int DeviceType { get; set; }
        public int AppStore { get; set; }

        public ClientHelloMessage() : base()
        {
            ResourceSha = string.Empty;
        }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteInt(Protocol);
            Stream.WriteInt(KeyVersion);
            Stream.WriteInt(ClientMajor);
            Stream.WriteInt(0);
            Stream.WriteInt(ClientBuild);
            Stream.WriteStringReference(ResourceSha);
            Stream.WriteInt(DeviceType);
            Stream.WriteInt(AppStore);
        }

        public override void Decode()
        {
            base.Decode();

            Protocol = Stream.ReadInt();
            KeyVersion = Stream.ReadInt();
            ClientMajor = Stream.ReadInt();
                          Stream.ReadInt();
            ClientBuild = Stream.ReadInt();
            ResourceSha = Stream.ReadStringReference();
            DeviceType = Stream.ReadInt();
            AppStore = Stream.ReadInt();
        }

        public override int GetMessageType()
        {
            return 10100;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }
    }
}
