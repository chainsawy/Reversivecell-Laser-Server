namespace Reversivecell.Laser.Logic.Util
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Titan.DataStream;

    public class IntValueEntry
    {
        private int _key;
        private int _value;

        public IntValueEntry(int key, int value)
        {
            _key = key;
            _value = value;
        }

        public JObject Save()
        {
            JObject json = new JObject();
            json["key"] = _key;
            json["value"] = _value;
            return json;
        }

        public void Load(JObject json)
        {
            _key = (int)json["key"];
            _value = (int)json["value"];
        }

        public void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteInt(_key);
            encoder.WriteInt(_value);
        }

        public int GetKey()
        {
            return _key;
        }

        public int GetValue()
        {
            return _value;
        }

        public void SetValue(int value)
        {
            _value = value;
        }
    }
}
