namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicLocationThemeData : LogicData
    {
        private string _tileSetPrefix;
        private string _maskedEnvironmentSCW;
        private string _blocking1SCW;
        private string _blocking1Mesh;
        private int _blocking1AngleStep;
        private string _blocking2SCW;
        private string _blocking2Mesh;
        private int _blocking2AngleStep;
        private string _blocking3SCW;
        private string _blocking3Mesh;
        private int _blocking3AngleStep;
        private string _blocking4SCW;
        private string _blocking4Mesh;
        private int _blocking4AngleStep;
        private string _respawningWallSCW;
        private string _respawningWallMesh;
        private int _respawningWallAngleStep;
        private string _respawningForestSCW;
        private string _forestSCW;
        private string _destructableSCW;
        private string _destructableMesh;
        private int _destructableAngleStep;
        private string _destructableSCW_CN;
        private string _destructableMesh_CN;
        private int _destructableAngleStep_CN;
        private string _fragileSCW;
        private string _fragileMesh;
        private int _fragileAngleStep;
        private string _fragileSCW_CN;
        private string _fragileMesh_CN;
        private int _fragileAngleStep_CN;
        private string _waterTileSCW;
        private string _fenceSCW;
        private string _indestructibleSCW;
        private string _indestructibleMesh;
        private string _benchSCW;
        private string _laserBallSkinOverride;
        private string _mineGemSpawnSCWOverride;
        private string _lootBoxSkinOverride;
        private string _showdownBoostSCWOverride;
        private int _mapPreviewBGColorRed;
        private int _mapPreviewBGColorGreen;
        private int _mapPreviewBGColorBlue;
        private string _mapPreviewGemGrabSpawnHoleExportName;
        private string _mapPreviewBallExportName;
        private string _mapPreviewGoal1ExportName;
        private string _mapPreviewGoal2ExportName;
        private string _mapPreviewCNOverrides;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicLocationThemeData" /> class.
        /// </summary>
        public LogicLocationThemeData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicLocationThemeData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._tileSetPrefix = GetValue("TileSetPrefix", 0);
            this._maskedEnvironmentSCW = GetValue("MaskedEnvironmentSCW", 0);
            this._blocking1SCW = GetValue("Blocking1SCW", 0);
            this._blocking1Mesh = GetValue("Blocking1Mesh", 0);
            this._blocking1AngleStep = GetIntegerValue("Blocking1AngleStep", 0);
            this._blocking2SCW = GetValue("Blocking2SCW", 0);
            this._blocking2Mesh = GetValue("Blocking2Mesh", 0);
            this._blocking2AngleStep = GetIntegerValue("Blocking2AngleStep", 0);
            this._blocking3SCW = GetValue("Blocking3SCW", 0);
            this._blocking3Mesh = GetValue("Blocking3Mesh", 0);
            this._blocking3AngleStep = GetIntegerValue("Blocking3AngleStep", 0);
            this._blocking4SCW = GetValue("Blocking4SCW", 0);
            this._blocking4Mesh = GetValue("Blocking4Mesh", 0);
            this._blocking4AngleStep = GetIntegerValue("Blocking4AngleStep", 0);
            this._respawningWallSCW = GetValue("RespawningWallSCW", 0);
            this._respawningWallMesh = GetValue("RespawningWallMesh", 0);
            this._respawningWallAngleStep = GetIntegerValue("RespawningWallAngleStep", 0);
            this._respawningForestSCW = GetValue("RespawningForestSCW", 0);
            this._forestSCW = GetValue("ForestSCW", 0);
            this._destructableSCW = GetValue("DestructableSCW", 0);
            this._destructableMesh = GetValue("DestructableMesh", 0);
            this._destructableAngleStep = GetIntegerValue("DestructableAngleStep", 0);
            this._destructableSCW_CN = GetValue("DestructableSCW_CN", 0);
            this._destructableMesh_CN = GetValue("DestructableMesh_CN", 0);
            this._destructableAngleStep_CN = GetIntegerValue("DestructableAngleStep_CN", 0);
            this._fragileSCW = GetValue("FragileSCW", 0);
            this._fragileMesh = GetValue("FragileMesh", 0);
            this._fragileAngleStep = GetIntegerValue("FragileAngleStep", 0);
            this._fragileSCW_CN = GetValue("FragileSCW_CN", 0);
            this._fragileMesh_CN = GetValue("FragileMesh_CN", 0);
            this._fragileAngleStep_CN = GetIntegerValue("FragileAngleStep_CN", 0);
            this._waterTileSCW = GetValue("WaterTileSCW", 0);
            this._fenceSCW = GetValue("FenceSCW", 0);
            this._indestructibleSCW = GetValue("IndestructibleSCW", 0);
            this._indestructibleMesh = GetValue("IndestructibleMesh", 0);
            this._benchSCW = GetValue("BenchSCW", 0);
            this._laserBallSkinOverride = GetValue("LaserBallSkinOverride", 0);
            this._mineGemSpawnSCWOverride = GetValue("MineGemSpawnSCWOverride", 0);
            this._lootBoxSkinOverride = GetValue("LootBoxSkinOverride", 0);
            this._showdownBoostSCWOverride = GetValue("ShowdownBoostSCWOverride", 0);
            this._mapPreviewBGColorRed = GetIntegerValue("MapPreviewBGColorRed", 0);
            this._mapPreviewBGColorGreen = GetIntegerValue("MapPreviewBGColorGreen", 0);
            this._mapPreviewBGColorBlue = GetIntegerValue("MapPreviewBGColorBlue", 0);
            this._mapPreviewGemGrabSpawnHoleExportName = GetValue("MapPreviewGemGrabSpawnHoleExportName", 0);
            this._mapPreviewBallExportName = GetValue("MapPreviewBallExportName", 0);
            this._mapPreviewGoal1ExportName = GetValue("MapPreviewGoal1ExportName", 0);
            this._mapPreviewGoal2ExportName = GetValue("MapPreviewGoal2ExportName", 0);
            this._mapPreviewCNOverrides = GetValue("MapPreviewCNOverrides", 0);

        }
		
        public string GetTileSetPrefix()
        {
            return _tileSetPrefix;
        }

        public string GetMaskedEnvironmentSCW()
        {
            return _maskedEnvironmentSCW;
        }

        public string GetBlocking1SCW()
        {
            return _blocking1SCW;
        }

        public string GetBlocking1Mesh()
        {
            return _blocking1Mesh;
        }

        public int GetBlocking1AngleStep()
        {
            return _blocking1AngleStep;
        }

        public string GetBlocking2SCW()
        {
            return _blocking2SCW;
        }

        public string GetBlocking2Mesh()
        {
            return _blocking2Mesh;
        }

        public int GetBlocking2AngleStep()
        {
            return _blocking2AngleStep;
        }

        public string GetBlocking3SCW()
        {
            return _blocking3SCW;
        }

        public string GetBlocking3Mesh()
        {
            return _blocking3Mesh;
        }

        public int GetBlocking3AngleStep()
        {
            return _blocking3AngleStep;
        }

        public string GetBlocking4SCW()
        {
            return _blocking4SCW;
        }

        public string GetBlocking4Mesh()
        {
            return _blocking4Mesh;
        }

        public int GetBlocking4AngleStep()
        {
            return _blocking4AngleStep;
        }

        public string GetRespawningWallSCW()
        {
            return _respawningWallSCW;
        }

        public string GetRespawningWallMesh()
        {
            return _respawningWallMesh;
        }

        public int GetRespawningWallAngleStep()
        {
            return _respawningWallAngleStep;
        }

        public string GetRespawningForestSCW()
        {
            return _respawningForestSCW;
        }

        public string GetForestSCW()
        {
            return _forestSCW;
        }

        public string GetDestructableSCW()
        {
            return _destructableSCW;
        }

        public string GetDestructableMesh()
        {
            return _destructableMesh;
        }

        public int GetDestructableAngleStep()
        {
            return _destructableAngleStep;
        }

        public string GetDestructableSCW_CN()
        {
            return _destructableSCW_CN;
        }

        public string GetDestructableMesh_CN()
        {
            return _destructableMesh_CN;
        }

        public int GetDestructableAngleStep_CN()
        {
            return _destructableAngleStep_CN;
        }

        public string GetFragileSCW()
        {
            return _fragileSCW;
        }

        public string GetFragileMesh()
        {
            return _fragileMesh;
        }

        public int GetFragileAngleStep()
        {
            return _fragileAngleStep;
        }

        public string GetFragileSCW_CN()
        {
            return _fragileSCW_CN;
        }

        public string GetFragileMesh_CN()
        {
            return _fragileMesh_CN;
        }

        public int GetFragileAngleStep_CN()
        {
            return _fragileAngleStep_CN;
        }

        public string GetWaterTileSCW()
        {
            return _waterTileSCW;
        }

        public string GetFenceSCW()
        {
            return _fenceSCW;
        }

        public string GetIndestructibleSCW()
        {
            return _indestructibleSCW;
        }

        public string GetIndestructibleMesh()
        {
            return _indestructibleMesh;
        }

        public string GetBenchSCW()
        {
            return _benchSCW;
        }

        public string GetLaserBallSkinOverride()
        {
            return _laserBallSkinOverride;
        }

        public string GetMineGemSpawnSCWOverride()
        {
            return _mineGemSpawnSCWOverride;
        }

        public string GetLootBoxSkinOverride()
        {
            return _lootBoxSkinOverride;
        }

        public string GetShowdownBoostSCWOverride()
        {
            return _showdownBoostSCWOverride;
        }

        public int GetMapPreviewBGColorRed()
        {
            return _mapPreviewBGColorRed;
        }

        public int GetMapPreviewBGColorGreen()
        {
            return _mapPreviewBGColorGreen;
        }

        public int GetMapPreviewBGColorBlue()
        {
            return _mapPreviewBGColorBlue;
        }

        public string GetMapPreviewGemGrabSpawnHoleExportName()
        {
            return _mapPreviewGemGrabSpawnHoleExportName;
        }

        public string GetMapPreviewBallExportName()
        {
            return _mapPreviewBallExportName;
        }

        public string GetMapPreviewGoal1ExportName()
        {
            return _mapPreviewGoal1ExportName;
        }

        public string GetMapPreviewGoal2ExportName()
        {
            return _mapPreviewGoal2ExportName;
        }

        public string GetMapPreviewCNOverrides()
        {
            return _mapPreviewCNOverrides;
        }


    }
}