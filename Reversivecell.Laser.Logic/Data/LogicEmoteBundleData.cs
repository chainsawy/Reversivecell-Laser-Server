namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicEmoteBundleData : LogicData
    {
        private bool _disabled;
        private string _iconSWF;
        private bool _canBeBought;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicEmoteBundleData" /> class.
        /// </summary>
        public LogicEmoteBundleData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicEmoteBundleData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._disabled = GetBooleanValue("Disabled", 0);
            this._iconSWF = GetValue("IconSWF", 0);
            this._canBeBought = GetBooleanValue("CanBeBought", 0);

        }
		
        public bool GetDisabled()
        {
            return _disabled;
        }

        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public bool GetCanBeBought()
        {
            return _canBeBought;
        }


    }
}