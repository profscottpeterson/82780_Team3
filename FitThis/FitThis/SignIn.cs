using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitThis
{
    public partial class SignIn : Form
    {
        List<string> UserList = new List<string>();
        List<int> UserIDList = new List<int>();

        public SignIn()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Create a new instance of the User creation form & show it.
            UserCreationForm UC = new UserCreationForm();
            UC.Show();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            // When the sign in form loads, we create a new instance of the 
            // FitThis hub form so we can connect to the program database.
            FitThisHUB FB = new FitThisHUB();
            FB.CreateConnection();
            // Set all users login value to false
            string sqlCurrentUserReset = "Update User Set CurrentUser = 0";
            SQLiteCommand command = new SQLiteCommand(sqlCurrentUserReset, FB.database);
            command.ExecuteNonQuery();

            // Create a query to select the list of user names from the database.
            String selectUsers = "Select Fname, LName, UserID from USER Order by LastLogin DESC";

            // Send the query to the database & execute.
            command = new SQLiteCommand(selectUsers, FB.database);

            // SQL query results returned to the reader.
            SQLiteDataReader reader = command.ExecuteReader();

            // For each of the results, add the first name and last name as a string
            // to a user list.
            while (reader.Read())
            {
                string Name = reader["Fname"].ToString() + " " + reader["LName"].ToString();
                this.UserList.Add(Name);
                this.UserIDList.Add(reader.GetInt32(2));
            }

            // Close the reader
            reader.Close();

            // For each user name in the list, add it as an option to the 
            // combobox dropdown selection menu on the sign in form.
            foreach (string u in this.UserList)
            {
                this.cmbUser.Items.Add(u);
            }

            // Have the last user logged in as the default value in the combobox
            this.cmbUser.SelectedItem = this.UserList[0];
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // Check if there's a value in the user combo box
            if (this.cmbUser.Text != null)
            {
                FitThisHUB FB = new FitThisHUB();
                FB.CreateConnection();

                int index = this.UserList.IndexOf(this.cmbUser.Text);
                int currentUserID = this.UserIDList.ElementAt(index);

                // once we have the correct user ID & corresponding primary
                // key in the table, we can update our current user field.
                // This will allow us to reference the current user from the Fit this Hub.

                string sqlUpdateCurrentUserField = "Update User Set CurrentUser = 1 Where UserID =" + currentUserID;
                SQLiteCommand command = new SQLiteCommand(sqlUpdateCurrentUserField, FB.database);
                command.ExecuteNonQuery();

                // Update last login time field 
                // TODO (this should be a separate method somewhere)
                DateTime loginTime = DateTime.Now;
                string loginTimeString = loginTime.ToShortDateString();
                string updateLastLogin = "Update User Set LastLogin ='" + loginTimeString +"'Where UserID =" + currentUserID;
                command = new SQLiteCommand(updateLastLogin, FB.database);
                command.ExecuteNonQuery();
            }
        }
    }
}
