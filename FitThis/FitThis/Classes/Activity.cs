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

        // Fills the dictionary
        private void fillDictionary()
        {
            workouts.Add("Running", 16);
            workouts.Add("Walking", 10);
            workouts.Add("Swimming", 24);
            workouts.Add("Biking", 14);
            workouts.Add("Eliptical", 30);
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
        public void sqlDataInsert(ComboBox combo, SQLiteConfig sqlcmd, System.Data.SQLite.SQLiteConnection database)
        {
            sqlInsert = ("Insert into Activity (ActivityID, Name, Duration, CaloriesBurned, Date, FK_USERID) " +
                    "values (" + (combo.SelectedIndex + 1) + ", '" + activityName + "', "
                    + duration + ", " + totalCalories + ", date('now')" + ", " + 1 + ")");
            MessageBox.Show(sqlInsert);
            sqlcmd.InsertUpdateDeleteData(database, sqlInsert);
        }

    }
}
