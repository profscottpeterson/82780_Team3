using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitThis
{
    class UserManagement
    {
        SQLiteCommand command = null;
        SQLiteDataReader reader = null;
        public List<string> UserList = new List<string>();
        public List<int> UserIDList = new List<int>();

        public void FillLists(SQLiteConnection db)
        {
            // Create a query to select the list of user names from the database.
            String selectUsers = "Select Fname, LName, UserID from USER Order by LastLogin DESC";

            // Send the query to the database & execute.
            command = new SQLiteCommand(selectUsers, db);

            // SQL query results returned to the reader.
            reader = command.ExecuteReader();

            // For each of the results, add the first name and last name as a string
            // to a user list and the userID to the ID list.
            while (reader.Read())
            {
                string Name = reader["Fname"].ToString() + " " + reader["LName"].ToString();
                this.UserList.Add(Name);
                this.UserIDList.Add(reader.GetInt32(2));
            }

            // Close the reader
            reader.Close();

        }

        public User LoadUser(User user1, string userName, SQLiteConnection db)
        {
            // Find the user ID, given a user name.
            int userID = 0;
            foreach (string s in this.UserList)
            {
                if (s == userName)
                {
                    userID = this.UserIDList[this.UserList.IndexOf(s)];
                    break;
                }
            }

            // Need command and reader to find object
            string sqlFindUser = "SELECT * FROM USER WHERE UserID =" + userID.ToString();
            command = new SQLiteCommand(sqlFindUser, db);
            reader = command.ExecuteReader();

            // Obtain & fill user fields user information from database.
            reader.Read();
            user1.UserID = reader.GetInt32(0);
            user1.FName = reader.GetString(1);
            user1.LName = reader.GetString(2);
            user1.StartingWeight = reader.GetInt32(3);
            user1.GoalWeight = reader.GetInt32(4);
            user1.Age = reader.GetInt32(5);
            user1.RecommendIntake = reader.GetInt32(6);
            this.UpdateLastLogin(db, user1);
            return user1;
        }

        public void UpdateLastLogin(SQLiteConnection db, User user1)
        {

            DateTime loginTime = DateTime.Now;
            string loginTimeString = loginTime.ToShortDateString();
            string updateLastLogin = "Update User Set LastLogin ='" + loginTimeString + "'Where UserID =" + user1.UserID;
            command = new SQLiteCommand(updateLastLogin, db);
            command.ExecuteNonQuery();

        }

        public void AddUserToDB(User user1, SQLiteConnection db)
        {
            string sqlUserInsert = "INSERT INTO USER" +
                "(FName, LName, Height, StartingWeight, GoalWeight, Age, Gender," +
                "ActivityLevel, RecommendIntake)"
                + "VALUES (" + "'" + user1.FName + "','"
                + user1.LName + "',"
                + user1.Height + ","
                + user1.StartingWeight + ","
                + user1.GoalWeight + ","
                + user1.Age + ",'"
                + user1.Gender + "','"
                + user1.ActivityLevel + "',"
                + user1.RecommendIntake + ")";

            // Open the databse & send the sql command.
            command = new SQLiteCommand(sqlUserInsert, db);
            command.ExecuteNonQuery();
            this.UpdateLastLogin(db, user1);
        }
        /// <summary>
        /// Set the given user instance to null 
        /// TODO not sure we actually need a method for this.
        /// </summary>
        /// <param name="user1"></param>
        /// <returns></returns>
        public User LogOut(User user1)
        {
            user1 = null;
            return user1;
        }


        
    }
}
