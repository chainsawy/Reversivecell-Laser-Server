namespace Reversivecell.Laser.Servers.Home.Session
{
    using Reversivecell.Laser.Servers.Home.Game;
    using Reversivecell.Laser.Titan.Math;
    using System.Collections.Concurrent;

    internal static class HomeSessionManager
    {
        private static ConcurrentDictionary<long, HomeSession> _sessions;

        public static void Init()
        {
            _sessions = new ConcurrentDictionary<long, HomeSession>();
        }

        public static HomeSession Create(LogicLong sessionId, LogicLong accountId)
        {
            HomeDocument document = HomeManager.GetDocument(accountId, true);

            HomeSession session = new HomeSession(sessionId, accountId);
            _sessions[sessionId] = session;
            session.SessionStarted(document);

            return session;
        }

        public static bool TryGet(LogicLong sessionId, out HomeSession session)
        {
            return _sessions.TryGetValue(sessionId, out session);
        }

        public static bool TryRemove(LogicLong sessionId)
        {
            return _sessions.TryRemove(sessionId, out _);
        }
    }
}
