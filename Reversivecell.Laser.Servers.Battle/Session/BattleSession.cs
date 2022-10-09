namespace Reversivecell.Laser.Servers.Battle.Session
{
    using Reversivecell.Laser.Servers.Core.Network.Session;
    using Reversivecell.Laser.Titan.Math;

    internal class BattleSession : NetSession
    {
        public BattleSession(LogicLong sessionId, LogicLong accountId) : base(sessionId, accountId)
        {
        }
    }
}
