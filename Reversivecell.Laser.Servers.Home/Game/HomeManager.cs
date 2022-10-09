namespace Reversivecell.Laser.Servers.Home.Game
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Servers.Core.Database;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Util;
    using System.Collections.Concurrent;

    internal static class HomeManager
    {
        private static CouchbaseDatabase _database;
        private static ConcurrentDictionary<long, HomeDocument> _cachedDocuments;

        public static void Init()
        {
            DatabaseManager.Initialize("laser-home");
            _cachedDocuments = new ConcurrentDictionary<long, HomeDocument>();
            _database = DatabaseManager.GetDatabaseAt(0, 0);

            new Thread(Update).Start();
        }

        private static void Update()
        {
            while (true)
            {
                Thread.Sleep(1000 * 60);

                foreach (HomeDocument document in _cachedDocuments.Values.ToArray())
                {
                    _database.UpdateDocument(document.Id, document.Save().ToString());
                    if (LogicTimeUtil.GetTimestamp() - document.DocumentLastActionTime > 60 * 15) // caching - 15 minutes.
                    {
                        _cachedDocuments.Remove(document.Id, out _);
                    }
                }
            }
        }

        public static void UpdateDocument(HomeDocument document)
        {
            if (GetDocument(document.Id) != null)
            {
                _cachedDocuments[document.Id] = document;
            }
        }

        public static HomeDocument GetDocument(LogicLong id, bool createIfNotExists = false)
        {
            if (!_cachedDocuments.TryGetValue(id, out HomeDocument document))
            {
                string json = _database.GetDocument(id);
                if (json != null)
                {
                    document = new HomeDocument();
                    document.Load(JObject.Parse(json));
                    _cachedDocuments[id] = document;

                    return document;
                }

                if (!createIfNotExists)
                    return null;

                document = new HomeDocument();
                document.Init(id);
                document.DocumentLastActionTime = LogicTimeUtil.GetTimestamp();

                _database.InsertDocument(id, document.Save().ToString());
                _cachedDocuments[id] = document;

                return document;
            }

            document.DocumentLastActionTime = LogicTimeUtil.GetTimestamp();
            return document;
        }
    }
}
