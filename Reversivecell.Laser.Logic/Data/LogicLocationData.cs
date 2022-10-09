namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicLocationData : LogicData
    {
        private bool _disabled;
        private string _bgPrefix;
        private string _locationTheme;
        private string _groundSCW;
        private string _campaignGroundSCW;
        private string _environmentSCW;
        private string _iconSWF;
        private string _gameMode;
        private string _allowedMaps;
        private string _music;
        private string _communityCredit;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicLocationData" /> class.
        /// </summary>
        public LogicLocationData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicLocationData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._disabled = GetBooleanValue("Disabled", 0);
            this._bgPrefix = GetValue("BgPrefix", 0);
            this._locationTheme = GetValue("LocationTheme", 0);
            this._groundSCW = GetValue("GroundSCW", 0);
            this._campaignGroundSCW = GetValue("CampaignGroundSCW", 0);
            this._environmentSCW = GetValue("EnvironmentSCW", 0);
            this._iconSWF = GetValue("IconSWF", 0);
            this._gameMode = GetValue("GameMode", 0);
            this._allowedMaps = GetValue("AllowedMaps", 0);
            this._music = GetValue("Music", 0);
            this._communityCredit = GetValue("CommunityCredit", 0);

        }
		
        public bool GetDisabled()
        {
            return _disabled;
        }

        public string GetBgPrefix()
        {
            return _bgPrefix;
        }

        public string GetLocationTheme()
        {
            return _locationTheme;
        }

        public string GetGroundSCW()
        {
            return _groundSCW;
        }

        public string GetCampaignGroundSCW()
        {
            return _campaignGroundSCW;
        }

        public string GetEnvironmentSCW()
        {
            return _environmentSCW;
        }

        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public string GetGameMode()
        {
            return _gameMode;
        }

        public string GetAllowedMaps()
        {
            return _allowedMaps;
        }

        public string GetMusic()
        {
            return _music;
        }

        public string GetCommunityCredit()
        {
            return _communityCredit;
        }


    }
}