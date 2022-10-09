namespace Reversivecell.Laser.Logic.Helper
{
    using Reversivecell.Laser.Logic.Data;
    using Reversivecell.Laser.Titan.DataStream;
    using Reversivecell.Laser.Titan.Math;

    public static class ByteStreamHelper
    {
        public static void EncodeLogicLong(ChecksumEncoder encoder, LogicLong value)
        {
            encoder.WriteVInt(value.GetHigherInt());
            encoder.WriteVInt(value.GetLowerInt());
        }

        public static LogicLong DecodeLogicLong(ByteStream stream)
        {
            int high = stream.ReadVInt();
            int low = stream.ReadVInt();

            return new LogicLong(high, low);
        }

        public static void WriteDataReference(ChecksumEncoder encoder, LogicData data)
        {
            if (data == null)
            {
                encoder.WriteVInt(0);
                return;
            }

            int globalId = data.GetGlobalID();
            encoder.WriteVInt(GlobalID.GetClassID(globalId));
            encoder.WriteVInt(GlobalID.GetInstanceID(globalId));
        }

        public static LogicData ReadDataReference(ByteStream stream)
        {
            int classId = stream.ReadVInt();
            if (classId == 0)
            {
                return null;
            }

            int instanceId = stream.ReadVInt();
            int globalId = GlobalID.CreateGlobalID(classId, instanceId);
            return LogicDataTables.GetDataById(globalId);
        }
    }
}
