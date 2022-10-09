namespace Reversivecell.Laser.Logic.Command.Server
{
    using Reversivecell.Laser.Logic.Home;
    using Reversivecell.Laser.Titan.DataStream;

    public class LogicChangeAvatarNameCommand : LogicServerCommand
    {
        public string Name { get; set; }
        public int DiamondsCost { get; set; }

        public override void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteString(Name);
            encoder.WriteVInt(DiamondsCost);
            base.Encode(encoder);
        }

        public override void Decode(ByteStream stream)
        {
            Name = stream.ReadString();
            DiamondsCost = stream.ReadVInt();
            base.Decode(stream);
        }

        public override int Execute(LogicHomeMode homeMode)
        {
            homeMode.ClientAvatar.SetName(Name);
            homeMode.ClientAvatar.SetNameSetByUser(true);
            return 0;
        }

        public override int GetCommandType()
        {
            return 201;
        }
    }
}
