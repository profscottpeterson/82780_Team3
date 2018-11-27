﻿using System;
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
        /// <summary>
        /// Loads user information upon new user login.
        /// </summary>
        private void LoadUser()
        {
            SignIn Si = new SignIn();
            Si.ShowDialog();
            this.currentUser = Si.currentUserS;
            // If last login = null, show the about form.
            string checkLastLogin = "SELECT USER.LastLogin FROM USER WHERE USER.LastLogin ISNULL AND USER.UserID = " + currentUser.UserID.ToString();

            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(checkLastLogin, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            AboutForm AF = new AboutForm();
                            AF.ShowDialog();
                        }
                    }
                }
            }
            UserManagement UM = new UserManagement();
            UM.UpdateLastLogin(currentUser);

            int allWeights = 0;
            int allFoods = 0;
            int allActivities = 0;
            int allFoodCalories = 0;
            int allBurnedCalories = 0;
            double LowestWeight = 0;
            double HighestWeight = 0;
            double ChangedWeight = 0;
            int LowestCaloriesBurned = 0;
            int HighestCaloriesBurned = 0;
            double AverageMealCalories = 0;
            int MostMealCalories = 0;
            int LeastMealCalories = 0;

            // Load and connect to the DB when the form loads.
            string sqlweight = "Select avg(weightrecorded), date from WEIGHT where fk_USERID =" + currentUser.UserID +
                               " group by date limit 5";
            DBManagement DB = new DBManagement();
            this.database = DB.ConnectDB(database);
            Activity active = new Activity();
            active.ImportData(dataGridActivity, chartActivity);

            // Load and connect to the DB when the form loads.

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

            string sqlActivity = "Select date, sum(duration) from activity where fk_USERID =" + currentUser.UserID +
                                 " group by date limit 5";
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

            string sqlFood = "Select dateadded, sum(calories) from food where fk_USERID =" + currentUser.UserID +
                             " group by dateadded limit 5";
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

            string sqlFoodAll = "Select foodid, Sum(Calories) from food where fk_USERID =" + currentUser.UserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFoodAll, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            allFoods++;
                            string test = rdr[1].ToString();
                            if (rdr[1].ToString() != "")
                            {
                                allFoodCalories = rdr.GetInt32(1);
                            }
                            else
                            {
                                allFoodCalories = 0;
                            }
                        }
                    }
                }
            }

            string sqlFoodCalsLowest = "Select calories from food where fk_USERID =" + currentUser.UserID +
                                       " order by calories asc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFoodCalsLowest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.NextResult())
                        {
                            LeastMealCalories = rdr.GetInt32(0);
                        }
                    }
                }
            }

            string sqlFoodCalsHighest = "Select calories from food where fk_USERID =" + currentUser.UserID +
                                        " order by calories desc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFoodCalsHighest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.NextResult())
                        {
                            MostMealCalories = rdr.GetInt32(0);
                        }
                    }
                }
            }

            string sqlWeightAll = "Select * from weight where fk_USERID =" + currentUser.UserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlWeightAll, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            allWeights++;
                        }
                    }
                }
            }

            string sqlWeightLowest = "Select weightrecorded from weight where fk_USERID =" + currentUser.UserID +
                                     " order by weightrecorded asc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlWeightLowest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.NextResult())
                        {
                            LowestWeight = rdr.GetDouble(0);
                        }
                    }
                }
            }

            string sqlWeightHighest = "Select weightrecorded from weight where fk_USERID =" + currentUser.UserID +
                                      " order by weightrecorded desc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlWeightHighest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            HighestWeight = rdr.GetDouble(0);
                        }
                    }
                }
            }


            string sqlActivitiesHighest = "Select CaloriesBurned from activity where fk_USERID =" + currentUser.UserID +
                                          " order by Caloriesburned asc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivitiesHighest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            HighestCaloriesBurned = rdr.GetInt32(0);
                        }
                    }
                }
            }

            string sqlActivitiesLowest = "Select CaloriesBurned from activity where fk_USERID =" + currentUser.UserID +
                                         " order by Caloriesburned desc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivitiesHighest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            LowestCaloriesBurned = rdr.GetInt32(0);
                        }
                    }
                }
            }

            string sqlActivitiesAll = "Select activityID, Sum(CaloriesBurned) from activity where fk_USERID =" +
                                      currentUser.UserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivitiesAll, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            allActivities++;
                            allBurnedCalories = rdr.GetInt32(1);
                        }
                    }
                }
            }

            ChangedWeight = Math.Abs(HighestWeight - LowestWeight);
            lblNumWeights.Text = allWeights.ToString();
            lblLowestWeight.Text = LowestWeight.ToString();
            lblHighest.Text = HighestWeight.ToString();
            lblChanged.Text = ChangedWeight + "lbs";
            lblActivitiesNum.Text = allActivities.ToString();
            lblTotalCalsBurned.Text = allBurnedCalories.ToString();
            lblHighestCalsBurned.Text = HighestCaloriesBurned.ToString();
            lblLeastCalsBurned.Text = LowestCaloriesBurned.ToString();
            lblMealsNum.Text = allFoods.ToString();
            lblTotalCals.Text = allFoodCalories.ToString();
            lblHighestMealCals.Text = MostMealCalories.ToString();
            lblLeastMealCals.Text = LeastMealCalories.ToString();
        }


        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            dataGridActivity.Rows.Clear();
            dataGridActivity.Refresh();
            chartActivity.Series[0].Points.Clear();
            //Initialize activity class
            Activity active = new Activity();
            // Validate the data entered
            if (active.ValidateActivtyInput(combActivities, tbxDuration))
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
            // Call the load user event to load current user's infomration
            this.LoadUser();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void HelpButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the about form and open it.
            AboutForm AF = new AboutForm();
            AF.Show();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            // Remove reference to current user
            currentUser = null;

            // Show the sign in form & load a differnet user.
            this.LoadUser();
        }
    }
}
