namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicLocaleData : LogicData
    {
        private string _iconSWF;
        private string _localizedName;
        private int _sortOrder;
        private bool _enabled;
        private string _fileName;
        private bool _testLanguage;
        private string _usedSystemFont;
        private string _preferedFallbackFont;
        private string _forcedFontFullName;
        private string _helpshiftSDKLanguage;
        private string _helpshiftSDKLanguageAndroid;
        private string _testExcludes;
        private bool _loadAllLanguages;
        private string _championshipRegisterUrl;
        private string _championshipRegisterUrl_cn;
        private string _termsAndServiceUrl;
        private string _parentsGuideUrl;
        private string _privacyPolicyUrl;
        private string _laserboxUrl;
        private string _laserboxUrlCN;
        private string _laserboxStagingUrl;
        private string _laserboxStagingUrlCN;
        private string _laserboxCommunityUrl;
        private string _laserboxCommunityUrlCN;
        private string _laserboxCommunityStagingUrl;
        private string _laserboxCommunityStagingUrlCN;
        private string _laserboxLangCode;
        private string _faqUrl_ios;
        private string _faqUrl_ios_cn;
        private string _faqUrl_android;
        private string _faqUrl_android_cn;
        private string _contactUsUrl_ios;
        private string _contactUsUrl_ios_cn;
        private string _contactUsUrl_android;
        private string _contactUsUrl_android_cn;
        private bool _laserboxEnabled;
        private bool _isRTL;
        private bool _isNounAdj;
        private bool _separateThousandsWithSpaces;
        private string _selfHelpUrl;
        private bool _fallbackToHelpshift;
        private bool _fallbackToHelpshiftCN;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicLocaleData" /> class.
        /// </summary>
        public LogicLocaleData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicLocaleData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._iconSWF = GetValue("IconSWF", 0);
            this._localizedName = GetValue("LocalizedName", 0);
            this._sortOrder = GetIntegerValue("SortOrder", 0);
            this._enabled = GetBooleanValue("Enabled", 0);
            this._fileName = GetValue("FileName", 0);
            this._testLanguage = GetBooleanValue("TestLanguage", 0);
            this._usedSystemFont = GetValue("UsedSystemFont", 0);
            this._preferedFallbackFont = GetValue("PreferedFallbackFont", 0);
            this._forcedFontFullName = GetValue("ForcedFontFullName", 0);
            this._helpshiftSDKLanguage = GetValue("HelpshiftSDKLanguage", 0);
            this._helpshiftSDKLanguageAndroid = GetValue("HelpshiftSDKLanguageAndroid", 0);
            this._testExcludes = GetValue("TestExcludes", 0);
            this._loadAllLanguages = GetBooleanValue("LoadAllLanguages", 0);
            this._championshipRegisterUrl = GetValue("ChampionshipRegisterUrl", 0);
            this._championshipRegisterUrl_cn = GetValue("ChampionshipRegisterUrl_cn", 0);
            this._termsAndServiceUrl = GetValue("TermsAndServiceUrl", 0);
            this._parentsGuideUrl = GetValue("ParentsGuideUrl", 0);
            this._privacyPolicyUrl = GetValue("PrivacyPolicyUrl", 0);
            this._laserboxUrl = GetValue("LaserboxUrl", 0);
            this._laserboxUrlCN = GetValue("LaserboxUrlCN", 0);
            this._laserboxStagingUrl = GetValue("LaserboxStagingUrl", 0);
            this._laserboxStagingUrlCN = GetValue("LaserboxStagingUrlCN", 0);
            this._laserboxCommunityUrl = GetValue("LaserboxCommunityUrl", 0);
            this._laserboxCommunityUrlCN = GetValue("LaserboxCommunityUrlCN", 0);
            this._laserboxCommunityStagingUrl = GetValue("LaserboxCommunityStagingUrl", 0);
            this._laserboxCommunityStagingUrlCN = GetValue("LaserboxCommunityStagingUrlCN", 0);
            this._laserboxLangCode = GetValue("LaserboxLangCode", 0);
            this._faqUrl_ios = GetValue("FaqUrl_ios", 0);
            this._faqUrl_ios_cn = GetValue("FaqUrl_ios_cn", 0);
            this._faqUrl_android = GetValue("FaqUrl_android", 0);
            this._faqUrl_android_cn = GetValue("FaqUrl_android_cn", 0);
            this._contactUsUrl_ios = GetValue("ContactUsUrl_ios", 0);
            this._contactUsUrl_ios_cn = GetValue("ContactUsUrl_ios_cn", 0);
            this._contactUsUrl_android = GetValue("ContactUsUrl_android", 0);
            this._contactUsUrl_android_cn = GetValue("ContactUsUrl_android_cn", 0);
            this._laserboxEnabled = GetBooleanValue("LaserboxEnabled", 0);
            this._isRTL = GetBooleanValue("IsRTL", 0);
            this._isNounAdj = GetBooleanValue("IsNounAdj", 0);
            this._separateThousandsWithSpaces = GetBooleanValue("SeparateThousandsWithSpaces", 0);
            this._selfHelpUrl = GetValue("SelfHelpUrl", 0);
            this._fallbackToHelpshift = GetBooleanValue("FallbackToHelpshift", 0);
            this._fallbackToHelpshiftCN = GetBooleanValue("FallbackToHelpshiftCN", 0);

        }
		
        public string GetIconSWF()
        {
            return _iconSWF;
        }

        public string GetLocalizedName()
        {
            return _localizedName;
        }

        public int GetSortOrder()
        {
            return _sortOrder;
        }

        public bool GetEnabled()
        {
            return _enabled;
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public bool GetTestLanguage()
        {
            return _testLanguage;
        }

        public string GetUsedSystemFont()
        {
            return _usedSystemFont;
        }

        public string GetPreferedFallbackFont()
        {
            return _preferedFallbackFont;
        }

        public string GetForcedFontFullName()
        {
            return _forcedFontFullName;
        }

        public string GetHelpshiftSDKLanguage()
        {
            return _helpshiftSDKLanguage;
        }

        public string GetHelpshiftSDKLanguageAndroid()
        {
            return _helpshiftSDKLanguageAndroid;
        }

        public string GetTestExcludes()
        {
            return _testExcludes;
        }

        public bool GetLoadAllLanguages()
        {
            return _loadAllLanguages;
        }

        public string GetChampionshipRegisterUrl()
        {
            return _championshipRegisterUrl;
        }

        public string GetChampionshipRegisterUrl_cn()
        {
            return _championshipRegisterUrl_cn;
        }

        public string GetTermsAndServiceUrl()
        {
            return _termsAndServiceUrl;
        }

        public string GetParentsGuideUrl()
        {
            return _parentsGuideUrl;
        }

        public string GetPrivacyPolicyUrl()
        {
            return _privacyPolicyUrl;
        }

        public string GetLaserboxUrl()
        {
            return _laserboxUrl;
        }

        public string GetLaserboxUrlCN()
        {
            return _laserboxUrlCN;
        }

        public string GetLaserboxStagingUrl()
        {
            return _laserboxStagingUrl;
        }

        public string GetLaserboxStagingUrlCN()
        {
            return _laserboxStagingUrlCN;
        }

        public string GetLaserboxCommunityUrl()
        {
            return _laserboxCommunityUrl;
        }

        public string GetLaserboxCommunityUrlCN()
        {
            return _laserboxCommunityUrlCN;
        }

        public string GetLaserboxCommunityStagingUrl()
        {
            return _laserboxCommunityStagingUrl;
        }

        public string GetLaserboxCommunityStagingUrlCN()
        {
            return _laserboxCommunityStagingUrlCN;
        }

        public string GetLaserboxLangCode()
        {
            return _laserboxLangCode;
        }

        public string GetFaqUrl_ios()
        {
            return _faqUrl_ios;
        }

        public string GetFaqUrl_ios_cn()
        {
            return _faqUrl_ios_cn;
        }

        public string GetFaqUrl_android()
        {
            return _faqUrl_android;
        }

        public string GetFaqUrl_android_cn()
        {
            return _faqUrl_android_cn;
        }

        public string GetContactUsUrl_ios()
        {
            return _contactUsUrl_ios;
        }

        public string GetContactUsUrl_ios_cn()
        {
            return _contactUsUrl_ios_cn;
        }

        public string GetContactUsUrl_android()
        {
            return _contactUsUrl_android;
        }

        public string GetContactUsUrl_android_cn()
        {
            return _contactUsUrl_android_cn;
        }

        public bool GetLaserboxEnabled()
        {
            return _laserboxEnabled;
        }

        public bool GetIsRTL()
        {
            return _isRTL;
        }

        public bool GetIsNounAdj()
        {
            return _isNounAdj;
        }

        public bool GetSeparateThousandsWithSpaces()
        {
            return _separateThousandsWithSpaces;
        }

        public string GetSelfHelpUrl()
        {
            return _selfHelpUrl;
        }

        public bool GetFallbackToHelpshift()
        {
            return _fallbackToHelpshift;
        }

        public bool GetFallbackToHelpshiftCN()
        {
            return _fallbackToHelpshiftCN;
        }


    }
}