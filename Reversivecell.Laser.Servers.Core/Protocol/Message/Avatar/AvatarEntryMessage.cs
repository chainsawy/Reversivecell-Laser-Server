namespace Reversivecell.Laser.Servers.Core.Protocol.Message.Avatar
{
    using Reversivecell.Laser.Servers.Core.Game;
    using Reversivecell.Laser.Titan.Math;

    public class AvatarEntryMessage : NetMessage
    {
        public LogicLong AvatarId { get; set; }
        public AvatarEntry Entry { get; set; }

        public override void Decode()
        {
            AvatarId = Stream.ReadLong();

            Entry = new AvatarEntry();
            Entry.Decode(Stream);
        }

        public override void Encode()
        {
            Stream.WriteLong(AvatarId);
            Entry.Encode(Stream);
        }

        public override int GetMessageType()
        {
            return 24100;
        }
    }
}
