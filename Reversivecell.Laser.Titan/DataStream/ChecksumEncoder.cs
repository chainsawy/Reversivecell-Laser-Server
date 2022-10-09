namespace Reversivecell.Laser.Titan.DataStream
{
    using Reversivecell.Laser.Titan.Math;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class ChecksumEncoder
    {
        private uint _checksum;
        private uint _snapshotChecksum;

        private bool _enabled;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChecksumEncoder" /> class.
        /// </summary>
        public ChecksumEncoder()
        {
            this._enabled = true;
        }

        /// <summary>
        ///     Enables the checksum.
        /// </summary>
        public void EnableCheckSum(bool enable)
        {
            if (!this._enabled || enable)
            {
                if (!this._enabled && enable)
                {
                    this._checksum = this._snapshotChecksum;
                }

                this._enabled = enable;
            }
            else
            {
                this._snapshotChecksum = this._checksum;
                this._enabled = false;
            }
        }

        /// <summary>
        ///     Reset this checksum.
        /// </summary>
        public void ResetCheckSum()
        {
            this._checksum = 0;
        }

        public virtual void WriteBoolean(bool value)
        {
            this._checksum = (uint)((value ? 13 : 7) + this.RotateRight(this._checksum, 31));
        }

        public virtual void WriteByte(byte value)
        {
            this._checksum = (uint)(value + this.RotateRight(this._checksum, 31) + 11);
        }

        public virtual void WriteShort(short value)
        {
            this._checksum = (uint)(value + this.RotateRight(this._checksum, 31) + 19);
        }

        public virtual void WriteInt(int value)
        {
            this._checksum = (uint)(value + this.RotateRight(this._checksum, 31) + 9);
        }

        public virtual void WriteVInt(int value)
        {
            this._checksum = (uint)(value + this.RotateRight(this._checksum, 31) + 33);
        }

        public virtual void WriteLong(LogicLong value)
        {
            value.Encode(this);
        }

        public virtual void WriteLongLong(long value)
        {
            int high = (int)(value >> 32);
            int low = (int)value;

           // this._checksum = high + this.RotateRight(low + this.RotateRight(this._checksum, 31) + 67, 31) + 91;
        }

        public virtual void WriteBytes(byte[] value, int length)
        {
            this._checksum = (uint)(((value != null ? length + 28 : 27) + (this._checksum >> 31)) | (this._checksum << (32 - 31)));
        }

        public virtual void WriteString(string value)
        {
            this._checksum = (uint)((value != null ? value.Length + 28 : 27) + this.RotateRight(this._checksum, 31));
        }

        public virtual void WriteStringReference(string value)
        {
            this._checksum = (uint)(value.Length + this.RotateRight(this._checksum, 31) + 38);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint RotateRight(uint value, int count)
        {
            return ((value >> count) | (value << (32 - count)));
        }

        /// <summary>
        ///     Gets the hash code of this instance.
        /// </summary>
        public virtual int HashCode()
        {
            //Debugger.Error("ChecksumEncoder hashCode not designed");
            return 42;
        }

        /// <summary>
        ///     Gets a value indicating whether the checksum mode is enabled.
        /// </summary>
        public bool IsCheckSumEnabled()
        {
            return this._enabled;
        }

        /// <summary>
        ///     Gets a value indicating whether this encoder is a only checksum mode.
        /// </summary>
        public virtual bool IsCheckSumOnlyMode()
        {
            return true;
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is equal to the specified instance.
        /// </summary>
        public bool Equals(ChecksumEncoder encoder)
        {
            if (encoder != null)
            {
                uint checksum = encoder._checksum;
                uint checksum2 = this._checksum;

                if (!encoder._enabled)
                {
                    checksum = encoder._snapshotChecksum;
                }

                if (!this._enabled)
                {
                    checksum2 = this._snapshotChecksum;
                }

                return checksum == checksum2;
            }

            return false;
        }

        public int GetCheckSum()
        {
            return (int)this._checksum;
        }
    }
}