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

        // Create a SQLite database object
        public SQLiteConnection database = new SQLiteConnection();

        public SQLiteConfig sqlcmd = new SQLiteConfig();

        public FitThisHUB(User currentUser1)
        {
            
            InitializeComponent();
            this.currentUser = currentUser1;
            
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            //Initialize activity class
            Activity active = new Activity();

            // Validate the data entered
            if(active.ValidateActivtyInput(combActivities, tbxDuration))
            {
                active.sqlDataInsert(combActivities, sqlcmd, database);
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
                            chartFood.Series["Food"].Points.AddXY(date, rdr["Sum(calories)"]);
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
        }
    }
}
