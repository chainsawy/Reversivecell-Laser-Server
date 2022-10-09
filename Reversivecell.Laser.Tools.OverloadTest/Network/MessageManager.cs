namespace Reversivecell.Laser.Tools.OverloadTest.Network
{
    using Reversivecell.Laser.Logic.Message.Account;
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Message;
    using Reversivecell.Laser.Titan.Message.Security;

    internal class MessageManager
    {
        private Messaging _messaging;

        public MessageManager(Messaging messaging)
        {
            _messaging = messaging;
        }

        public void ReceiveMessage(PiranhaMessage message)
        {
            Debugger.Print($"MessageManager::ReceiveMessage - {message.GetType().Name}");

            switch (message.GetMessageType())
            {
                case 20100:
                    this.ServerHelloReceived((ServerHelloMessage)message);
                    break;
                case 20103:
                    this.LoginFailedReceived((LoginFailedMessage)message);
                    break;
                case 20104:
                    this.LoginOkReceived((LoginOkMessage)message);
                    break;
                default:
                    Debugger.Warning($"MessageManager::ReceiveMessage - no case for message of type {message.GetMessageType()}");
                    break;
            }
        }

        private void LoginOkReceived(LoginOkMessage message)
        {
            Debugger.HudPrint(string.Format("Logged in! (server version: {0}.{1} client version: {2}.{3} env: {4}, id: {5})",
                       message.MajorVersion, message.BuildVersion, 27, 269, message.ServerEnvironment, message.AccountId));
        }

        private void LoginFailedReceived(LoginFailedMessage message)
        {
            Debugger.Warning($"Login failed (error code = {message.ErrorCode})");
        }

        private void ServerHelloReceived(ServerHelloMessage message)
        {
            LoginMessage login = new LoginMessage();
            login.AccountId = 0;
            login.PassToken = null;
            login.ResourceSha = "260d4f57f4673d680bda4107a08d74c3b69f9674";
            login.UDID = "а негры тоже)))0";
            login.Device = "ReversedPhone";
            login.ClientMajor = 27;
            login.ClientBuild = 269;

            _messaging.SendPepperLogin(message, login);
        }

        public void SendMessage(PiranhaMessage message)
        {
            if (message.IsClientToServerMessage())
            {
                _messaging.Send(message);
            }
            else
            {
                Debugger.Error($"MessageManager::SendMessage - send server to client message type");
            }
        }
    }
}
