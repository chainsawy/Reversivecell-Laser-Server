namespace Reversivecell.Laser.Servers.Proxy.Session
{
    using Reversivecell.Laser.Servers.Proxy.Network;
    using Reversivecell.Laser.Titan.Math;
    using System;
    using System.Collections.Concurrent;

    internal static class ProxySessionManager
    {
        private static long _sessionCounter;
        private static ConcurrentDictionary<long, ProxySession> _sessions;

        public static void Init()
        {
            _sessions = new ConcurrentDictionary<long, ProxySession>();
            _sessionCounter = 0;
        }

        public static ProxySession Create(NetworkClient client)
        {
            long sessionId = ++ProxySessionManager._sessionCounter;
            ProxySession session = new ProxySession(client, sessionId, -1);
            _sessions[sessionId] = session;
            return session;
        }

        public static bool TryGet(LogicLong sessionId, out ProxySession session)
        {
            return _sessions.TryGetValue(sessionId, out session);
        }

        public static bool TryRemove(LogicLong sessionId, out ProxySession session)
        {
            return _sessions.Remove(sessionId, out session);
        }
    }
}
