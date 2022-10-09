namespace Reversivecell.Laser.Servers.Core
{
    using Reversivecell.Laser.Titan.Debug;
    using MSDebug = System.Diagnostics.Debug;

    public static class Logging
    {
        public static void Init()
        {
            Debugger.SetListener(new DebuggerListener());
        }

        public static void HudPrint(string log)
        {
            Logging.Log(log, "[DEBUG] ", ConsoleColor.Red);
        }

        public static void Print(string log)
        {
            MSDebug.WriteLine("[DEBUG] " + log);
        }

        public static void Warning(string log)
        {
            Logging.Log(log, "[WARNING] ", ConsoleColor.Red);
        }

        public static void Error(string log)
        {
            Logging.Log(log, "[ERROR] ", ConsoleColor.Red);
        }

        private static void Log(string log, string prefix, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{prefix}{log}");
            Console.ResetColor();
        }
    }

    public class DebuggerListener : IDebuggerListener
    {
        public void Error(string message)
        {
            Console.WriteLine("[LOGIC] " + message);
        }

        public void HudPrint(string message)
        {
            ;
        }

        public void Print(string message)
        {
            MSDebug.WriteLine("[LOGIC] " + message);
        }

        public void Warning(string message)
        {
            Console.WriteLine("[LOGIC] " + message);
        }
    }
}
