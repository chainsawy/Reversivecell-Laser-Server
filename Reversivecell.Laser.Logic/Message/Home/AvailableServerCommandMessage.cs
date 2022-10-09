namespace Reversivecell.Laser.Logic.Message.Home
{
    using Reversivecell.Laser.Logic.Command;
    using Reversivecell.Laser.Titan.Message;

    public class AvailableServerCommandMessage : PiranhaMessage
    {
        public LogicCommand ServerCommand { get; set; }

        public AvailableServerCommandMessage() : base()
        {
            ;
        }

        public override void Encode()
        {
            base.Encode();

            LogicCommandManager.EncodeCommand(Stream, ServerCommand);
        }

        public override void Decode()
        {
            base.Decode();

            ServerCommand = LogicCommandManager.DecodeCommand(Stream);
        }

        public override int GetMessageType()
        {
            return 24111;
        }

        public override int GetServiceNodeType()
        {
            return 10;
        }
    }
}
