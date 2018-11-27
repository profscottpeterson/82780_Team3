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

        private void FitThisHUB_Load_1(object sender, EventArgs e)
        {
            // Load and connect to the DB when the form loads.
            DBManagement DB = new DBManagement();
            this.database = DB.ConnectDB(database);
            this.CreateConnection();
            Activity active = new Activity();
            active.ImportData(dataGridActivity, chartActivity);

        }

        private void btnRemoveActivity_Click(object sender, EventArgs e)
        {
            Activity active = new Activity();
            active.RemoveActivity(dataGridActivity, chartActivity);        
        }
    }
}
