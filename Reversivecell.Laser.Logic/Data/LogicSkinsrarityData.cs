namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicSkinsrarityData : LogicData
    {
        private int _price;
        private int _rarity;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicSkinsrarityData" /> class.
        /// </summary>
        public LogicSkinsrarityData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicSkinsrarityData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._price = GetIntegerValue("Price", 0);
            this._rarity = GetIntegerValue("Rarity", 0);

        }
		
        public int GetPrice()
        {
            return _price;
        }

        public int GetRarity()
        {
            return _rarity;
        }


    }
}