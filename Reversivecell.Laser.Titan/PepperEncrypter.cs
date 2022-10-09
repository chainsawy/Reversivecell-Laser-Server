namespace Reversivecell.Laser.Titan
{
    using Reversivecell.Laser.Titan.Libs.NaCl;

    public class PepperEncrypter : StreamEncrypter
    {
        public byte[] _key;
        public byte[] _nonce;

        public PepperEncrypter(byte[] key, byte[] nonce)
        {
            _key = key;
            _nonce = nonce;
        }

        public override int Decrypt(byte[] input, byte[] output, int length)
        {
            this.NextNonce();

            byte[] a = TweetNaCl.crypto_secretbox_xsalsa19poly1305_tweet_open(input.Take(length).ToArray(), _nonce, _key);
            if (a == null) return -1;

            Buffer.BlockCopy(a, 0, output, 0, length - GetOverheadEncryption());

            return 0;
        }

        public override int Encrypt(byte[] input, byte[] output, int length)
        {
            this.NextNonce();

            byte[] a = TweetNaCl.crypto_secretbox_xsalsa19poly1305_tweet(input.Take(length).ToArray(), _nonce, _key);
            if (a == null) return -1;

            Buffer.BlockCopy(a, 0, output, 0, length + GetOverheadEncryption());

            return 0;
        }

        public override int GetOverheadEncryption()
        {
            return 16;
        }

        private void NextNonce()
        {
            int v8 = 2;
            for (int i = 0; i != 24; i++)
            {
                int v10 = v8 + this._nonce[i];
                this._nonce[i] = (byte)v10;
                v8 = v10 / 256;
            }
        }
    }
}
