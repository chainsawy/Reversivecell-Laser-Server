namespace Reversivecell.Laser.Logic.Home.Profile.Entry
{
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Helper;
    using Reversivecell.Laser.Titan.DataStream;

    public class HeroEntry
    {
        private LogicCharacterData _characterData;
        private int _trophies;
        private int _highestTrophies;
        private int _powerLevel;

        public HeroEntry(LogicCharacterData characterData, int trophies, int highestTrophies, int powerLevel)
        {
            _characterData = characterData;
            _trophies = trophies;
            _highestTrophies = highestTrophies;
            _powerLevel = powerLevel;
        }

        public void Encode(ChecksumEncoder encoder)
        {
            ByteStreamHelper.WriteDataReference(encoder, _characterData);
            ByteStreamHelper.WriteDataReference(encoder, null);
            encoder.WriteVInt(_trophies);
            encoder.WriteVInt(_highestTrophies);
            encoder.WriteVInt(_powerLevel);
        }
    }
}
