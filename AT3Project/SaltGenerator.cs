using System.Security.Cryptography;
/*Name: Jun Yang LEE (Jayden)
 * ID: 30003668
 * Task: AT3 Final Project
 */
namespace AT3Project
{
    class SaltGenerator
    {
        // This class ensures that the generated number is always random and unique.
        private static RNGCryptoServiceProvider m_cryptoServiceProvider = null;
        private const int SALT_SIZE = 24;

        static SaltGenerator()
        {
            m_cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public static string GetSaltString()
        {
            //Lets create a byte array to store the salt bytes
            byte[] saltBytes = new byte[SALT_SIZE];

            //Lets generate the salt in the byte array
            m_cryptoServiceProvider.GetNonZeroBytes(saltBytes);

            //Lets us get some string representation for this salt
            string saltString = Utility.GetString(saltBytes);

            //Now we have our salt string ready Lets return it to the caller
            return saltString;
        }
    }
}
