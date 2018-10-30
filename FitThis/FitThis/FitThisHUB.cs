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
        //TODO These buttons can go now that we have working test data.
        private void CreateConnectDb_Click(object sender, EventArgs e)
        {
        }
        private void btnCreateTestTable_Click(object sender, EventArgs e)
        {
        }
        private void btnViewData_Click(object sender, EventArgs e)
        {
        }
        private void btnInsertTestData_Click(object sender, EventArgs e)
        {
        }
        private void btnCreateTables_Click(object sender, EventArgs e)
        {

        }
        private void btnInsertData_Click(object sender, EventArgs e)
        {
            
        }
        private void btnViewUser_Click(object sender, EventArgs e)
        {
       
        }
        private void btnViewFood_Click(object sender, EventArgs e)
        {

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
    }
}
