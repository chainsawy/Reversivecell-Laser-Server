namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicSkinCampaignData : LogicData
    {
        private string _bgItemName;
        private bool _skinBuyRequiresExclusiveOption;
        private string _emoteBundleName;
        private string _campaignIconExportName;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicSkinCampaignData" /> class.
        /// </summary>
        public LogicSkinCampaignData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicSkinCampaignData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._bgItemName = GetValue("BgItemName", 0);
            this._skinBuyRequiresExclusiveOption = GetBooleanValue("SkinBuyRequiresExclusiveOption", 0);
            this._emoteBundleName = GetValue("EmoteBundleName", 0);
            this._campaignIconExportName = GetValue("CampaignIconExportName", 0);

        }
		
        public string GetBgItemName()
        {
            return _bgItemName;
        }

        public bool GetSkinBuyRequiresExclusiveOption()
        {
            return _skinBuyRequiresExclusiveOption;
        }

        public string GetEmoteBundleName()
        {
            return _emoteBundleName;
        }

        public string GetCampaignIconExportName()
        {
            return _campaignIconExportName;
        }


    }
}