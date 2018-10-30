﻿using System;
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
            //Initialize activity class
            Activity active = new Activity();

            // Validate the data entered
            if(active.ValidateActivtyInput(combActivities, tbxDuration))
            {
                active.sqlDataInsert(combActivities, sqlcmd, database);
                lblCaloriesBurnedDisplay.Text = active.giveMeTheTotal().ToString();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void importDataActivity_Click(object sender, EventArgs e)
        {

            // Makes the X value of type date so that dates are shown instead of numbers
            chartActivity.Series["Minutes"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;

            // Populate the data grid
            //TODO Make sure the FK_UserID references the current user classes ID!!!!!!!
            string sql = "select * from Activity Where Fk_userID = 1 order by Date";
            SQLiteCommand command = new SQLiteCommand(sql, database);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //Adds data to the rows
                dataGridActivity.Rows.Add(reader["Date"], reader["Name"], reader["Duration"], reader["CaloriesBurned"]);

            }

            // FIll the chart with data
            //TODO Make sure the FK_UserID references the current user classes ID!!!!!!!
            string sqlChart = "select Date, SUM(Duration) from Activity Where Fk_userID = 1 group by Date";
            SQLiteCommand commandChart = new SQLiteCommand(sqlChart, database);
            SQLiteDataReader reader2 = commandChart.ExecuteReader();
            while (reader2.Read())
            {
                // Converts database date to c# date?
                DateTime date = reader2.GetDateTime(0).Date;

                //Adds the date to the chart
                chartActivity.Series["Minutes"].Points.AddXY(date.ToOADate(), reader2["Sum(Duration)"]);

            }

        }

        private void CreateConnectDb_Click_1(object sender, EventArgs e)
        {

        }
    }
}
