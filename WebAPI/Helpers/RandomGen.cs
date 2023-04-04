using System.Security.Cryptography;

namespace WebAPI.Helpers
{
    public class RandomGen
    {
        private static RNGCryptoServiceProvider _global = new RNGCryptoServiceProvider();

        [ThreadStatic]
        private static Random _local;

        public static double NextDouble()
        {
            Random i = _local;

            if(i == null)
            {
                byte[] buffer = new byte[4];
                _global.GetBytes(buffer);
                _local = i = new Random(BitConverter.ToInt32(buffer, 0));
            }
            return i.NextDouble();
        }


    }
}
