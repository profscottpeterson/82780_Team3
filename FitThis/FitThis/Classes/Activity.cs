﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitThis
{
    public class Activity
    {
        // Holds the total calories burned (duration * cals per minute)
        public int totalCalories;

        // A dictionary that will hold the all the activities and calorie expendatures
        Dictionary<string, int> workouts =
            new Dictionary<string, int>();

        // Variable to hold the text of the activity
        string activityName = "";

        // holds the duration time
        int duration = 0;

        // calories per minute based on chosen exercise
        int cals = 0;

        // The sql insert text
        string sqlInsert = "";

        public static int userNum;

        DBManagement dbm = new DBManagement();

        // Fills the dictionary
        private void fillDictionary()
        {
            workouts.Add("Running", 11);
            workouts.Add("Walking", 8);
            workouts.Add("Swimming", 20);
            workouts.Add("Biking", 12);
            workouts.Add("Eliptical", 18);
        }

        public Boolean ValidateActivtyInput(ComboBox combo, TextBox time)
        {
            if (combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a workout");
                combo.Focus();
                return false;
            }
            else if(!(time.Text.All(char.IsDigit)))
            {
                MessageBox.Show("You must select a workout duration");
                time.Focus();
                return false;
            }
            else
            {
                // Calls other two methods to perform calculations
                Int32.TryParse(time.Text, out duration);
                activityName = combo.GetItemText(combo.SelectedItem);
                cals = CaloriesPerMinute(activityName);
                totalCalories = CaloriesBurned(duration, cals);
                return true;
            }
        }

            
        // Find the calories burned per minute based on the activity
        public int CaloriesPerMinute(string activity)
        {
            // fills the dictionary
            fillDictionary();
            int cals = 0;

            foreach (KeyValuePair<string, int> entry in workouts)
            {
                // do something with entry.Value or entry.Key
                if(entry.Key == activity)
                {
                    cals = entry.Value;
                    break;
                }
            }
            return cals;
        }

        // Calculates calories burned
        public int CaloriesBurned(int min, int cals)
        {
            int calories = min * cals;
            return calories;
        }

        // gets total calories burned
        public int giveMeTheTotal()
        {
            return totalCalories;
        }

        // Inserts the data into the database table Activity
        public void sqlDataInsert(ComboBox combo, System.Data.SQLite.SQLiteConnection db)
        {

            // Activity ID was changed from combo.selectedindex +1 to a random number becuase activity IDs have to be unique.
            sqlInsert = ("Insert into Activity (Name, Duration, CaloriesBurned, Date, FK_USERID) " +
                    "values ('" + activityName + "', "
                    + duration + ", " + totalCalories + ", date('now')" + ", " + FitThisHUB.currentUserID + ")");
            dbm.ExecuteNonQuery(sqlInsert, db);
        }

        public void ImportData(DataGridView dataGridActivity, System.Windows.Forms.DataVisualization.Charting.Chart ActivityChart)
        {
            //Makes the X value of type date so that dates are shown instead of numbers
            ActivityChart.Series["Minutes"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;

            // Populate the data grid
            string sql = ("select * from Activity where FK_userID = " + FitThisHUB.currentUserID + " order by Date");

            using (SQLiteConnection data = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                data.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, data))
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
            string sqlChart = ("select Date, sum(duration) from Activity where FK_userID = " + FitThisHUB.currentUserID + " group by Date limit 10");
            using (SQLiteConnection data = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                data.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlChart, data))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Converts database date to c# date? 
                            DateTime date = reader.GetDateTime(0).Date;

                            //Adds the date to the chart
                            ActivityChart.Series["Minutes"].Points.AddXY(date, reader["sum(duration)"]);
                        }


                    }
                }
            }
        }

        public void RemoveActivity(DataGridView grid, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            //Get the row number according to what cell or row is selected
            int index = grid.CurrentCell.RowIndex;

            //Get the row's cell values
            string date = grid.Rows[index].Cells[0].Value.ToString();
            string name = grid.Rows[index].Cells[1].Value.ToString();
            string duration = grid.Rows[index].Cells[2].Value.ToString();
            string calories = grid.Rows[index].Cells[3].Value.ToString();

            //Convert Date to correct formating
            DateTime sqlDate = Convert.ToDateTime(date);
            string sqlDateString = sqlDate.ToString("yyyy-MM-dd");


            //Create sql deletion code and execute
            string sqlDelete = ("Delete from Activity where FK_UserID = " + userNum + " and date = '" + sqlDateString  + "' and name = '" +
                name + "' and Duration = " + duration + " and caloriesburned = " + calories + " ");

            using (SQLiteConnection data = new SQLiteConnection("Data Source=FitThis.sqlite"))
            {
                data.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlDelete, data))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            //Clear the chart and grid of data
            grid.Rows.Clear();
            grid.Refresh();
            chart.Series[0].Points.Clear();

            //Repopulate chart and data with updated table values
            ImportData(grid, chart);

        }

    }
}
