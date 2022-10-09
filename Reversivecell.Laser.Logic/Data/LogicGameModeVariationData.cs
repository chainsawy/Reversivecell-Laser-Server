namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicGameModeVariationData : LogicData
    {
        private int _variation;
        private bool _disabled;
        private string _chatSuggestionItemName;
        private string _gameModeRoomIconName;
        private string _gameModeIconName;
        private string _scoreSfx;
        private string _opponentScoreSfx;
        private string _scoreText;
        private string _scoreTextEnd;
        private int _friendlyMenuOrder;
        private string _introText;
        private string _introDescText;
        private string _introDescText2;
        private string _startNotification;
        private string _endNotification;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicGameModeVariationData" /> class.
        /// </summary>
        public LogicGameModeVariationData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicGameModeVariationData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._variation = GetIntegerValue("Variation", 0);
            this._disabled = GetBooleanValue("Disabled", 0);
            this._chatSuggestionItemName = GetValue("ChatSuggestionItemName", 0);
            this._gameModeRoomIconName = GetValue("GameModeRoomIconName", 0);
            this._gameModeIconName = GetValue("GameModeIconName", 0);
            this._scoreSfx = GetValue("ScoreSfx", 0);
            this._opponentScoreSfx = GetValue("OpponentScoreSfx", 0);
            this._scoreText = GetValue("ScoreText", 0);
            this._scoreTextEnd = GetValue("ScoreTextEnd", 0);
            this._friendlyMenuOrder = GetIntegerValue("FriendlyMenuOrder", 0);
            this._introText = GetValue("IntroText", 0);
            this._introDescText = GetValue("IntroDescText", 0);
            this._introDescText2 = GetValue("IntroDescText2", 0);
            this._startNotification = GetValue("StartNotification", 0);
            this._endNotification = GetValue("EndNotification", 0);

        }
		
        public int GetVariation()
        {
            return _variation;
        }

        public bool GetDisabled()
        {
            return _disabled;
        }

        public string GetChatSuggestionItemName()
        {
            return _chatSuggestionItemName;
        }

        public string GetGameModeRoomIconName()
        {
            return _gameModeRoomIconName;
        }

        public string GetGameModeIconName()
        {
            return _gameModeIconName;
        }

        public string GetScoreSfx()
        {
            return _scoreSfx;
        }

        public string GetOpponentScoreSfx()
        {
            return _opponentScoreSfx;
        }

        public string GetScoreText()
        {
            return _scoreText;
        }

        public string GetScoreTextEnd()
        {
            return _scoreTextEnd;
        }

        public int GetFriendlyMenuOrder()
        {
            return _friendlyMenuOrder;
        }

        public string GetIntroText()
        {
            return _introText;
        }

        public string GetIntroDescText()
        {
            return _introDescText;
        }

        public string GetIntroDescText2()
        {
            return _introDescText2;
        }

        public string GetStartNotification()
        {
            return _startNotification;
        }

        public string GetEndNotification()
        {
            return _endNotification;
        }


    }
}