namespace Reversivecell.Laser.Servers.Avatar.Network.Message
{
    using Reversivecell.Laser.Logic.Message.Avatar;
    using Reversivecell.Laser.Servers.Avatar.Game;
    using Reversivecell.Laser.Servers.Avatar.Session;
    using Reversivecell.Laser.Servers.Core.Network.Utils;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Avatar;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Session;
    using Reversivecell.Laser.Titan.Message;

    internal class AvatarMessageManager : NetMessageManager
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

                case 14100:
                    this.AskForAvatarEntryReceived((AskForAvatarEntryMessage)message);
                    break;

                case 20003:
                    break;
                case 24100:
                    this.AvatarEntryReceived((AvatarEntryMessage)message);
                    break;
            }
        }

        private void SessionErrorReceived(SessionErrorMessage message)
        {
            if (AvatarSessionManager.TryGet(message.SessionId, out AvatarSession session))
            {
                int i = session.BoundServers.IndexOf(message.ServiceNode);
                if (i == -1) return;

                session.BoundServers.Remove(i);
                ServerErrorMessage serverErrorMessage = new ServerErrorMessage();
                serverErrorMessage.ErrorCode = message.ErrorCode;
                session.ForwardPiranhaMessage(serverErrorMessage, NetUtil.SERVICE_NODE_PROXY);
            }
        }

        private void ForwardPiranhaMessageReceived(ForwardPiranhaMessage message)
        {
            if (AvatarSessionManager.TryGet(message.SessionId, out AvatarSession session))
            {
                PiranhaMessage piranhaMessage = message.RemovePiranhaMessage();
                piranhaMessage.Decode();
                session.MessageManager.ReceiveMessage(piranhaMessage);
            }
        }

        private void StopSessionReceived(StopSessionMessage message)
        {
            if (AvatarSessionManager.TryRemove(message.SessionId, out AvatarSession session))
            {
                session.UnbindAllServers();
            }
        }

        private void StartSessionReceived(StartSessionMessage message)
        {
            AvatarSession session = AvatarSessionManager.Create(message.SessionId, message.AccountId);
            session.Init();
            session.BindServer(NetUtil.SERVICE_NODE_HOME);
        }

        private void AskForAvatarEntryReceived(AskForAvatarEntryMessage message)
        {
            AvatarDocument document = AvatarManager.GetDocument(message.AvatarId);
            if (document != null)
            {
                AvatarEntryMessage avatarEntryMessage = new AvatarEntryMessage();
                avatarEntryMessage.AvatarId = message.AvatarId;
                avatarEntryMessage.Entry = document.AvatarEntry;
                NetMessageManager.Send(avatarEntryMessage, message.ServiceNode, message.SessionId);
            }
        }

        private void AvatarEntryReceived(AvatarEntryMessage message)
        {
            if (message.ServiceNode != NetUtil.SERVICE_NODE_HOME) // if we got this message from home server, we want to update our avatar data (possibly after command execution)
                return;

            AvatarDocument document = new AvatarDocument()
            {
                Id = message.AvatarId,
                AvatarEntry = message.Entry
            };
            AvatarManager.UpdateDocument(document);
        }
    }
}
