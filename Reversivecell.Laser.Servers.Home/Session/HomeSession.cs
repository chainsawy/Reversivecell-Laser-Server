namespace Reversivecell.Laser.Servers.Home.Session
{
    using Reversivecell.Laser.Servers.Home.Game;
    using Reversivecell.Laser.Servers.Home.Logic.Message;
    using Reversivecell.Laser.Servers.Home.Logic.Mode;
    using Reversivecell.Laser.Servers.Core.Network.Session;
    using Reversivecell.Laser.Titan.Math;

    internal class HomeSession : NetSession
    {
        public HomeMode HomeMode { get; private set; }
        public LogicMessageManager MessageManager { get; }

        public HomeSession(LogicLong sessionId, LogicLong accountId) : base(sessionId, accountId)
        {
            MessageManager = new LogicMessageManager(this);
        }

        public void SessionStarted(HomeDocument document)
        {
            HomeMode = HomeMode.LoadHomeState(this, document.ClientHome, document.ClientAvatar);
        }

        public void ReloadHome()
        {
            HomeMode = HomeMode.ReloadHomeState(HomeMode);
        }
    }
}
