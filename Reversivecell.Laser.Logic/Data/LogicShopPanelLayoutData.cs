namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicShopPanelLayoutData : LogicData
    {
        private bool _disabled;
        private string _assetFileName;
        private string _panelAsset;
        private string _asset;
        private string _items;
        private string _itemPlaceholderNames;
        private string _itemContextNames;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicShopPanelLayoutData" /> class.
        /// </summary>
        public LogicShopPanelLayoutData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicShopPanelLayoutData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._disabled = GetBooleanValue("Disabled", 0);
            this._assetFileName = GetValue("AssetFileName", 0);
            this._panelAsset = GetValue("PanelAsset", 0);
            this._asset = GetValue("Asset", 0);
            this._items = GetValue("Items", 0);
            this._itemPlaceholderNames = GetValue("ItemPlaceholderNames", 0);
            this._itemContextNames = GetValue("ItemContextNames", 0);

        }
		
        public bool GetDisabled()
        {
            return _disabled;
        }

        public string GetAssetFileName()
        {
            return _assetFileName;
        }

        public string GetPanelAsset()
        {
            return _panelAsset;
        }

        public string GetAsset()
        {
            return _asset;
        }

        public string GetItems()
        {
            return _items;
        }

        public string GetItemPlaceholderNames()
        {
            return _itemPlaceholderNames;
        }

        public string GetItemContextNames()
        {
            return _itemContextNames;
        }


    }
}