using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void DashCharts()
        {

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
                            dashChartWeightDate = rdr.GetDateTime(1).Date;
                            dashChartWeightAvg = rdr["avg(weightrecorded)"].ToString();
                           
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
                            dashChartActivityDate = rdr.GetDateTime(0).Date;
                            dashChartActivitySum = rdr["Sum(duration)"].ToString();
                        }
                    }
                }
            }

            //collects date and total number of calories for given day, to be used in the food chart
            string sqlFood = "Select dateadded, sum(calories) from food where fk_USERID =" + FitThisHUB.currentUserID +
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
                            dashChartFoodDate = rdr.GetDateTime(0).Date;
                            dashChartFoodSum = rdr["Sum(calories)"].ToString();
                        }
                    }
                }
            }
        }

        //method to collect all the data needed for the stats labeled on the dashboard
        public void DashGetAllStats()
        {
            //collects data for how many meals were logged and the total number of calories logged. 
            string sqlFoodAll = "Select foodid, Sum(Calories) from food where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFoodAll, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            allFoods++;
                            allFoodCalories = rdr.GetInt32(1);
                        }
                    }
                }
            }

            //collects the lowest amount of calories logged in a single meal
            string sqlFoodCalsLowest = "Select calories from food where fk_USERID =" + FitThisHUB.currentUserID + " order by calories asc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFoodCalsLowest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.NextResult())
                        {
                            LeastMealCalories = rdr.GetInt32(0);
                        }
                    }
                }
            }

            //collects the highest amount of calories logged in a single meal
            string sqlFoodCalsHighest = "Select calories from food where fk_USERID =" + FitThisHUB.currentUserID + " order by calories desc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlFoodCalsHighest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.NextResult())
                        {
                            MostMealCalories = rdr.GetInt32(0);
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
                        while (rdr.Read())
                        {
                            allWeights++;
                        }
                    }
                }
            }

            //collects the lowest weight ever recorded 
            string sqlWeightLowest = "Select weightrecorded from weight where fk_USERID =" + FitThisHUB.currentUserID + " order by weightrecorded asc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlWeightLowest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.NextResult())
                        {
                            LowestWeight = rdr.GetDouble(0);
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
                        while (rdr.Read())
                        {
                            HighestWeight = rdr.GetDouble(0);
                        }
                    }
                }
            }

            //collects the highest calories burned out of all activities
            string sqlActivitiesHighest = "Select CaloriesBurned from activity where fk_USERID =" + FitThisHUB.currentUserID + " order by Caloriesburned asc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivitiesHighest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            HighestCaloriesBurned = rdr.GetInt32(0);
                        }
                    }
                }
            }

            //collects the lowest calories burned out of all activities
            string sqlActivitiesLowest = "Select CaloriesBurned from activity where fk_USERID =" + FitThisHUB.currentUserID + " order by Caloriesburned desc limit 1";
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivitiesLowest, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            LowestCaloriesBurned = rdr.GetInt32(0);
                        }
                    }
                }
            }

            //collects total number of activities logged and total number of callories burned from all activities
            string sqlActivitiesAll = "Select activityID, Sum(CaloriesBurned) from activity where fk_USERID =" + FitThisHUB.currentUserID;
            using (SQLiteConnection c = new SQLiteConnection("Data Source = FitThis.sqlite"))
            {

                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sqlActivitiesAll, c))
                {
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            allActivities++;
                            allBurnedCalories = rdr.GetInt32(1);
                        }
                    }
                }
            }

            //calculates the difference between the highest and lowest logged weights
            ChangedWeight = Math.Abs(HighestWeight - LowestWeight);
        }
    }
}
