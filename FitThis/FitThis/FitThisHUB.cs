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
        public User currentUser;

        public static int currentUserID;


        // Create a SQLite database object
        public SQLiteConnection database = new SQLiteConnection();

        public SQLiteConfig sqlcmd = new SQLiteConfig();

        public FitThisHUB(User currentUser1)
        {
            
            InitializeComponent();
            this.currentUser = currentUser1;
            currentUserID = currentUser.UserID;
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            //Initialize activity class
            Activity active = new Activity();

            // Validate the data entered
            if(active.ValidateActivtyInput(combActivities, tbxDuration))
            {
                //active.sqlDataInsert(combActivities, sqlcmd, database);
                lblCaloriesBurnedDisplay.Text = active.giveMeTheTotal().ToString();
            }
        }



        /// <summary>
        /// On fit this hub load, establish database connection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FitThisHUB_Load(object sender, EventArgs e)
        {
            //makes instance of dashboard class
            Dashboard dash = new Dashboard();
            
            //method to collect information needed for charts
            dash.DashCharts();

            //sets all charts with their respective data points
            chartWeight.Series["Weight"].Points.AddXY(dash.dashChartWeightDate, dash.dashChartWeightAvg);
            chartDashAct.Series["Activity"].Points.AddXY(dash.dashChartActivityDate, dash.dashChartActivitySum);
            chartFood.Series["Food"].Points.AddXY(dash.dashChartFoodDate, dash.dashChartFoodSum);

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

        //button event to close entire program
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateConnectDb_Click_1(object sender, EventArgs e)
        {

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

        //button event to navigate to the activity tab
        private void btnDashActive_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabActivity;
        }

        //button event to navigate to the personal tab
        private void btnDashPersonal_Click(object sender, EventArgs e)
        {
            tabConsole1.SelectedTab = tabPersonal;
        }
    }
}
