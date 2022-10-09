namespace Reversivecell.Laser.Servers.Core.Protocol
{
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Account;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Avatar;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Battle;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Home;
    using Reversivecell.Laser.Servers.Core.Protocol.Message.Session;
    using Reversivecell.Laser.Titan.DataStream;

    public static class NetMessageFactory
    {
        public static NetMessage CreateMessageByType(int type)
        {
            switch (type)
            {
                case 10000:
                    return new StartSessionMessage();
                case 10001:
                    return new StopSessionMessage();

                case 10101:
                    return new AuthenticationRequestMessage();
                case 10400:
                    return new ForwardPiranhaMessage();
                case 14100:
                    return new AskForAvatarEntryMessage();
                case 14200:
                    return new ExecuteServerCommandMessage();
                case 14800:
                    return new BattleRequestMessage();

                case 20003:
                    return new SessionErrorMessage();
                case 20101:
                    return new AuthenticationResponseMessage();
                case 24100:
                    return new AvatarEntryMessage();
            }

            return null;
        }

        public static NetMessage DecodeMessage(ByteStream stream)
        {
            NetMessage message = NetMessageFactory.CreateMessageByType(stream.ReadVInt());
            if (message != null)
            {
                message.SetByteStream(stream);
                message.DecodeHeader();
                message.Decode();
            }
            return message;
        }

        public static byte[] EncodeMessage(NetMessage message)
        {
            ByteStream stream = new ByteStream(10);
            stream.WriteVInt(message.GetMessageType());

            message.SetByteStream(stream);
            message.EncodeHeader();
            message.Encode();

            return stream.GetByteArray().Take(stream.GetLength()).ToArray();
        }
    }
}
