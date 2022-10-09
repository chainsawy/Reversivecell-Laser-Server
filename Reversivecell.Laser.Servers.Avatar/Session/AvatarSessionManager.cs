namespace Reversivecell.Laser.Servers.Avatar.Session
{
    using Reversivecell.Laser.Servers.Avatar.Game;
    using Reversivecell.Laser.Titan.Math;
    using System.Collections.Concurrent;

    internal static class AvatarSessionManager
    {
        private static ConcurrentDictionary<long, AvatarSession> _sessions;

        public static void Init()
        {
            _sessions = new ConcurrentDictionary<long, AvatarSession>();
        }

        public static AvatarSession Create(LogicLong sessionId, LogicLong accountId)
        {
            AvatarDocument document = AvatarManager.GetDocument(accountId, true);

            AvatarSession session = new AvatarSession(document.AvatarEntry, sessionId, accountId);
            _sessions[sessionId] = session;

            return session;
        }

        public static bool TryGet(LogicLong sessionId, out AvatarSession session)
        {
            return _sessions.TryGetValue(sessionId, out session);
        }

        public static bool TryRemove(LogicLong sessionId, out AvatarSession session)
        {
            return _sessions.TryRemove(sessionId, out session);
        }
    }
}
