namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicRankedLocationData : LogicData
    {
        private bool _disabled;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicRankedLocationData" /> class.
        /// </summary>
        public LogicRankedLocationData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicRankedLocationData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._disabled = GetBooleanValue("Disabled", 0);

        }
		
        public bool GetDisabled()
        {
            return _disabled;
        }


    }
}