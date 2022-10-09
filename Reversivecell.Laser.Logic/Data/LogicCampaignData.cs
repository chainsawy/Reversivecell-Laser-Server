namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicCampaignData : LogicData
    {
        private string _location;
        private string _allowedHeroes;
        private string _reward;
        private int _levelGenerationSeed;
        private string _map;
        private string _enemies;
        private int _enemyLevel;
        private string _boss;
        private int _bossLevel;
        private string _base;
        private int _numBases;
        private int _baseLevel;
        private string _tower;
        private int _numTowers;
        private int _towerLevel;
        private int _requiredStars;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicCampaignData" /> class.
        /// </summary>
        public LogicCampaignData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicCampaignData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._location = GetValue("Location", 0);
            this._allowedHeroes = GetValue("AllowedHeroes", 0);
            this._reward = GetValue("Reward", 0);
            this._levelGenerationSeed = GetIntegerValue("LevelGenerationSeed", 0);
            this._map = GetValue("Map", 0);
            this._enemies = GetValue("Enemies", 0);
            this._enemyLevel = GetIntegerValue("EnemyLevel", 0);
            this._boss = GetValue("Boss", 0);
            this._bossLevel = GetIntegerValue("BossLevel", 0);
            this._base = GetValue("Base", 0);
            this._numBases = GetIntegerValue("NumBases", 0);
            this._baseLevel = GetIntegerValue("BaseLevel", 0);
            this._tower = GetValue("Tower", 0);
            this._numTowers = GetIntegerValue("NumTowers", 0);
            this._towerLevel = GetIntegerValue("TowerLevel", 0);
            this._requiredStars = GetIntegerValue("RequiredStars", 0);

        }
		
        public string GetLocation()
        {
            return _location;
        }

        public string GetAllowedHeroes()
        {
            return _allowedHeroes;
        }

        public string GetReward()
        {
            return _reward;
        }

        public int GetLevelGenerationSeed()
        {
            return _levelGenerationSeed;
        }

        public string GetMap()
        {
            return _map;
        }

        public string GetEnemies()
        {
            return _enemies;
        }

        public int GetEnemyLevel()
        {
            return _enemyLevel;
        }

        public string GetBoss()
        {
            return _boss;
        }

        public int GetBossLevel()
        {
            return _bossLevel;
        }

        public string GetBase()
        {
            return _base;
        }

        public int GetNumBases()
        {
            return _numBases;
        }

        public int GetBaseLevel()
        {
            return _baseLevel;
        }

        public string GetTower()
        {
            return _tower;
        }

        public int GetNumTowers()
        {
            return _numTowers;
        }

        public int GetTowerLevel()
        {
            return _towerLevel;
        }

        public int GetRequiredStars()
        {
            return _requiredStars;
        }


    }
}