namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicRegionData : LogicData
    {
        private string _displayName;
        private bool _isCountry;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicRegionData" /> class.
        /// </summary>
        public LogicRegionData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicRegionData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._displayName = GetValue("DisplayName", 0);
            this._isCountry = GetBooleanValue("IsCountry", 0);

        }
		
        public string GetDisplayName()
        {
            return _displayName;
        }

        public bool GetIsCountry()
        {
            return _isCountry;
        }


    }
}