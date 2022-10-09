namespace Reversivecell.Laser.Logic.Message.Home
{
    using Reversivecell.Laser.Logic.Avatar;
    using Reversivecell.Laser.Logic.Home;
    using Reversivecell.Laser.Titan.Message;

    public class OwnHomeDataMessage : PiranhaMessage
    {
        private LogicClientHome _logicClientHome;
        private LogicClientAvatar _logicClientAvatar;
        private int _currentTimeInSecondsSinceEpoch;

        public override void Encode()
        {
            base.Encode();

            _logicClientHome.Encode(Stream);
            _logicClientAvatar.Encode(Stream);
            Stream.WriteVInt(_currentTimeInSecondsSinceEpoch);
        }

        public void SetLogicClientHome(LogicClientHome home)
        {
            _logicClientHome = home;
        }

        public void SetLogicClientAvatar(LogicClientAvatar avatar)
        {
            _logicClientAvatar = avatar;
        }

        public LogicClientHome RemoveLogicClientHome()
        {
            LogicClientHome result = _logicClientHome;
            _logicClientHome = null;
            return result;
        }

        public LogicClientAvatar RemoveLogicClientAvatar()
        {
            LogicClientAvatar result = _logicClientAvatar;
            _logicClientAvatar = null;
            return result;
        }

        public int GetCurrentTimeInSecondsSinceEpoch()
        {
            return _currentTimeInSecondsSinceEpoch;
        }

        public void SetCurrentTimeInSecondsSinceEpoch(int currentTimeInSecondsSinceEpoch)
        {
            _currentTimeInSecondsSinceEpoch = currentTimeInSecondsSinceEpoch;
        }

        public override int GetMessageType()
        {
            return 24101;
        }

        public override int GetServiceNodeType()
        {
            return 10;
        }
    }
}
