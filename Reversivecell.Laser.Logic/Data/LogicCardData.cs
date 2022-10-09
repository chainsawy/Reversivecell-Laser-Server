namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicCardData : LogicData
    {
        private string _iconSWF;
        private string _target;
        private bool _lockedForChronos;
        private int _dynamicRarityStartSeason;
        private int _metaType;
        private string _requiresCard;
        private string _type;
        private string _skill;
        private int _value;
        private int _value2;
        private int _value3;
        private string _rarity;
        private string _powerNumberTID;
        private string _powerNumber2TID;
        private string _powerNumber3TID;
        private string _powerIcon1ExportName;
        private string _powerIcon2ExportName;
        private int _sortOrder;
        private bool _dontUpgradeStat;
        private bool _hideDamageStat;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicCardData" /> class.
        /// </summary>
        public LogicCardData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicCardData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._iconSWF = GetValue("IconSWF", 0);
            this._target = GetValue("Target", 0);
            this._lockedForChronos = GetBooleanValue("LockedForChronos", 0);
            this._dynamicRarityStartSeason = GetIntegerValue("DynamicRarityStartSeason", 0);
            this._metaType = GetIntegerValue("MetaType", 0);
            this._requiresCard = GetValue("RequiresCard", 0);
            this._type = GetValue("Type", 0);
            this._skill = GetValue("Skill", 0);
            this._value = GetIntegerValue("Value", 0);
            this._value2 = GetIntegerValue("Value2", 0);
            this._value3 = GetIntegerValue("Value3", 0);
            this._rarity = GetValue("Rarity", 0);
            this._powerNumberTID = GetValue("PowerNumberTID", 0);
            this._powerNumber2TID = GetValue("PowerNumber2TID", 0);
            this._powerNumber3TID = GetValue("PowerNumber3TID", 0);
            this._powerIcon1ExportName = GetValue("PowerIcon1ExportName", 0);
            this._powerIcon2ExportName = GetValue("PowerIcon2ExportName", 0);
            this._sortOrder = GetIntegerValue("SortOrder", 0);
            this._dontUpgradeStat = GetBooleanValue("DontUpgradeStat", 0);
            this._hideDamageStat = GetBooleanValue("HideDamageStat", 0);

        }
		
        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public string GetTarget()
        {
            return _target;
        }

        public bool GetLockedForChronos()
        {
            return _lockedForChronos;
        }

        public int GetDynamicRarityStartSeason()
        {
            return _dynamicRarityStartSeason;
        }

        public int GetMetaType()
        {
            return _metaType;
        }

        public string GetRequiresCard()
        {
            return _requiresCard;
        }

        public string GetType()
        {
            return _type;
        }

        public string GetSkill()
        {
            return _skill;
        }

        public int GetValue()
        {
            return _value;
        }

        public int GetValue2()
        {
            return _value2;
        }

        public int GetValue3()
        {
            return _value3;
        }

        public string GetRarity()
        {
            return _rarity;
        }

        public string GetPowerNumberTID()
        {
            return _powerNumberTID;
        }

        public string GetPowerNumber2TID()
        {
            return _powerNumber2TID;
        }

        public string GetPowerNumber3TID()
        {
            return _powerNumber3TID;
        }

        public string GetPowerIcon1ExportName()
        {
            return _powerIcon1ExportName;
        }

        public string GetPowerIcon2ExportName()
        {
            return _powerIcon2ExportName;
        }

        public int GetSortOrder()
        {
            return _sortOrder;
        }

        public bool GetDontUpgradeStat()
        {
            return _dontUpgradeStat;
        }

        public bool GetHideDamageStat()
        {
            return _hideDamageStat;
        }


    }
}