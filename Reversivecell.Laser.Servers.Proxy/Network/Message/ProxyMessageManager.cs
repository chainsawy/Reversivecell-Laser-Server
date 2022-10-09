namespace Reversivecell.Laser.Servers.Proxy.Network.Message
{
    using Reversivecell.Laser.Logic;
    using Reversivecell.Laser.Logic.Message.Account;
    using Reversivecell.Laser.Servers.Proxy.Session;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Network.Utils;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Account;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Session;

    internal class ProxyMessageManager : NetMessageManager
    {
        public override void ReceiveMessage(NetMessage message)
        {
            switch (message.GetMessageType())
            {
                case 20101:
                    this.AuthenticationResponseReceived((AuthenticationResponseMessage)message);
                    break;
                case 10400:
                    this.ForwardPiranhaMessageReceived((ForwardPiranhaMessage)message);
                    break;
            }
        }

        private void ForwardPiranhaMessageReceived(ForwardPiranhaMessage message)
        {
            if (ProxySessionManager.TryGet(message.SessionId, out ProxySession session))
            {
                session.Client.MessageManager.SendMessage(message.RemovePiranhaMessage());
            }
        }

        private void AuthenticationResponseReceived(AuthenticationResponseMessage message)
        {
            if (ProxySessionManager.TryGet(message.SessionId, out ProxySession session))
            {
                if (message.Status == 0)
                {
                    LoginOkMessage loginOk = new LoginOkMessage();
                    loginOk.AccountId = message.AccountId;
                    loginOk.HomeId = message.AccountId;
                    loginOk.PassToken = message.PassToken;
                    loginOk.SessionCount = message.SessionCount;
                    loginOk.PlayTimeSeconds = message.PlayTimeSeconds;
                    loginOk.DaysSinceStartedPlaying = message.DaysSinceStartedPlaying;
                    loginOk.MajorVersion = LogicVersion.Major;
                    loginOk.BuildVersion = LogicVersion.Build;
                    loginOk.ServerEnvironment = ServerCore.Environment;
                    session.Client.MessageManager.SendMessage(loginOk);

                    session.SetAccountId(message.AccountId);
                    session.BindServer(NetUtil.SERVICE_NODE_AVATAR);
                }
                else
                {
                    switch (message.Status)
                    {
                        case 1:
                            session.Client.MessageManager.SendLoginFailed(1);
                            break;
                        case 2:
                            session.Client.MessageManager.SendLoginFailed(0, "Internal Server Error");
                            break;
                    }
                }
            }
        }
    }
}
