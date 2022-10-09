namespace Reversivecell.Laser.Servers.Proxy.Logic.Message
{
    using Reversivecell.Laser.Logic;
    using Reversivecell.Laser.Logic.Message.Account;
    using Reversivecell.Laser.Servers.Proxy.Network;
    using Reversivecell.Laser.Servers.Proxy.Network.Security;
    using Reversivecell.Laser.Servers.Proxy.Session;
    using Reversivecell.Laser.Servers.Core.Network.Utils;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Account;
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Message;
    using Reversivecell.Laser.Titan.Message.Account;
    using Reversivecell.Laser.Titan.Message.Security;
    using Reversivecell.Laser.Titan.Util;

    internal class MessageManager
    {
        public NetworkMessaging Messaging { get; }
        private int _lastKeepAlive;

        public MessageManager(NetworkMessaging messaging)
        {
            Messaging = messaging;
            _lastKeepAlive = LogicTimeUtil.GetTimestamp();
        }

        public bool IsAlive()
        {
            return (LogicTimeUtil.GetTimestamp() - _lastKeepAlive) < 30;
        }

        public void ReceiveMessage(PiranhaMessage message)
        {
            int messageType = message.GetMessageType();
            int serviceNodeType = message.GetServiceNodeType();
            if (messageType != 10100 && messageType != 10101 && messageType != 10108)
            {
                if (serviceNodeType != 1)
                {
                    ProxySession session = Messaging.Client.GetSession();
                    if (session != null)
                    {
                        session.ForwardPiranhaMessage(message, serviceNodeType);
                    }

                    return;
                }
            }

            switch (message.GetMessageType())
            {
                case 10100:
                    this.ClientHelloReceived((ClientHelloMessage)message);
                    break;
                case 10101:
                    this.LoginMessageReceived((LoginMessage)message);
                    break;
                case 10108:
                    this.KeepAliveReceived((KeepAliveMessage)message);
                    break;
            }
        }

        private void LoginMessageReceived(LoginMessage message)
        {
            if (this.Messaging.GetPepperState() == -1)
            {
                this.SendLoginFailed(8);
                return;
            }

            if (message.ClientMajor == LogicVersion.Major && message.ClientBuild == LogicVersion.Build)
            {
                ProxySession session = ProxySessionManager.Create(this.Messaging.Client);
                this.Messaging.Client.SetSession(session);

                AuthenticationRequestMessage request = new AuthenticationRequestMessage();
                request.AccountId = message.AccountId;
                request.PassToken = message.PassToken;
                request.Device = message.Device;
                session.SendMessage(request, NetUtil.SERVICE_NODE_ACCOUNT);
            }
            else
            {
                this.SendLoginFailed(8);
            }
        }

        private void KeepAliveReceived(KeepAliveMessage message)
        {
            if (this.Messaging.Client.State == 6)
            {
                this._lastKeepAlive = LogicTimeUtil.GetTimestamp();
                this.SendMessage(new KeepAliveServerMessage());
            }
        }

        private void ClientHelloReceived(ClientHelloMessage message)
        {
            if (message.Protocol == 2)
            {
                if (message.KeyVersion == PepperKey.VERSION && message.ClientMajor == LogicVersion.Major && message.ClientBuild == LogicVersion.Build)
                {
                    ServerHelloMessage hello = new ServerHelloMessage();
                    hello.SetSessionToken(this.Messaging.SessionToken);
                    this.SendMessage(hello);
                }
                else
                {
                    this.SendLoginFailed(8);
                }
            }
            else
            {
                this.SendLoginFailed(16);
            }
        }

        public void SendMessage(PiranhaMessage message)
        {
            if (!message.IsClientToServerMessage())
            {
                this.Messaging.Send(message);
            }
            else
            {
                Debugger.Warning("MessageManager::sendMessage - send client to server message type " + message.GetMessageType());
            }
        }

        public void SendLoginFailed(int errorCode, string reason = null)
        {
            LoginFailedMessage message = new LoginFailedMessage();
            message.ErrorCode = errorCode;
            message.Reason = reason;
            this.SendMessage(message);
        }
    }
}
