namespace Reversivecell.Laser.Servers.Battle.Session
{
    using Reversivecell.Laser.Titan.Math;
    using System.Collections.Concurrent;

    internal static class BattleSessionManager
    {
        private static ConcurrentDictionary<long, BattleSession> _sessions;

        public static void Init()
        {
            _sessions = new ConcurrentDictionary<long, BattleSession>();
        }

        public static bool TryGet(LogicLong sessionId, out BattleSession session)
        {
            return _sessions.TryGetValue(sessionId, out session);
        }

        public static BattleSession Create(LogicLong sessionId, LogicLong accountId)
        {
            BattleSession session = new BattleSession(sessionId, accountId);
            _sessions[sessionId] = session;

            return session;
        }

        public static void Remove(LogicLong sessionId)
        {
            _sessions.TryRemove(sessionId, out _);
        }
    }
}
