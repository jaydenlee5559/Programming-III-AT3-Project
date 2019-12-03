using System.Security.Cryptography;
/*Name: Jun Yang LEE (Jayden)
 * ID: 30003668
 * Task: AT3 Final Project
 */
namespace AT3Project
{
    //SHA256CryptoServiceProvider class to generate the hash.
    public class HashComputer
    {
        public string GetPasswordHashAndSalt(string message)
        {
            //Lets us use SHA256 algorithm to generate the hash from this salted password
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Utility.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            //return the hash string to the caller
            return Utility.GetString(resultBytes);
        }
    }
}
