namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicPlayerMapEnvironmentData : LogicData
    {
        private bool _disabled;
        private string _gameModeVariations;
        private string _locationThemes;
        private string _mapTemplates;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicPlayerMapEnvironmentData" /> class.
        /// </summary>
        public LogicPlayerMapEnvironmentData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicPlayerMapEnvironmentData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._disabled = GetBooleanValue("Disabled", 0);
            this._gameModeVariations = GetValue("GameModeVariations", 0);
            this._locationThemes = GetValue("LocationThemes", 0);
            this._mapTemplates = GetValue("MapTemplates", 0);

        }
		
        public bool GetDisabled()
        {
            return _disabled;
        }

        public string GetGameModeVariations()
        {
            return _gameModeVariations;
        }

        public string GetLocationThemes()
        {
            return _locationThemes;
        }

        public string GetMapTemplates()
        {
            return _mapTemplates;
        }


    }
}