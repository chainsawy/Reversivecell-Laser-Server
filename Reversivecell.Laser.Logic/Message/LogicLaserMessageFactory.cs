namespace Reversivecell.Laser.Logic.Message
{
    using Reversivecell.Laser.Logic.Message.Account;
    using Reversivecell.Laser.Logic.Message.Avatar;
    using Reversivecell.Laser.Logic.Message.Home;
    using Reversivecell.Laser.Titan.Message;
    using Reversivecell.Laser.Titan.Message.Account;
    using Reversivecell.Laser.Titan.Message.Security;

    public class LogicLaserMessageFactory : LogicMessageFactory
    {
        public static readonly LogicMessageFactory Instance;

        static LogicLaserMessageFactory()
        {
            Instance = new LogicLaserMessageFactory();
        }

        public override PiranhaMessage CreateMessageByType(int type)
        {
            if (type < 20000 || type == 30000)
            {
                switch (type)
                {
                    case 10100:
                        return new ClientHelloMessage();
                    case 10101:
                        return new LoginMessage();
                    case 10107:
                        return new ClientCapabilitiesMessage();
                    case 10108:
                        return new KeepAliveMessage();
                    case 10212:
                        return new ChangeAvatarNameMessage();
                    case 14102:
                        return new EndClientTurnMessage();
                    case 14109:
                        return new GoHomeFromOfflinePractiseMessage();
                    case 14113:
                        return new GetPlayerProfileMessage();
                }
            }
            else
            {
                switch (type)
                {
                    case 20100:
                        return new ServerHelloMessage();
                    case 20104:
                        return new LoginOkMessage();
                    case 20108:
                        return new KeepAliveServerMessage();
                    case 24101:
                        return new OwnHomeDataMessage();
                    case 24104:
                        return new OutOfSyncMessage();
                    case 24111:
                        return new AvailableServerCommandMessage();
                    case 24112:
                        return new UdpConnectionInfoMessage();
                    case 24113:
                        return new PlayerProfileMessage();
                    case 24115:
                        return new ServerErrorMessage();
                }
            }

            return null;
        }
    }
}
