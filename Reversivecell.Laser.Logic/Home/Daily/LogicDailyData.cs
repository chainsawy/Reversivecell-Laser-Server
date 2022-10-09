namespace Reversivecell.Laser.Logic.Home.Daily
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Helper;
    using Reversivecell.Laser.Titan.DataStream;

    public class LogicDailyData
    {
        private int _serverDayIndex;
        private int _serverTime;

        private int _score;
        private int _highestScore;

        private int _trophyRoadProgress;
        private int _experience;

        private LogicPlayerThumbnailData _playerThumbnail;
        private LogicCharacterData _character;

        private string _region;
        private string _supportedContentAuthor;

        public LogicDailyData()
        {
            _playerThumbnail = (LogicPlayerThumbnailData)LogicDataTables.GetDataById(28000000);
            _character = LogicDataTables.GetCharacterByName("ShotgunGirl");
            _region = "RU";

            _trophyRoadProgress = 1;
        }

        public void SetScore(int score)
        {
            _score = score;
        }

        public void SetHighestScore(int score)
        {
            _highestScore = score;
        }

        public JObject Save()
        {
            JObject json = new JObject();
            json["trophy_road_progress"] = _trophyRoadProgress;
            json["exp"] = _experience;
            json["player_thumbnail"] = _playerThumbnail.GetGlobalID();
            json["character"] = _character.GetGlobalID();
            json["region"] = _region;
            json["content_author"] = _supportedContentAuthor;

            return json;
        }

        public void Load(JObject json)
        {
            _trophyRoadProgress = (int)json["trophy_road_progress"];
            _experience = (int)json["exp"];
            _playerThumbnail = (LogicPlayerThumbnailData)LogicDataTables.GetDataById((int)json["player_thumbnail"]);
            _character = (LogicCharacterData)LogicDataTables.GetDataById((int)json["character"]);
            _region = (string)json["region"];
            _supportedContentAuthor = (string)json["content_author"];
        }

        public int GetExperience()
        {
            return _experience;
        }

        public void SetPlayerThumbnail(LogicPlayerThumbnailData data)
        {
            _playerThumbnail = data;
        }

        public LogicPlayerThumbnailData GetPlayerThumbnail()
        {
            return _playerThumbnail;
        }

        public void SetServerDayIndex(int dayIndex)
        {
            _serverDayIndex = dayIndex;
        }

        public void SetServerTime(int time)
        {
            _serverTime = time;
        }

        public void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteVInt(_serverDayIndex); // 0x78d4b8
            encoder.WriteVInt(_serverTime); // 0x78d4cc
            encoder.WriteVInt(_score); // 0x78d4e0
            encoder.WriteVInt(_highestScore); // 0x78d4f4
            encoder.WriteVInt(_highestScore); // 0x78d508
            encoder.WriteVInt(_trophyRoadProgress); // 0x78d51c
            encoder.WriteVInt(_experience); // 0x78d530

            ByteStreamHelper.WriteDataReference(encoder, _playerThumbnail);
            encoder.WriteVInt(43); // 0x2b8208
            encoder.WriteVInt(0); // 0x2b8224

            encoder.WriteVInt(0); // 0x78d55c
            encoder.WriteVInt(0); // 0x78d6b4
            encoder.WriteVInt(0); // 0x78d7f8
            encoder.WriteVInt(0); // 0x78d7f8

            encoder.WriteVInt(0);
            encoder.WriteVInt(122);
            encoder.WriteVInt(0);
            encoder.WriteVInt(1);
            encoder.WriteBoolean(true);
            encoder.WriteVInt(1);
            encoder.WriteVInt(0); // token doubler
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);

            encoder.WriteVInt(0);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);

            encoder.WriteBoolean(false);
            encoder.WriteBoolean(false);
            encoder.WriteBoolean(false);
            encoder.WriteVInt(2);
            encoder.WriteVInt(2);
            encoder.WriteVInt(2);
            encoder.WriteVInt(0);
            encoder.WriteVInt(0);

            encoder.WriteVInt(0); // offer bundles
            encoder.WriteVInt(0);

            encoder.WriteVInt(200);
            encoder.WriteVInt(0);

            encoder.WriteVInt(0);

            encoder.WriteVInt(0);
            encoder.WriteVInt(0);

            ByteStreamHelper.WriteDataReference(encoder, _character);

            encoder.WriteString(_region); // 0x78e524
            encoder.WriteString(_supportedContentAuthor); // 0x78e53c

            encoder.WriteVInt(0); // rewards array

            encoder.WriteVInt(0); // array

            encoder.WriteVInt(1); // BrawlPassSeasonData
            {
                encoder.WriteVInt(0);
                encoder.WriteVInt(-1);
                encoder.WriteVInt(0);
                encoder.WriteVInt(0);
                encoder.WriteBoolean(false);
                encoder.WriteVInt(0);
            }

            encoder.WriteVInt(0);

            encoder.WriteBoolean(true);
            encoder.WriteVInt(0);

            encoder.WriteBoolean(true);
            encoder.WriteVInt(0);
        }
    }
}
