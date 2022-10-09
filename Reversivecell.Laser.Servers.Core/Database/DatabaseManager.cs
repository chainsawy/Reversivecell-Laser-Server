namespace Reversivecell.Laser.Servers.Core.Database
{
    using System;
    using System.Collections.Generic;

    using Reversivecell.Laser.Titan.Util;

    using Couchbase.Configuration.Client;
    using Reversivecell.Laser.Servers.Core.Settings;

    public static class DatabaseManager
    {
        private static LogicArrayList<CouchbaseDatabase[]> _databases;

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public static void Initialize(string bucketName)
        {
            if (DatabaseManager._databases == null)
            {
                DatabaseManager._databases = new LogicArrayList<CouchbaseDatabase[]>();
            }

            CouchbaseDatabase[] databases = new CouchbaseDatabase[1];

            for (int i = 0; i < databases.Length; i++)
            {
                databases[i] = new CouchbaseDatabase(i, new ClientConfiguration
                {
                    Servers = new List<Uri>
                    {
                        new Uri("http://" + ServerConfiguration.DatabaseUrl)
                    }
                }, bucketName, ServerConfiguration.DatabaseUser, ServerConfiguration.DatabasePasswd);
            }

            DatabaseManager._databases.Add(databases);
        }

        /// <summary>
        ///     Inserts the specified document.
        /// </summary>
        public static void Insert(int bucketIdx, long key, string json)
        {
            CouchbaseDatabase database = DatabaseManager._databases[bucketIdx][key >> 32];

            if (database != null)
            {
                database.InsertDocument(key, json);
            }
        }

        /// <summary>
        ///     Updates the specified document.
        /// </summary>
        public static void Update(int bucketIdx, long key, string json)
        {
            CouchbaseDatabase database = DatabaseManager._databases[bucketIdx][key >> 32];

            if (database != null)
            {
                database.UpdateDocument(key, json);
            }
        }

        /// <summary>
        ///     Gets the number of database.
        /// </summary>
        public static int GetDatabaseCount(int bucketIdx)
        {
            return DatabaseManager._databases[bucketIdx].Length;
        }

        /// <summary>
        ///     Gets the database instance at the specified idx.
        /// </summary>
        public static CouchbaseDatabase GetDatabaseAt(int bucketIdx, int idx)
        {
            return DatabaseManager._databases[bucketIdx][idx];
        }
    }
}
