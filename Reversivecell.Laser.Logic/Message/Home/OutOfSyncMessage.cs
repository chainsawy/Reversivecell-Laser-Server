namespace Reversivecell.Laser.Logic.Message.Home
{
    using Reversivecell.Laser.Titan.Message;

    public class OutOfSyncMessage : PiranhaMessage
    {
        private int _serverChecksum;
        private int _clientChecksum;
        private int _tick;

        public override void Encode()
        {
            base.Encode();

            Stream.WriteVInt(_serverChecksum);
            Stream.WriteVInt(_clientChecksum);
            Stream.WriteVInt(_tick);
        }

        public override void Decode()
        {
            base.Decode();

            _serverChecksum = Stream.ReadVInt();
            _clientChecksum = Stream.ReadVInt();
            _tick = Stream.ReadVInt();
        }

        public void SetServerChecksum(int checksum)
        {
            _serverChecksum = checksum;
        }

        public void SetClientChecksum(int checksum)
        {
            _clientChecksum = checksum;
        }

        public void SetTick(int tick)
        {
            _tick = tick;
        }

        public override int GetMessageType()
        {
            return 24104;
        }

        public override int GetServiceNodeType()
        {
            return 10;
        }
    }
}
