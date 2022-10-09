namespace Reversivecell.Laser.Tools.OverloadTest.Network
{
    using LMKR;
    using Reversivecell.Laser.Titan.Debug;
    using Reversivecell.Laser.Titan.Message.Security;
    using Reversivecell.Laser.Tools.OverloadTest.Network.Security;
    using Starksoft.Aspen.Proxy;
    using System.Net;
    using System.Net.Sockets;

    internal class ServerConnection
    {
        public static readonly int[] PORT_TABLE =
        {
            9339, 1863, 3724, 30000, 843
        };

        private Messaging _messaging;
        private NetworkStream _stream;

        private byte[] _receiveBuffer;
        private int _bufferOffset;

        private string _host;
        private int _port;

        public ServerConnection(string host)
        {
            _port = (ushort)SelectRandomPort();

            TcpClient c = new TcpClient();
            c.Connect(host, SelectRandomPort());
            _stream = c.GetStream();
            _receiveBuffer = new byte[4096];
            _bufferOffset = 0;
            _host = host;

            _messaging = new Messaging(this);
        }

        public void ConnectTo()
        {
            Debugger.Print($"Successfully connected to {_host}:{_port}");

            ClientHelloMessage clientHelloMessage = new ClientHelloMessage();
            clientHelloMessage.Protocol = 2;
            clientHelloMessage.KeyVersion = PepperKey.VERSION;
            clientHelloMessage.ClientMajor = 27;
            clientHelloMessage.ClientBuild = 269;
            clientHelloMessage.ResourceSha = "260d4f57f4673d680bda4107a08d74c3b69f9674";
            clientHelloMessage.AppStore = 0;
            clientHelloMessage.DeviceType = 0;

            _messaging.SendPepperAuthentication(clientHelloMessage);
            StartReceive();
        }

        private void StartReceive()
        {
            _stream.BeginRead(_receiveBuffer, _bufferOffset, 4096 - _bufferOffset, new AsyncCallback(ReadCallback), this);
        }

        public void Write(byte[] data, int length)
        {
            _stream.BeginWrite(data, 0, length, new AsyncCallback(WriteCallback), this);
        }

        private static int SelectRandomPort()
        {
            return PORT_TABLE[TestMain.Random.Rand(5)];
        }

        private static void ReadCallback(IAsyncResult result)
        {
            try
            {
                ServerConnection connection = (ServerConnection)result.AsyncState;
                int r = connection._stream.EndRead(result);

                if (r <= 0)
                {
                    Debugger.Print("ReadCallback: connection closed.");
                    return;
                }

                connection._bufferOffset += r;
                r = connection._messaging.OnReceive(connection._receiveBuffer, connection._bufferOffset);

                if (r == -1) return;

                connection._bufferOffset -= r;
                connection.StartReceive();
            }
            catch (Exception e)
            {
              //  Debugger.Error("Exception occured " + e.GetType().Name);
               // Debugger.Error(e.StackTrace);
            }
        }

        private static void WriteCallback(IAsyncResult result)
        {
            try
            {
                ServerConnection connection = (ServerConnection)result.AsyncState;
                connection._stream.EndWrite(result);
            }
            catch (Exception)
            {
                ;
            }
        }
    }
}
