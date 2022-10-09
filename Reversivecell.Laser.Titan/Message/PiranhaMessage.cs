namespace Reversivecell.Laser.Titan.Message
{
    using Reversivecell.Laser.Titan.DataStream;

    public abstract class PiranhaMessage
    {
        protected ByteStream Stream;
        protected int MessageVersion;

        public PiranhaMessage()
        {
            Stream = new ByteStream(10);
        }

        public bool IsClientToServerMessage()
        {
            int type = this.GetMessageType();
            return (type >= 10000 && type < 20000) || type == 30000;
        }

        public bool IsServerToClientMessage()
        {
            int type = this.GetMessageType();
            return (type >= 20000 && type < 30000) || type == 40000;
        }

        public virtual void Encode()
        {
            ;
        }

        public virtual void Decode()
        {
            ;
        }

        public int GetEncodingLength()
        {
            return Stream.GetLength();
        }

        public ByteStream GetByteStream()
        {
            return Stream;
        }

        public int GetMessageVersion()
        {
            return MessageVersion;
        }

        public void SetMessageVersion(int version)
        {
            MessageVersion = version;
        }

        public abstract int GetServiceNodeType();
        public abstract int GetMessageType();
    }
}
