namespace Reversivecell.Laser.Servers.Proxy.Network.ServerSocket
{
    using Reversivecell.Laser.Servers.Core;
    using System;
    using System.Net;
    using System.Net.Sockets;

    internal class NetworkTcpServerGateway : NetworkServerGateway
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="NetworkTcpServerGateway"/> class.
        /// </summary>
        internal NetworkTcpServerGateway(int port) : base(port)
        {
            Logging.Print("NetworkTcpServerGateway::NetworkTcpServerGateway listening on tcp port " + port);

            SocketAsyncEventArgs acceptEvent = new SocketAsyncEventArgs();
            acceptEvent.Completed += this.OnAcceptCompleted;
            acceptEvent.DisconnectReuseSocket = true;

            this.StartAccept(acceptEvent);
        }

        /// <summary>
        ///     Accepts a TCP Connection.
        /// </summary>
        /// <param name="acceptEvent">The <see cref="SocketAsyncEventArgs" /> instance containing the event data.</param>
        private void StartAccept(SocketAsyncEventArgs acceptEvent)
        {
            acceptEvent.AcceptSocket = null;

            if (!this._listener.AcceptAsync(acceptEvent))
            {
                this.OnAcceptCompleted(null, acceptEvent);
            }
        }

        /// <summary>
        ///     Called when the connection is accepted.
        /// </summary>
        private void OnAcceptCompleted(object sender, SocketAsyncEventArgs asyncEvent)
        {
            if (asyncEvent.SocketError == SocketError.Success)
            {
                NetworkTcpServerGateway.ProcessAccept(asyncEvent);
            }

            this.StartAccept(asyncEvent);
        }

        /// <summary>
        ///     Accept the new client and store it in memory.
        /// </summary>
        private static void ProcessAccept(SocketAsyncEventArgs asyncEvent)
        {
            if (asyncEvent.AcceptSocket.Connected)
            {
                Socket socket = asyncEvent.AcceptSocket;
                SocketAsyncEventArgs readEvent = new SocketAsyncEventArgs();

                readEvent.SetBuffer(new byte[1024], 0, 1024);
                readEvent.Completed += NetworkTcpServerGateway.OnReceiveCompleted;

                NetworkConnection connection = new NetworkConnection(socket, readEvent);

                if (NetworkMessagingManager.TryAdd(connection.Messaging))
                {
                    readEvent.UserToken = connection;

                    if (!socket.ReceiveAsync(readEvent))
                    {
                        NetworkTcpServerGateway.ProcessReceive(readEvent);
                    }
                }
            }
        }

        /// <summary>
        ///     Processes the received data.
        /// </summary>
        private static void ProcessReceive(SocketAsyncEventArgs asyncEvent)
        {
            if (asyncEvent.BytesTransferred > 0)
            {
                NetworkConnection connection = (NetworkConnection) asyncEvent.UserToken;

                if (!connection.IsDestructed())
                {
                    if (connection.TryReceive())
                    {
                        if (connection.Socket.Available == 0)
                        {
                            try
                            {
                                if (connection.Process())
                                {
                                    if (!connection.Messaging.IsDestructed())
                                    {
                                        if (!connection.Socket.ReceiveAsync(asyncEvent))
                                        {
                                            NetworkTcpServerGateway.ProcessReceive(asyncEvent);
                                        }
                                    }
                                }
                                else
                                {
                                    NetworkTcpServerGateway.Disconnect(asyncEvent);
                                }
                            }
                            catch (Exception)
                            {
                                NetworkTcpServerGateway.Disconnect(asyncEvent);
                            }
                        }
                        else
                        {
                            if (!connection.Socket.ReceiveAsync(asyncEvent))
                            {
                                NetworkTcpServerGateway.ProcessReceive(asyncEvent);
                            }
                        }
                    }
                    else
                    {
                        NetworkTcpServerGateway.Disconnect(asyncEvent);
                    }
                }
            }
            else
            {
                NetworkTcpServerGateway.Disconnect(asyncEvent);
            }
        }

        /// <summary>
        ///     Called when a receive event is completed.
        /// </summary>
        private static void OnReceiveCompleted(object sender, SocketAsyncEventArgs asyncEvent)
        {
            if (asyncEvent.SocketError == SocketError.Success)
            {
                NetworkTcpServerGateway.ProcessReceive(asyncEvent);
            }
            else
            {
                NetworkTcpServerGateway.Disconnect(asyncEvent);
            }
        }

        /// <summary>
        ///     Sends the specified message.
        /// </summary>
        internal static void Send(byte[] packet, int length, NetworkConnection connection)
        {
            if (connection.IsConnected())
            {
                SocketAsyncEventArgs writeEvent = new SocketAsyncEventArgs();

                writeEvent.Completed += NetworkTcpServerGateway.OnSendCompleted;
                writeEvent.UserToken = connection;
                writeEvent.SetBuffer(packet, 0, length);

                try
                {
                    if (!connection.Socket.SendAsync(writeEvent))
                    {
                        NetworkTcpServerGateway.OnSendCompleted(null, writeEvent);
                    }
                }
                catch (Exception)
                {
                    Logging.Error("NetworkTcpServerGateway::send socket->send");
                }
            }
        }

        /// <summary>
        ///     Called when the send event is completed.
        /// </summary>
        private static void OnSendCompleted(object sender, SocketAsyncEventArgs asyncEvent)
        {
            asyncEvent.Dispose();
        }

        /// <summary>
        ///     Disconnects the specified socket.
        /// </summary>
        internal static void Disconnect(SocketAsyncEventArgs asyncEvent)
        {
            if (asyncEvent.UserToken != null)
            {
                NetworkTcpServerGateway.Disconnect((NetworkConnection) asyncEvent.UserToken);
                asyncEvent.Dispose();
            }
        }

        /// <summary>
        ///     Disconnects the specified socket.
        /// </summary>
        internal static void Disconnect(NetworkConnection connection)
        {
            if (connection.Messaging != null)
            {
                if (NetworkMessagingManager.TryRemove(connection.Messaging))
                {
                    connection.Destruct();
                }
            }
        }
    }
}