namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicGearBoostData : LogicData
    {
        private int _logicType;
        private int _speedIncrease;
        private int _heal;
        private int _damageBoost;
        private int _visionTicks;
        private int _healthShield;
        private string _resource;
        private string _iconSWF;
        private string _tokenTypeTID;
        private string _shopFrameName;
        private string _upgradeInfoTID;
        private string _upgradeTargetTID;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicGearBoostData" /> class.
        /// </summary>
        public LogicGearBoostData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicGearBoostData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._logicType = GetIntegerValue("LogicType", 0);
            this._speedIncrease = GetIntegerValue("SpeedIncrease", 0);
            this._heal = GetIntegerValue("Heal", 0);
            this._damageBoost = GetIntegerValue("DamageBoost", 0);
            this._visionTicks = GetIntegerValue("VisionTicks", 0);
            this._healthShield = GetIntegerValue("HealthShield", 0);
            this._resource = GetValue("Resource", 0);
            this._iconSWF = GetValue("IconSWF", 0);
            this._tokenTypeTID = GetValue("TokenTypeTID", 0);
            this._shopFrameName = GetValue("ShopFrameName", 0);
            this._upgradeInfoTID = GetValue("UpgradeInfoTID", 0);
            this._upgradeTargetTID = GetValue("UpgradeTargetTID", 0);

        }
		
        public int GetLogicType()
        {
            return _logicType;
        }

        public int GetSpeedIncrease()
        {
            return _speedIncrease;
        }

        public int GetHeal()
        {
            return _heal;
        }

        public int GetDamageBoost()
        {
            return _damageBoost;
        }

        public int GetVisionTicks()
        {
            return _visionTicks;
        }

        public int GetHealthShield()
        {
            return _healthShield;
        }

        public string GetResource()
        {
            return _resource;
        }

        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public string GetTokenTypeTID()
        {
            return _tokenTypeTID;
        }

        public string GetShopFrameName()
        {
            return _shopFrameName;
        }

        public string GetUpgradeInfoTID()
        {
            return _upgradeInfoTID;
        }

        public string GetUpgradeTargetTID()
        {
            return _upgradeTargetTID;
        }


    }
}