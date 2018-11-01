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
        User currentUser = new User();
        

        // Create a SQLite database object
        public SQLiteConnection database = new SQLiteConnection();

        public SQLiteConfig sqlcmd = new SQLiteConfig();
        public void CreateConnection()
        {
            database = sqlcmd.DatabaseConnection();
        }


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
                database = new SQLiteConnection("Data Source=FitThis.sqlite");
                active.sqlDataInsert(combActivities, database);
                lblCaloriesBurnedDisplay.Text = active.giveMeTheTotal().ToString();
            }

        }

        private void btnClearActivity_Click(object sender, EventArgs e)
        {
            combActivities.SelectedIndex = -1;
            tbxDuration.Clear();
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
            this.CreateConnection();
        }


        private void importDataActivity_Click(object sender, EventArgs e)
        {

            // Makes the X value of type date so that dates are shown instead of numbers
            chartActivity.Series["Minutes"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;

            // Populate the data grid
            string sql = ("select * from Activity Where Fk_userID = " + 0 + " order by Date");

            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Adds data to the rows
                            dataGridActivity.Rows.Add(reader["Date"], reader["Name"], reader["Duration"], reader["CaloriesBurned"]);

                        }
                    }
                }
            }

            //filling in the chart
            string sqlChart = ("select Date, sum(duration) from Activity Where Fk_userID = " + 0 + " group by Date");
            using (SQLiteConnection c = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlChart, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Converts database date to c# date?
                            DateTime date = reader.GetDateTime(0).Date;
                            var dur = reader[1];

                            //Adds the date to the chart
                            chartActivity.Series["Minutes"].Points.AddXY(date.ToOADate(), reader["sum(duration)"]);
                        }


                    }
                }
            }

        }
    }
}
