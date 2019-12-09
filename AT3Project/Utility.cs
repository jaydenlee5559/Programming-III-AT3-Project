/*Name: Jun Yang LEE (Jayden)
 * ID: 30003668
 * Task: AT3 Final Project
 */
namespace AT3Project
{   //The utility class will convert string to byte[] and vis versa   
    class Utility
    {
        //utility function to convert string to bytes[]
        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        //utility function to convert byte[] to string
        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
