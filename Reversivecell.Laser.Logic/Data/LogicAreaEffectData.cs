namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicAreaEffectData : LogicData
    {
        private string _parentAreaEffectForSkin;
        private string _fileName;
        private string _ownExportName;
        private string _blueExportName;
        private string _redExportName;
        private string _neutralExportName;
        private string _layer;
        private string _exportNameTop;
        private string _exportNameObject;
        private string _effect;
        private string _loopingEffect;
        private bool _allowEffectInterrupt;
        private bool _serverControlsFrame;
        private int _scale;
        private int _timeMs;
        private int _radius;
        private int _damage;
        private int _customValue;
        private string _type;
        private bool _isPersonal;
        private string _bulletExplosionBullet;
        private int _bulletExplosionBulletDistance;
        private string _bulletExplosionItem;
        private bool _destroysEnvironment;
        private int _pushbackStrength;
        private int _pushbackStrengthSelf;
        private int _pushbackDeadzone;
        private bool _canStopGrapple;
        private int _freezeStrength;
        private int _freezeTicks;
        private bool _shouldShowEvenIfOutsideScreen;
        private int _sameAreaEffectCanNotDamageMs;
        private bool _dontShowToEnemy;
        private bool _requireLineOfSight;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicAreaEffectData" /> class.
        /// </summary>
        public LogicAreaEffectData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicAreaEffectData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._parentAreaEffectForSkin = GetValue("ParentAreaEffectForSkin", 0);
            this._fileName = GetValue("FileName", 0);
            this._ownExportName = GetValue("OwnExportName", 0);
            this._blueExportName = GetValue("BlueExportName", 0);
            this._redExportName = GetValue("RedExportName", 0);
            this._neutralExportName = GetValue("NeutralExportName", 0);
            this._layer = GetValue("Layer", 0);
            this._exportNameTop = GetValue("ExportNameTop", 0);
            this._exportNameObject = GetValue("ExportNameObject", 0);
            this._effect = GetValue("Effect", 0);
            this._loopingEffect = GetValue("LoopingEffect", 0);
            this._allowEffectInterrupt = GetBooleanValue("AllowEffectInterrupt", 0);
            this._serverControlsFrame = GetBooleanValue("ServerControlsFrame", 0);
            this._scale = GetIntegerValue("Scale", 0);
            this._timeMs = GetIntegerValue("TimeMs", 0);
            this._radius = GetIntegerValue("Radius", 0);
            this._damage = GetIntegerValue("Damage", 0);
            this._customValue = GetIntegerValue("CustomValue", 0);
            this._type = GetValue("Type", 0);
            this._isPersonal = GetBooleanValue("IsPersonal", 0);
            this._bulletExplosionBullet = GetValue("BulletExplosionBullet", 0);
            this._bulletExplosionBulletDistance = GetIntegerValue("BulletExplosionBulletDistance", 0);
            this._bulletExplosionItem = GetValue("BulletExplosionItem", 0);
            this._destroysEnvironment = GetBooleanValue("DestroysEnvironment", 0);
            this._pushbackStrength = GetIntegerValue("PushbackStrength", 0);
            this._pushbackStrengthSelf = GetIntegerValue("PushbackStrengthSelf", 0);
            this._pushbackDeadzone = GetIntegerValue("PushbackDeadzone", 0);
            this._canStopGrapple = GetBooleanValue("CanStopGrapple", 0);
            this._freezeStrength = GetIntegerValue("FreezeStrength", 0);
            this._freezeTicks = GetIntegerValue("FreezeTicks", 0);
            this._shouldShowEvenIfOutsideScreen = GetBooleanValue("ShouldShowEvenIfOutsideScreen", 0);
            this._sameAreaEffectCanNotDamageMs = GetIntegerValue("SameAreaEffectCanNotDamageMs", 0);
            this._dontShowToEnemy = GetBooleanValue("DontShowToEnemy", 0);
            this._requireLineOfSight = GetBooleanValue("RequireLineOfSight", 0);

        }
		
        public string GetParentAreaEffectForSkin()
        {
            return _parentAreaEffectForSkin;
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public string GetOwnExportName()
        {
            return _ownExportName;
        }

        public string GetBlueExportName()
        {
            return _blueExportName;
        }

        public string GetRedExportName()
        {
            return _redExportName;
        }

        public string GetNeutralExportName()
        {
            return _neutralExportName;
        }

        public string GetLayer()
        {
            return _layer;
        }

        public string GetExportNameTop()
        {
            return _exportNameTop;
        }

        public string GetExportNameObject()
        {
            return _exportNameObject;
        }

        public string GetEffect()
        {
            return _effect;
        }

        public string GetLoopingEffect()
        {
            return _loopingEffect;
        }

        public bool GetAllowEffectInterrupt()
        {
            return _allowEffectInterrupt;
        }

        public bool GetServerControlsFrame()
        {
            return _serverControlsFrame;
        }

        public int GetScale()
        {
            return _scale;
        }

        public int GetTimeMs()
        {
            return _timeMs;
        }

        public int GetRadius()
        {
            return _radius;
        }

        public int GetDamage()
        {
            return _damage;
        }

        public int GetCustomValue()
        {
            return _customValue;
        }

        public string GetType()
        {
            return _type;
        }

        public bool GetIsPersonal()
        {
            return _isPersonal;
        }

        public string GetBulletExplosionBullet()
        {
            return _bulletExplosionBullet;
        }

        public int GetBulletExplosionBulletDistance()
        {
            return _bulletExplosionBulletDistance;
        }

        public string GetBulletExplosionItem()
        {
            return _bulletExplosionItem;
        }

        public bool GetDestroysEnvironment()
        {
            return _destroysEnvironment;
        }

        public int GetPushbackStrength()
        {
            return _pushbackStrength;
        }

        public int GetPushbackStrengthSelf()
        {
            return _pushbackStrengthSelf;
        }

        public int GetPushbackDeadzone()
        {
            return _pushbackDeadzone;
        }

        public bool GetCanStopGrapple()
        {
            return _canStopGrapple;
        }

        public int GetFreezeStrength()
        {
            return _freezeStrength;
        }

        public int GetFreezeTicks()
        {
            return _freezeTicks;
        }

        public bool GetShouldShowEvenIfOutsideScreen()
        {
            return _shouldShowEvenIfOutsideScreen;
        }

        public int GetSameAreaEffectCanNotDamageMs()
        {
            return _sameAreaEffectCanNotDamageMs;
        }

        public bool GetDontShowToEnemy()
        {
            return _dontShowToEnemy;
        }

        public bool GetRequireLineOfSight()
        {
            return _requireLineOfSight;
        }


    }
}