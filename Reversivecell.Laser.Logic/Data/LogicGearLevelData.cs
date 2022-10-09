namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicGearLevelData : LogicData
    {
        private int _gearTokens;
        private int _gearScrap;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicGearLevelData" /> class.
        /// </summary>
        public LogicGearLevelData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicGearLevelData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._gearTokens = GetIntegerValue("GearTokens", 0);
            this._gearScrap = GetIntegerValue("GearScrap", 0);

        }
		
        public int GetGearTokens()
        {
            return _gearTokens;
        }

        public int GetGearScrap()
        {
            return _gearScrap;
        }


    }
}