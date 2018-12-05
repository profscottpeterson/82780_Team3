using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FitThis.Classes;

namespace FitThis.Classes
{
    class Dashboard
    {
        public DateTime dashChartWeightDate;
        public string dashChartWeightAvg;
        public DateTime dashChartActivityDate;
        public string dashChartActivitySum;
        public DateTime dashChartFoodDate;
        public string dashChartFoodSum;
        public int allWeights = 0;
        public int allFoods = 0;
        public int allActivities = 0;
        public int allFoodCalories = 0;
        public int allBurnedCalories = 0;
        public double LowestWeight = 0;
        public double HighestWeight = 0;
        public double ChangedWeight = 0;
        public int LowestCaloriesBurned = 0;
        public int HighestCaloriesBurned = 0;
        public int MostMealCalories = 0;
        public int LeastMealCalories = 0;



        //collects all data needed for the charts on the dashboard
        public void DashCharts(System.Windows.Forms.DataVisualization.Charting.Chart weightChart,
            System.Windows.Forms.DataVisualization.Charting.Chart activityChart,
            System.Windows.Forms.DataVisualization.Charting.Chart foodChart)
        {
            weightChart.Series[0].Points.Clear();
            activityChart.Series[0].Points.Clear();
            foodChart.Series[0].Points.Clear();

            activityChart.Series[0].XValueType = ChartValueType.DateTime;
            weightChart.Series[0].XValueType = ChartValueType.DateTime;
            foodChart.Series[0].XValueType = ChartValueType.DateTime;

            //collects the date and average weight to be used in the weight chart
            string sqlweight = "Select avg(weightrecorded), date from WEIGHT where fk_USERID =" +
                               FitThisHUB.currentUserID +
                               " group by date limit 5";
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
                            weightChart.Series["Weight"].Points.AddXY(date, rdr[0]);
                        }
                    }
                }
            }

            //collects date and total amount of time logged for given day to be used in activity chart
            string sqlActivity = "Select date, sum(duration) from activity where fk_USERID =" + FitThisHUB.currentUserID +
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
                            activityChart.Series["Minutes"].Points.AddXY(date, rdr["sum(duration)"]);
                        }
                    }
                }
            }

            //collects date and total number of calories for given day, to be used in the food chart
            string sqlFood = "Select dateadded, sum(calories) from food where fk_USERID =" +  FitThisHUB.currentUserID +
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
                            foodChart.Series["Calories"].Points.AddXY(date, rdr[1]);
                        }
                    }
                }
            }
        }

        //method to collect all the data needed for the stats labeled on the dashboard
        public void DashGetAllStats()
        {
            //collects data for how many meals were logged and the total number of calories logged. 
            string sqlFoodAll = "Select foodid, Calories from food where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFoodAll, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (rdr.Read())
                            {
                                allFoods++;
                                allFoodCalories += rdr.GetInt32(1);
                            }
                        }
                        catch
                        {
                            allFoods = 0;
                            allFoodCalories = 0;
                        }
                    }
                }
            }



            //collects the lowest amount of calories logged in a single meal
            string sqlFoodCalsLowest = "Select min(calories) from food where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFoodCalsLowest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            rdr.Read();
                            LeastMealCalories = rdr.GetInt32(0);
                        }
                        catch
                        {
                            LeastMealCalories = 0;
                        }
                    }
                }
            }

            //collects the highest amount of calories logged in a single meal
            string sqlFoodCalsHighest = "Select max(calories) from food where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFoodCalsHighest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            rdr.Read();
                            MostMealCalories = rdr.GetInt32(0);
                        }
                        catch
                        {
                            MostMealCalories = 0;
                        }
                    }
                }
            }

            //collects the total number of times a weight was logged
            string sqlWeightAll = "Select * from weight where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlWeightAll, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (rdr.Read())
                            {
                                allWeights++;
                            }
                        }
                        catch
                        {
                            allWeights = 0;
                        }
                    }
                }
            }

            //collects the lowest weight ever recorded 
            string sqlWeightLowest = "Select min(weightrecorded) from weight where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlWeightLowest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            rdr.Read();
                            LowestWeight = rdr.GetDouble(0);
                        }
                        catch
                        {
                            LowestWeight = 0;
                        }
                    }
                }
            }

            //collects the highest weight ever recorded
            string sqlWeightHighest = "Select weightrecorded from weight where fk_USERID =" + FitThisHUB.currentUserID + " order by weightrecorded desc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlWeightHighest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (rdr.Read())
                            {
                                HighestWeight = rdr.GetDouble(0);
                            }
                        }
                        catch
                        {
                            HighestWeight = 0;
                        }
                    }
                }
            }

            //collects the highest calories burned out of all activities
            string sqlActivitiesHighest = "Select max(CaloriesBurned) from activity where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivitiesHighest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            rdr.Read();
                            HighestCaloriesBurned = rdr.GetInt32(0);

                        }
                        catch
                        {
                            HighestCaloriesBurned = 0;
                        }
                    }
                }
            }

            //collects the lowest calories burned out of all activities
            string sqlActivitiesLowest = "Select min(CaloriesBurned) from activity where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivitiesLowest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            rdr.Read();
                            LowestCaloriesBurned = rdr.GetInt32(0);
                        }
                        catch
                        {
                            LowestCaloriesBurned = 0;
                        }
                    }
                }
            }

            //collects total number of activities logged and total number of callories burned from all activities
            string sqlActivitiesAll = "Select activityID, CaloriesBurned from activity where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivitiesAll, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (rdr.Read())
                            {
                                allActivities++;
                                allBurnedCalories += rdr.GetInt32(1);
                            }
                        }
                        catch
                        {
                            allActivities = 0;
                            allBurnedCalories = 0;
                        }
                    }
                }
            }

            //calculates the difference between the highest and lowest logged weights
            ChangedWeight = Math.Abs(HighestWeight - LowestWeight);
        }
    }
}
