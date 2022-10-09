namespace Reversivecell.Laser.Servers.Core.Protocol.Message.Avatar
{
    using Reversivecell.Laser.Titan.Math;

    public class AskForAvatarEntryMessage : NetMessage
    {
        public LogicLong AvatarId;

        public override void Decode()
        {
            AvatarId = Stream.ReadLong();
        }

        public override void Encode()
        {
            Stream.WriteLong(AvatarId);
        }

        public override int GetMessageType()
        {
            return 14100;
        }
    }
}
