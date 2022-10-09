namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicResourceData : LogicData
    {
        private string _iconSWF;
        private string _collectEffect;
        private string _type;
        private string _rarity;
        private bool _premiumCurrency;
        private int _textRed;
        private int _textGreen;
        private int _textBlue;
        private int _cap;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicResourceData" /> class.
        /// </summary>
        public LogicResourceData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicResourceData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._iconSWF = GetValue("IconSWF", 0);
            this._collectEffect = GetValue("CollectEffect", 0);
            this._type = GetValue("Type", 0);
            this._rarity = GetValue("Rarity", 0);
            this._premiumCurrency = GetBooleanValue("PremiumCurrency", 0);
            this._textRed = GetIntegerValue("TextRed", 0);
            this._textGreen = GetIntegerValue("TextGreen", 0);
            this._textBlue = GetIntegerValue("TextBlue", 0);
            this._cap = GetIntegerValue("Cap", 0);

        }
		
        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public string GetCollectEffect()
        {
            return _collectEffect;
        }

        public string GetType()
        {
            return _type;
        }

        public string GetRarity()
        {
            return _rarity;
        }

        public bool GetPremiumCurrency()
        {
            return _premiumCurrency;
        }

        public int GetTextRed()
        {
            return _textRed;
        }

        public int GetTextGreen()
        {
            return _textGreen;
        }

        public int GetTextBlue()
        {
            return _textBlue;
        }

        public int GetCap()
        {
            return _cap;
        }


    }
}