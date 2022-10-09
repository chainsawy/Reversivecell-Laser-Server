namespace Reversivecell.Laser.Servers.Proxy.Network
{
    using System;

    internal class NetworkBuffer
    {
        private const int InitCapacity = 1024;
        private const int MaxCapacity = 8192;

        private bool _destructed;
        private byte[] _buffer;
        private int _length;
        private int _capacity;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkBuffer"/> class.
        /// </summary>
        internal NetworkBuffer()
        {
            this._capacity = 1024;
            this._buffer = new byte[this._capacity];
        }

        /// <summary>
        ///     Destructs this instance.
        /// </summary>
        internal void Destruct()
        {
            this._buffer = null;
            this._length = -1;
            this._capacity = -1;
        }

        /// <summary>
        ///     Gets if we can write on the buffer.
        /// </summary>
        internal bool CanWrite(byte[] buffer, int length)
        {
            return NetworkBuffer.MaxCapacity >= this._capacity + length;
        }

        /// <summary>
        ///     Gets the length.
        /// </summary>
        internal int GetLength()
        {
            return this._length;
        }

        /// <summary>
        ///     Gets the buffer.
        /// </summary>
        internal byte[] GetBuffer()
        {
            return this._buffer;
        }

        /// <summary>
        ///     Removes the number of specified bytes.
        /// </summary>
        internal void Remove(int length)
        {
            if (length > this._length || length < -1)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            
            Array.Copy(this._buffer, length, this._buffer, 0, this._length -= length);
        }

        /// <summary>
        ///     Writes the byte array to the buffer.
        /// </summary>
        internal void Write(byte[] buffer, int length)
        {
            this.EnsureCapacity(length);
            Array.Copy(buffer, 0, this._buffer, this._length, length);
            this._length += length;
        }

        /// <summary>
        ///     Ensures the capacity of buffer.
        /// </summary>
        private void EnsureCapacity(int length)
        {
            if (this._length + length > this._capacity)
            {
                byte[] tmp = this._buffer;
                this._capacity += length;
                this._buffer = new byte[this._capacity];
                Array.Copy(tmp, 0, this._buffer, 0, this._length);
            }
        }
    }
}