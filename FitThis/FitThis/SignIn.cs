using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitThis
{
    public partial class SignIn : Form
    {
        // User object to store the current user
        User currentUserS = new User(); // a current user object

        // User Management object
        UserManagement UserMgmt = new UserManagement();

        // Create a SQLite database object
        public SQLiteConnection database = new SQLiteConnection();

        public void OpenFitThisHub()
        {
            FitThisHUB FB = new FitThisHUB(this.currentUserS);
            FB.Show();
            this.Close();
        }
      
        // Instantiation of the form, accepts a user object from the program class.
        public SignIn(User user1)
        {
            InitializeComponent();
            // Sets passes in user to current user.
            user1 = this.currentUserS;
        }

        /// <summary>
        /// Button will open new user form to allow addtion 
        /// of new user object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Create a new instance of the User creation form & show it.
            UserCreationForm UC = new UserCreationForm();
            UC.ShowDialog();
            currentUserS = UC.user1;
            if (currentUserS != null)
            {
                database = new SQLiteConnection("Data Source=FitThis.sqlite");
                UserMgmt.AddUserToDB(currentUserS, database);
                this.OpenFitThisHub();
            }
            // So program doesn't break if UC form closed
            else
            {
                currentUserS = new User();
            }
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

            // Connect to the database when the form loads.
            //this.CreateConnection();

            DBManagement DB = new DBManagement();
            DB.checkForFiles();
            
            UserMgmt.FillLists();
            
            

            // For each user name in the list, add it as an option to the 
            // combobox dropdown selection menu on the sign in form.
            foreach (string s in UserMgmt.UserList)
            {
                this.cmbUser.Items.Add(s);
            }

            // Have the last user logged in as the default value in the combobox
            //this.cmbUser.SelectedItem = UserMgmt.UserList[0];
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // Check if there's a value in the user combo box
            if (this.cmbUser.Text != null)
            {
                UserMgmt.LoadUser(this.currentUserS, this.cmbUser.Text, this.database);
                this.OpenFitThisHub();
            }
        }
    }
}
