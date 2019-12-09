using System;
using System.Windows.Forms;
/*Name: Jun Yang LEE (Jayden)
 * ID: 30003668
 * Task: AT3 Final Project
 */
namespace AT3Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
