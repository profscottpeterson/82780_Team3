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
using FitThis.Classes;



namespace FitThis
{
    public partial class FitThisHUB : Form
    {
        // varaible to hold the current user
        User currentUser;
        int currentUserID;

        public SQLiteConnection database = new SQLiteConnection();

        public SQLiteConfig sqlcmd = new SQLiteConfig();
        public void CreateConnection()
        {
            database = sqlcmd.DatabaseConnection();
        }


        public FitThisHUB()
        {
            
            InitializeComponent();
            
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            Activity active = new Activity();
            string act = "";
            int duration = 0;

            if(combActivities.SelectedIndex == -1)
            {
                MessageBox.Show("YOu MUST SELECT A WORKOUT!!!!!!!!!!!!");
                combActivities.Focus();
            }
            else
            {
                act = combActivities.GetItemText(this.combActivities.SelectedItem);
                MessageBox.Show(act);

                if (tbxDuration.Text.All(char.IsDigit))
                {
                    Int32.TryParse(tbxDuration.Text, out duration);
                }
                int cals = active.CaloriesPerHour(act);

                double total;
                total = active.CaloriesBurned(duration, cals);
                lblCaloriesBurnedDisplay.Text = total.ToString();
            }

            

        }

        private void btnClearActivity_Click(object sender, EventArgs e)
        {
            combActivities.SelectedIndex = -1;
            tbxDuration.Clear();
        }

        private void CreateConnectDb_Click(object sender, EventArgs e)
        {
            database = sqlcmd.DatabaseConnection();
        }

        private void btnCreateTestTable_Click(object sender, EventArgs e)
        {
            database = sqlcmd.CreateTable(database,"CREATE TABLE test (Id INT, Fname VARCHAR(20), Lname VARCHAR(20))");
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            this.txbResults.Text = "Id\tFirst Name \t Last Name\r\n";
            string sql = "select * from Test order by Id";
            SQLiteCommand command = new SQLiteCommand(sql, database);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                this.txbResults.Text += reader["Id"] + "\t" + reader["Fname"] + "\t" + reader["Lname"] + "\r\n";
                //("Name: " + reader["name"] + "\tScore: " + reader["score"]);
            }
        }

        private void btnInsertTestData_Click(object sender, EventArgs e)
        {
            sqlcmd.InsertUpdateDeleteData(database, "Insert into Test (Id, Fname, Lname)values (1, 'John', 'Doe')");
            sqlcmd.InsertUpdateDeleteData(database, "Insert into Test (Id, Fname, Lname)values (2, 'Will', 'Smith')");
            sqlcmd.InsertUpdateDeleteData(database, "Insert into Test (Id, Fname, Lname)values (3, 'Star', 'Bucks')");
        }

        //TODO Why does this fail? First create works, other two do not :'(  Bad SQL?
        private void btnCreateTables_Click(object sender, EventArgs e)
        {

            //sqlcmd.CreateTable(database, "CREATE TABLE USER (UserID INT, Fname varchar(20), Lname varchar(20), Height varchar(5))");
            sqlcmd.CreateTable(database, "CREATE TABLE USER (" +
                                         "UserID INT PRIMARY KEY," +
                                         "Fname varchar(20)," +
                                         "LName varchar(20)," +
                                         "Height varchar(5)," +
                                         "StartingWeight INT," +
                                         "GoalWeight INT," +
                                         "Age INT," +
                                         "RecommendIntake INT)");
            sqlcmd.CreateTable(database, "CREATE TABLE FOOD (" +
                                         "FoodID INT PRIMARY KEY," +
                                         "Title varchar(50)," +
                                         "Calories INT," +
                                         "DateAdded DATE," +
                                         "FK_UserID INT," +
                                         "FOREIGN KEY(FK_UserId) REFERENCES User(UserID))");
            sqlcmd.CreateTable(database, "CREATE TABLE Weight(" +
                                         "WeightID INT PRIMARY KEY," +
                                         "Date DATE," +
                                         "FK_UserID INT," +
                                         "FOREIGN KEY(FK_UserID) REFERENCES User(UserID))");
            sqlcmd.CreateTable(database, "CREATE TABLE Activity (" +
                                         "ActivityID INT PRIMARY KEY," +
                                         "Name Varchar(20)," +
                                         "Duration INT," +
                                         "CaloriesBurned INT," +
                                         "Date DATE," +
                                         "FK_UserID INT," +
                                         "FOREIGN KEY(FK_UserID) REFERENCES User(UserID))");
            //sqlcmd.CreateTable(database, "CREATE TABLE USER (UserID INT, Fname varchar(20), LName varchar(20), Height varchar(5), StartingWeight INT, GoalWeight INT, Age INT, RecommendIntake INT");

        }

        private void btnInsertData_Click(object sender, EventArgs e)
        {
            sqlcmd.InsertUpdateDeleteData(database, "INSERT into USER (UserId, Fname, Lname) values (1, 'John', 'Doe')");
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            SQLiteDataReader reader = new SQLiteCommand("Select * from USER", database).ExecuteReader();
            while (reader.Read())
            {
                //this.txbResults.Text = reader.GetName(0) + reader. +"";
                for (int index = 0; index < reader.FieldCount; index++)
                {
                    this.txbResults.Text += reader.GetName(index) + "\t";
                }
                //this.txbResults.Text = reader[0] + "\t" + reader[1] + "\t" + reader[2];
            }
        }

        private void btnViewFood_Click(object sender, EventArgs e)
        {

        }

        private void FitThisHUB_Load(object sender, EventArgs e)
        {
            // On load, find the current user and load information into current user object
            // TODO Activity level in database
            string sqlLoadCurrentUser = "Select * From user where currentUser = 1";
            this.CreateConnection();
            SQLiteCommand command = new SQLiteCommand(sqlLoadCurrentUser, database);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            this.currentUserID = reader.GetInt32(0);
            int height = 0;
            int.TryParse(reader["Height"].ToString(), out height);
            // this.currentUser = new User(reader["Fname"].ToString(), reader["LName"].ToString(), reader.GetInt32(6), height,
              //  reader.GetInt32(4), reader.GetInt32(5), reader["Gender"].ToString(), "FixThisActLevl");
        }
    }
}
