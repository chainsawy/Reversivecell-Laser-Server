namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicBossData : LogicData
    {
        private int _playerCount;
        private int _requiredCampaignProgressToUnlock;
        private string _location;
        private string _allowedHeroes;
        private string _reward;
        private int _levelGenerationSeed;
        private string _map;
        private string _boss;
        private int _bossLevel;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicBossData" /> class.
        /// </summary>
        public LogicBossData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicBossData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._playerCount = GetIntegerValue("PlayerCount", 0);
            this._requiredCampaignProgressToUnlock = GetIntegerValue("RequiredCampaignProgressToUnlock", 0);
            this._location = GetValue("Location", 0);
            this._allowedHeroes = GetValue("AllowedHeroes", 0);
            this._reward = GetValue("Reward", 0);
            this._levelGenerationSeed = GetIntegerValue("LevelGenerationSeed", 0);
            this._map = GetValue("Map", 0);
            this._boss = GetValue("Boss", 0);
            this._bossLevel = GetIntegerValue("BossLevel", 0);

        }
		
        public int GetPlayerCount()
        {
            return _playerCount;
        }

        public int GetRequiredCampaignProgressToUnlock()
        {
            return _requiredCampaignProgressToUnlock;
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

        public string GetBoss()
        {
            return _boss;
        }

        public int GetBossLevel()
        {
            return _bossLevel;
        }


    }
}