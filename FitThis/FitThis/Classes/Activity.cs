using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitThis.Classes
{
    public class Activity
    {
        public int totalCalories;


        public int CaloriesPerHour(string activity)
        {

            int cals = 0;

            Dictionary<string, int> workouts =
            new Dictionary<string, int>();


            workouts.Add("Running", 16);
            workouts.Add("Walking", 10);
            workouts.Add("Swimming", 24);
            workouts.Add("Biking", 14);
            workouts.Add("Eliptical", 30);

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

        public double CaloriesBurned(int min, int cals)
        {
            double calories = min * cals;
            return calories;
        }
    }
}
