namespace Reversivecell.Laser.Logic.Message.Avatar
{
    using Reversivecell.Laser.Titan.Message;

    public class ChangeAvatarNameMessage : PiranhaMessage
    {
        public string Name { get; set; }

        public override void Encode()
        {
            base.Encode();

            Stream.WriteString(Name);
        }

        public override void Decode()
        {
            base.Decode();

            Name = Stream.ReadString();
        }

        public override int GetMessageType()
        {
            return 10212;
        }

        public override int GetServiceNodeType()
        {
            return 9;
        }
    }
}
