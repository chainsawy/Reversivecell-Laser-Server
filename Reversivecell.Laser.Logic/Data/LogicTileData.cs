namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicTileData : LogicData
    {
        private string _tileCode;
        private int _dynamicCode;
        private bool _blocksMovement;
        private bool _blocksProjectiles;
        private bool _isDestructible;
        private bool _isDestructibleNormalWeapon;
        private bool _hidesHero;
        private int _respawnSeconds;
        private int _collisionMargin;
        private string _baseExportName;
        private string _baseExplosionEffect;
        private string _baseHitEffect;
        private string _baseWindEffect;
        private string _baseBulletHole1;
        private string _baseBulletHole2;
        private string _baseCrack1;
        private string _baseCrack2;
        private int _sortOffset;
        private bool _hasHitAnim;
        private bool _hasWindAnim;
        private int _shadowScaleX;
        private int _shadowScaleY;
        private int _shadowX;
        private int _shadowY;
        private int _shadowSkew;
        private int _lifetime;
        private string _customSCW;
        private string _customMesh;
        private int _customAngleStep;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicTileData" /> class.
        /// </summary>
        public LogicTileData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicTileData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._tileCode = GetValue("TileCode", 0);
            this._dynamicCode = GetIntegerValue("DynamicCode", 0);
            this._blocksMovement = GetBooleanValue("BlocksMovement", 0);
            this._blocksProjectiles = GetBooleanValue("BlocksProjectiles", 0);
            this._isDestructible = GetBooleanValue("IsDestructible", 0);
            this._isDestructibleNormalWeapon = GetBooleanValue("IsDestructibleNormalWeapon", 0);
            this._hidesHero = GetBooleanValue("HidesHero", 0);
            this._respawnSeconds = GetIntegerValue("RespawnSeconds", 0);
            this._collisionMargin = GetIntegerValue("CollisionMargin", 0);
            this._baseExportName = GetValue("BaseExportName", 0);
            this._baseExplosionEffect = GetValue("BaseExplosionEffect", 0);
            this._baseHitEffect = GetValue("BaseHitEffect", 0);
            this._baseWindEffect = GetValue("BaseWindEffect", 0);
            this._baseBulletHole1 = GetValue("BaseBulletHole1", 0);
            this._baseBulletHole2 = GetValue("BaseBulletHole2", 0);
            this._baseCrack1 = GetValue("BaseCrack1", 0);
            this._baseCrack2 = GetValue("BaseCrack2", 0);
            this._sortOffset = GetIntegerValue("SortOffset", 0);
            this._hasHitAnim = GetBooleanValue("HasHitAnim", 0);
            this._hasWindAnim = GetBooleanValue("HasWindAnim", 0);
            this._shadowScaleX = GetIntegerValue("ShadowScaleX", 0);
            this._shadowScaleY = GetIntegerValue("ShadowScaleY", 0);
            this._shadowX = GetIntegerValue("ShadowX", 0);
            this._shadowY = GetIntegerValue("ShadowY", 0);
            this._shadowSkew = GetIntegerValue("ShadowSkew", 0);
            this._lifetime = GetIntegerValue("Lifetime", 0);
            this._customSCW = GetValue("CustomSCW", 0);
            this._customMesh = GetValue("CustomMesh", 0);
            this._customAngleStep = GetIntegerValue("CustomAngleStep", 0);

        }
		
        public string GetTileCode()
        {
            return _tileCode;
        }

        public int GetDynamicCode()
        {
            return _dynamicCode;
        }

        public bool GetBlocksMovement()
        {
            return _blocksMovement;
        }

        public bool GetBlocksProjectiles()
        {
            return _blocksProjectiles;
        }

        public bool GetIsDestructible()
        {
            return _isDestructible;
        }

        public bool GetIsDestructibleNormalWeapon()
        {
            return _isDestructibleNormalWeapon;
        }

        public bool GetHidesHero()
        {
            return _hidesHero;
        }

        public int GetRespawnSeconds()
        {
            return _respawnSeconds;
        }

        public int GetCollisionMargin()
        {
            return _collisionMargin;
        }

        public string GetBaseExportName()
        {
            return _baseExportName;
        }

        public string GetBaseExplosionEffect()
        {
            return _baseExplosionEffect;
        }

        public string GetBaseHitEffect()
        {
            return _baseHitEffect;
        }

        public string GetBaseWindEffect()
        {
            return _baseWindEffect;
        }

        public string GetBaseBulletHole1()
        {
            return _baseBulletHole1;
        }

        public string GetBaseBulletHole2()
        {
            return _baseBulletHole2;
        }

        public string GetBaseCrack1()
        {
            return _baseCrack1;
        }

        public string GetBaseCrack2()
        {
            return _baseCrack2;
        }

        public int GetSortOffset()
        {
            return _sortOffset;
        }

        public bool GetHasHitAnim()
        {
            return _hasHitAnim;
        }

        public bool GetHasWindAnim()
        {
            return _hasWindAnim;
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

        public int GetLifetime()
        {
            return _lifetime;
        }

        public string GetCustomSCW()
        {
            return _customSCW;
        }

        public string GetCustomMesh()
        {
            return _customMesh;
        }

        public int GetCustomAngleStep()
        {
            return _customAngleStep;
        }


    }
}