namespace Reversivecell.Laser.Logic.Message.Home
{
    using Reversivecell.Laser.Logic.Command;
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Message;
    using Reversivecell.Laser.Titan.Util;

    public class EndClientTurnMessage : PiranhaMessage
    {
        private bool _stopHomeLogic;
        private int _clientTick;
        private int _clientChecksum;
        private LogicArrayList<LogicCommand> _commands;

        public EndClientTurnMessage() : base()
        {
            _clientTick = -1;
            _clientChecksum = -1;

            _commands = new LogicArrayList<LogicCommand>();
        }

        public override void Decode()
        {
            base.Decode();

            _stopHomeLogic = Stream.ReadBoolean();
            _clientTick = Stream.ReadVInt();
            _clientChecksum = Stream.ReadVInt();

            int commandsCount = Stream.ReadVInt();

            if (commandsCount > 0x200)
            {
                Debugger.Error($"EndClientTurnMessage::decode() command count is invalid ({commandsCount})");
                return;
            }

            for (int i = 0; i < commandsCount; i++)
            {
                LogicCommand command = LogicCommandManager.DecodeCommand(Stream);
                if (command == null)
                {
                    return;
                }

                _commands.Add(command);
            }
        }

        public bool ShouldStopHomeLogic()
        {
            return _stopHomeLogic;
        }

        public int GetClientTick()
        {
            return _clientTick;
        }

        public int GetClientChecksum()
        {
            return _clientChecksum;
        }

        public LogicArrayList<LogicCommand> GetCommands()
        {
            return _commands;
        }

        public override int GetMessageType()
        {
            return 14102;
        }

        public override int GetServiceNodeType()
        {
            return 10;
        }
    }
}
