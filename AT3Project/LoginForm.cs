using System;
using System.Windows.Forms;
/*Name: Jun Yang LEE (Jayden)
 * ID: 30003668
 * Task: AT3 Final Project
 */
namespace AT3Project
{
    public partial class LoginForm : Form //Question 7 - Contain GUI
    {
        // Dummy repository class for DB operations
        static MockUserRepository userRepo = new MockUserRepository();
        // Let us use the Password manager class to generate the password and salt
        static PasswordManager pwdManager = new PasswordManager();
        public LoginForm()
        {
            InitializeComponent();
            InitialiseDefaultUser(); //initial default user while the form is been run
        }
        //method to create first default user 
        private void InitialiseDefaultUser()
        {
            string userid = "zcxzcxzcxvbxcvcxzcxzcxzzxczczxczxczxczxcxz";
            string password = "zcxzcxzcxvbxcvcxzcxzcxzzxczczxczxczxczxcxz";
            string salt = null;
            string passwordHash = pwdManager.GeneratePasswordHash(password, out salt);
            // save the values in the database
            User initialUser = new User
            {
                UserId = userid,
                PasswordHash = passwordHash,
                Salt = salt
            };
            userRepo.AddUser(initialUser);

        }
        //Question 2 - Contain hashing techniques
        //sign up method to create user
        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbSignUpUsername.Text) && !String.IsNullOrEmpty(tbSignUpPassword.Text))
            {
                //capture details from user input
                string signUpUserName = tbSignUpUsername.Text;
                string signUpPassword = tbSignUpPassword.Text;
                string salt = null;
                string passwordHash = pwdManager.GeneratePasswordHash(signUpPassword, out salt);
                //add values into database
                User newUser = new User
                {
                    UserId = signUpUserName,
                    PasswordHash = passwordHash,
                    Salt = salt
                };
                userRepo.AddUser(newUser);

                MessageBox.Show("Sign Up completed!");
                tbSignUpUsername.Clear();
                tbSignUpPassword.Clear();

            }
            else
            {
                MessageBox.Show("Username and password must not empty!");
            }
        }
        //Question 2 - Contain hashing techniques
        //login method
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //capture username and password from user input
            string loginUsername = tbLoginUsername.Text;
            string loginPassword = tbLoginPassword.Text;

            //check if user existing in user class
            User user = userRepo.GetUser(loginUsername);
            //check password matching with password manager class
            bool result = pwdManager.IsPasswordMatch(loginPassword, user.Salt, user.PasswordHash);
            if (result)
            {
                MessageBox.Show("Password Matched");
                MusicPlayer mp = new MusicPlayer(); // if password match open up music player form
                mp.Show();
                tbLoginUsername.Clear();
                tbLoginPassword.Clear();
            }
            else
            {
                MessageBox.Show("Password not Matched");// password not match
                tbLoginUsername.Clear();
                tbLoginPassword.Clear();
            }

        }
    }
}
