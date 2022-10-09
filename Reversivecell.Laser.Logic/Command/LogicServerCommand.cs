namespace Reversivecell.Laser.Logic.Command
{
    using Reversivecell.Laser.Titan.DataStream;

    public abstract class LogicServerCommand : LogicCommand
    {
        private int _id;

        public override void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteVInt(_id);
            base.Encode(encoder);
        }

        public override void Decode(ByteStream stream)
        {
            _id = stream.ReadVInt();
            base.Decode(stream);
        }

        public override bool IsServerCommand()
        {
            return true;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }
    }
}
