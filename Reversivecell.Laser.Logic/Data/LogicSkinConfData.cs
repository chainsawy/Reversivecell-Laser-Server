namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicSkinConfData : LogicData
    {
        private string _character;
        private string _model;
        private string _gadgetModel;
        private string _portraitCameraFile;
        private string _introCameraFile;
        private bool _mirrorIntro;
        private string _idleAnim;
        private string _walkAnim;
        private string _primarySkillAnim;
        private string _secondarySkillAnim;
        private string _primarySkillRecoilAnim;
        private string _primarySkillRecoilAnim2;
        private string _secondarySkillRecoilAnim;
        private string _secondarySkillRecoilAnim2;
        private string _reloadingAnim;
        private string _pushbackAnim;
        private string _happyAnim;
        private string _happyLoopAnim;
        private string _sadAnim;
        private string _sadLoopAnim;
        private string _heroScreenIdleAnim;
        private string _heroScreenAnim;
        private string _heroScreenLoopAnim;
        private string _signatureAnim;
        private string _happyEnterAnim;
        private string _sadEnterAnim;
        private string _profileAnim;
        private string _introAnim;
        private string _bossAutoAttackAnim;
        private string _bossAutoAttackRecoilAnim;
        private string _bossAutoAttackRecoilAnim2;
        private string _gadgetActiveAnim;
        private string _gadgetRecoilAnim;
        private string _idleFace;
        private string _walkFace;
        private string _happyFace;
        private string _happyLoopFace;
        private string _sadFace;
        private string _sadLoopFace;
        private string _heroScreenIdleFace;
        private string _heroScreenFace;
        private string _heroScreenLoopFace;
        private string _signatureFace;
        private string _profileFace;
        private string _introFace;
        private string _happyEffect;
        private string _sadEffect;
        private bool _petInSameSprite;
        private bool _attackLocksAttackAngle;
        private bool _ultiLocksAttackAngle;
        private string _mainAttackProjectile;
        private string _ultiProjectile;
        private string _mainAttackEffect;
        private string _ultiAttackEffect;
        private bool _useBlueTextureInMenus;
        private string _mainAttackUseEffect;
        private string _ultiUseEffect;
        private string _ultiEndEffect;
        private string _meleeHitEffect;
        private string _spawnEffect;
        private string _ultiLoopEffect;
        private string _ultiLoopEffect2;
        private string _areaEffect;
        private string _areaEffectStarPower;
        private string _spawnedItem;
        private string _killCelebrationSoundVO;
        private string _inLeadCelebrationSoundVO;
        private string _startSoundVO;
        private string _useUltiSoundVO;
        private string _takeDamageSoundVO;
        private string _deathSoundVO;
        private string _attackSoundVO;
        private string _boneEffect1;
        private string _boneEffect2;
        private string _boneEffect3;
        private string _boneEffect4;
        private string _boneEffectUse;
        private string _autoAttackProjectile;
        private string _projectileForShockyStarPower;
        private string _incendiaryStarPowerAreaEffect;
        private string _moveEffect;
        private string _stillEffect;
        private string _chargedShotEffect;
        private bool _disableHeadRotation;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicSkinConfData" /> class.
        /// </summary>
        public LogicSkinConfData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicSkinConfData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._character = GetValue("Character", 0);
            this._model = GetValue("Model", 0);
            this._gadgetModel = GetValue("GadgetModel", 0);
            this._portraitCameraFile = GetValue("PortraitCameraFile", 0);
            this._introCameraFile = GetValue("IntroCameraFile", 0);
            this._mirrorIntro = GetBooleanValue("MirrorIntro", 0);
            this._idleAnim = GetValue("IdleAnim", 0);
            this._walkAnim = GetValue("WalkAnim", 0);
            this._primarySkillAnim = GetValue("PrimarySkillAnim", 0);
            this._secondarySkillAnim = GetValue("SecondarySkillAnim", 0);
            this._primarySkillRecoilAnim = GetValue("PrimarySkillRecoilAnim", 0);
            this._primarySkillRecoilAnim2 = GetValue("PrimarySkillRecoilAnim2", 0);
            this._secondarySkillRecoilAnim = GetValue("SecondarySkillRecoilAnim", 0);
            this._secondarySkillRecoilAnim2 = GetValue("SecondarySkillRecoilAnim2", 0);
            this._reloadingAnim = GetValue("ReloadingAnim", 0);
            this._pushbackAnim = GetValue("PushbackAnim", 0);
            this._happyAnim = GetValue("HappyAnim", 0);
            this._happyLoopAnim = GetValue("HappyLoopAnim", 0);
            this._sadAnim = GetValue("SadAnim", 0);
            this._sadLoopAnim = GetValue("SadLoopAnim", 0);
            this._heroScreenIdleAnim = GetValue("HeroScreenIdleAnim", 0);
            this._heroScreenAnim = GetValue("HeroScreenAnim", 0);
            this._heroScreenLoopAnim = GetValue("HeroScreenLoopAnim", 0);
            this._signatureAnim = GetValue("SignatureAnim", 0);
            this._happyEnterAnim = GetValue("HappyEnterAnim", 0);
            this._sadEnterAnim = GetValue("SadEnterAnim", 0);
            this._profileAnim = GetValue("ProfileAnim", 0);
            this._introAnim = GetValue("IntroAnim", 0);
            this._bossAutoAttackAnim = GetValue("BossAutoAttackAnim", 0);
            this._bossAutoAttackRecoilAnim = GetValue("BossAutoAttackRecoilAnim", 0);
            this._bossAutoAttackRecoilAnim2 = GetValue("BossAutoAttackRecoilAnim2", 0);
            this._gadgetActiveAnim = GetValue("GadgetActiveAnim", 0);
            this._gadgetRecoilAnim = GetValue("GadgetRecoilAnim", 0);
            this._idleFace = GetValue("IdleFace", 0);
            this._walkFace = GetValue("WalkFace", 0);
            this._happyFace = GetValue("HappyFace", 0);
            this._happyLoopFace = GetValue("HappyLoopFace", 0);
            this._sadFace = GetValue("SadFace", 0);
            this._sadLoopFace = GetValue("SadLoopFace", 0);
            this._heroScreenIdleFace = GetValue("HeroScreenIdleFace", 0);
            this._heroScreenFace = GetValue("HeroScreenFace", 0);
            this._heroScreenLoopFace = GetValue("HeroScreenLoopFace", 0);
            this._signatureFace = GetValue("SignatureFace", 0);
            this._profileFace = GetValue("ProfileFace", 0);
            this._introFace = GetValue("IntroFace", 0);
            this._happyEffect = GetValue("HappyEffect", 0);
            this._sadEffect = GetValue("SadEffect", 0);
            this._petInSameSprite = GetBooleanValue("PetInSameSprite", 0);
            this._attackLocksAttackAngle = GetBooleanValue("AttackLocksAttackAngle", 0);
            this._ultiLocksAttackAngle = GetBooleanValue("UltiLocksAttackAngle", 0);
            this._mainAttackProjectile = GetValue("MainAttackProjectile", 0);
            this._ultiProjectile = GetValue("UltiProjectile", 0);
            this._mainAttackEffect = GetValue("MainAttackEffect", 0);
            this._ultiAttackEffect = GetValue("UltiAttackEffect", 0);
            this._useBlueTextureInMenus = GetBooleanValue("UseBlueTextureInMenus", 0);
            this._mainAttackUseEffect = GetValue("MainAttackUseEffect", 0);
            this._ultiUseEffect = GetValue("UltiUseEffect", 0);
            this._ultiEndEffect = GetValue("UltiEndEffect", 0);
            this._meleeHitEffect = GetValue("MeleeHitEffect", 0);
            this._spawnEffect = GetValue("SpawnEffect", 0);
            this._ultiLoopEffect = GetValue("UltiLoopEffect", 0);
            this._ultiLoopEffect2 = GetValue("UltiLoopEffect2", 0);
            this._areaEffect = GetValue("AreaEffect", 0);
            this._areaEffectStarPower = GetValue("AreaEffectStarPower", 0);
            this._spawnedItem = GetValue("SpawnedItem", 0);
            this._killCelebrationSoundVO = GetValue("KillCelebrationSoundVO", 0);
            this._inLeadCelebrationSoundVO = GetValue("InLeadCelebrationSoundVO", 0);
            this._startSoundVO = GetValue("StartSoundVO", 0);
            this._useUltiSoundVO = GetValue("UseUltiSoundVO", 0);
            this._takeDamageSoundVO = GetValue("TakeDamageSoundVO", 0);
            this._deathSoundVO = GetValue("DeathSoundVO", 0);
            this._attackSoundVO = GetValue("AttackSoundVO", 0);
            this._boneEffect1 = GetValue("BoneEffect1", 0);
            this._boneEffect2 = GetValue("BoneEffect2", 0);
            this._boneEffect3 = GetValue("BoneEffect3", 0);
            this._boneEffect4 = GetValue("BoneEffect4", 0);
            this._boneEffectUse = GetValue("BoneEffectUse", 0);
            this._autoAttackProjectile = GetValue("AutoAttackProjectile", 0);
            this._projectileForShockyStarPower = GetValue("ProjectileForShockyStarPower", 0);
            this._incendiaryStarPowerAreaEffect = GetValue("IncendiaryStarPowerAreaEffect", 0);
            this._moveEffect = GetValue("MoveEffect", 0);
            this._stillEffect = GetValue("StillEffect", 0);
            this._chargedShotEffect = GetValue("ChargedShotEffect", 0);
            this._disableHeadRotation = GetBooleanValue("DisableHeadRotation", 0);

        }
		
        public string GetCharacter()
        {
            return _character;
        }

        public string GetModel()
        {
            return _model;
        }

        public string GetGadgetModel()
        {
            return _gadgetModel;
        }

        public string GetPortraitCameraFile()
        {
            return _portraitCameraFile;
        }

        public string GetIntroCameraFile()
        {
            return _introCameraFile;
        }

        public bool GetMirrorIntro()
        {
            return _mirrorIntro;
        }

        public string GetIdleAnim()
        {
            return _idleAnim;
        }

        public string GetWalkAnim()
        {
            return _walkAnim;
        }

        public string GetPrimarySkillAnim()
        {
            return _primarySkillAnim;
        }

        public string GetSecondarySkillAnim()
        {
            return _secondarySkillAnim;
        }

        public string GetPrimarySkillRecoilAnim()
        {
            return _primarySkillRecoilAnim;
        }

        public string GetPrimarySkillRecoilAnim2()
        {
            return _primarySkillRecoilAnim2;
        }

        public string GetSecondarySkillRecoilAnim()
        {
            return _secondarySkillRecoilAnim;
        }

        public string GetSecondarySkillRecoilAnim2()
        {
            return _secondarySkillRecoilAnim2;
        }

        public string GetReloadingAnim()
        {
            return _reloadingAnim;
        }

        public string GetPushbackAnim()
        {
            return _pushbackAnim;
        }

        public string GetHappyAnim()
        {
            return _happyAnim;
        }

        public string GetHappyLoopAnim()
        {
            return _happyLoopAnim;
        }

        public string GetSadAnim()
        {
            return _sadAnim;
        }

        public string GetSadLoopAnim()
        {
            return _sadLoopAnim;
        }

        public string GetHeroScreenIdleAnim()
        {
            return _heroScreenIdleAnim;
        }

        public string GetHeroScreenAnim()
        {
            return _heroScreenAnim;
        }

        public string GetHeroScreenLoopAnim()
        {
            return _heroScreenLoopAnim;
        }

        public string GetSignatureAnim()
        {
            return _signatureAnim;
        }

        public string GetHappyEnterAnim()
        {
            return _happyEnterAnim;
        }

        public string GetSadEnterAnim()
        {
            return _sadEnterAnim;
        }

        public string GetProfileAnim()
        {
            return _profileAnim;
        }

        public string GetIntroAnim()
        {
            return _introAnim;
        }

        public string GetBossAutoAttackAnim()
        {
            return _bossAutoAttackAnim;
        }

        public string GetBossAutoAttackRecoilAnim()
        {
            return _bossAutoAttackRecoilAnim;
        }

        public string GetBossAutoAttackRecoilAnim2()
        {
            return _bossAutoAttackRecoilAnim2;
        }

        public string GetGadgetActiveAnim()
        {
            return _gadgetActiveAnim;
        }

        public string GetGadgetRecoilAnim()
        {
            return _gadgetRecoilAnim;
        }

        public string GetIdleFace()
        {
            return _idleFace;
        }

        public string GetWalkFace()
        {
            return _walkFace;
        }

        public string GetHappyFace()
        {
            return _happyFace;
        }

        public string GetHappyLoopFace()
        {
            return _happyLoopFace;
        }

        public string GetSadFace()
        {
            return _sadFace;
        }

        public string GetSadLoopFace()
        {
            return _sadLoopFace;
        }

        public string GetHeroScreenIdleFace()
        {
            return _heroScreenIdleFace;
        }

        public string GetHeroScreenFace()
        {
            return _heroScreenFace;
        }

        public string GetHeroScreenLoopFace()
        {
            return _heroScreenLoopFace;
        }

        public string GetSignatureFace()
        {
            return _signatureFace;
        }

        public string GetProfileFace()
        {
            return _profileFace;
        }

        public string GetIntroFace()
        {
            return _introFace;
        }

        public string GetHappyEffect()
        {
            return _happyEffect;
        }

        public string GetSadEffect()
        {
            return _sadEffect;
        }

        public bool GetPetInSameSprite()
        {
            return _petInSameSprite;
        }

        public bool GetAttackLocksAttackAngle()
        {
            return _attackLocksAttackAngle;
        }

        public bool GetUltiLocksAttackAngle()
        {
            return _ultiLocksAttackAngle;
        }

        public string GetMainAttackProjectile()
        {
            return _mainAttackProjectile;
        }

        public string GetUltiProjectile()
        {
            return _ultiProjectile;
        }

        public string GetMainAttackEffect()
        {
            return _mainAttackEffect;
        }

        public string GetUltiAttackEffect()
        {
            return _ultiAttackEffect;
        }

        public bool GetUseBlueTextureInMenus()
        {
            return _useBlueTextureInMenus;
        }

        public string GetMainAttackUseEffect()
        {
            return _mainAttackUseEffect;
        }

        public string GetUltiUseEffect()
        {
            return _ultiUseEffect;
        }

        public string GetUltiEndEffect()
        {
            return _ultiEndEffect;
        }

        public string GetMeleeHitEffect()
        {
            return _meleeHitEffect;
        }

        public string GetSpawnEffect()
        {
            return _spawnEffect;
        }

        public string GetUltiLoopEffect()
        {
            return _ultiLoopEffect;
        }

        public string GetUltiLoopEffect2()
        {
            return _ultiLoopEffect2;
        }

        public string GetAreaEffect()
        {
            return _areaEffect;
        }

        public string GetAreaEffectStarPower()
        {
            return _areaEffectStarPower;
        }

        public string GetSpawnedItem()
        {
            return _spawnedItem;
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

        public string GetAutoAttackProjectile()
        {
            return _autoAttackProjectile;
        }

        public string GetProjectileForShockyStarPower()
        {
            return _projectileForShockyStarPower;
        }

        public string GetIncendiaryStarPowerAreaEffect()
        {
            return _incendiaryStarPowerAreaEffect;
        }

        public string GetMoveEffect()
        {
            return _moveEffect;
        }

        public string GetStillEffect()
        {
            return _stillEffect;
        }

        public string GetChargedShotEffect()
        {
            return _chargedShotEffect;
        }

        public bool GetDisableHeadRotation()
        {
            return _disableHeadRotation;
        }


    }
}