namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicRankedRankData : LogicData
    {
        private int _rank;
        private string _hexColor;
        private string _frameLabel;
        private string _rankIconTextField;
        private string _rankIconTID;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicRankedRankData" /> class.
        /// </summary>
        public LogicRankedRankData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicRankedRankData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._rank = GetIntegerValue("Rank", 0);
            this._hexColor = GetValue("HexColor", 0);
            this._frameLabel = GetValue("FrameLabel", 0);
            this._rankIconTextField = GetValue("RankIconTextField", 0);
            this._rankIconTID = GetValue("RankIconTID", 0);

        }
		
        public int GetRank()
        {
            return _rank;
        }

        public string GetHexColor()
        {
            return _hexColor;
        }

        public string GetFrameLabel()
        {
            return _frameLabel;
        }

        public string GetRankIconTextField()
        {
            return _rankIconTextField;
        }

        public string GetRankIconTID()
        {
            return _rankIconTID;
        }


    }
}