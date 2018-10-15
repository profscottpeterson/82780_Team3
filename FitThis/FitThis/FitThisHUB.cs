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

        private SQLiteConnection database = new SQLiteConnection();

        private SQLiteConfig sqlcmd = new SQLiteConfig();


        public FitThisHUB()
        {
            
            InitializeComponent();
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
                                         "UserID INT," +
                                         "Fname varchar(20)," +
                                         "LName varchar(20)," +
                                         "Height varchar(5)," +
                                         "StartingWeight INT," +
                                         "GoalWeight INT," +
                                         "Age INT," +
                                         "RecommendIntake INT)");
                                         
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
    }
}
