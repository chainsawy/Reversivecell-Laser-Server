namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicAllianceLeagueModeData : LogicData
    {
        private int _eventSlot;
        private string _modeOverrideIconName;
        private string _modeOverrideRoomIconName;
        private string _bannerOverrideSWF;
        private string _bannerOverrideExportName;
        private string _eventTeaseBgColorOverride;
        private int _previewTickets;
        private int _previewMaxWin;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicAllianceLeagueModeData" /> class.
        /// </summary>
        public LogicAllianceLeagueModeData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicAllianceLeagueModeData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._eventSlot = GetIntegerValue("EventSlot", 0);
            this._modeOverrideIconName = GetValue("ModeOverrideIconName", 0);
            this._modeOverrideRoomIconName = GetValue("ModeOverrideRoomIconName", 0);
            this._bannerOverrideSWF = GetValue("BannerOverrideSWF", 0);
            this._bannerOverrideExportName = GetValue("BannerOverrideExportName", 0);
            this._eventTeaseBgColorOverride = GetValue("EventTeaseBgColorOverride", 0);
            this._previewTickets = GetIntegerValue("PreviewTickets", 0);
            this._previewMaxWin = GetIntegerValue("PreviewMaxWin", 0);

        }
		
        public int GetEventSlot()
        {
            return _eventSlot;
        }

        public string GetModeOverrideIconName()
        {
            return _modeOverrideIconName;
        }

        public string GetModeOverrideRoomIconName()
        {
            return _modeOverrideRoomIconName;
        }

        public string GetBannerOverrideSWF()
        {
            return _bannerOverrideSWF;
        }

        public string GetBannerOverrideExportName()
        {
            return _bannerOverrideExportName;
        }

        public string GetEventTeaseBgColorOverride()
        {
            return _eventTeaseBgColorOverride;
        }

        public int GetPreviewTickets()
        {
            return _previewTickets;
        }

        public int GetPreviewMaxWin()
        {
            return _previewMaxWin;
        }


    }
}