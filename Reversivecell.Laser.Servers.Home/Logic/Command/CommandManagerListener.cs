namespace Reversivecell.Laser.Servers.Home.Logic.Command
{
    using Reversivecell.Laser.Logic.Command;
    using Reversivecell.Laser.Logic.Message.Home;
    using Reversivecell.Laser.Servers.Home.Session;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Network.Utils;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Debug;

    internal class CommandManagerListener : LogicCommandManagerListener
    {
        private HomeSession _session;

        public CommandManagerListener(HomeSession session)
        {
            _session = session;
        }

        public override void CommandExecuted(LogicCommand command)
        {
            Logging.HudPrint($"Command executed - type: {command.GetCommandType()}");
        }

        public override void ServerCommandAdded(LogicCommand command)
        {
            AvailableServerCommandMessage availableServerCommandMessage = new AvailableServerCommandMessage();
            availableServerCommandMessage.ServerCommand = command;
            _session.ForwardPiranhaMessage(availableServerCommandMessage, NetUtil.SERVICE_NODE_PROXY);
        }
    }
}
