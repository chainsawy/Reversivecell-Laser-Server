namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Util;

    public class LogicDataTable
    {
        private readonly CSVTable _table;
        private readonly int _tableIndex;
        private LogicArrayList<LogicData> _items;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LogicDataTable" /> class.
        /// </summary>
        public LogicDataTable(CSVTable table, int index)
        {
            this._tableIndex = index;
            this._table = table;

            this.LoadTable();
        }

        /// <summary>
        ///     Loads the data table.
        /// </summary>
        public void LoadTable()
        {
            this._items = new LogicArrayList<LogicData>();

            for (int i = 0; i < this._table.GetRowCount(); i++)
            {
                LogicData data = this.CreateItem(this._table.GetRowAt(i));

                if (data == null)
                {
                    break;
                }

                this._items.Add(data);
            }

            this.CreateReferences();
        }

        /// <summary>
        ///     Creates a new data item.
        /// </summary>
        public LogicData CreateItem(CSVRow row)
        {
            LogicData data = null;

            switch (this._tableIndex)
            {
                case 5:
                    return new LogicResourceData(row, this);
                case 6:
                    return new LogicProjectileData(row, this);
                case 8:
                    return new LogicAllianceBadgeData(row, this);
                case 15:
                    return new LogicLocationData(row, this);
                case 16:
                    return new LogicCharacterData(row, this);
                case 17:
                    return new LogicAreaEffectData(row, this);
                case 18:
                    return new LogicItemData(row, this);
                case 20:
                    return new LogicSkillData(row, this);
                case 23:
                    return new LogicCardData(row, this);
                case 27:
                    return new LogicTileData(row, this);
                case 28:
                    return new LogicPlayerThumbnailData(row, this);
                case 29:
                    return new LogicSkinData(row, this);
                case 41:
                    return new LogicThemeData(row, this);
                case 44:
                    return new LogicSkinConfData(row, this);

                default:
                    {
                        Debugger.Error("Invalid data table id: " + this._tableIndex);
                        break;
                    }
            }

            return data;
        }

        /// <summary>
        ///     Called for initialize datas.
        /// </summary>
        public void CreateReferences()
        {
            for (int i = 0; i < this._items.Count; i++)
            {
                this._items[i].AutoLoadData();
            }

            for (int i = 0; i < this._items.Count; i++)
            {
                this._items[i].CreateReferences();
            }
        }

        /// <summary>
        ///     Gets the item at specified index.
        /// </summary>
        public LogicData GetItemAt(int index)
        {
            return this._items[index];
        }

        /// <summary>
        ///     Gets the item at specified index.
        /// </summary>
        public LogicData GetDataByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < this._items.Count; i++)
                {
                    if (this._items[i].GetName().Equals(name))
                    {
                        return this._items[i];
                    }
                }
            }

            return null;
        }

        /// <summary>
        ///     Gets a item by id.
        /// </summary>
        public LogicData GetItemById(int globalId)
        {
            int instanceId = GlobalID.GetInstanceID(globalId);

            if (instanceId < 0 || instanceId >= this._items.Count)
            {
                Debugger.Warning("LogicDataTable::getItemById() - Instance id out of bounds! " + (instanceId + 1) + "/" + this._items.Count);
                return null;
            }

            return this._items[instanceId];
        }

        /// <summary>
        ///     Gets the number of items.
        /// </summary>
        public int GetItemCount()
        {
            return this._items.Count;
        }

        /// <summary>
        ///     Gets the index of this data table.
        /// </summary>
        public int GetTableIndex()
        {
            return this._tableIndex;
        }

        /// <summary>
        ///     Gets the name of this data table.
        /// </summary>
        public string GetTableName()
        {
            return this._table.GetFileName();
        }
    }
}
