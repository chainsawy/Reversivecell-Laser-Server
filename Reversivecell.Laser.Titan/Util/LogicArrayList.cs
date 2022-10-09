namespace Reversivecell.Laser.Titan.Util
{
    using Reversivecell.Laser.Titan.Debug;
    using System;

    public class LogicArrayList<T>
    {
        private T[] _items;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicArrayList{T}" /> class.
        /// </summary>
        public LogicArrayList()
        {
            this._items = new T[0];
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicArrayList{T}" /> class.
        /// </summary>
        public LogicArrayList(int initialCapacity)
        {
            this._items = new T[initialCapacity];
        }

        /// <summary>
        ///     Gets a value indicating the number of items in list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Gets the item at specified index.
        /// </summary>
        public T this[int index]
        {
            get
            {
                if (index < this.Count && index > -1)
                {
                    return this._items[index];
                }

                Debugger.Error(string.Format("LogicArrayList.get out of bounds {0}/{1}", index, this.Count));

                return default(T);
            }
            set
            {
                if (index < this.Count && index > -1)
                {
                    this._items[index] = value;
                }
                else
                {
                    Debugger.Error(string.Format("LogicArrayList.set out of bounds {0}/{1}", index, this.Count));
                }
            }
        }

        /// <summary>
        ///     Adds the specified item to list.
        /// </summary>
        public void Add(T item)
        {
            int size = this._items.Length;

            if (size == this.Count)
            {
                this.EnsureCapacity(size != 0 ? size * 2 : 5);
            }

            this._items[this.Count++] = item;
        }

        /// <summary>
        ///     Adds the specified item to list.
        /// </summary>
        public void Add(int index, T item)
        {
            int size = this._items.Length;

            if (size == this.Count)
            {
                this.EnsureCapacity(size != 0 ? size * 2 : 5);
            }

            if (this.Count > index)
            {
                Array.Copy(this._items, index, this._items, index + 1, this.Count - index);
            }

            this._items[index] = item;
            this.Count += 1;
        }

        /// <summary>
        ///     Gets the index of specified item.
        /// </summary>
        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Removes the item at specified index to list.
        /// </summary>
        public void Remove(int index)
        {
            if (index < this.Count && index > -1)
            {
                this.Count -= 1;

                if (index != this.Count)
                {
                    Array.Copy(this._items, index + 1, this._items, index, this.Count - index);
                }

                this._items[this.Count] = default(T);
            }
            else
            {
                Debugger.Error(string.Format("LogicArrayList.remove out of bounds {0}/{1}", index, this.Count));
            }
        }

        /// <summary>
        ///     Ensures the capacity of item array.
        /// </summary>
        public void EnsureCapacity(int count)
        {
            int size = this._items.Length;

            if (size < count)
            {
                T[] tmp = new T[count];
                Array.Copy(this._items, tmp, size);
                this._items = tmp;
            }
        }

        public void Clear()
        {
            this.Count = 0;
        }

        /// <summary>
        ///     Called for destructs this instance.
        /// </summary>
        ~LogicArrayList()
        {
            this._items = null;
            this.Count = 0;
        }
    }
}