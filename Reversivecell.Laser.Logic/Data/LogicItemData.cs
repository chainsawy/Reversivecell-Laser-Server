namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicItemData : LogicData
    {
        private string _parentItemForSkin;
        private string _fileName;
        private string _exportName;
        private string _exportNameEnemy;
        private string _shadowExportName;
        private string _groundGlowExportName;
        private string _loopingEffect;
        private int _value;
        private int _value2;
        private int _triggerRangeSubTiles;
        private string _triggerAreaEffect;
        private bool _canBePickedUp;
        private string _spawnEffect;
        private string _activateEffect;
        private string _sCW;
        private string _sCWEnemy;
        private string _layer;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicItemData" /> class.
        /// </summary>
        public LogicItemData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicItemData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._parentItemForSkin = GetValue("ParentItemForSkin", 0);
            this._fileName = GetValue("FileName", 0);
            this._exportName = GetValue("ExportName", 0);
            this._exportNameEnemy = GetValue("ExportNameEnemy", 0);
            this._shadowExportName = GetValue("ShadowExportName", 0);
            this._groundGlowExportName = GetValue("GroundGlowExportName", 0);
            this._loopingEffect = GetValue("LoopingEffect", 0);
            this._value = GetIntegerValue("Value", 0);
            this._value2 = GetIntegerValue("Value2", 0);
            this._triggerRangeSubTiles = GetIntegerValue("TriggerRangeSubTiles", 0);
            this._triggerAreaEffect = GetValue("TriggerAreaEffect", 0);
            this._canBePickedUp = GetBooleanValue("CanBePickedUp", 0);
            this._spawnEffect = GetValue("SpawnEffect", 0);
            this._activateEffect = GetValue("ActivateEffect", 0);
            this._sCW = GetValue("SCW", 0);
            this._sCWEnemy = GetValue("SCWEnemy", 0);
            this._layer = GetValue("Layer", 0);

        }
		
        public string GetParentItemForSkin()
        {
            return _parentItemForSkin;
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public string GetExportName()
        {
            return _exportName;
        }

        public string GetExportNameEnemy()
        {
            return _exportNameEnemy;
        }

        public string GetShadowExportName()
        {
            return _shadowExportName;
        }

        public string GetGroundGlowExportName()
        {
            return _groundGlowExportName;
        }

        public string GetLoopingEffect()
        {
            return _loopingEffect;
        }

        public int GetValue()
        {
            return _value;
        }

        public int GetValue2()
        {
            return _value2;
        }

        public int GetTriggerRangeSubTiles()
        {
            return _triggerRangeSubTiles;
        }

        public string GetTriggerAreaEffect()
        {
            return _triggerAreaEffect;
        }

        public bool GetCanBePickedUp()
        {
            return _canBePickedUp;
        }

        public string GetSpawnEffect()
        {
            return _spawnEffect;
        }

        public string GetActivateEffect()
        {
            return _activateEffect;
        }

        public string GetSCW()
        {
            return _sCW;
        }

        public string GetSCWEnemy()
        {
            return _sCWEnemy;
        }

        public string GetLayer()
        {
            return _layer;
        }


    }
}