namespace Reversivecell.Laser.Logic.Home
{
    using Reversivecell.Laser.Logic.Avatar;

    public class LogicHomeMode
    {
        private int _currentTimestamp;

        public LogicClientHome ClientHome { get; }
        public LogicClientAvatar ClientAvatar { get; }

        public LogicHomeMode(LogicClientHome clientHome, LogicClientAvatar clientAvatar, int currentTimestamp)
        {
            ClientHome = clientHome;
            ClientAvatar = clientAvatar;
            _currentTimestamp = currentTimestamp;
        }

        public int CalculateChecksum()
        {
            return ClientAvatar.GetChecksum();
        }

        public int GetCurrentTimestamp()
        {
            return _currentTimestamp;
        }
    }
}
