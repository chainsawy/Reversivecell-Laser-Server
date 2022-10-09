namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicMapBlockData : LogicData
    {
        private string _group;
        private string _data;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicMapBlockData" /> class.
        /// </summary>
        public LogicMapBlockData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicMapBlockData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._group = GetValue("Group", 0);
            this._data = GetValue("Data", 0);

        }
		
        public string GetGroup()
        {
            return _group;
        }

        public string GetData()
        {
            return _data;
        }


    }
}