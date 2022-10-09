namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicAllianceRoleData : LogicData
    {
        private int _level;
        private bool _canInvite;
        private bool _canSendMail;
        private bool _canChangeAllianceSettings;
        private bool _canAcceptJoinRequest;
        private bool _canKick;
        private bool _canBePromotedToLeader;
        private int _promoteSkill;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicAllianceRoleData" /> class.
        /// </summary>
        public LogicAllianceRoleData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicAllianceRoleData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._level = GetIntegerValue("Level", 0);
            this._canInvite = GetBooleanValue("CanInvite", 0);
            this._canSendMail = GetBooleanValue("CanSendMail", 0);
            this._canChangeAllianceSettings = GetBooleanValue("CanChangeAllianceSettings", 0);
            this._canAcceptJoinRequest = GetBooleanValue("CanAcceptJoinRequest", 0);
            this._canKick = GetBooleanValue("CanKick", 0);
            this._canBePromotedToLeader = GetBooleanValue("CanBePromotedToLeader", 0);
            this._promoteSkill = GetIntegerValue("PromoteSkill", 0);

        }
		
        public int GetLevel()
        {
            return _level;
        }

        public bool GetCanInvite()
        {
            return _canInvite;
        }

        public bool GetCanSendMail()
        {
            return _canSendMail;
        }

        public bool GetCanChangeAllianceSettings()
        {
            return _canChangeAllianceSettings;
        }

        public bool GetCanAcceptJoinRequest()
        {
            return _canAcceptJoinRequest;
        }

        public bool GetCanKick()
        {
            return _canKick;
        }

        public bool GetCanBePromotedToLeader()
        {
            return _canBePromotedToLeader;
        }

        public int GetPromoteSkill()
        {
            return _promoteSkill;
        }


    }
}