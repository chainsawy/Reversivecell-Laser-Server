namespace Reversivecell.Laser.Titan.Library.Blake
{
    public abstract class NodeHasher
    {
        public abstract void Init(int depth, long nodeOffset);

        public abstract byte[] Finish(bool isEndOfLayer);

        public abstract void Update(byte[] data, int start, int count);

        public void Update(byte[] data)
        {
            Update(data, 0, data.Length);
        }
    }
}