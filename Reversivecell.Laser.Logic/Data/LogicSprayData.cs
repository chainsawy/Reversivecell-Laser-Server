namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicSprayData : LogicData
    {
        private bool _disabled;
        private string _fileName;
        private string _exportName;
        private string _character;
        private string _skin;
        private string _rarity;
        private int _effectColorR;
        private int _effectColorG;
        private int _effectColorB;
        private bool _flipSprayForEnemies;
        private bool _lockedForChronos;
        private string _sprayBundles;
        private bool _isDefaultBattleSpray;
        private string _texture;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicSprayData" /> class.
        /// </summary>
        public LogicSprayData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicSprayData.
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
            this._rarity = GetValue("Rarity", 0);
            this._effectColorR = GetIntegerValue("EffectColorR", 0);
            this._effectColorG = GetIntegerValue("EffectColorG", 0);
            this._effectColorB = GetIntegerValue("EffectColorB", 0);
            this._flipSprayForEnemies = GetBooleanValue("FlipSprayForEnemies", 0);
            this._lockedForChronos = GetBooleanValue("LockedForChronos", 0);
            this._sprayBundles = GetValue("SprayBundles", 0);
            this._isDefaultBattleSpray = GetBooleanValue("IsDefaultBattleSpray", 0);
            this._texture = GetValue("Texture", 0);

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

        public string GetRarity()
        {
            return _rarity;
        }

        public int GetEffectColorR()
        {
            return _effectColorR;
        }

        public int GetEffectColorG()
        {
            return _effectColorG;
        }

        public int GetEffectColorB()
        {
            return _effectColorB;
        }

        public bool GetFlipSprayForEnemies()
        {
            return _flipSprayForEnemies;
        }

        public bool GetLockedForChronos()
        {
            return _lockedForChronos;
        }

        public string GetSprayBundles()
        {
            return _sprayBundles;
        }

        public bool GetIsDefaultBattleSpray()
        {
            return _isDefaultBattleSpray;
        }

        public string GetTexture()
        {
            return _texture;
        }


    }
}