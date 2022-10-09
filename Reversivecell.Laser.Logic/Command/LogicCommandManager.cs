namespace Reversivecell.Laser.Logic.Command
{
    using Reversivecell.Laser.Logic.Command.Server;
    using Reversivecell.Laser.Logic.Home;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Debug;
    using System;

    public class LogicCommandManager
    {
        private LogicCommandManagerListener _listener;
        private LogicHomeMode _homeMode;

        private int _tick;

        public LogicCommandManager(LogicHomeMode homeMode)
        {
            _homeMode = homeMode;
            _tick = 1;
        }

        public void AddServerCommand(LogicCommand command)
        {
            command.SetExecuteTick(_tick);
            command.SetExecutorAccountId(_homeMode.ClientAvatar.GetAccountId());

            if (_listener != null)
            {
                _listener.ServerCommandAdded(command);
            }
        }

        public void AddCommand(LogicCommand command)
        {
            command.SetExecuteTick(_tick);
            command.SetExecutorAccountId(_homeMode.ClientAvatar.GetAccountId());
            int errorCode = command.Execute(_homeMode);
            if (errorCode != 0)
            {
                Debugger.Error($"Failed to execute command {command.GetCommandType()}, errorCode={errorCode}");
                return;
            }

            if (_listener != null)
            {
                _listener.CommandExecuted(command);
            }
        }

        public void FastForward(int ticks)
        {
            _tick += ticks;
        }

        public void SetListener(LogicCommandManagerListener listener)
        {
            _listener = listener;
        }

        public static LogicCommand CreateCommand(int type)
        {
            switch (type)
            {
                case 201:
                    return new LogicChangeAvatarNameCommand();

                default:
                    Debugger.Warning("LogicCommandManager::createCommand - unknown command type " + type);
                    return null;
            }
        }

        public static LogicCommand DecodeCommand(ByteStream stream)
        {
            LogicCommand command = LogicCommandManager.CreateCommand(stream.ReadVInt());
            if (command != null)
            {
                command.Decode(stream);
            }
            return command;
        }

        public static void EncodeCommand(ChecksumEncoder encoder, LogicCommand command)
        {
            encoder.WriteVInt(command.GetCommandType());
            command.Encode(encoder);
        }

        public void Destruct()
        {
            _listener = null;
            _homeMode = null;
            _tick = 0;
        }
    }
}
