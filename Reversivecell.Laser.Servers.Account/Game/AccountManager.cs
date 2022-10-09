namespace Reversivecell.Laser.Servers.Account.Game
{
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Database;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Titan.Util;

    internal static class AccountManager
    {
        private static int _maxLowId;
        private static CouchbaseDatabase _database;

        private const string PASS_TOKEN_CHARS = "abcdefghijklmnopqrstuvwxyz0123456789";

        public static void Init()
        {
            DatabaseManager.Initialize("laser-account");
            _database = DatabaseManager.GetDatabaseAt(0, 0);

            _maxLowId = _database.GetHigherId();
        }

        public static bool TryGet(LogicLong accountId, out AccountDocument account)
        {
            string json = _database.GetDocument(accountId);
            if (json != null)
            {
                account = new AccountDocument();
                account.Load(json);
                return true;
            }

            account = null;
            return false;
        }

        public static void Update(AccountDocument account)
        {
            _database.UpdateDocument(account.Id, account.Save());
        }

        public static AccountDocument Create()
        {
            LogicLong id = new LogicLong(0, ++_maxLowId);
            string token = AccountManager.GeneratePassToken();

            AccountDocument document = new AccountDocument(id, token);
            document.AccountCreationTime = LogicTimeUtil.GetTimestamp();
            _database.InsertDocument(id, document.Save());

            return document;
        }

        /// <summary>
        ///     Generates a random pass token.
        /// </summary>
        private static string GeneratePassToken()
        {
            string passToken = null;

            for (int i = 0, rnd = 0; i < 40; i++, rnd >>= 8)
            {
                if (i % 4 == 0)
                {
                    rnd = ServerCore.Random.Rand(0x7fffffff);
                }

                passToken += AccountManager.PASS_TOKEN_CHARS[rnd % AccountManager.PASS_TOKEN_CHARS.Length];
            }

            return passToken;
        }
    }
}
