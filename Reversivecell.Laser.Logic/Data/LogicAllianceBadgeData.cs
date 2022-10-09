namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicAllianceBadgeData : LogicData
    {
        private string _iconSWF;
        private string _category;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicAllianceBadgeData" /> class.
        /// </summary>
        public LogicAllianceBadgeData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicAllianceBadgeData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._iconSWF = GetValue("IconSWF", 0);
            this._category = GetValue("Category", 0);

        }
		
        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public string GetCategory()
        {
            return _category;
        }


    }
}