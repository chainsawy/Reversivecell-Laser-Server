namespace Reversivecell.Laser.Servers.Account.Network.Message
{
    using Reversivecell.Laser.Servers.Account.Game;
    using Reversivecell.Laser.Servers.Core.Protocol;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Account;
    using Reversivecell.Laser.Titan.Util;

    internal class AccountMessageManager : NetMessageManager
    {
        public override void ReceiveMessage(NetMessage message)
        {
            switch (message.GetMessageType())
            {
                case 10101:
                    this.AuthenticationRequestReceived((AuthenticationRequestMessage)message);
                    break;
            }
        }

        private void AuthenticationRequestReceived(AuthenticationRequestMessage message)
        {
            AuthenticationResponseMessage response = new AuthenticationResponseMessage();

            if (message.AccountId == 0 && message.PassToken == null)
            {
                AccountDocument account = AccountManager.Create();
                account.SessionStarted();
                AccountManager.Update(account);

                response.Status = 0;
                response.AccountId = account.Id;
                response.PassToken = account.PassToken;
                response.SessionCount = account.SessionCount;
                response.DaysSinceStartedPlaying = (LogicTimeUtil.GetTimestamp() - account.AccountCreationTime) / (3600 * 24);
            }
            else
            {
                if (AccountManager.TryGet(message.AccountId, out AccountDocument account))
                {
                    if (account.PassToken == message.PassToken)
                    {
                        response.Status = 0;
                        response.AccountId = account.Id;
                        response.PassToken = account.PassToken;
                        response.SessionCount = account.SessionCount;
                        response.DaysSinceStartedPlaying = (LogicTimeUtil.GetTimestamp() - account.AccountCreationTime) / (3600 * 24);
                    }
                    else
                    {
                        response.Status = 1;
                    }
                }
                else
                {
                    response.Status = 1;
                }
            }

            NetMessageManager.Send(response, message.ServiceNode, message.SessionId);
        }
    }
}
