namespace Reversivecell.Laser.Logic.Data
{
    using System;
    using System.Reflection;
    using Reversivecell.Laser.Titan.CSV;
    using Reversivecell.Laser.Titan.Debug;

    public class LogicData
    {
        protected readonly int _globalId;

        protected int _villageType;

        protected readonly CSVRow _row;
        protected readonly LogicDataTable _table;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicData" />
        /// </summary>
        public LogicData(CSVRow row, LogicDataTable table)
        {
            this._row = row;
            this._table = table;
            this._globalId = GlobalID.CreateGlobalID(table.GetTableIndex(), table.GetItemCount());
        }

        public override bool Equals(object obj)
        {
            LogicData data = (LogicData)obj;
            if (data == null) return false;

            return data.GetGlobalID() == this.GetGlobalID();
        }

        /// <summary>
        ///     Called for create references.
        /// </summary>
        public virtual void CreateReferences()
        {
            // CreateReferences.
        }

        /// <summary>
        ///     Gets the array size of specified column.
        /// </summary>
        public int GetArraySize(string column)
        {
            return this._row.GetBiggestArraySize();
        }

        /// <summary>
        ///     Gets the data type.
        /// </summary>
        public int GetDataType()
        {
            return this._table.GetTableIndex();
        }

        /// <summary>
        ///     Gets the global id.
        /// </summary>
        public int GetGlobalID()
        {
            return this._globalId;
        }

        /// <summary>
        ///     Gets the instance id.
        /// </summary>
        public int GetInstanceID()
        {
            return GlobalID.GetInstanceID(this._globalId);
        }

        /// <summary>
        ///     Gets the column index.
        /// </summary>
        public int GetColumnIndex(string name)
        {
            int columnIndex = this._row.GetColumnIndexByName(name);

            if (columnIndex == -1)
            {
                Debugger.Warning("Unable to find column " + name + " from " + this._row.GetName() + " (" + this._table.GetTableName() + ")");
            }

            return columnIndex;
        }

        /// <summary>
        ///     Gets the debugger name of this data.
        /// </summary>
        public string GetDebuggerName()
        {
            return this._row.GetName() + " (" + this._table.GetTableName() + ")";
        }

        /// <summary>
        ///     Gets a boolean value at specified column and specified index.
        /// </summary>
        public bool GetBooleanValue(string columnName, int index)
        {
            return this._row.GetBooleanValue(columnName, index);
        }

        /// <summary>
        ///     Gets a clamped boolean value at specified column and specified index.
        /// </summary>
        public bool GetClampedBooleanValue(string columnName, int index)
        {
            return this._row.GetClampedBooleanValue(columnName, index);
        }

        /// <summary>
        ///     Gets a integer value at specified column and specified index.
        /// </summary>
        public int GetIntegerValue(string columnName, int index)
        {
            return this._row.GetIntegerValue(columnName, index);
        }

        /// <summary>
        ///     Gets a clamped integer value at specified column and specified index.
        /// </summary>
        public int GetClampedIntegerValue(string columnName, int index)
        {
            return this._row.GetClampedIntegerValue(columnName, index);
        }

        /// <summary>
        ///     Gets a value at specified column and specified index.
        /// </summary>
        public string GetValue(string columnName, int index)
        {
            return this._row.GetValue(columnName, index);
        }

        /// <summary>
        ///     Gets a clamped value at specified column and specified index.
        /// </summary>
        public string GetClampedValue(string columnName, int index)
        {
            return this._row.GetClampedValue(columnName, index);
        }

        /// <summary>
        ///     Gets the name of this data.
        /// </summary>
        public string GetName()
        {
            return this._row.GetName();
        }

        /// <summary>
        ///     Loads automaticaly the data.
        /// </summary>
        public void AutoLoadData()
        {
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (propertyInfo.CanWrite)
                {
                    if (propertyInfo.PropertyType.IsArray)
                    {
                        Type elementType = propertyInfo.PropertyType.GetElementType();

                        if (elementType == typeof(int))
                        {
                            int arraySize = this._row.GetBiggestArraySize();
                            int[] array = new int[arraySize];

                            for (int i = 0; i < arraySize; i++)
                            {
                                array[i] = this.GetIntegerValue(propertyInfo.Name, i);
                            }

                            propertyInfo.SetValue(this, array);
                        }
                        else if (elementType == typeof(bool))
                        {
                            int arraySize = this._row.GetBiggestArraySize();
                            bool[] array = new bool[arraySize];

                            for (int i = 0; i < arraySize; i++)
                            {
                                array[i] = this.GetBooleanValue(propertyInfo.Name, i);
                            }

                            propertyInfo.SetValue(this, array);
                        }
                        else if (elementType == typeof(string))
                        {
                            int arraySize = this._row.GetBiggestArraySize();
                            string[] array = new string[arraySize];

                            for (int i = 0; i < arraySize; i++)
                            {
                                array[i] = this.GetValue(propertyInfo.Name, i);
                            }

                            propertyInfo.SetValue(this, array);
                        }
                    }
                    else if (propertyInfo.PropertyType == typeof(LogicData) || propertyInfo.PropertyType.BaseType == typeof(LogicData))
                    {
                        LogicData data = (LogicData)propertyInfo.GetValue(this);

                        if (data != null)
                        {
                            data.AutoLoadData();
                        }
                    }
                    else
                    {
                        Type elementType = propertyInfo.PropertyType;

                        if (elementType == typeof(bool))
                        {
                            propertyInfo.SetValue(this, this.GetBooleanValue(propertyInfo.Name, 0));
                        }
                        else if (elementType == typeof(int))
                        {
                            propertyInfo.SetValue(this, this.GetIntegerValue(propertyInfo.Name, 0));
                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            propertyInfo.SetValue(this, this.GetValue(propertyInfo.Name, 0));
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the village type
        /// </summary>
        public int GetVillageType()
        {
            return this._villageType;
        }
    }
}
