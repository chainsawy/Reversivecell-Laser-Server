namespace Reversivecell.Laser.Servers.Avatar.Game
{
    using Newtonsoft.Json.Linq;
    using Reversivecell.Laser.Servers.Core.Database;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Util;
    using System.Collections.Concurrent;

    internal static class AvatarManager
    {
        private static CouchbaseDatabase _database;
        private static ConcurrentDictionary<long, AvatarDocument> _cachedDocuments;

        public static void Init()
        {
            DatabaseManager.Initialize("laser-avatar");
            _cachedDocuments = new ConcurrentDictionary<long, AvatarDocument>();
            _database = DatabaseManager.GetDatabaseAt(0, 0);

            new Thread(Update).Start();
        }

        private static void Update()
        {
            while (true)
            {
                Thread.Sleep(1000 * 60);

                foreach (AvatarDocument document in _cachedDocuments.Values.ToArray())
                {
                    _database.UpdateDocument(document.Id, document.Save().ToString());
                    if (LogicTimeUtil.GetTimestamp() - document.DocumentLastActionTime > 60 * 15) // caching - 15 minutes.
                    {
                        _cachedDocuments.Remove(document.Id, out _);
                    }
                }
            }
        }

        public static void UpdateDocument(AvatarDocument document)
        {
            if (GetDocument(document.Id) != null)
            {
                _cachedDocuments[document.Id] = document;
            }
        }

        public static AvatarDocument GetDocument(LogicLong id, bool createIfNotExists = false)
        {
            if (!_cachedDocuments.TryGetValue(id, out AvatarDocument document))
            {
                string json = _database.GetDocument(id);
                if (json != null)
                {
                    document = new AvatarDocument();
                    document.Load(JObject.Parse(json));
                    _cachedDocuments[id] = document;

                    return document;
                }

                if (!createIfNotExists)
                    return null;

                document = new AvatarDocument();
                document.Id = id;
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
