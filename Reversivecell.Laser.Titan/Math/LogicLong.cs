namespace Reversivecell.Laser.Titan.Math
{
    using Reversivecell.Laser.Titan.DataStream;
    
    public class LogicLong
    {
        private int _highInteger;
        private int _lowInteger;

        public LogicLong()
        {
            // LogicLong.
        }

        public LogicLong(int highInteger, int lowInteger)
        {
            this._highInteger = highInteger;
            this._lowInteger = lowInteger;
        }

        public void Set(int highInteger, int lowInteger)
        {
            this._highInteger = highInteger;
            this._lowInteger = lowInteger;
        }

        public static long ToLong(int highValue, int lowValue)
        {
            return ((long) highValue << 32) | (uint) lowValue;
        }

        public LogicLong Clone()
        {
            return new LogicLong(this._highInteger, this._lowInteger);
        }

        public bool IsZero()
        {
            return this._highInteger == 0 && this._lowInteger == 0;
        }

        public int GetHigherInt()
        {
            return this._highInteger;
        }

        public int GetLowerInt()
        {
            return this._lowInteger;
        }

        public void Decode(ByteStream stream)
        {
            this._highInteger = stream.ReadInt();
            this._lowInteger = stream.ReadInt();
        }

        public void Encode(ChecksumEncoder stream)
        {
            stream.WriteInt(this._highInteger);
            stream.WriteInt(this._lowInteger);
        }

        public int HashCode()
        {
            return this._lowInteger + 31 * this._highInteger;
        }

        public override int GetHashCode()
        {
            return this.HashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is LogicLong logicLong)
                return logicLong._highInteger == this._highInteger && logicLong._lowInteger == this._lowInteger;
            return false;
        }

        public static bool Equals(LogicLong a1, LogicLong a2)
        {
            if (a1 == null || a2 == null)
                return a1 == null && a2 == null;
            return a1._highInteger == a2._highInteger && a1._lowInteger == a2._lowInteger;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", this._highInteger, this._lowInteger);
        }

        public static implicit operator LogicLong(long Long)
        {
            return new LogicLong((int) (Long >> 32), (int) Long);
        }

        public static implicit operator long(LogicLong Long)
        {
            return ((long) Long._highInteger << 32) | (uint) Long._lowInteger;
        }
    }
}