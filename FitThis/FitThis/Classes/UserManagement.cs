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
        DBManagement dbm = new DBManagement();
        Activity active = new Activity();
        public int UserNum;

        public void FillLists()
        {
            // Create a query to select the list of user names from the database.
            String selectUsers = "Select Fname, LName, UserID from USER Order by LastLogin DESC";

            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(selectUsers, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Name = reader["Fname"].ToString() + " " + reader["LName"].ToString();
                            this.UserList.Add(Name);
                            this.UserIDList.Add(reader.GetInt32(2));
                        }
                    }
                }
            }
            

        }

        public User LoadUser(User user1)
        {
            // Find the user ID, given a user name.
            int userID = 0;

            // Need command and reader to find object
            string sqlFindUser = "SELECT * FROM USER WHERE USER.FName = '" + user1.FName +
            "' AND USER.LName = '" + user1.LName + "'";

            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFindUser, c))
                {
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
            active.setUserId(user1.UserID);
            return user1;
        }
        public User LoadUser(User user1, string userName)
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

            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFindUser, c))
                {
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
            active.setUserId(user1.UserID);
            return user1;
        }

        public void UpdateLastLogin(User user1)
        {
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

        public void AddUserToDB(User user1)
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
            SQLiteConnection db = new SQLiteConnection("Data Source=FitThis.sqlite");
            // Open the databse & send the sql command.
            dbm.ExecuteNonQuery(sqlUserInsert, db);

            //Must send new connection becuase old one is sent for the trash after
            //it has been opened
            this.UpdateLastLogin(user1);
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
