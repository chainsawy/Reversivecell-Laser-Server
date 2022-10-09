namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicMilestoneData : LogicData
    {
        private int _type;
        private int _index;
        private int _progressStart;
        private int _progress;
        private int _league;
        private int _tier;
        private int _season;
        private int _seasonEndRewardKeys;
        private int _primaryLvlUpRewardType;
        private int _primaryLvlUpRewardCount;
        private int _primaryLvlUpRewardExtraData;
        private string _primaryLvlUpRewardData;
        private int _secondaryLvlUpRewardType;
        private int _secondaryLvlUpRewardCount;
        private int _secondaryLvlUpRewardExtraData;
        private string _secondaryLvlUpRewardData;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicMilestoneData" /> class.
        /// </summary>
        public LogicMilestoneData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicMilestoneData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._type = GetIntegerValue("Type", 0);
            this._index = GetIntegerValue("Index", 0);
            this._progressStart = GetIntegerValue("ProgressStart", 0);
            this._progress = GetIntegerValue("Progress", 0);
            this._league = GetIntegerValue("League", 0);
            this._tier = GetIntegerValue("Tier", 0);
            this._season = GetIntegerValue("Season", 0);
            this._seasonEndRewardKeys = GetIntegerValue("SeasonEndRewardKeys", 0);
            this._primaryLvlUpRewardType = GetIntegerValue("PrimaryLvlUpRewardType", 0);
            this._primaryLvlUpRewardCount = GetIntegerValue("PrimaryLvlUpRewardCount", 0);
            this._primaryLvlUpRewardExtraData = GetIntegerValue("PrimaryLvlUpRewardExtraData", 0);
            this._primaryLvlUpRewardData = GetValue("PrimaryLvlUpRewardData", 0);
            this._secondaryLvlUpRewardType = GetIntegerValue("SecondaryLvlUpRewardType", 0);
            this._secondaryLvlUpRewardCount = GetIntegerValue("SecondaryLvlUpRewardCount", 0);
            this._secondaryLvlUpRewardExtraData = GetIntegerValue("SecondaryLvlUpRewardExtraData", 0);
            this._secondaryLvlUpRewardData = GetValue("SecondaryLvlUpRewardData", 0);

        }
		
        public int GetType()
        {
            return _type;
        }

        public int GetIndex()
        {
            return _index;
        }

        public int GetProgressStart()
        {
            return _progressStart;
        }

        public int GetProgress()
        {
            return _progress;
        }

        public int GetLeague()
        {
            return _league;
        }

        public int GetTier()
        {
            return _tier;
        }

        public int GetSeason()
        {
            return _season;
        }

        public int GetSeasonEndRewardKeys()
        {
            return _seasonEndRewardKeys;
        }

        public int GetPrimaryLvlUpRewardType()
        {
            return _primaryLvlUpRewardType;
        }

        public int GetPrimaryLvlUpRewardCount()
        {
            return _primaryLvlUpRewardCount;
        }

        public int GetPrimaryLvlUpRewardExtraData()
        {
            return _primaryLvlUpRewardExtraData;
        }

        public string GetPrimaryLvlUpRewardData()
        {
            return _primaryLvlUpRewardData;
        }

        public int GetSecondaryLvlUpRewardType()
        {
            return _secondaryLvlUpRewardType;
        }

        public int GetSecondaryLvlUpRewardCount()
        {
            return _secondaryLvlUpRewardCount;
        }

        public int GetSecondaryLvlUpRewardExtraData()
        {
            return _secondaryLvlUpRewardExtraData;
        }

        public string GetSecondaryLvlUpRewardData()
        {
            return _secondaryLvlUpRewardData;
        }


    }
}