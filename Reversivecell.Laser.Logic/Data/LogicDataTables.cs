namespace Reversivecell.Laser.Logic.Data
{
    using Reversivecell.Laser.Titan.CSV;
    using Reversivecell.Laser.Titan.Debug;

    public static class LogicDataTables
    {
        private static LogicDataTable[] _dataTables;

        private static LogicResourceData _heroLvlUpMaterialData;

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            LogicDataTables._dataTables = new LogicDataTable[61];

            LogicDataTables.Load("csv/resources.csv", 5);
            LogicDataTables.Load("csv/projectiles.csv", 6);
            LogicDataTables.Load("csv/alliance_badges.csv", 8);
            LogicDataTables.Load("csv/locations.csv", 15);
            LogicDataTables.Load("csv/characters.csv", 16);
            LogicDataTables.Load("csv/area_effects.csv", 17);
            LogicDataTables.Load("csv/items.csv", 18);
            LogicDataTables.Load("csv/skills.csv", 20);
            LogicDataTables.Load("csv/cards.csv", 23);
            LogicDataTables.Load("csv/tiles.csv", 27);
            LogicDataTables.Load("csv/player_thumbnails.csv", 28);
            LogicDataTables.Load("csv/skins.csv", 29);
            LogicDataTables.Load("csv/themes.csv", 41);
            LogicDataTables.Load("csv/skin_confs.csv", 44);

            LogicDataTables._heroLvlUpMaterialData = LogicDataTables.GetResourceByName("HeroLvlUpMaterial");
        }

        /// <summary>
        ///     Loads the specified csv file.
        /// </summary>
        public static void Load(string path, int tableIndex)
        {
            if (File.Exists("Assets/" + path))
            {
                string[] lines = File.ReadAllLines("Assets/" + path);

                if (lines.Length > 1)
                {
                    LogicDataTables.LoadTable(new CSVNode(lines, path).GetTable(), tableIndex);
                }
            }
            else
            {
                Debugger.Warning("LogicDataTables::load file " + path + " not exist");
            }
        }

        public static void LoadTable(CSVTable table, int tableIndex)
        {
            LogicDataTables._dataTables[tableIndex] = new LogicDataTable(table, tableIndex);
        }

        public static int GetTableCount()
        {
            return 61;
        }

        /// <summary>
        ///     Gets a data reference by id.
        /// </summary>
        public static LogicData GetDataById(int globalId)
        {
            int tableIndex = GlobalID.GetClassID(globalId);

            if (tableIndex >= 0 && tableIndex <= 60 && LogicDataTables._dataTables[tableIndex] != null)
            {
                return LogicDataTables._dataTables[tableIndex].GetItemById(globalId);
            }

            return null;
        }

        public static LogicResourceData GetHeroLvlUpMaterialData()
        {
            return LogicDataTables._heroLvlUpMaterialData;
        }

        public static LogicResourceData GetResourceByName(string name)
        {
            return (LogicResourceData)LogicDataTables._dataTables[5].GetDataByName(name);
        }

        public static LogicCharacterData GetCharacterByName(string name)
        {
            return (LogicCharacterData)LogicDataTables._dataTables[16].GetDataByName(name);
        }

        public static LogicCardData GetCardByName(string name)
        {
            return (LogicCardData)LogicDataTables._dataTables[23].GetDataByName(name);
        }

        public static LogicProjectileData GetProjectileByName(string name)
        {
            return (LogicProjectileData)LogicDataTables._dataTables[6].GetDataByName(name);
        }

        public static LogicAllianceBadgeData GetAllianceBadgeByName(string name)
        {
            return (LogicAllianceBadgeData)LogicDataTables._dataTables[8].GetDataByName(name);
        }

        public static LogicLocationData GetLocationByName(string name)
        {
            return (LogicLocationData)LogicDataTables._dataTables[15].GetDataByName(name);
        }

        public static LogicAreaEffectData GetAreaEffectByName(string name)
        {
            return (LogicAreaEffectData)LogicDataTables._dataTables[17].GetDataByName(name);
        }

        public static LogicItemData GetItemByName(string name)
        {
            return (LogicItemData)LogicDataTables._dataTables[18].GetDataByName(name);
        }

        public static LogicSkillData GetSkillByName(string name)
        {
            return (LogicSkillData)LogicDataTables._dataTables[20].GetDataByName(name);
        }

        public static LogicTileData GetTileByName(string name)
        {
            return (LogicTileData)LogicDataTables._dataTables[27].GetDataByName(name);
        }

        public static LogicPlayerThumbnailData GetPlayerThumbnailByName(string name)
        {
            return (LogicPlayerThumbnailData)LogicDataTables._dataTables[28].GetDataByName(name);
        }

        public static LogicSkinData GetSkinByName(string name)
        {
            return (LogicSkinData)LogicDataTables._dataTables[29].GetDataByName(name);
        }

        public static LogicThemeData GetThemeByName(string name)
        {
            return (LogicThemeData)LogicDataTables._dataTables[41].GetDataByName(name);
        }

        public static LogicSkinConfData GetSkinConfByName(string name)
        {
            return (LogicSkinConfData)LogicDataTables._dataTables[44].GetDataByName(name);
        }
    }
}
