namespace Reversivecell.Laser.Logic.Command
{
    using Reversivecell.Laser.Logic.Helper;
    using Reversivecell.Laser.Logic.Home;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Math;

    public abstract class LogicCommand
    {
        private int _tickWhenGiven;
        private int _executeTick;
        private LogicLong _executorAccountId;

        public LogicCommand()
        {
            _executorAccountId = -1;
        }

        public virtual void Encode(ChecksumEncoder encoder)
        {
            encoder.WriteVInt(_tickWhenGiven);
            encoder.WriteVInt(_executeTick);
            ByteStreamHelper.EncodeLogicLong(encoder, _executorAccountId);
        }

        public virtual void Decode(ByteStream stream)
        {
            _tickWhenGiven = stream.ReadVInt();
            _executeTick = stream.ReadVInt();
            _executorAccountId = ByteStreamHelper.DecodeLogicLong(stream);
        }

        public void SetExecuteTick(int tick)
        {
            _executeTick = tick;
        }

        public void SetExecutorAccountId(LogicLong id)
        {
            _executorAccountId = id;
        }

        public virtual int Execute(LogicHomeMode homeMode)
        {
            return 0;
        }

        public virtual bool IsServerCommand()
        {
            return false;
        }

        public abstract int GetCommandType();
    }
}
