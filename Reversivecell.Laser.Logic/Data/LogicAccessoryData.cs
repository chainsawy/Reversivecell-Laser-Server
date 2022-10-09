namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicAccessoryData : LogicData
    {
        private string _type;
        private int _chargeCount;
        private int _cooldown;
        private string _useEffect;
        private string _loopingEffect;
        private int _activationDelay;
        private int _activeTicks;
        private bool _stopMovement;
        private bool _setAttackAngle;
        private int _aimGuideType;
        private bool _consumesAmmo;
        private string _areaEffect;
        private string _petAreaEffect;
        private bool _interruptsAction;
        private bool _allowStunActivation;
        private bool _requirePet;
        private bool _destroyPet;
        private int _requireEnemyDistance;
        private int _shieldPercent;
        private int _shieldTicks;
        private bool _skipTypeCondition;
        private string _customObject;
        private int _customValue1;
        private int _customValue2;
        private int _customValue3;
        private int _customValue4;
        private int _customValue5;
        private int _customValue6;
        private string _missingTargetText;
        private string _targetTooFarText;
        private string _targetAlreadyActiveText;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicAccessoryData" /> class.
        /// </summary>
        public LogicAccessoryData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicAccessoryData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._type = GetValue("Type", 0);
            this._chargeCount = GetIntegerValue("ChargeCount", 0);
            this._cooldown = GetIntegerValue("Cooldown", 0);
            this._useEffect = GetValue("UseEffect", 0);
            this._loopingEffect = GetValue("LoopingEffect", 0);
            this._activationDelay = GetIntegerValue("ActivationDelay", 0);
            this._activeTicks = GetIntegerValue("ActiveTicks", 0);
            this._stopMovement = GetBooleanValue("StopMovement", 0);
            this._setAttackAngle = GetBooleanValue("SetAttackAngle", 0);
            this._aimGuideType = GetIntegerValue("AimGuideType", 0);
            this._consumesAmmo = GetBooleanValue("ConsumesAmmo", 0);
            this._areaEffect = GetValue("AreaEffect", 0);
            this._petAreaEffect = GetValue("PetAreaEffect", 0);
            this._interruptsAction = GetBooleanValue("InterruptsAction", 0);
            this._allowStunActivation = GetBooleanValue("AllowStunActivation", 0);
            this._requirePet = GetBooleanValue("RequirePet", 0);
            this._destroyPet = GetBooleanValue("DestroyPet", 0);
            this._requireEnemyDistance = GetIntegerValue("RequireEnemyDistance", 0);
            this._shieldPercent = GetIntegerValue("ShieldPercent", 0);
            this._shieldTicks = GetIntegerValue("ShieldTicks", 0);
            this._skipTypeCondition = GetBooleanValue("SkipTypeCondition", 0);
            this._customObject = GetValue("CustomObject", 0);
            this._customValue1 = GetIntegerValue("CustomValue1", 0);
            this._customValue2 = GetIntegerValue("CustomValue2", 0);
            this._customValue3 = GetIntegerValue("CustomValue3", 0);
            this._customValue4 = GetIntegerValue("CustomValue4", 0);
            this._customValue5 = GetIntegerValue("CustomValue5", 0);
            this._customValue6 = GetIntegerValue("CustomValue6", 0);
            this._missingTargetText = GetValue("MissingTargetText", 0);
            this._targetTooFarText = GetValue("TargetTooFarText", 0);
            this._targetAlreadyActiveText = GetValue("TargetAlreadyActiveText", 0);

        }
		
        public string GetType()
        {
            return _type;
        }

        public int GetChargeCount()
        {
            return _chargeCount;
        }

        public int GetCooldown()
        {
            return _cooldown;
        }

        public string GetUseEffect()
        {
            return _useEffect;
        }

        public string GetLoopingEffect()
        {
            return _loopingEffect;
        }

        public int GetActivationDelay()
        {
            return _activationDelay;
        }

        public int GetActiveTicks()
        {
            return _activeTicks;
        }

        public bool GetStopMovement()
        {
            return _stopMovement;
        }

        public bool GetSetAttackAngle()
        {
            return _setAttackAngle;
        }

        public int GetAimGuideType()
        {
            return _aimGuideType;
        }

        public bool GetConsumesAmmo()
        {
            return _consumesAmmo;
        }

        public string GetAreaEffect()
        {
            return _areaEffect;
        }

        public string GetPetAreaEffect()
        {
            return _petAreaEffect;
        }

        public bool GetInterruptsAction()
        {
            return _interruptsAction;
        }

        public bool GetAllowStunActivation()
        {
            return _allowStunActivation;
        }

        public bool GetRequirePet()
        {
            return _requirePet;
        }

        public bool GetDestroyPet()
        {
            return _destroyPet;
        }

        public int GetRequireEnemyDistance()
        {
            return _requireEnemyDistance;
        }

        public int GetShieldPercent()
        {
            return _shieldPercent;
        }

        public int GetShieldTicks()
        {
            return _shieldTicks;
        }

        public bool GetSkipTypeCondition()
        {
            return _skipTypeCondition;
        }

        public string GetCustomObject()
        {
            return _customObject;
        }

        public int GetCustomValue1()
        {
            return _customValue1;
        }

        public int GetCustomValue2()
        {
            return _customValue2;
        }

        public int GetCustomValue3()
        {
            return _customValue3;
        }

        public int GetCustomValue4()
        {
            return _customValue4;
        }

        public int GetCustomValue5()
        {
            return _customValue5;
        }

        public int GetCustomValue6()
        {
            return _customValue6;
        }

        public string GetMissingTargetText()
        {
            return _missingTargetText;
        }

        public string GetTargetTooFarText()
        {
            return _targetTooFarText;
        }

        public string GetTargetAlreadyActiveText()
        {
            return _targetAlreadyActiveText;
        }


    }
}