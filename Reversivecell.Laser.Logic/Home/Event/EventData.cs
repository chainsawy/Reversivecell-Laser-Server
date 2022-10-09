namespace Reversivecell.Laser.Logic.Home.Event
{
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Helper;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Util;

    public class EventData
    {
        private LogicLocationData _location;
        private int _eventId;
        private int _eventSlot;
        private int _endTimestamp;

        public EventData(int eventId, int eventSlot, int endTimestamp)
        {
            _eventId = eventId;
            _eventSlot = eventSlot;
        }

        public void SetLocation(LogicLocationData data)
        {
            _location = data;
        }

        public void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteVInt(_eventId); // 0xacec0c
            encoder.WriteVInt(_eventSlot); // 0xacec20
            encoder.WriteVInt(0); // 0xacec34
            encoder.WriteVInt(_endTimestamp - LogicTimeUtil.GetTimestamp()); // 0xacec48
            encoder.WriteVInt(0); // 0xacec5c

            ByteStreamHelper.WriteDataReference(encoder, _location);

            encoder.WriteVInt(2); // 0xacec7c
            encoder.WriteString(null); // 0xacecac
            encoder.WriteVInt(0); // 0xacecc0
            encoder.WriteVInt(0); // 0xacecd4
            encoder.WriteVInt(0); // 0xacece8

            encoder.WriteVInt(0); // 0xacecfc

            encoder.WriteVInt(0); // 0xacee58
            encoder.WriteVInt(0); // 0xacee6c
        }
    }
}
