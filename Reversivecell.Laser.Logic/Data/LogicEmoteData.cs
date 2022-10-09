namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicEmoteData : LogicData
    {
        private bool _disabled;
        private string _fileName;
        private string _exportName;
        private string _character;
        private string _skin;
        private int _type;
        private int _rarity;
        private bool _lockedForChronos;
        private int _bundleCode;
        private bool _isDefaultBattleEmote;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicEmoteData" /> class.
        /// </summary>
        public LogicEmoteData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicEmoteData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._disabled = GetBooleanValue("Disabled", 0);
            this._fileName = GetValue("FileName", 0);
            this._exportName = GetValue("ExportName", 0);
            this._character = GetValue("Character", 0);
            this._skin = GetValue("Skin", 0);
            this._type = GetIntegerValue("Type", 0);
            this._rarity = GetIntegerValue("Rarity", 0);
            this._lockedForChronos = GetBooleanValue("LockedForChronos", 0);
            this._bundleCode = GetIntegerValue("BundleCode", 0);
            this._isDefaultBattleEmote = GetBooleanValue("IsDefaultBattleEmote", 0);

        }
		
        public bool GetDisabled()
        {
            return _disabled;
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public string GetExportName()
        {
            return _exportName;
        }

        public string GetCharacter()
        {
            return _character;
        }

        public string GetSkin()
        {
            return _skin;
        }

        public int GetType()
        {
            return _type;
        }

        public int GetRarity()
        {
            return _rarity;
        }

        public bool GetLockedForChronos()
        {
            return _lockedForChronos;
        }

        public int GetBundleCode()
        {
            return _bundleCode;
        }

        public bool GetIsDefaultBattleEmote()
        {
            return _isDefaultBattleEmote;
        }


    }
}