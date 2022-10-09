namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicPinData : LogicData
    {
        private int _pinType;
        private int _rarity;
        private int _index;
        private int _bonus;
        private int _craftCost;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicPinData" /> class.
        /// </summary>
        public LogicPinData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicPinData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._pinType = GetIntegerValue("PinType", 0);
            this._rarity = GetIntegerValue("Rarity", 0);
            this._index = GetIntegerValue("Index", 0);
            this._bonus = GetIntegerValue("Bonus", 0);
            this._craftCost = GetIntegerValue("CraftCost", 0);

        }
		
        public int GetPinType()
        {
            return _pinType;
        }

        public int GetRarity()
        {
            return _rarity;
        }

        public int GetIndex()
        {
            return _index;
        }

        public int GetBonus()
        {
            return _bonus;
        }

        public int GetCraftCost()
        {
            return _craftCost;
        }


    }
}