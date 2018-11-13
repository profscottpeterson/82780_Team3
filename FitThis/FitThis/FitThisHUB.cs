using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FitThis.Classes;



namespace FitThis
{
    public partial class FitThisHUB : Form 
    {
        // varaible to hold the current user
        User currentUser = new User();
        

        // Create a SQLite database object
        public SQLiteConnection database = new SQLiteConnection();

        public SQLiteConfig sqlcmd = new SQLiteConfig();

        public FitThisHUB()
        {       
            InitializeComponent();
                   
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            dataGridActivity.Rows.Clear();
            dataGridActivity.Refresh();
            chartActivity.Series[0].Points.Clear();
            //Initialize activity class
            Activity active = new Activity();
            // Validate the data entered
            if(active.ValidateActivtyInput(combActivities, tbxDuration))
            {
                database = new SQLiteConnection("Data Source=FitThis.sqlite");
                active.sqlDataInsert(combActivities, database);
                lblCaloriesBurnedDisplay.Text = active.giveMeTheTotal().ToString();
            }
            active.ImportData(dataGridActivity, chartActivity);
        }

       

        /// <summary>
        /// On fit this hub load, establish database connection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FitThisHUB_Load(object sender, EventArgs e)
        {
            // Load and connect to the DB when the form loads.
            DBManagement DB = new DBManagement();
            this.database = DB.ConnectDB(database);
            SignIn si = new SignIn();
            si.ShowDialog();
           this.currentUser = si.currentUserS;
            Activity active = new Activity();
            active.ImportData(dataGridActivity, chartActivity);

            // Load and connect to the DB when the form loads.
            string sqlweight = "Select avg(weightrecorded), date from WEIGHT where fk_USERID =" + "2 " + "group by date limit 5"; //currentUser.UserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlweight, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            DateTime date = rdr.GetDateTime(1).Date;
                            chartWeight.Series["Weight"].Points.AddXY(date, rdr["avg(weightrecorded)"]);

                        }
                    }
                }
            }

            string sqlActivity = "Select date, sum(duration) from activity where fk_USERID =" + "2 " + "group by date limit 5"; //currentUser.UserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivity, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            DateTime date = rdr.GetDateTime(0).Date;
                            chartDashAct.Series["Activity"].Points.AddXY(date, rdr["Sum(duration)"]);
                        }
                    }
                }
            }

            string sqlFood = "Select dateadded, sum(calories) from food where fk_USERID =" + "2 " + "group by dateadded limit 5"; //currentUser.UserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFood, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            DateTime date = rdr.GetDateTime(0).Date;
                            //chartFood.Series["Food"].Points.AddXY(date, rdr["Sum(calories)"]);
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateConnectDb_Click_1(object sender, EventArgs e)
        {
            Activity active = new Activity();
            active.ImportData(dataGridActivity, chartActivity);

        }

        private void btnDashWeight_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabWeight;
        }

        private void btnDashFood_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabFood;
        }

        private void btnDashActive_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabActivity;
        }

        private void btnDashPersonal_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabPersonal;
            // Load and connect to the DB when the form loads.
            DBManagement DB = new DBManagement();
            this.database = DB.ConnectDB(database);
            //this.CreateConnection();
            Activity active = new Activity();
            active.ImportData(dataGridActivity, chartActivity);

        }

        private void btnCalCalc_Click(object sender, EventArgs e)
        {
            //variable to hold total number of calories consumed
            int calorieIntake = 0;

            //vairable for total number of callories recommended for the day
            int calAllowance = 0;

            //variable for the calories left for the day after eating
            int calLeft = 0;

            //opens connection to database
            database = sqlcmd.DatabaseConnection();

            //create reader to collect calories consumed
            SQLiteDataReader intakeReader = new SQLiteCommand("Select CALORIES from FOOD", database).ExecuteReader();

            //while there is a next record in the database
            //find the number of calories for each meal
            //then add them into the calorie intake variable
            while (intakeReader.Read())
            {

                for (int i = 0; i < intakeReader.FieldCount; i++)
                {
                    calorieIntake += intakeReader.GetInt32(i);
                }

            }

            //create reader to collect the user's calorie allowance
            SQLiteDataReader allowanceReader = new SQLiteCommand(
                "Select RECOMMENDINTAKE from USER where USERID = 1", database).ExecuteReader();

            //finds the user's calorie allowance and places it in the variable
            while (allowanceReader.Read())
            {

                for (int i = 0; i < allowanceReader.FieldCount; i++)
                {
                    calAllowance += allowanceReader.GetInt32(i);
                }

            }

            //subtracts the allowance from the intake to get the calories 
            //that can be consumed
            calLeft = calAllowance - calorieIntake;

            //adds title to chart
            chartCal.Titles.Add("Calories");

            //gives label and values to chart
            //random text
            chartCal.Series["Cals"].Points.AddXY("Calories Consumed", calorieIntake.ToString());
            chartCal.Series["Cals"].Points.AddXY("Calories Available", calLeft.ToString());
        }
    }
}
