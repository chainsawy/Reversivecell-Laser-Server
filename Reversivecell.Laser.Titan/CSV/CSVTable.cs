namespace Reversivecell.Laser.Titan.CSV
{
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Util;

    public class CSVTable
    {
        private readonly LogicArrayList<string> _columnNameList;
        private readonly LogicArrayList<CSVColumn> _columnList;
        private readonly LogicArrayList<CSVRow> _rowList;

        private readonly CSVNode _node;

        private readonly int Size;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CSVTable" /> class.
        /// </summary>
        public CSVTable(CSVNode node, int size)
        {
            this._columnNameList = new LogicArrayList<string>();
            this._columnList = new LogicArrayList<CSVColumn>();
            this._rowList = new LogicArrayList<CSVRow>();

            this._node = node;
            this.Size = size;
        }

        /// <summary>
        ///     Adds and converts the specified value to list.
        /// </summary>
        public void AddAndConvertValue(string value, int columnIndex)
        {
            CSVColumn column = this._columnList[columnIndex];

            if (!string.IsNullOrEmpty(value))
            {
                switch (column.ColumnType)
                {
                    case -1:
                    case 0:
                    {
                        column.AddStringValue(value);
                        break;
                    }

                    case 1:
                    {
                        column.AddIntegerValue(int.Parse(value));
                        break;
                    }

                    case 2:
                    {
                        if (bool.TryParse(value, out bool booleanValue))
                        {
                            column.AddBooleanValue(booleanValue);
                        }
                        else
                        {
                            Debugger.Warning("CSVTable::addAndConvertValue invalid value '" + value + "' in Boolean column '" + this._columnNameList[columnIndex] + "', " + this.GetFileName());
                            column.AddBooleanValue(false);
                        }

                        break;
                    }
                }
            }
            else
            {
                column.AddEmptyValue();
            }
        }

        /// <summary>
        ///     Adds a new column name to array list.
        /// </summary>
        public void AddColumn(string name)
        {
            this._columnNameList.Add(name);
        }

        /// <summary>
        ///     Adds a new column to array list.
        /// </summary>
        public void AddColumnType(int type)
        {
            this._columnList.Add(new CSVColumn(type, this.Size));
        }

        /// <summary>
        ///     Adds a new row instance to array list.
        /// </summary>
        public void AddRow(CSVRow row)
        {
            this._rowList.Add(row);
        }

        /// <summary>
        ///     Called when the column names has been loaded.
        /// </summary>
        public void ColumnNamesLoaded()
        {
            this._columnList.EnsureCapacity(this._columnNameList.Count);
        }

        /// <summary>
        ///     Creates a new row instance.
        /// </summary>
        public void CreateRow()
        {
            this._rowList.Add(new CSVRow(this));
        }

        /// <summary>
        ///     Gets the array size at specified column.
        /// </summary>
        public int GetArraySizeAt(CSVRow row, int columnIdx)
        {
            if (this._rowList.Count > 0)
            {
                int rowIdx = this._rowList.IndexOf(row);

                if (rowIdx != -1)
                {
                    CSVColumn column = this._columnList[columnIdx];
                    return column.GetArraySize(this._rowList[rowIdx].GetRowOffset(), 
                                               rowIdx + 1 >= this._rowList.Count ? column.GetSize() : this._rowList[rowIdx + 1].GetRowOffset());
                }
            }

            return 0;
        }

        /// <summary>
        ///     Gets the column name by index.
        /// </summary>
        public string GetColumnName(int idx)
        {
            return this._columnNameList[idx];
        }

        /// <summary>
        ///     Gets the index of column by name.
        /// </summary>
        public int GetColumnIndexByName(string name)
        {
            return this._columnNameList.IndexOf(name);
        }

        /// <summary>
        ///     Gets the number of columns.
        /// </summary>
        public int GetColumnCount()
        {
            return this._columnNameList.Count;
        }

        /// <summary>
        ///     Gets the number of rows.
        /// </summary>
        public int GetColumnRowCount()
        {
            return this._columnList[0].GetSize();
        }

        /// <summary>
        ///     Gets the number of type.
        /// </summary>
        public int GetColumnTypeCount()
        {
            return this._columnList.Count;
        }

        /// <summary>
        ///     Gets the file name of csv.
        /// </summary>
        public string GetFileName()
        {
            return this._node.GetFileName();
        }

        /// <summary>
        ///     Gets the boolean value at specified column and specified value index.
        /// </summary>
        public bool GetBooleanValue(string name, int index)
        {
            return this.GetBooleanValueAt(this._columnNameList.IndexOf(name), index);
        }

        /// <summary>
        ///     Gets the boolean value at specified column index and specified value index.
        /// </summary>
        public bool GetBooleanValueAt(int columnIndex, int index)
        {
            if (columnIndex != -1)
            {
                return this._columnList[columnIndex].GetBooleanValue(index);
            }

            return false;
        }

        /// <summary>
        ///     Gets the integer value at specified column and specified value index.
        /// </summary>
        public int GetIntegerValue(string name, int index)
        {
            return this.GetIntegerValueAt(this._columnNameList.IndexOf(name), index);
        }

        /// <summary>
        ///     Gets the integer value at specified column index and specified value index.
        /// </summary>
        public int GetIntegerValueAt(int columnIndex, int index)
        {
            if (columnIndex != -1)
            {
                int value = this._columnList[columnIndex].GetIntegerValue(index);

                if (value == 0x7fffffff)
                {
                    value = 0;
                }

                return value;
            }

            return 0;
        }

        /// <summary>
        ///     Gets the value at specified column and specified value index.
        /// </summary>
        public string GetValue(string name, int index)
        {
            return this.GetValueAt(this._columnNameList.IndexOf(name), index);
        }

        /// <summary>
        ///     Gets the value at specified column index and specified value index.
        /// </summary>
        public string GetValueAt(int columnIndex, int index)
        {
            if (columnIndex != -1)
            {
                return this._columnList[columnIndex].GetStringValue(index);
            }

            return string.Empty;
        }

        /// <summary>
        ///     Gets the integer value at specified index.
        /// </summary>
        public CSVRow GetRowAt(int index)
        {
            return this._rowList[index];
        }

        /// <summary>
        ///     Gets the <see cref="CSVColumn"/> instance at the specified index.
        /// </summary>
        public CSVColumn GetCSVColumn(int index)
        {
            return this._columnList[index];
        }

        /// <summary>
        ///     Gets the number of rows.
        /// </summary>
        public int GetRowCount()
        {
            return this._rowList.Count;
        }

        /// <summary>
        ///     Validates the column types.
        /// </summary>
        public void ValidateColumnTypes()
        {
            if (this._columnNameList.Count != this._columnList.Count)
            {
                Debugger.Warning($"Column name count {this._columnNameList.Count}, column type count {this._columnList.Count}, file {this.GetFileName()}");
            }
        }
    }
}