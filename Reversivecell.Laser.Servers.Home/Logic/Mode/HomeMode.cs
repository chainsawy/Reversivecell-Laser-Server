namespace Reversivecell.Laser.Servers.Home.Logic.Mode
{
    using Reversivecell.Laser.Logic.Avatar;
    using Reversivecell.Laser.Logic.Command;
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Logic.Home;
    using Reversivecell.Laser.Logic.Message.Home;
    using Reversivecell.Laser.Servers.Home.Logic.Command;
    using Reversivecell.Laser.Servers.Home.Session;
    using Reversivecell.Laser.Servers.Core;
    using Reversivecell.Laser.Servers.Core.Network.Utils;
    using Reversivecell.Laser.Titan.Util;
    using System;

    internal class HomeMode
    {
        private HomeSession _session;
        private LogicHomeMode _logicHomeMode;
        private LogicCommandManager _commandManager;

        private int _lastUpdate;
        private int _ticksGone;

        public HomeMode(HomeSession session, LogicHomeMode logicHomeMode, LogicCommandManager commandManager)        {
            _session = session;
            _logicHomeMode = logicHomeMode;
            _commandManager = commandManager;

            _ticksGone = 1;
            _lastUpdate = LogicTimeUtil.GetTimestamp();
        }

        public bool IsLogicStopped()
        {
            return _ticksGone == -1;
        }

        public LogicClientHome GetClientHome()
        {
            return _logicHomeMode.ClientHome;
        }

        public LogicClientAvatar GetClientAvatar()
        {
            return _logicHomeMode.ClientAvatar;
        }

        public void ClientTurnReceived(int tick, int checksum, LogicArrayList<LogicCommand> commands, bool shouldStopHomeLogic)
        {
            if (_commandManager == null)
            {
                if (_ticksGone == -1)
                {
                    Logging.Warning("HomeMode::clientTurnReceived client turn received when home logic is stopped.");
                }

                return;
            }

            if (tick > -1)
            {
                int currentTimestamp = LogicTimeUtil.GetTimestamp();
                int logicTimestamp = this._logicHomeMode.GetCurrentTimestamp() + (tick / 20);

                if (!_logicHomeMode.ClientAvatar.ShouldGoToFirstTutorialBattle())
                {
                    if (currentTimestamp >= logicTimestamp)
                    {
                        this.FastForward((LogicTimeUtil.GetTimestamp() - _lastUpdate) * 20);

                        if (commands.Count > 0)
                        {
                            for (int i = 0; i < commands.Count; i++)
                            {
                                _commandManager.AddCommand(commands[i]);
                            }
                        }

                        int serverChecksum = _logicHomeMode.CalculateChecksum();

                        if (serverChecksum != checksum)
                        {
                            OutOfSyncMessage outOfSyncMessage = new OutOfSyncMessage();
                            outOfSyncMessage.SetServerChecksum(serverChecksum);
                            outOfSyncMessage.SetClientChecksum(checksum);
                            outOfSyncMessage.SetTick(tick);

                            _session.ForwardPiranhaMessage(outOfSyncMessage, NetUtil.SERVICE_NODE_PROXY);

                            Logging.HudPrint(string.Format("HomeMode::clientTurnReceived out of sync, checksum: {0}, server checksum: {1}", checksum, serverChecksum));

                            return;
                        }

                        Logging.HudPrint(string.Format("HomeMode::clientTurnReceived clientTurn received, tick: {0}, checksum: {1}", tick, serverChecksum));
                    }
                    else
                    {
                        Logging.Warning("HomeMode::clientTurnReceived tick is too high! (" + tick + ")");
                    }
                }
            }
            else
            {
                Logging.Warning("HomeMode::clientTurnReceived tick is negative");
            }

            if (shouldStopHomeLogic)
            {
                _ticksGone = -1;

                _commandManager.Destruct();
                _commandManager = null;
            }
        }

        private void FastForward(int ticks)
        {
            _ticksGone += ticks;
            _commandManager.FastForward(ticks);
        }

        public static HomeMode ReloadHomeState(HomeMode home)
        {
            return LoadHomeState(home._session, home.GetClientHome(), home.GetClientAvatar());
        }

        public static HomeMode LoadHomeState(HomeSession session, LogicClientHome clientHome, LogicClientAvatar clientAvatar)
        {
            int currentTime = LogicTimeUtil.GetTimestamp();

            LogicHomeMode logicHomeMode = new LogicHomeMode(clientHome, clientAvatar, currentTime);
            LogicCommandManager commandManager = new LogicCommandManager(logicHomeMode);
            commandManager.SetListener(new CommandManagerListener(session));

            clientHome.GetDailyData().SetScore(clientAvatar.GetScore());
            clientHome.GetDailyData().SetHighestScore(clientAvatar.GetHighestScore());

            LogicThemeData theme = LogicDataTables.GetThemeByName("Bazaar");
            clientHome.GetConfData().AddIntValue(1, theme.GetGlobalID());
            clientHome.GetConfData().AddIntValue(46, 1);
            HomeMode homeMode = new HomeMode(session, logicHomeMode, commandManager);

            OwnHomeDataMessage ownHomeDataMessage = new OwnHomeDataMessage();
            ownHomeDataMessage.SetLogicClientHome(clientHome);
            ownHomeDataMessage.SetLogicClientAvatar(clientAvatar);
            ownHomeDataMessage.SetCurrentTimeInSecondsSinceEpoch(currentTime);
            session.ForwardPiranhaMessage(ownHomeDataMessage, NetUtil.SERVICE_NODE_PROXY);

            Logging.HudPrint($"HOME: Begin emulate home state. Id: {clientHome.GetHomeId()}, server time: {currentTime}");

            return homeMode;
        }

        public LogicCommandManager GetCommandManager()
        {
            return _commandManager;
        }
    }
}
