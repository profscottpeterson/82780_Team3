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

//testing


namespace FitThis
{
    public partial class FitThisHUB : Form
    {
        // varaible to hold the current user
        public User currentUser = new User();

        public static int currentUserID;
        
        // Create a SQLite database object
        public SQLiteConnection database = new SQLiteConnection();

        public FitThisHUB()
        {

            InitializeComponent();

        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            dataGridActivity.Rows.Clear();
            dataGridActivity.Refresh();
            ActivityChart.Series[0].Points.Clear();
            //Initialize activity class
            Activity active = new Activity();
            // Validate the data entered
            if (active.ValidateActivtyInput(combActivities, tbxDuration))
            {
                database = new SQLiteConnection("Data Source=FitThis.sqlite");
                active.sqlDataInsert(combActivities, database);
                lblCaloriesBurnedDisplay.Text = active.giveMeTheTotal().ToString();
            }

            active.ImportData(dataGridActivity, ActivityChart);
        }

        /// <summary>
        /// Loads user information upon new user login.
        /// </summary>
        private void LoadUser()
        {
            tabConsole1.SelectedTab = tabDash;

            // Show the sign in form to find to create/select the current user.
            SignIn Si = new SignIn();
            Si.ShowDialog();
            // Set this form's current user field from the user selected at sign in.
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

            // Update the last login field for the user.
            UserManagement UM = new UserManagement();
            UM.UpdateLastLogin(currentUser);
            currentUserID = currentUser.UserID;

            // Load and connect to the DB when the form loads.
            DBManagement DB = new DBManagement();
            this.database = DB.ConnectDB(database);
            Activity active = new Activity();
            active.ImportData(dataGridActivity, ActivityChart);

            //Refresh Personal Info to form
            txtName.Text = currentUser.FName + " " + currentUser.LName;
            txtHeight.Text = currentUser.Height.ToString();
            txtActLvl.Text = currentUser.ActivityLevel;
            txtStrtWght.Text = currentUser.CurrentWeight.ToString();
            txtBMI.Text = currentUser.CalculateBMI().ToString();
            txtBMR.Text = currentUser.CalculateBMR().ToString();

            if (currentUser.UserID == 0)
            {
                Application.Exit(); 
            }
            else
            {
                this.Show();
                UpdateDashInfo();
            }
        }


        //button event to navigate to the weight tab
        private void btnDashWeight_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabWeight;
        }

        //button event to navigate to the food tab
        private void btnDashFood_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabFood;
        }

               
        //button event to navigate to the personal tab
        private void btnDashPersonal_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabPersonal;
        }

        private void btnRemoveActivity_Click(object sender, EventArgs e)
        {
            Activity active = new Activity();
            active.RemoveActivity(dataGridActivity, ActivityChart);        
        }

        private void tabWeight_Enter(object sender, EventArgs e)
        {
            // load list box
            string lbxsql = "Select * From Weight WHERE FK_UserID = " + currentUser.UserID + " ORDER BY Date DESC";
            //SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader();
            using (database = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                try
                {
                    database.Open();
                }
                catch
                {
                    // Load and connect to the DB when the form loads.
                    DBManagement DB = new DBManagement();
                    this.database = DB.ConnectDB(database);
                    database.Open();
                }
                using (SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader())
                {
                    lbxWeightLog.Items.Clear();
                    while (lbxdata.Read())
                    {
                        //TODO Remove Time From Date Stamp
                        //string date = lbxdata.GetDateTime(1).ToString();
                        lbxWeightLog.Items.Add(lbxdata["Date"] + "\t" + lbxdata["WeightRecorded"]);
                    }

                    lbxdata.Close();
                }
            }

                // load labels (current and goal)
                lblGoalWeight.Text = currentUser.GoalWeight.ToString();
                string currentweightsql =
                    "Select WeightRecorded, Date FROM WEIGHT INNER JOIN USER ON User.UserID = Weight.FK_UserID " +
                    "WHERE UserID = " + currentUser.UserID +
                    " order by weightID desc";
            using (database = new SQLiteConnection("Data Source=FitThis.sqlite"))
            { 
                database.Open();
            using (SQLiteDataReader curwght = new SQLiteCommand(currentweightsql, database).ExecuteReader())
            {
                if (curwght.Read())
                {
                    this.lblCurrentWeight.Text = curwght[0].ToString();
                }

                curwght.Close();
            }
               database.Close();
            }
        }

        /// <summary>
        /// On fit this hub load, establish database connection, and find which user to load.
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

        

        private void btnDashActive_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabActivity;
        }

        private void tabFood_Click(object sender, EventArgs e)
        {

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
            this.Hide();

            // Show the sign in form & load a differnet user.
            this.LoadUser();
        }
        

        private void DashTab_Enter(object sender, EventArgs e)
        {
            UpdateDashInfo();
        }

        private void UpdateDashInfo()
        {
            //makes instance of dashboard class
            Dashboard dash = new Dashboard();

            //method to collect information needed for charts
            dash.DashCharts(chartWeight, chartDashAct, chartDashFood);

            //method to collect all stats needed for dashboard overview labels
            dash.DashGetAllStats();

            //sets all dashboard overview labels to their correct data points
            lblNumWeights.Text = dash.allWeights.ToString();
            lblLowestWeight.Text = dash.LowestWeight.ToString();
            lblHighest.Text = dash.HighestWeight.ToString();
            lblChanged.Text = dash.ChangedWeight + "lbs";
            lblActivitiesNum.Text = dash.allActivities.ToString();
            lblTotalCalsBurned.Text = dash.allBurnedCalories.ToString();
            lblHighestCalsBurned.Text = dash.HighestCaloriesBurned.ToString();
            lblLeastCalsBurned.Text = dash.LowestCaloriesBurned.ToString();
            lblMealsNum.Text = dash.allFoods.ToString();
            lblTotalCals.Text = dash.allFoodCalories.ToString();
            lblHighestMealCals.Text = dash.MostMealCalories.ToString();
            lblLeastMealCals.Text = dash.LeastMealCalories.ToString();
        }

        private void btnSaveWeight_Click(object sender, EventArgs e)
        {
            int weight;
            // check that value isn't blank or 0
            if (int.TryParse(txbWeight.Text, out weight))
            {
                if (weight != 0)
                {

                    // create sql statement
                    string savesql = "INSERT into WEIGHT (Date, WeightRecorded, FK_UserID) " +
                                     "VALUES (date('now'), " + weight + " , " + currentUser.UserID +")";
                    
                    // execute statement
                    using (database = new SQLiteConnection("Data Source=FitThis.sqlite"))
                    {
                        database.Open();
                        using (SQLiteCommand weightcmd = new SQLiteCommand(savesql, database))
                        {
                            weightcmd.ExecuteNonQuery();
                        }
                    }

                    // update listbox
                    //string lbxsql = "Select * From Weight WHERE FK_UserID = " + currentUser.UserID + " ORDER BY Date DESC";
                    ////SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader();
                    //using (database = new SQLiteConnection("Data Source=FitThis.sqlite"))
                    //{
                    //    database.Open();
                    //    using (SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader())
                    //    {
                    //        lbxWeightLog.Items.Clear();
                    //        while (lbxdata.Read())
                    //        {
                    //            //TODO Remove Time From Date Stamp
                    //            //string date = lbxdata.GetDateTime(1).ToString();
                    //            lbxWeightLog.Items.Add(lbxdata["Date"] + "\t" + lbxdata["WeightRecorded"]);
                    //        }

                    //        lbxdata.Close();
                    //    }
                    //}

                    // update dgv
                    string lbxsql = "Select * From Weight WHERE FK_UserID = " + currentUser.UserID + " ORDER BY Date DESC";
                    using (database = new SQLiteConnection("Data Source=FitThis.sqlite"))
                    {
                        database.Open();
                        using (SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader())
                        {

                        }
                    }

                        //update current weight
                        string currentweightsql =
                            "Select WeightRecorded, Date FROM WEIGHT INNER JOIN USER ON User.UserID = Weight.FK_UserID " +
                            "WHERE UserID = " + currentUser.UserID +
                            " order by weightid desc";

                    // Date in ( SELECT MAX(Date) from Test_Most_Recent group by User)


                    using (database = new SQLiteConnection("Data Source=FitThis.sqlite"))
                    {
                        database.Open();
                        using (SQLiteDataReader curwght = new SQLiteCommand(currentweightsql, database).ExecuteReader())
                        {
                            if (curwght.Read())
                            {
                                this.lblCurrentWeight.Text = curwght[0].ToString();
                            }

                            curwght.Close();
                        }
                        database.Close();
                    }


                }
                else
                {
                    MessageBox.Show("Must enter a valid weight larger than 0.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a value in the Weight Text Box.");
            }
        }

        private void btnResetWeight_Click(object sender, EventArgs e)
        {
            txbWeight.Text = "";
        }

        private void tabFood_Enter(object sender, EventArgs e)
        {
            // clear inputs
            txbTitleFood.Text = "";
            txbCalories.Text = "";

            // update listbox
            string lbxsql = "Select * From FOOD WHERE FK_UserID = " + currentUser.UserID + " ORDER BY DateAdded DESC";
            //string lbxsql = "Select * From FOOD WHERE FK_UserID = " + currentUser.UserID + "ORDER BY DateAdded";

            //SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader();
            using (database = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                database.Open();
                using (SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader())
                {
                    lbxFood.Items.Clear();
                    while (lbxdata.Read())
                    {
                        //TODO Remove Time From Date Stamp
                        //string date = lbxdata.GetDateTime(1).ToString();
                        lbxFood.Items.Add(lbxdata["Title"] + "\t" + lbxdata["Calories"] + "\t" + lbxdata["DateAdded"]);
                    }

                    lbxdata.Close();
                }
            }
        }

        private void btnResetFood_Click(object sender, EventArgs e)
        {
            txbTitleFood.Text = "";
            txbCalories.Text = "";
        }

        private void btnSaveFood_Click(object sender, EventArgs e)
        {
            int calories;

            // validate Title
            if (txbTitleFood.Text == "")
            {
                MessageBox.Show("Food must have a title.");
            }
            else
            {
                // validate Calories
                if (txbCalories.Text == "")
                {
                    MessageBox.Show("Foods must have a Calorie Value");
                }
                else
                {
                    if (!int.TryParse(txbCalories.Text, out calories))
                    {
                        MessageBox.Show("Please insert a valid number for calories.");
                    }
                    else
                    {
                        if (calories < 0)
                        {
                            MessageBox.Show("Foods cannot have a negative calorie value");
                        }
                        else
                        {
                            // store record
                            string foodsql = "Insert into FOOD (Title, Calories, DateAdded, FK_UserID)" +
                                             "VALUES ('" + txbTitleFood.Text + "', " + txbCalories.Text + ", " +
                                             "date('now'), " + currentUser.UserID + ")";
                            using (database = new SQLiteConnection("Data Source =FitThis.sqlite"))
                            {
                                database.Open();
                                using (SQLiteCommand foodcmd = new SQLiteCommand(foodsql, database))
                                {
                                    foodcmd.ExecuteNonQuery();
                                }
                            }

                            // update listbox
                            string lbxsql = "Select * From FOOD WHERE FK_UserID = " + currentUser.UserID + " ORDER BY DateAdded DESC";
                            //string lbxsql = "Select * From FOOD WHERE FK_UserID = " + currentUser.UserID + "ORDER BY DateAdded";

                            //SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader();
                            using (database = new SQLiteConnection("Data Source=FitThis.sqlite"))
                            {
                                database.Open();
                                using (SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader())
                                {
                                    lbxFood.Items.Clear();
                                    while (lbxdata.Read())
                                    {
                                        //TODO Remove Time From Date Stamp
                                        //string date = lbxdata.GetDateTime(1).ToString();
                                        lbxFood.Items.Add(lbxdata["Title"] + "\t" + lbxdata["Calories"] + "\t" + lbxdata["DateAdded"]);
                                    }

                                    lbxdata.Close();
                                }
                            }
                        }
                    }
                }
            }
            
        }
    }
}
