namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicSkinData : LogicData
    {
        private string _conf;
        private int _campaign;
        private int _obtainType;
        private int _obtainTypeCN;
        private string _petSkin;
        private string _petSkin2;
        private int _costLegendaryTrophies;
        private int _costGems;
        private string _shopTID;
        private string _features;
        private string _communityCredit;
        private string _materialsFile;
        private string _blueTexture;
        private string _redTexture;
        private string _blueSpecular;
        private string _redSpecular;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicSkinData" /> class.
        /// </summary>
        public LogicSkinData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicSkinData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._conf = GetValue("Conf", 0);
            this._campaign = GetIntegerValue("Campaign", 0);
            this._obtainType = GetIntegerValue("ObtainType", 0);
            this._obtainTypeCN = GetIntegerValue("ObtainTypeCN", 0);
            this._petSkin = GetValue("PetSkin", 0);
            this._petSkin2 = GetValue("PetSkin2", 0);
            this._costLegendaryTrophies = GetIntegerValue("CostLegendaryTrophies", 0);
            this._costGems = GetIntegerValue("CostGems", 0);
            this._shopTID = GetValue("ShopTID", 0);
            this._features = GetValue("Features", 0);
            this._communityCredit = GetValue("CommunityCredit", 0);
            this._materialsFile = GetValue("MaterialsFile", 0);
            this._blueTexture = GetValue("BlueTexture", 0);
            this._redTexture = GetValue("RedTexture", 0);
            this._blueSpecular = GetValue("BlueSpecular", 0);
            this._redSpecular = GetValue("RedSpecular", 0);

        }
		
        public string GetConf()
        {
            return _conf;
        }

        public int GetCampaign()
        {
            return _campaign;
        }

        public int GetObtainType()
        {
            return _obtainType;
        }

        public int GetObtainTypeCN()
        {
            return _obtainTypeCN;
        }

        public string GetPetSkin()
        {
            return _petSkin;
        }

        public string GetPetSkin2()
        {
            return _petSkin2;
        }

        public int GetCostLegendaryTrophies()
        {
            return _costLegendaryTrophies;
        }

        public int GetCostGems()
        {
            return _costGems;
        }

        public string GetShopTID()
        {
            return _shopTID;
        }

        public string GetFeatures()
        {
            return _features;
        }

        public string GetCommunityCredit()
        {
            return _communityCredit;
        }

        public string GetMaterialsFile()
        {
            return _materialsFile;
        }

        public string GetBlueTexture()
        {
            return _blueTexture;
        }

        public string GetRedTexture()
        {
            return _redTexture;
        }

        public string GetBlueSpecular()
        {
            return _blueSpecular;
        }

        public string GetRedSpecular()
        {
            return _redSpecular;
        }


    }
}