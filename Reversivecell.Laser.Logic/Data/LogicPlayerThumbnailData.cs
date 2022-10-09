namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicPlayerThumbnailData : LogicData
    {
        private int _requiredExpLevel;
        private int _requiredTotalTrophies;
        private int _requiredSeasonPoints;
        private string _requiredHero;
        private string _iconSWF;
        private int _sortOrder;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicPlayerThumbnailData" /> class.
        /// </summary>
        public LogicPlayerThumbnailData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicPlayerThumbnailData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._requiredExpLevel = GetIntegerValue("RequiredExpLevel", 0);
            this._requiredTotalTrophies = GetIntegerValue("RequiredTotalTrophies", 0);
            this._requiredSeasonPoints = GetIntegerValue("RequiredSeasonPoints", 0);
            this._requiredHero = GetValue("RequiredHero", 0);
            this._iconSWF = GetValue("IconSWF", 0);
            this._sortOrder = GetIntegerValue("SortOrder", 0);

        }
		
        public int GetRequiredExpLevel()
        {
            return _requiredExpLevel;
        }

        public int GetRequiredTotalTrophies()
        {
            return _requiredTotalTrophies;
        }

        public int GetRequiredSeasonPoints()
        {
            return _requiredSeasonPoints;
        }

        public string GetRequiredHero()
        {
            return _requiredHero;
        }

        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public int GetSortOrder()
        {
            return _sortOrder;
        }


    }
}