namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicMessageData : LogicData
    {
        private string _bubbleOverrideTID;
        private bool _disabled;
        private int _messageType;
        private string _fileName;
        private string _exportName;
        private int _quickEmojiType;
        private int _sortPriority;
        private bool _ageGated;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicMessageData" /> class.
        /// </summary>
        public LogicMessageData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicMessageData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._bubbleOverrideTID = GetValue("BubbleOverrideTID", 0);
            this._disabled = GetBooleanValue("Disabled", 0);
            this._messageType = GetIntegerValue("MessageType", 0);
            this._fileName = GetValue("FileName", 0);
            this._exportName = GetValue("ExportName", 0);
            this._quickEmojiType = GetIntegerValue("QuickEmojiType", 0);
            this._sortPriority = GetIntegerValue("SortPriority", 0);
            this._ageGated = GetBooleanValue("AgeGated", 0);

        }
		
        public string GetBubbleOverrideTID()
        {
            return _bubbleOverrideTID;
        }

        public bool GetDisabled()
        {
            return _disabled;
        }

        public int GetMessageType()
        {
            return _messageType;
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public string GetExportName()
        {
            return _exportName;
        }

        public int GetQuickEmojiType()
        {
            return _quickEmojiType;
        }

        public int GetSortPriority()
        {
            return _sortPriority;
        }

        public bool GetAgeGated()
        {
            return _ageGated;
        }


    }
}