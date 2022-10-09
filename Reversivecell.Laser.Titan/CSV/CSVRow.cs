namespace Reversivecell.Laser.Titan.CSV
{
    using Reversivecell.Laser.Titan.Math;

    public class CSVRow
    {
        private readonly int _rowOffset;
        private readonly CSVTable _table;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CSVRow" /> class.
        /// </summary>
        public CSVRow(CSVTable table)
        {
            this._table = table;
            this._rowOffset = table.GetColumnRowCount();
        }

        /// <summary>
        ///     Gets the array size of specified column.
        /// </summary>
        public int GetBiggestArraySize(string column)
        {
            int columnIndex = this.GetColumnIndexByName(column);

            if (columnIndex == -1)
            {
                return 0;
            }

            return this._table.GetArraySizeAt(this, columnIndex);
        }

        /// <summary>
        ///     Gets the biggest array size.
        /// </summary>
        public int GetBiggestArraySize()
        {
            int columnCount = this._table.GetColumnCount();
            int maxSize = 0;

            for (int i = 0; i < columnCount; i++)
            {
                maxSize = LogicMath.Max(this._table.GetArraySizeAt(this, i), maxSize);
            }

            return maxSize;
        }

        /// <summary>
        ///     Gets the number of columns.
        /// </summary>
        public int GetColumnCount()
        {
            return this._table.GetColumnCount();
        }

        /// <summary>
        ///     Gets the index of specified column.
        /// </summary>
        public int GetColumnIndexByName(string name)
        {
            return this._table.GetColumnIndexByName(name);
        }

        /// <summary>
        ///     Gets the boolean value at specified column and specified index.
        /// </summary>
        public bool GetBooleanValue(string columnName, int index)
        {
            return this._table.GetBooleanValue(columnName, this._rowOffset + index);
        }

        /// <summary>
        ///     Gets the boolean value at specified column index and specified index.
        /// </summary>
        public bool GetBooleanValueAt(int columnIndex, int index)
        {
            return this._table.GetBooleanValueAt(columnIndex, this._rowOffset + index);
        }

        /// <summary>
        ///     Gets the clamped boolean value at specified column and specified index.
        /// </summary>
        public bool GetClampedBooleanValue(string columnName, int index)
        {
            int columnIndex = this.GetColumnIndexByName(columnName);

            if (columnIndex != -1)
            {
                int arraySize = this._table.GetArraySizeAt(this, columnIndex);

                if (index >= arraySize || arraySize < 1)
                {
                    index = LogicMath.Max(arraySize - 1, 0);
                }

                return this._table.GetBooleanValueAt(columnIndex, this._rowOffset + index);
            }

            return false;
        }

        /// <summary>
        ///     Gets the integer value at specified column and specified index.
        /// </summary>
        public int GetIntegerValue(string columnName, int index)
        {
            return this._table.GetIntegerValue(columnName, this._rowOffset + index);
        }

        /// <summary>
        ///     Gets the integer value at specified column index and specified index.
        /// </summary>
        public int GetIntegerValueAt(int columnIndex, int index)
        {
            return this._table.GetIntegerValueAt(columnIndex, this._rowOffset + index);
        }

        /// <summary>
        ///     Gets the clamped integer value at specified column and specified index.
        /// </summary>
        public int GetClampedIntegerValue(string columnName, int index)
        {
            int columnIndex = this.GetColumnIndexByName(columnName);

            if (columnIndex != -1)
            {
                int arraySize = this._table.GetArraySizeAt(this, columnIndex);

                if (index >= arraySize || arraySize < 1)
                {
                    index = LogicMath.Max(arraySize - 1, 0);
                }

                return this._table.GetIntegerValueAt(columnIndex, this._rowOffset + index);
            }

            return 0;
        }

        /// <summary>
        ///     Gets the value at specified column and specified index.
        /// </summary>
        public string GetValue(string columnName, int index)
        {
            return this._table.GetValue(columnName, this._rowOffset + index);
        }

        /// <summary>
        ///     Gets the value at specified column index and specified index.
        /// </summary>
        public string GetValueAt(int columnIndex, int index)
        {
            return this._table.GetValueAt(columnIndex, this._rowOffset + index);
        }

        /// <summary>
        ///     Gets the clamped value at specified column and specified index.
        /// </summary>
        public string GetClampedValue(string columnName, int index)
        {
            int columnIndex = this.GetColumnIndexByName(columnName);

            if (columnIndex != -1)
            {
                int arraySize = this._table.GetArraySizeAt(this, columnIndex);

                if (index >= arraySize || arraySize < 1)
                {
                    index = LogicMath.Max(arraySize - 1, 0);
                }

                return this._table.GetValueAt(columnIndex, this._rowOffset + index);
            }

            return string.Empty;
        }

        /// <summary>
        ///     Gets the name of this row.
        /// </summary>
        public string GetName()
        {
            return this._table.GetValueAt(0, this._rowOffset);
        }

        /// <summary>
        ///     Gets the row offset.
        /// </summary>
        public int GetRowOffset()
        {
            return this._rowOffset;
        }
    }
}