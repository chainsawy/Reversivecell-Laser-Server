namespace Reversivecell.Laser.Servers.Home.Network.Message
{
    using Reversivecell.Laser.Servers.Home.Session;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Home;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Session;
    using Reversivecell.Laser.Titan.Message;

    internal class HomeMessageManager : NetMessageManager
    {
        public override void ReceiveMessage(NetMessage message)
        {
            switch (message.GetMessageType())
            {
                case 10000:
                    this.StartSessionReceived((StartSessionMessage)message);
                    break;
                case 10001:
                    this.StopSessionReceived((StopSessionMessage)message);
                    break;

                case 10400:
                    this.ForwardPiranhaMessageReceived((ForwardPiranhaMessage)message);
                    break;

                case 14200:
                    this.ExecuteServerCommandReceived((ExecuteServerCommandMessage)message);
                    break;
            }
        }

        private void ExecuteServerCommandReceived(ExecuteServerCommandMessage message)
        {
            if (HomeSessionManager.TryGet(message.SessionId, out HomeSession session))
            {
                session.HomeMode.GetCommandManager().AddServerCommand(message.Command);
            }
        }

        private void ForwardPiranhaMessageReceived(ForwardPiranhaMessage message)
        {
            if (HomeSessionManager.TryGet(message.SessionId, out HomeSession session))
            {
                PiranhaMessage piranhaMessage = message.RemovePiranhaMessage();
                piranhaMessage.Decode();
                session.MessageManager.ReceiveMessage(piranhaMessage);
            }
        }

        private void StartSessionReceived(StartSessionMessage message)
        {
            HomeSessionManager.Create(message.SessionId, message.AccountId);
        }

        private void StopSessionReceived(StopSessionMessage message)
        {
            HomeSessionManager.TryRemove(message.SessionId);
        }
    }
}
