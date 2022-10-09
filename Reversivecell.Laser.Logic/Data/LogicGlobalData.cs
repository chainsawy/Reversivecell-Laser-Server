namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicGlobalData : LogicData
    {
        private int _numberValue;
        private bool _booleanValue;
        private string _textValue;
        private string _stringArray;
        private int _numberArray;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicGlobalData" /> class.
        /// </summary>
        public LogicGlobalData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicGlobalData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._numberValue = GetIntegerValue("NumberValue", 0);
            this._booleanValue = GetBooleanValue("BooleanValue", 0);
            this._textValue = GetValue("TextValue", 0);
            this._stringArray = GetValue("StringArray", 0);
            this._numberArray = GetIntegerValue("NumberArray", 0);

        }
		
        public int GetNumberValue()
        {
            return _numberValue;
        }

        public bool GetBooleanValue()
        {
            return _booleanValue;
        }

        public string GetTextValue()
        {
            return _textValue;
        }

        public string GetStringArray()
        {
            return _stringArray;
        }

        public int GetNumberArray()
        {
            return _numberArray;
        }


    }
}