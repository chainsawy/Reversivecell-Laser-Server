namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;

    public class LogicCarryableData : LogicData
    {
        private bool _throwOverWalls;
        private bool _throwFromGroundLevel;
        private int _maxZ;
        private string _throwSkill;
        private string _throwSkillUlti;
        private bool _shouldRoll;
        private bool _bouncing;
        private int _minScale;
        private int _maxScale;
        private bool _showTeamCircle;
        private bool _allowOwnTeamPickup;
        private bool _preventPickupInTargetBase;
        private bool _preventPickupFromLastTouchingTeam;
        private bool _throwOnTouch;
        private int _minHeightForGrab;


        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicCarryableData" /> class.
        /// </summary>
        public LogicCarryableData(CSVRow row, LogicDataTable table) : base(row, table)
        {
            // LogicCarryableData.
        }

        /// <summary>
        ///     Called when all instances has been loaded for initialized members in instance.
        /// </summary>
        public override void CreateReferences()
        {
            this._throwOverWalls = GetBooleanValue("ThrowOverWalls", 0);
            this._throwFromGroundLevel = GetBooleanValue("ThrowFromGroundLevel", 0);
            this._maxZ = GetIntegerValue("MaxZ", 0);
            this._throwSkill = GetValue("ThrowSkill", 0);
            this._throwSkillUlti = GetValue("ThrowSkillUlti", 0);
            this._shouldRoll = GetBooleanValue("ShouldRoll", 0);
            this._bouncing = GetBooleanValue("Bouncing", 0);
            this._minScale = GetIntegerValue("MinScale", 0);
            this._maxScale = GetIntegerValue("MaxScale", 0);
            this._showTeamCircle = GetBooleanValue("ShowTeamCircle", 0);
            this._allowOwnTeamPickup = GetBooleanValue("AllowOwnTeamPickup", 0);
            this._preventPickupInTargetBase = GetBooleanValue("PreventPickupInTargetBase", 0);
            this._preventPickupFromLastTouchingTeam = GetBooleanValue("PreventPickupFromLastTouchingTeam", 0);
            this._throwOnTouch = GetBooleanValue("ThrowOnTouch", 0);
            this._minHeightForGrab = GetIntegerValue("MinHeightForGrab", 0);

        }
		
        public bool GetThrowOverWalls()
        {
            return _throwOverWalls;
        }

        public bool GetThrowFromGroundLevel()
        {
            return _throwFromGroundLevel;
        }

        public int GetMaxZ()
        {
            return _maxZ;
        }

        public string GetThrowSkill()
        {
            return _throwSkill;
        }

        public string GetThrowSkillUlti()
        {
            return _throwSkillUlti;
        }

        public bool GetShouldRoll()
        {
            return _shouldRoll;
        }

        public bool GetBouncing()
        {
            return _bouncing;
        }

        public int GetMinScale()
        {
            return _minScale;
        }

        public int GetMaxScale()
        {
            return _maxScale;
        }

        public bool GetShowTeamCircle()
        {
            return _showTeamCircle;
        }

        public bool GetAllowOwnTeamPickup()
        {
            return _allowOwnTeamPickup;
        }

        public bool GetPreventPickupInTargetBase()
        {
            return _preventPickupInTargetBase;
        }

        public bool GetPreventPickupFromLastTouchingTeam()
        {
            return _preventPickupFromLastTouchingTeam;
        }

        public bool GetThrowOnTouch()
        {
            return _throwOnTouch;
        }

        public int GetMinHeightForGrab()
        {
            return _minHeightForGrab;
        }


    }
}