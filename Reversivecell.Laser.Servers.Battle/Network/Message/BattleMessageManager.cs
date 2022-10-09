namespace Reversivecell.Laser.Servers.Battle.Network.Message
{
    using Reversivecell.Laser.Servers.Battle.Session;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Battle;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Session;

    public class BattleMessageManager : NetMessageManager
    {
        public override void ReceiveMessage(NetMessage message)
        {
            switch (message.GetMessageType())
            {
                case 10000:
                    this.StartSessionReceived((StartSessionMessage)message);
                    return;
                case 10001:
                    this.StopSessionReceived((StopSessionMessage)message);
                    return;
                case 14800:
                    this.BattleRequestReceived((BattleRequestMessage)message);
                    return;
            }
        }

        private void BattleRequestReceived(BattleRequestMessage message)
        {
            
        }

        private void StopSessionReceived(StopSessionMessage message)
        {
            BattleSessionManager.Remove(message.SessionId);
        }

        private void StartSessionReceived(StartSessionMessage message)
        {
            BattleSessionManager.Create(message.SessionId, message.AccountId);
        }
    }
}
