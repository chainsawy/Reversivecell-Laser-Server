namespace Reversivecell.Laser.Logic.Util
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Helper;
    using Reversivecell.Laser.Titan.DataStream;

    public class LogicDataSlot
    {
        private LogicData _data;
        private int _count;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicDataSlot"/> class.
        /// </summary>
        /// <param name="data">the Data</param>
        /// <param name="count">the count</param>
        public LogicDataSlot(LogicData data, int count)
        {
            _data = data;
            _count = count;
        }

        public LogicDataSlot(LogicData data) : this(data, 0)
        {
            // LogicDataSlot.
        }

        public LogicData GetData()
        {
            return this._data;
        }

        public LogicDataSlot Clone()
        {
            return new LogicDataSlot(this._data, this._count);
        }

        public void Encode(ChecksumEncoder encoder)
        {
            ByteStreamHelper.WriteDataReference(encoder, this._data);
            encoder.WriteVInt(this._count);
        }

        public void Decode(ByteStream stream)
        {
            this._data = ByteStreamHelper.ReadDataReference(stream);
            this._count = stream.ReadVInt();
        }

        public int GetCount()
        {
            return this._count;
        }

        public void SetCount(int count)
        {
            this._count = count;
        }

        /// <summary>
        ///     Reads this instance from json.
        /// </summary>
        public void ReadFromJSON(JObject obj)
        {
            int id = (int)obj["data"];
            this._data = LogicDataTables.GetDataById(id);

            this._count = (int)obj["count"];
        }

        /// <summary>
        ///     Writes this instance ti json.
        /// </summary>
        public JObject WriteToJSON()
        {
            JObject obj = new JObject();
            obj["data"] = _data.GetGlobalID();
            obj["count"] = _count;

            return obj;
        }
    }
}
