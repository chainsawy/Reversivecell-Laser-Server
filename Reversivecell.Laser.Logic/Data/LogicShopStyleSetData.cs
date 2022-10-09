namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicShopStyleSetData : LogicData
    {
        private bool _disabled;
        private bool _starterPackLike;
        private string _variant;
        private string _panelAssetOverride;
        private string _offerCardAssetOverride;
        private string _popupAssetOverride;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicShopStyleSetData" /> class.
        /// </summary>
        public LogicShopStyleSetData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicShopStyleSetData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._disabled = GetBooleanValue("Disabled", 0);
            this._starterPackLike = GetBooleanValue("StarterPackLike", 0);
            this._variant = GetValue("Variant", 0);
            this._panelAssetOverride = GetValue("PanelAssetOverride", 0);
            this._offerCardAssetOverride = GetValue("OfferCardAssetOverride", 0);
            this._popupAssetOverride = GetValue("PopupAssetOverride", 0);

        }
		
        public bool GetDisabled()
        {
            return _disabled;
        }

        public bool GetStarterPackLike()
        {
            return _starterPackLike;
        }

        public string GetVariant()
        {
            return _variant;
        }

        public string GetPanelAssetOverride()
        {
            return _panelAssetOverride;
        }

        public string GetOfferCardAssetOverride()
        {
            return _offerCardAssetOverride;
        }

        public string GetPopupAssetOverride()
        {
            return _popupAssetOverride;
        }


    }
}