namespace Reversivecell.Laser.Servers.Core.Protocol.Message.Session
{
    using Reversivecell.Laser.Logic.Message;
    using Reversivecell.Laser.Titan.Message;

    public class ForwardPiranhaMessage : NetMessage
    {
        private PiranhaMessage _piranhaMessage;

        public void SetPiranhaMessage(PiranhaMessage message)
        {
            _piranhaMessage = message;
        }

        public PiranhaMessage RemovePiranhaMessage()
        {
            PiranhaMessage result = _piranhaMessage;
            _piranhaMessage = null;
            return result;
        }

        public override void Decode()
        {
            int type = Stream.ReadVInt();
            int length = Stream.ReadVInt();
            byte[] data = Stream.ReadBytes(length, 900000);

            PiranhaMessage message = LogicLaserMessageFactory.Instance.CreateMessageByType(type);
            if (message == null)
            {
                Logging.Error("ForwardPiranhaMessage.Decode - message is NULL!");
                return;
            }

            message.GetByteStream().SetByteArray(data, length);

            _piranhaMessage = message;
        }

        public override void Encode()
        {
            if (_piranhaMessage.GetByteStream().GetLength() == 0) _piranhaMessage.Encode();

            Stream.WriteVInt(_piranhaMessage.GetMessageType());
            Stream.WriteVInt(_piranhaMessage.GetEncodingLength());
            Stream.WriteBytesWithoutLength(_piranhaMessage.GetByteStream().GetByteArray(), _piranhaMessage.GetEncodingLength());
        }

        public override int GetMessageType()
        {
            return 10400;
        }
    }
}
