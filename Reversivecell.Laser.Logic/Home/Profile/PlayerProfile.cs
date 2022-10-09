namespace Reversivecell.Laser.Logic.Home.Profile
{
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Helper;
    using Reversivecell.Laser.Logic.Home.Profile.Entry;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Util;

    public class PlayerProfile
    {
        private LogicLong _accountId;
        private string _name;
        private int _experience;
        private LogicPlayerThumbnailData _playerThumbnail;
        private LogicArrayList<HeroEntry> _heroEntries;
        private LogicArrayList<LogicVector2> _stats;

        public PlayerProfile(LogicLong accountId, string name, LogicPlayerThumbnailData thumbnailData, int experience)
        {
            _accountId = accountId;
            _name = name;
            _playerThumbnail = thumbnailData;
            _experience = experience;
            _heroEntries = new LogicArrayList<HeroEntry>();
            _stats = new LogicArrayList<LogicVector2>();
        }

        public void AddStat(int id, int value)
        {
            _stats.Add(new LogicVector2(id, value));
        }

        public void AddHeroEntry(HeroEntry entry)
        {
            _heroEntries.Add(entry);
        }

        public void Encode(ChecksumEncoder encoder)
        {
            ByteStreamHelper.EncodeLogicLong(encoder, _accountId);
            ByteStreamHelper.WriteDataReference(encoder, null);

            encoder.WriteVInt(_heroEntries.Count);
            for (int i = 0; i < _heroEntries.Count; i++)
            {
                _heroEntries[i].Encode(encoder);
            }

            encoder.WriteVInt(_stats.Count);
            for (int i = 0; i < _stats.Count; i++)
            {
                encoder.WriteVInt(_stats[i].GetX());
                encoder.WriteVInt(_stats[i].GetY());
            }

            encoder.WriteString(_name);
            encoder.WriteVInt(100);
            encoder.WriteVInt(_playerThumbnail.GetGlobalID());
            encoder.WriteVInt(43000000);
        }
    }
}
