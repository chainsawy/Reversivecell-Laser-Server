namespace Reversivecell.Laser.Logic.Home.Event
{
    using Reversivecell.Laser.Titan.DataStream;

    public class EventSlot
    {
        public int Index { get; set; }

        public EventSlot(int index)
        {
            Index = index;
        }

        public void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteVInt(Index);
        }

        public void Decode(ByteStream stream)
        {
            Index = stream.ReadVInt();
        }
    }
}
