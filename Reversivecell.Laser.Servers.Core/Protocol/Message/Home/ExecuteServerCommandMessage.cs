namespace Reversivecell.Laser.Servers.Core.Protocol.Message.Home
{
    using Reversivecell.Laser.Logic.Command;

    public class ExecuteServerCommandMessage : NetMessage
    {
        public LogicServerCommand Command { get; set; }

        public override void Decode()
        {
            Command = (LogicServerCommand)LogicCommandManager.DecodeCommand(Stream);
        }

        public override void Encode()
        {
            LogicCommandManager.EncodeCommand(Stream, Command);
        }

        public override int GetMessageType()
        {
            return 14200;
        }
    }
}
