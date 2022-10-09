namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicThemeData : LogicData
    {
        private string _fileName;
        private string _exportName;
        private string _particleFileName;
        private string _particleExportName;
        private string _particleStyle;
        private int _particleVariations;
        private string _themeMusic;
        private bool _useInLevelSelection;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicThemeData" /> class.
        /// </summary>
        public LogicThemeData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicThemeData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._fileName = GetValue("FileName", 0);
            this._exportName = GetValue("ExportName", 0);
            this._particleFileName = GetValue("ParticleFileName", 0);
            this._particleExportName = GetValue("ParticleExportName", 0);
            this._particleStyle = GetValue("ParticleStyle", 0);
            this._particleVariations = GetIntegerValue("ParticleVariations", 0);
            this._themeMusic = GetValue("ThemeMusic", 0);
            this._useInLevelSelection = GetBooleanValue("UseInLevelSelection", 0);

        }
		
        public string GetFileName()
        {
            return _fileName;
        }

        public string GetExportName()
        {
            return _exportName;
        }

        public string GetParticleFileName()
        {
            return _particleFileName;
        }

        public string GetParticleExportName()
        {
            return _particleExportName;
        }

        public string GetParticleStyle()
        {
            return _particleStyle;
        }

        public int GetParticleVariations()
        {
            return _particleVariations;
        }

        public string GetThemeMusic()
        {
            return _themeMusic;
        }

        public bool GetUseInLevelSelection()
        {
            return _useInLevelSelection;
        }


    }
}