﻿using System;
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
        public User currentUserS = new User(); // a current user object

        // User Management object
        UserManagement UserMgmt = new UserManagement();

        // Create a SQLite database object
        public SQLiteConnection database = new SQLiteConnection();

        public void CloseSignIn()
        {
            this.Close();
        }
      
        // Instantiation of the form, accepts a user object from the program class.
        public SignIn()
        {
            InitializeComponent();
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
                UserMgmt.AddUserToDB(currentUserS);
                UserMgmt.LoadUser(currentUserS);
                this.CloseSignIn();
            }
            // So program doesn't break if UC form closed
            else
            {
                currentUserS = new User();
            }
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            // When the sign in loads, check if the program database exists.
            DBManagement DB = new DBManagement();
            DB.checkForFiles();

            // Load the previous user lists based on database information.
            UserMgmt.FillLists();
            
            

            // For each user name in the list, add it as an option to the 
            // combobox dropdown selection menu on the sign in form.
            foreach (string s in UserMgmt.UserList)
            {
                this.cmbUser.Items.Add(s);
            }

            // Have the last user logged in as the default value in the combobox
            this.cmbUser.SelectedItem = UserMgmt.UserList[0];
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // Check if there's a value in the user combo box
            if (this.cmbUser.Text != null)
            {
                // If there is a selected value, loaad the user and close the form.
                UserMgmt.LoadUser(this.currentUserS, this.cmbUser.Text);
                this.CloseSignIn();
            }
        }
    }
}
