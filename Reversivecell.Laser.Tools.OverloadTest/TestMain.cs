namespace Reversivecell.Laser.Tools.OverloadTest
{
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Math;
    using Reversivecell.Laser.Tools.OverloadTest.Network;

    internal static class TestMain
    {
        public const string TargetServerHost = "3.65.75.53";
        public static LogicRandom Random { get; private set; }

        public const int CONNECTION_COUNT = 9339;

        public static void Init()
        {
            Console.Title = "Reversivecell.Laser.Tools.OverloadTest";

            Debugger.SetListener(new DebuggerListener());
            TestMain.Random = new LogicRandom((int)DateTime.Now.Ticks);

            for (int i = 0; i < CONNECTION_COUNT; i++)
            {
                ServerConnection connection = new ServerConnection(TargetServerHost);
                connection.ConnectTo();

                Thread.Sleep(100);
            }

            Thread.Sleep(-1);
        }

        private class DebuggerListener : IDebuggerListener
        {
            public void Error(string message)
            {
                Console.WriteLine($"[ERROR] {message}");
            }

            public void HudPrint(string message)
            {
                Console.WriteLine($"[INFO] {message}");
            }

            public void Print(string message)
            {
                Console.WriteLine($"[DEBUG] {message}");
            }

            public void Warning(string message)
            {
                Console.WriteLine($"[WARNING] {message}");
            }
        }
    }
}
