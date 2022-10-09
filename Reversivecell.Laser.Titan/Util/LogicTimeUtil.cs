namespace Reversivecell.Laser.Titan.Util
{
    public static class LogicTimeUtil
    {
        private static readonly DateTime _unixTime = new DateTime(1970, 1, 1);

        public static int GetTimestamp()
        {
            return (int) DateTime.UtcNow.Subtract(LogicTimeUtil._unixTime).TotalSeconds;
        }

        public static int GetTimestamp(DateTime time)
        {
            return (int) time.Subtract(LogicTimeUtil._unixTime).TotalSeconds;
        }

        public static string GetTimestampMS()
        {
            return DateTime.UtcNow.Subtract(LogicTimeUtil._unixTime).TotalMilliseconds.ToString("#");
        }

        public static DateTime GetDateTimeFromTimestamp(int timestamp)
        {
            return LogicTimeUtil._unixTime.AddSeconds(timestamp);
        }

        public static int GetDayIndex()
        {
            DateTime utcNow = DateTime.UtcNow;

            return (utcNow.Year * 1000 + utcNow.DayOfYear);
        }

        public static int GetTimeOfDay()
        {
            DateTime utcNow = DateTime.UtcNow;

            return (utcNow.Hour * 3600 + utcNow.Minute * 60 + utcNow.Second);
        }
    }
}