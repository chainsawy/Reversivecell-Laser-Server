namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicCharacterData : LogicData
    {
        private bool _lockedForChronos;
        private bool _disabled;
        private string _itemName;
        private string _weaponSkill;
        private string _ultimateSkill;
        private string _pet;
        private int _speed;
        private int _hitpoints;
        private bool _meleeAutoAttackSplashDamage;
        private int _autoAttackSpeedMs;
        private int _autoAttackDamage;
        private int _autoAttackBulletsPerShot;
        private string _autoAttackMode;
        private int _autoAttackProjectileSpread;
        private string _autoAttackProjectile;
        private int _autoAttackRange;
        private int _regeneratePerSecond;
        private int _ultiChargeMul;
        private int _ultiChargeUltiMul;
        private string _type;
        private int _damagerPercentFromAliens;
        private string _defaultSkin;
        private string _fileName;
        private string _blueExportName;
        private string _redExportName;
        private string _shadowExportName;
        private string _areaEffect;
        private string _deathAreaEffect;
        private string _takeDamageEffect;
        private string _deathEffect;
        private string _moveEffect;
        private string _reloadEffect;
        private string _outOfAmmoEffect;
        private string _dryFireEffect;
        private string _spawnEffect;
        private string _meleeHitEffect;
        private string _autoAttackStartEffect;
        private string _boneEffect1;
        private string _boneEffect2;
        private string _boneEffect3;
        private string _boneEffect4;
        private string _boneEffectUse;
        private string _loopedEffect;
        private string _loopedEffect2;
        private string _killCelebrationSoundVO;
        private string _inLeadCelebrationSoundVO;
        private string _startSoundVO;
        private string _useUltiSoundVO;
        private string _takeDamageSoundVO;
        private string _deathSoundVO;
        private string _attackSoundVO;
        private int _attackStartEffectOffset;
        private int _twoWeaponAttackEffectOffset;
        private int _shadowScaleX;
        private int _shadowScaleY;
        private int _shadowX;
        private int _shadowY;
        private int _shadowSkew;
        private int _scale;
        private int _heroScreenScale;
        private int _fitToBoxScale;
        private int _endScreenScale;
        private int _gatchaScreenScale;
        private int _homeScreenScale;
        private int _heroScreenXOffset;
        private int _heroScreenZOffset;
        private int _collisionRadius;
        private string _healthBar;
        private int _healthBarOffsetY;
        private int _flyingHeight;
        private int _projectileStartZ;
        private int _stopMovementAfterMS;
        private int _waitMS;
        private bool _forceAttackAnimationToEnd;
        private string _iconSWF;
        private int _recoilAmount;
        private string _homeworld;
        private string _footstepClip;
        private int _differentFootstepOffset;
        private int _footstepIntervalMS;
        private int _attackingWeaponScale;
        private bool _useThrowingLeftWeaponBoneScaling;
        private bool _useThrowingRightWeaponBoneScaling;
        private int _commonSetUpgradeBonus;
        private int _rareSetUpgradeBonus;
        private int _superRareSetUpgradeBonus;
        private bool _canWalkOverWater;
        private bool _useColorMod;
        private int _redAdd;
        private int _greenAdd;
        private int _blueAdd;
        private int _redMul;
        private int _greenMul;
        private int _blueMul;
        private int _chargeUltiAutomatically;
        private string _videoLink;
        private bool _shouldEncodePetStatus;
        private bool _secondaryPet;
        private int _extraMinions;
        private int _petAutoSpawnDelay;
        private int _offenseRating;
        private int _defenseRating;
        private int _utilityRating;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicCharacterData" /> class.
        /// </summary>
        public LogicCharacterData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicCharacterData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._lockedForChronos = GetBooleanValue("LockedForChronos", 0);
            this._disabled = GetBooleanValue("Disabled", 0);
            this._itemName = GetValue("ItemName", 0);
            this._weaponSkill = GetValue("WeaponSkill", 0);
            this._ultimateSkill = GetValue("UltimateSkill", 0);
            this._pet = GetValue("Pet", 0);
            this._speed = GetIntegerValue("Speed", 0);
            this._hitpoints = GetIntegerValue("Hitpoints", 0);
            this._meleeAutoAttackSplashDamage = GetBooleanValue("MeleeAutoAttackSplashDamage", 0);
            this._autoAttackSpeedMs = GetIntegerValue("AutoAttackSpeedMs", 0);
            this._autoAttackDamage = GetIntegerValue("AutoAttackDamage", 0);
            this._autoAttackBulletsPerShot = GetIntegerValue("AutoAttackBulletsPerShot", 0);
            this._autoAttackMode = GetValue("AutoAttackMode", 0);
            this._autoAttackProjectileSpread = GetIntegerValue("AutoAttackProjectileSpread", 0);
            this._autoAttackProjectile = GetValue("AutoAttackProjectile", 0);
            this._autoAttackRange = GetIntegerValue("AutoAttackRange", 0);
            this._regeneratePerSecond = GetIntegerValue("RegeneratePerSecond", 0);
            this._ultiChargeMul = GetIntegerValue("UltiChargeMul", 0);
            this._ultiChargeUltiMul = GetIntegerValue("UltiChargeUltiMul", 0);
            this._type = GetValue("Type", 0);
            this._damagerPercentFromAliens = GetIntegerValue("DamagerPercentFromAliens", 0);
            this._defaultSkin = GetValue("DefaultSkin", 0);
            this._fileName = GetValue("FileName", 0);
            this._blueExportName = GetValue("BlueExportName", 0);
            this._redExportName = GetValue("RedExportName", 0);
            this._shadowExportName = GetValue("ShadowExportName", 0);
            this._areaEffect = GetValue("AreaEffect", 0);
            this._deathAreaEffect = GetValue("DeathAreaEffect", 0);
            this._takeDamageEffect = GetValue("TakeDamageEffect", 0);
            this._deathEffect = GetValue("DeathEffect", 0);
            this._moveEffect = GetValue("MoveEffect", 0);
            this._reloadEffect = GetValue("ReloadEffect", 0);
            this._outOfAmmoEffect = GetValue("OutOfAmmoEffect", 0);
            this._dryFireEffect = GetValue("DryFireEffect", 0);
            this._spawnEffect = GetValue("SpawnEffect", 0);
            this._meleeHitEffect = GetValue("MeleeHitEffect", 0);
            this._autoAttackStartEffect = GetValue("AutoAttackStartEffect", 0);
            this._boneEffect1 = GetValue("BoneEffect1", 0);
            this._boneEffect2 = GetValue("BoneEffect2", 0);
            this._boneEffect3 = GetValue("BoneEffect3", 0);
            this._boneEffect4 = GetValue("BoneEffect4", 0);
            this._boneEffectUse = GetValue("BoneEffectUse", 0);
            this._loopedEffect = GetValue("LoopedEffect", 0);
            this._loopedEffect2 = GetValue("LoopedEffect2", 0);
            this._killCelebrationSoundVO = GetValue("KillCelebrationSoundVO", 0);
            this._inLeadCelebrationSoundVO = GetValue("InLeadCelebrationSoundVO", 0);
            this._startSoundVO = GetValue("StartSoundVO", 0);
            this._useUltiSoundVO = GetValue("UseUltiSoundVO", 0);
            this._takeDamageSoundVO = GetValue("TakeDamageSoundVO", 0);
            this._deathSoundVO = GetValue("DeathSoundVO", 0);
            this._attackSoundVO = GetValue("AttackSoundVO", 0);
            this._attackStartEffectOffset = GetIntegerValue("AttackStartEffectOffset", 0);
            this._twoWeaponAttackEffectOffset = GetIntegerValue("TwoWeaponAttackEffectOffset", 0);
            this._shadowScaleX = GetIntegerValue("ShadowScaleX", 0);
            this._shadowScaleY = GetIntegerValue("ShadowScaleY", 0);
            this._shadowX = GetIntegerValue("ShadowX", 0);
            this._shadowY = GetIntegerValue("ShadowY", 0);
            this._shadowSkew = GetIntegerValue("ShadowSkew", 0);
            this._scale = GetIntegerValue("Scale", 0);
            this._heroScreenScale = GetIntegerValue("HeroScreenScale", 0);
            this._fitToBoxScale = GetIntegerValue("FitToBoxScale", 0);
            this._endScreenScale = GetIntegerValue("EndScreenScale", 0);
            this._gatchaScreenScale = GetIntegerValue("GatchaScreenScale", 0);
            this._homeScreenScale = GetIntegerValue("HomeScreenScale", 0);
            this._heroScreenXOffset = GetIntegerValue("HeroScreenXOffset", 0);
            this._heroScreenZOffset = GetIntegerValue("HeroScreenZOffset", 0);
            this._collisionRadius = GetIntegerValue("CollisionRadius", 0);
            this._healthBar = GetValue("HealthBar", 0);
            this._healthBarOffsetY = GetIntegerValue("HealthBarOffsetY", 0);
            this._flyingHeight = GetIntegerValue("FlyingHeight", 0);
            this._projectileStartZ = GetIntegerValue("ProjectileStartZ", 0);
            this._stopMovementAfterMS = GetIntegerValue("StopMovementAfterMS", 0);
            this._waitMS = GetIntegerValue("WaitMS", 0);
            this._forceAttackAnimationToEnd = GetBooleanValue("ForceAttackAnimationToEnd", 0);
            this._iconSWF = GetValue("IconSWF", 0);
            this._recoilAmount = GetIntegerValue("RecoilAmount", 0);
            this._homeworld = GetValue("Homeworld", 0);
            this._footstepClip = GetValue("FootstepClip", 0);
            this._differentFootstepOffset = GetIntegerValue("DifferentFootstepOffset", 0);
            this._footstepIntervalMS = GetIntegerValue("FootstepIntervalMS", 0);
            this._attackingWeaponScale = GetIntegerValue("AttackingWeaponScale", 0);
            this._useThrowingLeftWeaponBoneScaling = GetBooleanValue("UseThrowingLeftWeaponBoneScaling", 0);
            this._useThrowingRightWeaponBoneScaling = GetBooleanValue("UseThrowingRightWeaponBoneScaling", 0);
            this._commonSetUpgradeBonus = GetIntegerValue("CommonSetUpgradeBonus", 0);
            this._rareSetUpgradeBonus = GetIntegerValue("RareSetUpgradeBonus", 0);
            this._superRareSetUpgradeBonus = GetIntegerValue("SuperRareSetUpgradeBonus", 0);
            this._canWalkOverWater = GetBooleanValue("CanWalkOverWater", 0);
            this._useColorMod = GetBooleanValue("UseColorMod", 0);
            this._redAdd = GetIntegerValue("RedAdd", 0);
            this._greenAdd = GetIntegerValue("GreenAdd", 0);
            this._blueAdd = GetIntegerValue("BlueAdd", 0);
            this._redMul = GetIntegerValue("RedMul", 0);
            this._greenMul = GetIntegerValue("GreenMul", 0);
            this._blueMul = GetIntegerValue("BlueMul", 0);
            this._chargeUltiAutomatically = GetIntegerValue("ChargeUltiAutomatically", 0);
            this._videoLink = GetValue("VideoLink", 0);
            this._shouldEncodePetStatus = GetBooleanValue("ShouldEncodePetStatus", 0);
            this._secondaryPet = GetBooleanValue("SecondaryPet", 0);
            this._extraMinions = GetIntegerValue("ExtraMinions", 0);
            this._petAutoSpawnDelay = GetIntegerValue("PetAutoSpawnDelay", 0);
            this._offenseRating = GetIntegerValue("OffenseRating", 0);
            this._defenseRating = GetIntegerValue("DefenseRating", 0);
            this._utilityRating = GetIntegerValue("UtilityRating", 0);

        }
		
        public bool GetLockedForChronos()
        {
            return _lockedForChronos;
        }

        public bool GetDisabled()
        {
            return _disabled;
        }

        public string GetItemName()
        {
            return _itemName;
        }

        public string GetWeaponSkill()
        {
            return _weaponSkill;
        }

        public string GetUltimateSkill()
        {
            return _ultimateSkill;
        }

        public string GetPet()
        {
            return _pet;
        }

        public int GetSpeed()
        {
            return _speed;
        }

        public int GetHitpoints()
        {
            return _hitpoints;
        }

        public bool GetMeleeAutoAttackSplashDamage()
        {
            return _meleeAutoAttackSplashDamage;
        }

        public int GetAutoAttackSpeedMs()
        {
            return _autoAttackSpeedMs;
        }

        public int GetAutoAttackDamage()
        {
            return _autoAttackDamage;
        }

        public int GetAutoAttackBulletsPerShot()
        {
            return _autoAttackBulletsPerShot;
        }

        public string GetAutoAttackMode()
        {
            return _autoAttackMode;
        }

        public int GetAutoAttackProjectileSpread()
        {
            return _autoAttackProjectileSpread;
        }

        public string GetAutoAttackProjectile()
        {
            return _autoAttackProjectile;
        }

        public int GetAutoAttackRange()
        {
            return _autoAttackRange;
        }

        public int GetRegeneratePerSecond()
        {
            return _regeneratePerSecond;
        }

        public int GetUltiChargeMul()
        {
            return _ultiChargeMul;
        }

        public int GetUltiChargeUltiMul()
        {
            return _ultiChargeUltiMul;
        }

        public string GetType()
        {
            return _type;
        }

        public int GetDamagerPercentFromAliens()
        {
            return _damagerPercentFromAliens;
        }

        public string GetDefaultSkin()
        {
            return _defaultSkin;
        }

        public string GetFileName()
        {
            return _fileName;
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

        public string GetAreaEffect()
        {
            return _areaEffect;
        }

        public string GetDeathAreaEffect()
        {
            return _deathAreaEffect;
        }

        public string GetTakeDamageEffect()
        {
            return _takeDamageEffect;
        }

        public string GetDeathEffect()
        {
            return _deathEffect;
        }

        public string GetMoveEffect()
        {
            return _moveEffect;
        }

        public string GetReloadEffect()
        {
            return _reloadEffect;
        }

        public string GetOutOfAmmoEffect()
        {
            return _outOfAmmoEffect;
        }

        public string GetDryFireEffect()
        {
            return _dryFireEffect;
        }

        public string GetSpawnEffect()
        {
            return _spawnEffect;
        }

        public string GetMeleeHitEffect()
        {
            return _meleeHitEffect;
        }

        public string GetAutoAttackStartEffect()
        {
            return _autoAttackStartEffect;
        }

        public string GetBoneEffect1()
        {
            return _boneEffect1;
        }

        public string GetBoneEffect2()
        {
            return _boneEffect2;
        }

        public string GetBoneEffect3()
        {
            return _boneEffect3;
        }

        public string GetBoneEffect4()
        {
            return _boneEffect4;
        }

        public string GetBoneEffectUse()
        {
            return _boneEffectUse;
        }

        public string GetLoopedEffect()
        {
            return _loopedEffect;
        }

        public string GetLoopedEffect2()
        {
            return _loopedEffect2;
        }

        public string GetKillCelebrationSoundVO()
        {
            return _killCelebrationSoundVO;
        }

        public string GetInLeadCelebrationSoundVO()
        {
            return _inLeadCelebrationSoundVO;
        }

        public string GetStartSoundVO()
        {
            return _startSoundVO;
        }

        public string GetUseUltiSoundVO()
        {
            return _useUltiSoundVO;
        }

        public string GetTakeDamageSoundVO()
        {
            return _takeDamageSoundVO;
        }

        public string GetDeathSoundVO()
        {
            return _deathSoundVO;
        }

        public string GetAttackSoundVO()
        {
            return _attackSoundVO;
        }

        public int GetAttackStartEffectOffset()
        {
            return _attackStartEffectOffset;
        }

        public int GetTwoWeaponAttackEffectOffset()
        {
            return _twoWeaponAttackEffectOffset;
        }

        public int GetShadowScaleX()
        {
            return _shadowScaleX;
        }

        public int GetShadowScaleY()
        {
            return _shadowScaleY;
        }

        public int GetShadowX()
        {
            return _shadowX;
        }

        public int GetShadowY()
        {
            return _shadowY;
        }

        public int GetShadowSkew()
        {
            return _shadowSkew;
        }

        public int GetScale()
        {
            return _scale;
        }

        public int GetHeroScreenScale()
        {
            return _heroScreenScale;
        }

        public int GetFitToBoxScale()
        {
            return _fitToBoxScale;
        }

        public int GetEndScreenScale()
        {
            return _endScreenScale;
        }

        public int GetGatchaScreenScale()
        {
            return _gatchaScreenScale;
        }

        public int GetHomeScreenScale()
        {
            return _homeScreenScale;
        }

        public int GetHeroScreenXOffset()
        {
            return _heroScreenXOffset;
        }

        public int GetHeroScreenZOffset()
        {
            return _heroScreenZOffset;
        }

        public int GetCollisionRadius()
        {
            return _collisionRadius;
        }

        public string GetHealthBar()
        {
            return _healthBar;
        }

        public int GetHealthBarOffsetY()
        {
            return _healthBarOffsetY;
        }

        public int GetFlyingHeight()
        {
            return _flyingHeight;
        }

        public int GetProjectileStartZ()
        {
            return _projectileStartZ;
        }

        public int GetStopMovementAfterMS()
        {
            return _stopMovementAfterMS;
        }

        public int GetWaitMS()
        {
            return _waitMS;
        }

        public bool GetForceAttackAnimationToEnd()
        {
            return _forceAttackAnimationToEnd;
        }

        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public int GetRecoilAmount()
        {
            return _recoilAmount;
        }

        public string GetHomeworld()
        {
            return _homeworld;
        }

        public string GetFootstepClip()
        {
            return _footstepClip;
        }

        public int GetDifferentFootstepOffset()
        {
            return _differentFootstepOffset;
        }

        public int GetFootstepIntervalMS()
        {
            return _footstepIntervalMS;
        }

        public int GetAttackingWeaponScale()
        {
            return _attackingWeaponScale;
        }

        public bool GetUseThrowingLeftWeaponBoneScaling()
        {
            return _useThrowingLeftWeaponBoneScaling;
        }

        public bool GetUseThrowingRightWeaponBoneScaling()
        {
            return _useThrowingRightWeaponBoneScaling;
        }

        public int GetCommonSetUpgradeBonus()
        {
            return _commonSetUpgradeBonus;
        }

        public int GetRareSetUpgradeBonus()
        {
            return _rareSetUpgradeBonus;
        }

        public int GetSuperRareSetUpgradeBonus()
        {
            return _superRareSetUpgradeBonus;
        }

        public bool GetCanWalkOverWater()
        {
            return _canWalkOverWater;
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

        public int GetChargeUltiAutomatically()
        {
            return _chargeUltiAutomatically;
        }

        public string GetVideoLink()
        {
            return _videoLink;
        }

        public bool GetShouldEncodePetStatus()
        {
            return _shouldEncodePetStatus;
        }

        public bool GetSecondaryPet()
        {
            return _secondaryPet;
        }

        public int GetExtraMinions()
        {
            return _extraMinions;
        }

        public int GetPetAutoSpawnDelay()
        {
            return _petAutoSpawnDelay;
        }

        public int GetOffenseRating()
        {
            return _offenseRating;
        }

        public int GetDefenseRating()
        {
            return _defenseRating;
        }

        public int GetUtilityRating()
        {
            return _utilityRating;
        }


    }
}