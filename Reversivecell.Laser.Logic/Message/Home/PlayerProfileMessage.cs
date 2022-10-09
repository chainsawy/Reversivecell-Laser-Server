namespace Reversivecell.Laser.Logic.Message.Home
{
    using Reversivecell.Laser.Logic.Helper;
    using Reversivecell.Laser.Logic.Home.Profile;
    using Reversivecell.Laser.Titan.Message;

    public class PlayerProfileMessage : PiranhaMessage
    {
        private PlayerProfile _playerProfile;

        public override void Encode()
        {
            base.Encode();

            _playerProfile.Encode(Stream);

            Stream.WriteBoolean(false);
            ByteStreamHelper.WriteDataReference(Stream, null);
        }

        public void SetPlayerProfile(PlayerProfile profile)
        {
            _playerProfile = profile;
        }

        public PlayerProfile RemovePlayerProfile()
        {
            PlayerProfile result = _playerProfile;
            _playerProfile = null;
            return result;
        }

        public override int GetMessageType()
        {
            return 24113;
        }

        public override int GetServiceNodeType()
        {
            return 10;
        }
    }
}
