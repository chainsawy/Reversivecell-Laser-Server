namespace Reversivecell.Laser.Servers.Core.Protocol
{
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Math;

    public abstract class NetMessage
    {
        public NetMessage()
        {
            Stream = new ByteStream(10);
            SessionId = -1;
        }

        protected ByteStream Stream { get; private set; }
        public LogicLong SessionId { get; set; }
        public int ServiceNode { get; set; }

        public abstract void Encode();
        public abstract void Decode();
        public abstract int GetMessageType();

        public void EncodeHeader()
        {
            Stream.WriteVInt(ServiceNode);
            Stream.WriteLong(SessionId);
        }

        public void DecodeHeader()
        {
            ServiceNode = Stream.ReadVInt();
            SessionId = Stream.ReadLong();
        }

        public void SetByteStream(ByteStream stream)
        {
            if (stream != null)
            {
                Stream.Destruct();
                Stream = stream;
            }
        }
    }
}
