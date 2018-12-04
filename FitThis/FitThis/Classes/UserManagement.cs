using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitThis
{
    /// <summary>
    /// The user management class contains methods related to loading user information from 
    /// the SQLite database.
    /// </summary>
    class UserManagement
    {
        //SQLiteCommand command = null;
        //SQLiteDataReader reader = null;
        public List<string> UserList = new List<string>();
        public List<int> UserIDList = new List<int>();
        DBManagement dbm = new DBManagement();
        //Activity active = new Activity();
        //public int UserNum;

        /// <summary>
        /// Method to fill log in list on sign in page and a second list to hold corresponding
        /// user ID's
        /// </summary>
        public void FillLists()
        {
            // Create a query to select the list of user names from the database.
            String selectUsers = "Select Fname, LName, UserID from USER Order by LastLogin DESC";
            
            // Database access to send query and retrieve information
            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(selectUsers, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Concatenate first and last name before adding to user name list.
                            string Name = reader["Fname"].ToString() + " " + reader["LName"].ToString();
                            this.UserList.Add(Name);
                            
                            // Add user ID to corresponding list.
                            this.UserIDList.Add(reader.GetInt32(2));
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Overloaded LoadUser method, for newly created users.
        /// Given a user object, load all database information for this user and return user.
        /// </summary>
        /// <param name="user1"> The passed in user object<param>
        /// <returns></returns>
        public User LoadUser(User user1)
        {
            // SQL string to find the newly created user object in the database and load all fields.
            string sqlFindUser = "SELECT * FROM USER WHERE USER.FName = '" + user1.FName +
            "' AND USER.LName = '" + user1.LName + "'";

            // Database connection to find user.
            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFindUser, c))
                {
                    // Assign user information from the reader object.
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        user1.UserID = reader.GetInt32(0);
                        user1.FName = reader.GetString(1);
                        user1.LName = reader.GetString(2);
                        user1.StartingWeight = reader.GetInt32(3);
                        user1.GoalWeight = reader.GetInt32(4);
                        user1.Age = reader.GetInt32(5);
                        user1.RecommendIntake = reader.GetInt32(6);

                    }
                }
            }
            // return a reference to the filled user object.
            return user1;
        }

        /// <summary>
        /// Loads a user object for a user that has previously used the program, 
        /// given a user object and the userName.
        /// </summary>
        /// <param name="user1"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User LoadUser(User user1, string userName)
        {
            // Find the user ID, given a user name.
            int userID = 0;
            foreach (string s in this.UserList)
            {
                // Search through user list until Name found & assign 
                // user ID from userID list.
                if (s == userName)
                {
                    userID = this.UserIDList[this.UserList.IndexOf(s)];
                    break;
                }
            }

            // Based on the user ID, query the database for user information.
            string sqlFindUser = "SELECT * FROM USER WHERE UserID =" + userID.ToString();

            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFindUser, c))
                {
                    // Load in user information from database reaer.
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        user1.UserID = reader.GetInt32(0);
                        user1.FName = reader.GetString(1);
                        user1.LName = reader.GetString(2);
                        user1.StartingWeight = reader.GetInt32(3);
                        user1.GoalWeight = reader.GetInt32(4);
                        user1.Age = reader.GetInt32(5);
                        user1.RecommendIntake = reader.GetInt32(6);
                        
                    }
                }
            }
            
            // Return a refernce to the updated user object.
            return user1;
        }

        /// <summary>
        /// Method to update the last login field given a user.
        /// </summary>
        /// <param name="user1"></param>
        public void UpdateLastLogin(User user1)
        {

            // Query the database to find the current user id & update the last login date based
            // on the current time.
            string updateLastLogin = "Update User Set LastLogin = date('now') Where UserID = " + user1.UserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(updateLastLogin, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }

        /// <summary>
        /// Method to add a newly created user to the database.
        /// </summary>
        /// <param name="user1"></param>
        public void AddUserToDB(User user1)
        {
            // Insert all user information into the user table.
            string sqlUserInsert = "INSERT INTO USER" +
                "(FName, LName, Height, StartingWeight, GoalWeight, Age, Gender," +
                "ActivityLevel, RecommendIntake)"
                + "VALUES (" + "'" + user1.FName + "','"
                + user1.LName + "',"
                + user1.Height + ","
                + user1.CurrentWeight + ","
                + user1.GoalWeight + ","
                + user1.Age + ",'"
                + user1.Gender + "','"
                + user1.ActivityLevel + "',"
                + user1.RecommendIntake + ")";
            SQLiteConnection db = new SQLiteConnection("Data Source=FitThis.sqlite");
            // Open the databse & send the sql command.
            dbm.ExecuteNonQuery(sqlUserInsert, db);

            //Must send new connection becuase old one is sent for the trash after
            //it has been opened
            this.UpdateLastLogin(user1);
        }
    }
}
