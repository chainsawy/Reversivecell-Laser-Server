namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicSkillData : LogicData
    {
        private string _behaviorType;
        private bool _canMoveAtSameTime;
        private bool _targeted;
        private bool _canAutoShoot;
        private bool _faceMovement;
        private int _cooldown;
        private int _activeTime;
        private int _castingTime;
        private int _castingRange;
        private int _rangeVisual;
        private int _rangeInputScale;
        private int _maxCastingRange;
        private int _forceValidTile;
        private int _rechargeTime;
        private int _maxCharge;
        private int _damage;
        private int _msBetweenAttacks;
        private int _spread;
        private int _attackPattern;
        private int _numBulletsInOneAttack;
        private bool _twoGuns;
        private bool _executeFirstAttackImmediately;
        private int _chargePushback;
        private int _chargeSpeed;
        private int _chargeType;
        private int _numSpawns;
        private int _maxSpawns;
        private bool _breakInvisibilityOnAttack;
        private int _seeInvisibilityDistance;
        private bool _alwaysCastAtMaxRange;
        private string _projectile;
        private string _summonedCharacter;
        private string _areaEffectObject;
        private string _areaEffectObject2;
        private string _spawnedItem;
        private string _iconSWF;
        private string _largeIconSWF;
        private string _largeIconExportName;
        private string _buttonSWF;
        private string _buttonExportName;
        private string _attackEffect;
        private string _useEffect;
        private string _endEffect;
        private string _loopEffect;
        private string _loopEffect2;
        private string _chargeMoveSound;
        private bool _multiShot;
        private bool _skillCanChange;
        private bool _showTimerBar;
        private string _secondaryProjectile;
        private int _chargedShotCount;
        private int _damageModifier;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicSkillData" /> class.
        /// </summary>
        public LogicSkillData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicSkillData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._behaviorType = GetValue("BehaviorType", 0);
            this._canMoveAtSameTime = GetBooleanValue("CanMoveAtSameTime", 0);
            this._targeted = GetBooleanValue("Targeted", 0);
            this._canAutoShoot = GetBooleanValue("CanAutoShoot", 0);
            this._faceMovement = GetBooleanValue("FaceMovement", 0);
            this._cooldown = GetIntegerValue("Cooldown", 0);
            this._activeTime = GetIntegerValue("ActiveTime", 0);
            this._castingTime = GetIntegerValue("CastingTime", 0);
            this._castingRange = GetIntegerValue("CastingRange", 0);
            this._rangeVisual = GetIntegerValue("RangeVisual", 0);
            this._rangeInputScale = GetIntegerValue("RangeInputScale", 0);
            this._maxCastingRange = GetIntegerValue("MaxCastingRange", 0);
            this._forceValidTile = GetIntegerValue("ForceValidTile", 0);
            this._rechargeTime = GetIntegerValue("RechargeTime", 0);
            this._maxCharge = GetIntegerValue("MaxCharge", 0);
            this._damage = GetIntegerValue("Damage", 0);
            this._msBetweenAttacks = GetIntegerValue("MsBetweenAttacks", 0);
            this._spread = GetIntegerValue("Spread", 0);
            this._attackPattern = GetIntegerValue("AttackPattern", 0);
            this._numBulletsInOneAttack = GetIntegerValue("NumBulletsInOneAttack", 0);
            this._twoGuns = GetBooleanValue("TwoGuns", 0);
            this._executeFirstAttackImmediately = GetBooleanValue("ExecuteFirstAttackImmediately", 0);
            this._chargePushback = GetIntegerValue("ChargePushback", 0);
            this._chargeSpeed = GetIntegerValue("ChargeSpeed", 0);
            this._chargeType = GetIntegerValue("ChargeType", 0);
            this._numSpawns = GetIntegerValue("NumSpawns", 0);
            this._maxSpawns = GetIntegerValue("MaxSpawns", 0);
            this._breakInvisibilityOnAttack = GetBooleanValue("BreakInvisibilityOnAttack", 0);
            this._seeInvisibilityDistance = GetIntegerValue("SeeInvisibilityDistance", 0);
            this._alwaysCastAtMaxRange = GetBooleanValue("AlwaysCastAtMaxRange", 0);
            this._projectile = GetValue("Projectile", 0);
            this._summonedCharacter = GetValue("SummonedCharacter", 0);
            this._areaEffectObject = GetValue("AreaEffectObject", 0);
            this._areaEffectObject2 = GetValue("AreaEffectObject2", 0);
            this._spawnedItem = GetValue("SpawnedItem", 0);
            this._iconSWF = GetValue("IconSWF", 0);
            this._largeIconSWF = GetValue("LargeIconSWF", 0);
            this._largeIconExportName = GetValue("LargeIconExportName", 0);
            this._buttonSWF = GetValue("ButtonSWF", 0);
            this._buttonExportName = GetValue("ButtonExportName", 0);
            this._attackEffect = GetValue("AttackEffect", 0);
            this._useEffect = GetValue("UseEffect", 0);
            this._endEffect = GetValue("EndEffect", 0);
            this._loopEffect = GetValue("LoopEffect", 0);
            this._loopEffect2 = GetValue("LoopEffect2", 0);
            this._chargeMoveSound = GetValue("ChargeMoveSound", 0);
            this._multiShot = GetBooleanValue("MultiShot", 0);
            this._skillCanChange = GetBooleanValue("SkillCanChange", 0);
            this._showTimerBar = GetBooleanValue("ShowTimerBar", 0);
            this._secondaryProjectile = GetValue("SecondaryProjectile", 0);
            this._chargedShotCount = GetIntegerValue("ChargedShotCount", 0);
            this._damageModifier = GetIntegerValue("DamageModifier", 0);

        }
		
        public string GetBehaviorType()
        {
            return _behaviorType;
        }

        public bool GetCanMoveAtSameTime()
        {
            return _canMoveAtSameTime;
        }

        public bool GetTargeted()
        {
            return _targeted;
        }

        public bool GetCanAutoShoot()
        {
            return _canAutoShoot;
        }

        public bool GetFaceMovement()
        {
            return _faceMovement;
        }

        public int GetCooldown()
        {
            return _cooldown;
        }

        public int GetActiveTime()
        {
            return _activeTime;
        }

        public int GetCastingTime()
        {
            return _castingTime;
        }

        public int GetCastingRange()
        {
            return _castingRange;
        }

        public int GetRangeVisual()
        {
            return _rangeVisual;
        }

        public int GetRangeInputScale()
        {
            return _rangeInputScale;
        }

        public int GetMaxCastingRange()
        {
            return _maxCastingRange;
        }

        public int GetForceValidTile()
        {
            return _forceValidTile;
        }

        public int GetRechargeTime()
        {
            return _rechargeTime;
        }

        public int GetMaxCharge()
        {
            return _maxCharge;
        }

        public int GetDamage()
        {
            return _damage;
        }

        public int GetMsBetweenAttacks()
        {
            return _msBetweenAttacks;
        }

        public int GetSpread()
        {
            return _spread;
        }

        public int GetAttackPattern()
        {
            return _attackPattern;
        }

        public int GetNumBulletsInOneAttack()
        {
            return _numBulletsInOneAttack;
        }

        public bool GetTwoGuns()
        {
            return _twoGuns;
        }

        public bool GetExecuteFirstAttackImmediately()
        {
            return _executeFirstAttackImmediately;
        }

        public int GetChargePushback()
        {
            return _chargePushback;
        }

        public int GetChargeSpeed()
        {
            return _chargeSpeed;
        }

        public int GetChargeType()
        {
            return _chargeType;
        }

        public int GetNumSpawns()
        {
            return _numSpawns;
        }

        public int GetMaxSpawns()
        {
            return _maxSpawns;
        }

        public bool GetBreakInvisibilityOnAttack()
        {
            return _breakInvisibilityOnAttack;
        }

        public int GetSeeInvisibilityDistance()
        {
            return _seeInvisibilityDistance;
        }

        public bool GetAlwaysCastAtMaxRange()
        {
            return _alwaysCastAtMaxRange;
        }

        public string GetProjectile()
        {
            return _projectile;
        }

        public string GetSummonedCharacter()
        {
            return _summonedCharacter;
        }

        public string GetAreaEffectObject()
        {
            return _areaEffectObject;
        }

        public string GetAreaEffectObject2()
        {
            return _areaEffectObject2;
        }

        public string GetSpawnedItem()
        {
            return _spawnedItem;
        }

        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public string GetLargeIconSWF()
        {
            return _largeIconSWF;
        }

        public string GetLargeIconExportName()
        {
            return _largeIconExportName;
        }

        public string GetButtonSWF()
        {
            return _buttonSWF;
        }

        public string GetButtonExportName()
        {
            return _buttonExportName;
        }

        public string GetAttackEffect()
        {
            return _attackEffect;
        }

        public string GetUseEffect()
        {
            return _useEffect;
        }

        public string GetEndEffect()
        {
            return _endEffect;
        }

        public string GetLoopEffect()
        {
            return _loopEffect;
        }

        public string GetLoopEffect2()
        {
            return _loopEffect2;
        }

        public string GetChargeMoveSound()
        {
            return _chargeMoveSound;
        }

        public bool GetMultiShot()
        {
            return _multiShot;
        }

        public bool GetSkillCanChange()
        {
            return _skillCanChange;
        }

        public bool GetShowTimerBar()
        {
            return _showTimerBar;
        }

        public string GetSecondaryProjectile()
        {
            return _secondaryProjectile;
        }

        public int GetChargedShotCount()
        {
            return _chargedShotCount;
        }

        public int GetDamageModifier()
        {
            return _damageModifier;
        }


    }
}