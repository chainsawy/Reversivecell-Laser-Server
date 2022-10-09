namespace Reversivecell.Laser.Servers.Core
{
    using System.Text;

    public class PrefixedOutput : TextWriter
    {
        private TextWriter _out;

        public PrefixedOutput(TextWriter outWriter)
        {
            _out = outWriter;
        }

        public override Encoding Encoding => Encoding.ASCII;

        public override void Write(string value)
        {
            _out.Write(value);
        }

        public override void WriteLine()
        {
            _out.WriteLine();
        }

        public override void WriteLine(string log)
        {
            if (log.Length < Console.WindowWidth)
            {
                Console.SetCursorPosition((Console.WindowWidth - log.Length) / 2, Console.CursorTop);
            }
            _out.WriteLine(log);
        }
    }
}
