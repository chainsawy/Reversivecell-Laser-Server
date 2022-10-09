namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicSeasonalSkinSectionData : LogicData
    {
        private int _mode;
        private string _includedCampaigns;
        private string _sectionTitleTID;
        private string _sectionItemTID;
        private string _sectionInfoTID;
        private bool _lastChanceSectionSeparately;
        private string _lastChanceSectionTID;
        private bool _groupCampaign;
        private string _groupShopItem;
        private string _shopItemCharacters;
        private bool _checkDataFromOffers;
        private string _purchasePopupBg;
        private string _emotesBundle;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicSeasonalSkinSectionData" /> class.
        /// </summary>
        public LogicSeasonalSkinSectionData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicSeasonalSkinSectionData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._mode = GetIntegerValue("Mode", 0);
            this._includedCampaigns = GetValue("IncludedCampaigns", 0);
            this._sectionTitleTID = GetValue("SectionTitleTID", 0);
            this._sectionItemTID = GetValue("SectionItemTID", 0);
            this._sectionInfoTID = GetValue("SectionInfoTID", 0);
            this._lastChanceSectionSeparately = GetBooleanValue("LastChanceSectionSeparately", 0);
            this._lastChanceSectionTID = GetValue("LastChanceSectionTID", 0);
            this._groupCampaign = GetBooleanValue("GroupCampaign", 0);
            this._groupShopItem = GetValue("GroupShopItem", 0);
            this._shopItemCharacters = GetValue("ShopItemCharacters", 0);
            this._checkDataFromOffers = GetBooleanValue("CheckDataFromOffers", 0);
            this._purchasePopupBg = GetValue("PurchasePopupBg", 0);
            this._emotesBundle = GetValue("EmotesBundle", 0);

        }
		
        public int GetMode()
        {
            return _mode;
        }

        public string GetIncludedCampaigns()
        {
            return _includedCampaigns;
        }

        public string GetSectionTitleTID()
        {
            return _sectionTitleTID;
        }

        public string GetSectionItemTID()
        {
            return _sectionItemTID;
        }

        public string GetSectionInfoTID()
        {
            return _sectionInfoTID;
        }

        public bool GetLastChanceSectionSeparately()
        {
            return _lastChanceSectionSeparately;
        }

        public string GetLastChanceSectionTID()
        {
            return _lastChanceSectionTID;
        }

        public bool GetGroupCampaign()
        {
            return _groupCampaign;
        }

        public string GetGroupShopItem()
        {
            return _groupShopItem;
        }

        public string GetShopItemCharacters()
        {
            return _shopItemCharacters;
        }

        public bool GetCheckDataFromOffers()
        {
            return _checkDataFromOffers;
        }

        public string GetPurchasePopupBg()
        {
            return _purchasePopupBg;
        }

        public string GetEmotesBundle()
        {
            return _emotesBundle;
        }


    }
}