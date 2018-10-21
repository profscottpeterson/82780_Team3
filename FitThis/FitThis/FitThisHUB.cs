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

        private SQLiteConfig sqlcmd = new SQLiteConfig();
        private SQLiteConnection database = new SQLiteConnection();
        

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

        private void btnRyanTest_Click(object sender, EventArgs e)
        {
            // connect
            database = sqlcmd.DatabaseConnection();

            // Create Tables
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
                                         "Weight INT," +
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

            // insert User
            //UserID INT PRIMARY KEY
            //Fname varchar(20)," +
            //LName varchar(20)," +
            //Height varchar(5)," +
            //StartingWeight INT," +
            //GoalWeight INT," +
            //Age INT," +
            //RecommendIntake INT)");
            string sqltestuser = "INSERT INTO USER (UserID, Fname, Lname, Height, StartingWeight, GoalWeight, Age, RecommendIntake) " +
                                 "values (0, 'John', 'Doe', '5-10', 195, 175, 26, 2500)";
            SQLiteCommand cmdtestuser = new SQLiteCommand(sqltestuser, database);
            cmdtestuser.ExecuteNonQuery();

            // insert Weight log x3
            //WeightID INT PRIMARY KEY," +
            //Date DATE," +
            //Weight INT," +
            //FK_UserID INT," +
            //FOREIGN KEY(FK_UserID) REFERENCES User(UserID))");
            string sqltestfood = "INSERT INTO Weight (WeightID, Date, Weight FK_UserID)" +
                                 " values (0, 2018-10-21, 193, 0)";
            SQLiteCommand cmdtestfood = new SQLiteCommand(sqltestfood, database);
            cmdtestfood.ExecuteNonQuery();
            sqltestfood = "INSERT INTO Weight (WeightID, Date, Weight FK_UserID)" +
                          " values (1, 2018-10-21, 192, 0)";
            cmdtestfood = new SQLiteCommand(sqltestfood, database);
            cmdtestfood.ExecuteNonQuery();
            sqltestfood = "INSERT INTO Weight (WeightID, Date, Weight FK_UserID)" +
                          " values (2, 2018-10-21, 190, 0)";
            cmdtestfood = new SQLiteCommand(sqltestfood, database);
            cmdtestfood.ExecuteNonQuery();
        }
    }
}
