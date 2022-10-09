namespace Reversivecell.Laser.Titan.Message.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TitanLoginMessage : PiranhaMessage
    {
        public override int GetMessageType()
        {
            return 10101;
        }

        public override int GetServiceNodeType()
        {
            return 1;
        }
    }
}
