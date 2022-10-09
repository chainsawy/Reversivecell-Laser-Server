namespace Reversivecell.Laser.Servers.Avatar.Logic.Message
{
    using Reversivecell.Laser.Logic.Command.Server;
    using Reversivecell.Laser.Logic.Message.Avatar;
    using Reversivecell.Laser.Servers.Avatar.Session;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Network.Utils;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Home;
    using Reversivecell.Laser.Titan.Message;

    internal class LogicMessageManager
    {
        public AvatarSession Session { get; }

        public LogicMessageManager(AvatarSession session)
        {
            Session = session;
        }

        public void ReceiveMessage(PiranhaMessage message)
        {
            switch (message.GetMessageType())
            {
                case 10212:
                    this.ChangeAvatarNameReceived((ChangeAvatarNameMessage)message);
                    break;
                default:
                    Logging.Warning("LogicMessageManager::receiveMessage - no case for message of type " + message.GetMessageType());
                    break;
            }
        }

        private void ChangeAvatarNameReceived(ChangeAvatarNameMessage message)
        {
            if (Session.AvatarEntry.NameSet) return;

            Session.AvatarEntry.Name = message.Name;
            Session.AvatarEntry.NameSet = true;

            LogicChangeAvatarNameCommand command = new LogicChangeAvatarNameCommand();
            command.Name = message.Name;

            ExecuteServerCommandMessage executeServerCommandMessage = new ExecuteServerCommandMessage();
            executeServerCommandMessage.Command = command;
            NetMessageManager.Send(executeServerCommandMessage, NetUtil.SERVICE_NODE_HOME, Session.SessionId);
        }
    }
}
