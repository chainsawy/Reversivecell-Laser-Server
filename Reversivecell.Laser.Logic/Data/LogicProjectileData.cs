namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicProjectileData : LogicData
    {
        private string _parentProjectileForSkin;
        private int _speed;
        private string _fileName;
        private string _blueSCW;
        private string _redSCW;
        private string _blueExportName;
        private string _redExportName;
        private string _shadowExportName;
        private string _blueGroundGlowExportName;
        private string _redGroundGlowExportName;
        private string _preExplosionBlueExportName;
        private string _preExplosionRedExportName;
        private int _preExplosionTimeMs;
        private string _hitEffectEnv;
        private string _hitEffectChar;
        private string _maxRangeReachedEffect;
        private string _cancelEffect;
        private int _radius;
        private bool _indirect;
        private bool _constantFlyTime;
        private int _triggerWithDelayMs;
        private int _bouncePercent;
        private int _gravity;
        private int _earlyTicks;
        private int _hideTime;
        private int _scale;
        private int _randomStartFrame;
        private string _spawnAreaEffectObject;
        private string _spawnAreaEffectObject2;
        private string _spawnCharacter;
        private string _spawnItem;
        private string _trailEffect;
        private bool _shotByHero;
        private bool _isBeam;
        private bool _isBouncing;
        private int _distanceAddFromBounce;
        private string _rendering;
        private bool _piercesCharacters;
        private bool _piercesEnvironment;
        private bool _piercesEnvironmentLikeButter;
        private int _pushbackStrength;
        private bool _variablePushback;
        private bool _directionAlignedPushback;
        private int _chainsToEnemies;
        private int _chainBullets;
        private int _chainSpread;
        private int _chainTravelDistance;
        private string _chainBullet;
        private int _executeChainSpecialCase;
        private int _damagePercentStart;
        private int _damagePercentEnd;
        private int _damagesConstantlyTickDelay;
        private int _freezeStrength;
        private int _freezeDurationMS;
        private int _stunLengthMS;
        private int _scaleStart;
        private int _scaleEnd;
        private bool _attractsPet;
        private int _lifeStealPercent;
        private bool _passesEnvironment;
        private int _poisonDamagePercent;
        private bool _damageOnlyWithOneProj;
        private int _healOwnPercent;
        private bool _canGrowStronger;
        private bool _hideFaster;
        private bool _grapplesEnemy;
        private int _kickBack;
        private bool _useColorMod;
        private int _redAdd;
        private int _greenAdd;
        private int _blueAdd;
        private int _redMul;
        private int _greenMul;
        private int _blueMul;
        private bool _groundBasis;
        private int _minDistanceForSpread;
        private bool _isFriendlyHomingMissile;
        private bool _isBoomerang;
        private bool _canHitAgainAfterBounce;
        private bool _isHomingMissile;
        private bool _blockUltiCharge;
        private int _poisonType;
        private int _travelType;
        private int _steerStrength;
        private int _steerIgnoreTicks;
        private int _homeDistance;
        private int _steerLifeTime;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicProjectileData" /> class.
        /// </summary>
        public LogicProjectileData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicProjectileData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._parentProjectileForSkin = GetValue("ParentProjectileForSkin", 0);
            this._speed = GetIntegerValue("Speed", 0);
            this._fileName = GetValue("FileName", 0);
            this._blueSCW = GetValue("BlueSCW", 0);
            this._redSCW = GetValue("RedSCW", 0);
            this._blueExportName = GetValue("BlueExportName", 0);
            this._redExportName = GetValue("RedExportName", 0);
            this._shadowExportName = GetValue("ShadowExportName", 0);
            this._blueGroundGlowExportName = GetValue("BlueGroundGlowExportName", 0);
            this._redGroundGlowExportName = GetValue("RedGroundGlowExportName", 0);
            this._preExplosionBlueExportName = GetValue("PreExplosionBlueExportName", 0);
            this._preExplosionRedExportName = GetValue("PreExplosionRedExportName", 0);
            this._preExplosionTimeMs = GetIntegerValue("PreExplosionTimeMs", 0);
            this._hitEffectEnv = GetValue("HitEffectEnv", 0);
            this._hitEffectChar = GetValue("HitEffectChar", 0);
            this._maxRangeReachedEffect = GetValue("MaxRangeReachedEffect", 0);
            this._cancelEffect = GetValue("CancelEffect", 0);
            this._radius = GetIntegerValue("Radius", 0);
            this._indirect = GetBooleanValue("Indirect", 0);
            this._constantFlyTime = GetBooleanValue("ConstantFlyTime", 0);
            this._triggerWithDelayMs = GetIntegerValue("TriggerWithDelayMs", 0);
            this._bouncePercent = GetIntegerValue("BouncePercent", 0);
            this._gravity = GetIntegerValue("Gravity", 0);
            this._earlyTicks = GetIntegerValue("EarlyTicks", 0);
            this._hideTime = GetIntegerValue("HideTime", 0);
            this._scale = GetIntegerValue("Scale", 0);
            this._randomStartFrame = GetIntegerValue("RandomStartFrame", 0);
            this._spawnAreaEffectObject = GetValue("SpawnAreaEffectObject", 0);
            this._spawnAreaEffectObject2 = GetValue("SpawnAreaEffectObject2", 0);
            this._spawnCharacter = GetValue("SpawnCharacter", 0);
            this._spawnItem = GetValue("SpawnItem", 0);
            this._trailEffect = GetValue("TrailEffect", 0);
            this._shotByHero = GetBooleanValue("ShotByHero", 0);
            this._isBeam = GetBooleanValue("IsBeam", 0);
            this._isBouncing = GetBooleanValue("IsBouncing", 0);
            this._distanceAddFromBounce = GetIntegerValue("DistanceAddFromBounce", 0);
            this._rendering = GetValue("Rendering", 0);
            this._piercesCharacters = GetBooleanValue("PiercesCharacters", 0);
            this._piercesEnvironment = GetBooleanValue("PiercesEnvironment", 0);
            this._piercesEnvironmentLikeButter = GetBooleanValue("PiercesEnvironmentLikeButter", 0);
            this._pushbackStrength = GetIntegerValue("PushbackStrength", 0);
            this._variablePushback = GetBooleanValue("VariablePushback", 0);
            this._directionAlignedPushback = GetBooleanValue("DirectionAlignedPushback", 0);
            this._chainsToEnemies = GetIntegerValue("ChainsToEnemies", 0);
            this._chainBullets = GetIntegerValue("ChainBullets", 0);
            this._chainSpread = GetIntegerValue("ChainSpread", 0);
            this._chainTravelDistance = GetIntegerValue("ChainTravelDistance", 0);
            this._chainBullet = GetValue("ChainBullet", 0);
            this._executeChainSpecialCase = GetIntegerValue("ExecuteChainSpecialCase", 0);
            this._damagePercentStart = GetIntegerValue("DamagePercentStart", 0);
            this._damagePercentEnd = GetIntegerValue("DamagePercentEnd", 0);
            this._damagesConstantlyTickDelay = GetIntegerValue("DamagesConstantlyTickDelay", 0);
            this._freezeStrength = GetIntegerValue("FreezeStrength", 0);
            this._freezeDurationMS = GetIntegerValue("FreezeDurationMS", 0);
            this._stunLengthMS = GetIntegerValue("StunLengthMS", 0);
            this._scaleStart = GetIntegerValue("ScaleStart", 0);
            this._scaleEnd = GetIntegerValue("ScaleEnd", 0);
            this._attractsPet = GetBooleanValue("AttractsPet", 0);
            this._lifeStealPercent = GetIntegerValue("LifeStealPercent", 0);
            this._passesEnvironment = GetBooleanValue("PassesEnvironment", 0);
            this._poisonDamagePercent = GetIntegerValue("PoisonDamagePercent", 0);
            this._damageOnlyWithOneProj = GetBooleanValue("DamageOnlyWithOneProj", 0);
            this._healOwnPercent = GetIntegerValue("HealOwnPercent", 0);
            this._canGrowStronger = GetBooleanValue("CanGrowStronger", 0);
            this._hideFaster = GetBooleanValue("HideFaster", 0);
            this._grapplesEnemy = GetBooleanValue("GrapplesEnemy", 0);
            this._kickBack = GetIntegerValue("KickBack", 0);
            this._useColorMod = GetBooleanValue("UseColorMod", 0);
            this._redAdd = GetIntegerValue("RedAdd", 0);
            this._greenAdd = GetIntegerValue("GreenAdd", 0);
            this._blueAdd = GetIntegerValue("BlueAdd", 0);
            this._redMul = GetIntegerValue("RedMul", 0);
            this._greenMul = GetIntegerValue("GreenMul", 0);
            this._blueMul = GetIntegerValue("BlueMul", 0);
            this._groundBasis = GetBooleanValue("GroundBasis", 0);
            this._minDistanceForSpread = GetIntegerValue("MinDistanceForSpread", 0);
            this._isFriendlyHomingMissile = GetBooleanValue("IsFriendlyHomingMissile", 0);
            this._isBoomerang = GetBooleanValue("IsBoomerang", 0);
            this._canHitAgainAfterBounce = GetBooleanValue("CanHitAgainAfterBounce", 0);
            this._isHomingMissile = GetBooleanValue("IsHomingMissile", 0);
            this._blockUltiCharge = GetBooleanValue("BlockUltiCharge", 0);
            this._poisonType = GetIntegerValue("PoisonType", 0);
            this._travelType = GetIntegerValue("TravelType", 0);
            this._steerStrength = GetIntegerValue("SteerStrength", 0);
            this._steerIgnoreTicks = GetIntegerValue("SteerIgnoreTicks", 0);
            this._homeDistance = GetIntegerValue("HomeDistance", 0);
            this._steerLifeTime = GetIntegerValue("SteerLifeTime", 0);

        }
		
        public string GetParentProjectileForSkin()
        {
            return _parentProjectileForSkin;
        }

        public int GetSpeed()
        {
            return _speed;
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public string GetBlueSCW()
        {
            return _blueSCW;
        }

        public string GetRedSCW()
        {
            return _redSCW;
        }

        public string GetBlueExportName()
        {
            return _blueExportName;
        }

        public string GetRedExportName()
        {
            return _redExportName;
        }

        public string GetShadowExportName()
        {
            return _shadowExportName;
        }

        public string GetBlueGroundGlowExportName()
        {
            return _blueGroundGlowExportName;
        }

        public string GetRedGroundGlowExportName()
        {
            return _redGroundGlowExportName;
        }

        public string GetPreExplosionBlueExportName()
        {
            return _preExplosionBlueExportName;
        }

        public string GetPreExplosionRedExportName()
        {
            return _preExplosionRedExportName;
        }

        public int GetPreExplosionTimeMs()
        {
            return _preExplosionTimeMs;
        }

        public string GetHitEffectEnv()
        {
            return _hitEffectEnv;
        }

        public string GetHitEffectChar()
        {
            return _hitEffectChar;
        }

        public string GetMaxRangeReachedEffect()
        {
            return _maxRangeReachedEffect;
        }

        public string GetCancelEffect()
        {
            return _cancelEffect;
        }

        public int GetRadius()
        {
            return _radius;
        }

        public bool GetIndirect()
        {
            return _indirect;
        }

        public bool GetConstantFlyTime()
        {
            return _constantFlyTime;
        }

        public int GetTriggerWithDelayMs()
        {
            return _triggerWithDelayMs;
        }

        public int GetBouncePercent()
        {
            return _bouncePercent;
        }

        public int GetGravity()
        {
            return _gravity;
        }

        public int GetEarlyTicks()
        {
            return _earlyTicks;
        }

        public int GetHideTime()
        {
            return _hideTime;
        }

        public int GetScale()
        {
            return _scale;
        }

        public int GetRandomStartFrame()
        {
            return _randomStartFrame;
        }

        public string GetSpawnAreaEffectObject()
        {
            return _spawnAreaEffectObject;
        }

        public string GetSpawnAreaEffectObject2()
        {
            return _spawnAreaEffectObject2;
        }

        public string GetSpawnCharacter()
        {
            return _spawnCharacter;
        }

        public string GetSpawnItem()
        {
            return _spawnItem;
        }

        public string GetTrailEffect()
        {
            return _trailEffect;
        }

        public bool GetShotByHero()
        {
            return _shotByHero;
        }

        public bool GetIsBeam()
        {
            return _isBeam;
        }

        public bool GetIsBouncing()
        {
            return _isBouncing;
        }

        public int GetDistanceAddFromBounce()
        {
            return _distanceAddFromBounce;
        }

        public string GetRendering()
        {
            return _rendering;
        }

        public bool GetPiercesCharacters()
        {
            return _piercesCharacters;
        }

        public bool GetPiercesEnvironment()
        {
            return _piercesEnvironment;
        }

        public bool GetPiercesEnvironmentLikeButter()
        {
            return _piercesEnvironmentLikeButter;
        }

        public int GetPushbackStrength()
        {
            return _pushbackStrength;
        }

        public bool GetVariablePushback()
        {
            return _variablePushback;
        }

        public bool GetDirectionAlignedPushback()
        {
            return _directionAlignedPushback;
        }

        public int GetChainsToEnemies()
        {
            return _chainsToEnemies;
        }

        public int GetChainBullets()
        {
            return _chainBullets;
        }

        public int GetChainSpread()
        {
            return _chainSpread;
        }

        public int GetChainTravelDistance()
        {
            return _chainTravelDistance;
        }

        public string GetChainBullet()
        {
            return _chainBullet;
        }

        public int GetExecuteChainSpecialCase()
        {
            return _executeChainSpecialCase;
        }

        public int GetDamagePercentStart()
        {
            return _damagePercentStart;
        }

        public int GetDamagePercentEnd()
        {
            return _damagePercentEnd;
        }

        public int GetDamagesConstantlyTickDelay()
        {
            return _damagesConstantlyTickDelay;
        }

        public int GetFreezeStrength()
        {
            return _freezeStrength;
        }

        public int GetFreezeDurationMS()
        {
            return _freezeDurationMS;
        }

        public int GetStunLengthMS()
        {
            return _stunLengthMS;
        }

        public int GetScaleStart()
        {
            return _scaleStart;
        }

        public int GetScaleEnd()
        {
            return _scaleEnd;
        }

        public bool GetAttractsPet()
        {
            return _attractsPet;
        }

        public int GetLifeStealPercent()
        {
            return _lifeStealPercent;
        }

        public bool GetPassesEnvironment()
        {
            return _passesEnvironment;
        }

        public int GetPoisonDamagePercent()
        {
            return _poisonDamagePercent;
        }

        public bool GetDamageOnlyWithOneProj()
        {
            return _damageOnlyWithOneProj;
        }

        public int GetHealOwnPercent()
        {
            return _healOwnPercent;
        }

        public bool GetCanGrowStronger()
        {
            return _canGrowStronger;
        }

        public bool GetHideFaster()
        {
            return _hideFaster;
        }

        public bool GetGrapplesEnemy()
        {
            return _grapplesEnemy;
        }

        public int GetKickBack()
        {
            return _kickBack;
        }

        public bool GetUseColorMod()
        {
            return _useColorMod;
        }

        public int GetRedAdd()
        {
            return _redAdd;
        }

        public int GetGreenAdd()
        {
            return _greenAdd;
        }

        public int GetBlueAdd()
        {
            return _blueAdd;
        }

        public int GetRedMul()
        {
            return _redMul;
        }

        public int GetGreenMul()
        {
            return _greenMul;
        }

        public int GetBlueMul()
        {
            return _blueMul;
        }

        public bool GetGroundBasis()
        {
            return _groundBasis;
        }

        public int GetMinDistanceForSpread()
        {
            return _minDistanceForSpread;
        }

        public bool GetIsFriendlyHomingMissile()
        {
            return _isFriendlyHomingMissile;
        }

        public bool GetIsBoomerang()
        {
            return _isBoomerang;
        }

        public bool GetCanHitAgainAfterBounce()
        {
            return _canHitAgainAfterBounce;
        }

        public bool GetIsHomingMissile()
        {
            return _isHomingMissile;
        }

        public bool GetBlockUltiCharge()
        {
            return _blockUltiCharge;
        }

        public int GetPoisonType()
        {
            return _poisonType;
        }

        public int GetTravelType()
        {
            return _travelType;
        }

        public int GetSteerStrength()
        {
            return _steerStrength;
        }

        public int GetSteerIgnoreTicks()
        {
            return _steerIgnoreTicks;
        }

        public int GetHomeDistance()
        {
            return _homeDistance;
        }

        public int GetSteerLifeTime()
        {
            return _steerLifeTime;
        }


    }
}