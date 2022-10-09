namespace Reversivecell.Laser.Titan.CSV
{
    using System;
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Util;

    public class CSVNode
    {
        private readonly string _fileName;
        private CSVTable _table;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CSVNode" /> class.
        /// </summary>
        public CSVNode(string[] lines, string fileName)
        {
            try
            {
                this._fileName = fileName;
                this.Load(lines);
            } catch (Exception)
            {
                Console.WriteLine("Exception while processing file " + fileName);
            }
        }

        /// <summary>
        ///     Loads the csv file.
        /// </summary>
        public void Load(string[] lines)
        {
            this._table = new CSVTable(this, lines.Length);

            if (lines.Length >= 2)
            {
                LogicArrayList<string> columnNames = this.ParseLine(lines[0]);
                LogicArrayList<string> columnTypes = this.ParseLine(lines[1]);

                for (int i = 0; i < columnNames.Count; i++)
                {
                    this._table.AddColumn(columnNames[i]);
                }

                for (int i = 0; i < columnTypes.Count; i++)
                {
                    string type = columnTypes[i];
                    int columnType = -1;

                    if (!string.IsNullOrEmpty(type))
                    {
                        if (string.Equals(type, "string", StringComparison.InvariantCultureIgnoreCase))
                        {
                            columnType = 0;
                        }
                        else if (string.Equals(type, "int", StringComparison.InvariantCultureIgnoreCase))
                        {
                            columnType = 1;
                        }
                        else if (string.Equals(type, "boolean", StringComparison.InvariantCultureIgnoreCase))
                        {
                            columnType = 2;
                        }
                        else
                        {
                            Debugger.Error("Invalid column type '" + columnTypes[i] + "', column name " + columnNames[i] + ", file " + this._fileName + ". Expecting: int/string/boolean.");
                        }
                    }

                    this._table.AddColumnType(columnType);
                }

                this._table.ValidateColumnTypes();

                if (lines.Length > 2)
                {
                    for (int i = 2; i < lines.Length; i++)
                    {
                        LogicArrayList<string> values = this.ParseLine(lines[i]);

                        if (values.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(values[0]))
                            {
                                this._table.CreateRow();
                            }

                            for (int j = 0; j < values.Count; j++)
                            {
                                this._table.AddAndConvertValue(values[j], j);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Parses the specified line.
        /// </summary>
        public LogicArrayList<string> ParseLine(string line)
        {
            bool inQuote = false;
            string readField = string.Empty;

            LogicArrayList<string> fields = new LogicArrayList<string>();

            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (currentChar == '"')
                {
                    if (inQuote)
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            readField += currentChar;
                        }
                        else
                        {
                            inQuote = false;
                        }
                    }
                    else
                    {
                        inQuote = true;
                    }
                }
                else if (currentChar == ',' && !inQuote)
                {
                    fields.Add(readField);
                    readField = string.Empty;
                }
                else
                {
                    readField += currentChar;
                }
            }

            fields.Add(readField);

            return fields;
        }

        /// <summary>
        ///     Gets the file name.
        /// </summary>
        public string GetFileName()
        {
            return this._fileName;
        }

        /// <summary>
        ///     Gets the csv table.
        /// </summary>
        public CSVTable GetTable()
        {
            return this._table;
        }
    }
}