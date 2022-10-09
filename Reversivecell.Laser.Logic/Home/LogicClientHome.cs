namespace Reversivecell.Laser.Logic.Home
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Logic.Home.Conf;
    using Reversivecell.Laser.Logic.Home.Daily;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Math;

    public class LogicClientHome
    {
        private LogicLong _homeId;
        private LogicDailyData _dailyData;
        private LogicConfData _confData;

        public LogicClientHome()
        {
            _homeId = -1;

            _dailyData = new LogicDailyData();
            _confData = new LogicConfData();
        }

        public void Encode(ChecksumEncoder encoder)
        {
            _dailyData.Encode(encoder);
            _confData.Encode(encoder);

            encoder.WriteLong(_homeId);
            encoder.WriteVInt(0); // 0x1f7760
            encoder.WriteVInt(0); // 0x1f7774
            encoder.WriteBoolean(false); // 0x1f78f4
            encoder.WriteVInt(0); // 0x1f7908
            encoder.WriteVInt(0); // 0x1f7aa8
        }

        public JObject Save()
        {
            JObject json = new JObject();

            json["id_hi"] = _homeId.GetHigherInt();
            json["id_lo"] = _homeId.GetLowerInt();

            json["daily_data"] = _dailyData.Save();
            json["conf_data"] = _confData.Save();

            return json;
        }

        public void Load(JObject json)
        {
            _homeId = new LogicLong((int)json["id_hi"], (int)json["id_lo"]);

            _dailyData = new LogicDailyData();
            _dailyData.Load((JObject)json["daily_data"]);

            _confData = new LogicConfData();
            _confData.Load((JObject)json["conf_data"]);
        }

        public LogicDailyData GetDailyData()
        {
            return _dailyData;
        }

        public LogicConfData GetConfData()
        {
            return _confData;
        }

        public void SetHomeId(LogicLong id)
        {
            _homeId = id;
        }

        public LogicLong GetHomeId()
        {
            return _homeId;
        }
    }
}
