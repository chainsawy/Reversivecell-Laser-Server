namespace Reversivecell.Laser.Servers.Proxy.Network
{
    using Reversivecell.Laser.Servers.Proxy.Logic.Message;
    using Reversivecell.Laser.Servers.Proxy.Session;

    internal class NetworkClient
    {
        private ProxySession _session;

        /// <summary>
        ///     Gets the client state.
        /// </summary>
        internal int State { get; set; }

        /// <summary>
        ///     Gets or Sets the device model.
        /// </summary>
        internal string DeviceModel { get; set; }

        /// <summary>
        ///     Gets the <see cref="NetworkMessaging"/> instance.
        /// </summary>
        internal NetworkMessaging Messaging { get; private set; }

        internal MessageManager MessageManager
        {
            get
            {
                return Messaging.MessageManager;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkClient"/> class.
        /// </summary>
        internal NetworkClient(NetworkMessaging messaging)
        {
            this.State = 1;
            this.Messaging = messaging;
        }

        /// <summary>
        ///     Destructs this instance.
        /// </summary>
        internal void Destruct()
        {
            this.State = -1;

            if (this._session != null)
            {
                ProxySessionManager.TryRemove(this._session.SessionId, out _);

                this._session.UnbindAllServers();
                this._session = null;
            }

            this.Messaging = null;
        }

        /// <summary>
        ///     Gets the client address.
        /// </summary>
        internal string GetAddress()
        {
            return this.Messaging.Connection.GetAddress();
        }

        /// <summary>
        ///     Gets the <see cref="NetProxySession"/> instance.
        /// </summary>
        internal ProxySession GetSession()
        {
            return this._session;
        }

        /// <summary>
        ///     Sets the <see cref="NetProxySession"/> instance.
        /// </summary>
        internal void SetSession(ProxySession session)
        {
            this._session = session;
        }
    }
}