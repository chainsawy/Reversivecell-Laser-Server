namespace Reversivecell.Laser.Logic.Data
{
    public static class GlobalID
    {
        /// <summary>
        ///     Creates a new global id.
        /// </summary>
        public static int CreateGlobalID(int classId, int instanceId)
        {
            return 1000000 * classId + instanceId;
        }

        /// <summary>
        ///     Gets the instance id.
        /// </summary>
        public static int GetInstanceID(int globalId)
        {
            return globalId % 1000000;
        }

        /// <summary>
        ///     Gets the class id.
        /// </summary>
        public static int GetClassID(int globalId)
        {
            return globalId / 1000000;
        }
    }
}
