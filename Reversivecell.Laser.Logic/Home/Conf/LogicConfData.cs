namespace Reversivecell.Laser.Logic.Home.Conf
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Home.Event;
    using Reversivecell.Laser.Logic.Util;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Util;

    public class LogicConfData
    {
        private int _serverDayIndex;
        private LogicArrayList<EventSlot> _eventSlots;
        private LogicArrayList<EventData> _activeEvents;
        private LogicArrayList<EventData> _upcomingEvents;

        private LogicArrayList<IntValueEntry> _intValues;

        public LogicConfData()
        {
            _eventSlots = new LogicArrayList<EventSlot>();
            _activeEvents = new LogicArrayList<EventData>();
            _upcomingEvents = new LogicArrayList<EventData>();

            _intValues = new LogicArrayList<IntValueEntry>();

            _eventSlots.Add(new EventSlot(1));
            _activeEvents.Add(new EventData(1, 1, LogicTimeUtil.GetTimestamp() + 2222));
            _activeEvents[0].SetLocation((LogicLocationData)LogicDataTables.GetDataById(15000007));
        }

        public JObject Save()
        {
            JObject json = new JObject();

            JArray intValues = new JArray();
            for (int i = 0; i < _intValues.Count; i++)
            {
                intValues.Add(_intValues[i].Save());
            }

            json["int_value_entries"] = intValues;
            return json;
        }

        public void Load(JObject json)
        {
            JArray intValues = (JArray)json["int_value_entries"];

            for (int i = 0; i < intValues.Count; i++)
            {
                IntValueEntry entry = new IntValueEntry(-1, -1);
                entry.Load((JObject)intValues[i]);
                _intValues.Add(entry);
            }
        }

        public void SetServerDayIndex(int dayIndex)
        {
            _serverDayIndex = dayIndex;
        }

        public void AddIntValue(int key, int value)
        {
            for (int i = 0; i < _intValues.Count; i++)
            {
                if (_intValues[i].GetKey() == key)
                {
                    _intValues[i].SetValue(value);
                    return;
                }
            }

            _intValues.Add(new IntValueEntry(key, value));
        }

        public void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteVInt(_serverDayIndex);
            encoder.WriteVInt(100);
            encoder.WriteVInt(10);
            encoder.WriteVInt(30);
            encoder.WriteVInt(3);
            encoder.WriteVInt(80);
            encoder.WriteVInt(10);
            encoder.WriteVInt(40);
            encoder.WriteVInt(1000);
            encoder.WriteVInt(550);
            encoder.WriteVInt(0);
            encoder.WriteVInt(999900);

            encoder.WriteVInt(0);

            encoder.WriteVInt(_eventSlots.Count);
            for (int i = 0; i < _eventSlots.Count; i++)
            {
                _eventSlots[i].Encode(encoder);
            }

            encoder.WriteVInt(_activeEvents.Count);
            for (int i = 0; i < _activeEvents.Count; i++)
            {
                _activeEvents[i].Encode(encoder);
            }

            encoder.WriteVInt(_upcomingEvents.Count);
            for (int i = 0; i < _upcomingEvents.Count; i++)
            {
                _upcomingEvents[i].Encode(encoder);
            }

            encoder.WriteVInt(8); // 0x13b988
            encoder.WriteVInt(20); // 0x13b9e4
            encoder.WriteVInt(35); // 0x13b9e4
            encoder.WriteVInt(75); // 0x13b9e4
            encoder.WriteVInt(140); // 0x13b9e4
            encoder.WriteVInt(290); // 0x13b9e4
            encoder.WriteVInt(480); // 0x13b9e4
            encoder.WriteVInt(800); // 0x13b9e4
            encoder.WriteVInt(1250); // 0x13b9e4

            encoder.WriteVInt(8); // 0x13b988
            encoder.WriteVInt(1); // 0x13b9e4
            encoder.WriteVInt(1); // 0x13b9e4
            encoder.WriteVInt(1); // 0x13b9e4
            encoder.WriteVInt(1); // 0x13b9e4
            encoder.WriteVInt(1); // 0x13b9e4
            encoder.WriteVInt(1); // 0x13b9e4
            encoder.WriteVInt(1); // 0x13b9e4
            encoder.WriteVInt(1); // 0x13b9e4

            encoder.WriteVInt(3); // 0x13b988
            encoder.WriteVInt(20); // 0x13b9e4
            encoder.WriteVInt(50); // 0x13b9e4
            encoder.WriteVInt(140); // 0x13b9e4

            encoder.WriteVInt(3); // 0x13b988
            encoder.WriteVInt(20); // 0x13b9e4
            encoder.WriteVInt(50); // 0x13b9e4
            encoder.WriteVInt(140); // 0x13b9e4

            encoder.WriteVInt(4); // 0x13b988
            encoder.WriteVInt(20); // 0x13b9e4
            encoder.WriteVInt(50); // 0x13b9e4
            encoder.WriteVInt(140); // 0x13b9e4
            encoder.WriteVInt(280); // 0x13b9e4

            encoder.WriteVInt(4); // 0x13b988
            encoder.WriteVInt(150); // 0x13b9e4
            encoder.WriteVInt(400); // 0x13b9e4
            encoder.WriteVInt(1200); // 0x13b9e4
            encoder.WriteVInt(2600); // 0x13b9e4

            encoder.WriteVInt(2);
            encoder.WriteVInt(200);
            encoder.WriteVInt(20);

            encoder.WriteVInt(8640);
            encoder.WriteVInt(10);
            encoder.WriteVInt(5);

            encoder.WriteBoolean(false);
            encoder.WriteBoolean(false);
            encoder.WriteBoolean(false);

            encoder.WriteVInt(50);
            encoder.WriteVInt(604800);

            encoder.WriteBoolean(true);

            encoder.WriteVInt(0);

            encoder.WriteVInt(_intValues.Count); // 0x595ae8
            for (int i = 0; i < _intValues.Count; i++)
            {
                _intValues[i].Encode(encoder);
            }

            encoder.WriteVInt(0); // 0x595c34
        }
    }
}
