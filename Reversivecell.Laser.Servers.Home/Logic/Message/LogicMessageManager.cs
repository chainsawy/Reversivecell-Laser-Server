namespace Reversivecell.Laser.Servers.Home.Logic.Message
{
    using Reversivecell.Laser.Logic.Avatar;
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Home.Profile;
    using Reversivecell.Laser.Logic.Home.Profile.Entry;
    using Reversivecell.Laser.Logic.Message.Home;
    using Reversivecell.Laser.Servers.Home.Game;
    using Reversivecell.Laser.Servers.Home.Session;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Network.Utils;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Session;
    using Reversivecell.Laser.Titan.Message;
    using Reversivecell.Laser.Titan.Util;

    internal class LogicMessageManager
    {
        public HomeSession Session { get; }

        public LogicMessageManager(HomeSession session)
        {
            Session = session;
        }

        public void ReceiveMessage(PiranhaMessage message)
        {
            switch (message.GetMessageType())
            {
                case 14102:
                    this.EndClientTurnReceived((EndClientTurnMessage)message);
                    break;
                case 14109:
                    this.GoHomeFromOfflinePractiseReceived((GoHomeFromOfflinePractiseMessage)message);
                    break;
                case 14113:
                    this.GetPlayerProfileReceived((GetPlayerProfileMessage)message);
                    break;

                default:
                    Logging.Warning("LogicMessageManager::receiveMessage - no case for message of type " + message.GetMessageType());
                    break;
            }
        }

        private void GoHomeFromOfflinePractiseReceived(GoHomeFromOfflinePractiseMessage message)
        {
            if (!Session.HomeMode.IsLogicStopped())
            {
                SessionErrorMessage sessionErrorMessage = new SessionErrorMessage();
                sessionErrorMessage.ErrorCode = 39;
                Session.SendMessage(sessionErrorMessage, NetUtil.SERVICE_NODE_AVATAR);

                HomeSessionManager.TryRemove(Session.SessionId);
                return;
            }

            if (Session.HomeMode.GetClientAvatar().IsTutorialState())
            {
                Session.HomeMode.GetClientAvatar().SkipTutorial();
            }

            Session.ReloadHome();
        }

        private void GetPlayerProfileReceived(GetPlayerProfileMessage message)
        {
            HomeDocument document = HomeManager.GetDocument(message.GetAccountId());
            if (document != null)
            {
                LogicClientAvatar avatar = document.ClientAvatar;

                PlayerProfile profile = new PlayerProfile(avatar.GetAccountId(), avatar.GetName(), document.ClientHome.GetDailyData().GetPlayerThumbnail(), document.ClientHome.GetDailyData().GetExperience());

                LogicArrayList<LogicCardData> cards = avatar.GetAllHeroOrItemCards();
                for (int i = 0; i < cards.Count; i++)
                {
                    LogicCharacterData character = LogicDataTables.GetCharacterByName(cards[i].GetTarget());

                    int score = avatar.GetCommodityCount(1, character);
                    int highestScore = avatar.GetCommodityCount(2, character);
                    int powerLevel = avatar.GetCommodityCount(5, character) + 1;

                    profile.AddHeroEntry(new HeroEntry(character, score, highestScore, powerLevel));
                }

                profile.AddStat(1, 0); // trio wins
                profile.AddStat(2, document.ClientHome.GetDailyData().GetExperience());
                profile.AddStat(3, avatar.GetScore()); // score
                profile.AddStat(4, avatar.GetHighestScore()); // highest score
                profile.AddStat(5, cards.Count);
                profile.AddStat(7, document.ClientHome.GetDailyData().GetPlayerThumbnail().GetGlobalID());
                profile.AddStat(8, 0); // solo wins
                profile.AddStat(9, 0);
                profile.AddStat(10, 0);
                profile.AddStat(11, 0);
                profile.AddStat(12, 0);
                profile.AddStat(13, 0);
                profile.AddStat(14, 0);
                profile.AddStat(15, 0);

                PlayerProfileMessage playerProfileMessage = new PlayerProfileMessage();
                playerProfileMessage.SetPlayerProfile(profile);
                Session.ForwardPiranhaMessage(playerProfileMessage, NetUtil.SERVICE_NODE_PROXY);
            }
        }

        private void EndClientTurnReceived(EndClientTurnMessage message)
        {
            Session.HomeMode.ClientTurnReceived(message.GetClientTick(), message.GetClientChecksum(), message.GetCommands(), message.ShouldStopHomeLogic());
        }
    }
}
