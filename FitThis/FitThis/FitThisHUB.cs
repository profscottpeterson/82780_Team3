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

        public SQLiteConfig sqlcmd = new SQLiteConfig();

        public FitThisHUB()
        {

            InitializeComponent();
            //currentUserID = currentUser.UserID;
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

            //todo see how this fits in

            UM.UpdateLastLogin(currentUser);
            currentUserID = currentUser.UserID;

            // Load and connect to the DB when the form loads.
            DBManagement DB = new DBManagement();
            this.database = DB.ConnectDB(database);
            Activity active = new Activity();
            active.ImportData(dataGridActivity, chartActivity);

            // Load and connect to the DB when the form loads.

            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {
                //makes instance of dashboard class
                Dashboard dash = new Dashboard();

                //method to collect information needed for charts
                dash.DashCharts();

                //sets all charts with their respective data points
                chartWeight.Series["Weight"].Points.AddXY(dash.dashChartWeightDate, dash.dashChartWeightAvg);
                chartDashAct.Series["Activity"].Points.AddXY(dash.dashChartActivityDate, dash.dashChartActivitySum);
                //chartFood.Series["Food"].Points.AddXY(dash.dashChartFoodDate, dash.dashChartFoodSum);

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

            //Create PersonalInfo Class
            PersonalInfo PersonalInfo = new PersonalInfo();
            PersonalInfo.LoadUserInfo();
            //Load Personal Info
        }

        private void btnRemoveActivity_Click(object sender, EventArgs e)
        {
            Activity active = new Activity();
            active.RemoveActivity(dataGridActivity, chartActivity);        
        }

        private void tabWeight_Enter(object sender, EventArgs e)
        {
            // load list box
            string lbxsql = "Select * From Weight WHERE FK_UserID = " + currentUser.UserID;
            //SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader();
            using (database)
            {
                database.Open();
                using (SQLiteDataReader lbxdata = new SQLiteCommand(lbxsql, database).ExecuteReader())
                {
                    while (lbxdata.Read())
                    {
                        //TODO Remove Time From Date Stamp
                        //string date = lbxdata.GetDateTime(1).ToString();
                        lbxWeightLog.Items.Add(lbxdata["Date"] + "\t" + lbxdata["WeightRecorded"]);
                    }

                    lbxdata.Close();
                }





                // load labels (current and goal)
                lblGoalWeight.Text = currentUser.GoalWeight.ToString();
                string currentweightsql =
                    "Select Weight, Date FROM WEIGHT INNER JOIN USER ON User.UserID = Weight.FK_UserID " +
                    "WHERE UserID = " + currentUser.UserID +
                    " ORDER BY Date";
                SQLiteDataReader curwght = new SQLiteCommand(currentweightsql, database).ExecuteReader();

                if (curwght.Read())
                {
                    this.lblCurrentWeight.Text = curwght[0].ToString();
                }

                curwght.Close();
            }
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

            // Show the sign in form & load a differnet user.
            this.LoadUser();
        }
    }
}
