using System.Collections.Generic;
using System.Linq;
/*Name: Jun Yang LEE (Jayden)
 * ID: 30003668
 * Task: AT3 Final Project
 */
namespace AT3Project
{
    //Create simple repository class which will keep all the data in memory.
    class MockUserRepository
    {
        List<User> users = new List<User>();

        //Function to add the user to im memory dummy DB
        public void AddUser(User user)
        {
            users.Add(user);
        }

        //Function tp retrieve the user based on user id
        public User GetUser(string userid)
        {
            try
            {
                return users.Single(u => u.UserId == userid);
            }
            catch
            {
                return users.First();
            }

        }
    }
}
