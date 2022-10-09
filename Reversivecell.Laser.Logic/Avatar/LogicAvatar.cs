namespace Reversivecell.Laser.Logic.Avatar
{
    using Reversivecell.Laser.Titan.DataStream;

    public abstract class LogicAvatar
    {
        public LogicAvatar()
        {
            ;
        }

        public abstract void Encode(ChecksumEncoder encoder);
        public abstract void Decode(ByteStream stream);

        public int GetChecksum()
        {
            ChecksumEncoder encoder = new ChecksumEncoder();
            this.Encode(encoder);
            return encoder.GetCheckSum();
        }
    }
}
