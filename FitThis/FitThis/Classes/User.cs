namespace FitThis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The user class- represents and holds information about a FitThis program user.
    /// </summary>
    public class User
    {
        // Private fields to hold user information, as entered on the create new user form.

        /// <summary>
        /// Integer to hold a created userID, for program and database reference
        /// </summary>
        private int userID;

        /// <summary>
        /// String to hold the user's first name
        /// </summary>
        private string fName;

        /// <summary>
        /// String to hold the user's last name
        /// </summary>
        private string lName;

        /// <summary>
        /// String to hold the user's gender
        /// </summary>
        private string gender;

        /// <summary>
        /// String to hold the user's activity level
        /// </summary>
        private string activityLevel;

        /// <summary>
        /// Double to hold the user's height, in inches.
        /// </summary>
        private double height;

        /// <summary>
        /// Double to hold the user's starting weight
        /// </summary>
        private double startingWeight;

        /// <summary>
        /// Double to hold the user's goal weight
        /// </summary>
        private double goalWeight;

        /// <summary>
        ///  Double to hold the user's current weight
        /// </summary>
        private double currentWeight;

        /// <summary>
        /// Integer to hold the user's age
        /// </summary>
        private int age;

        /// <summary>
        /// Integer to hold the user's recommended daily calorie intake.
        /// </summary>
        private int recommendIntake;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        /// <param name="fName1">User first name</param>
        /// <param name="lName1">User last name</param>
        /// <param name="age1">User age</param>
        /// <param name="height1">User height</param>
        /// <param name="weight1">User weight</param>
        /// <param name="goalWeight1">User goal weight</param>
        /// <param name="gender1">User gender</param>
        /// <param name="actlevel1">User activity level</param>
        public User
            (string fName1, 
            string lName1,
            int age1, 
            int height1,
            int weight1, 
            int goalWeight1, 
            string gender1, 
            string actlevel1)
        {
            // Set user fields based on passed in values.
            this.fName = fName1;
            this.lName = lName1;
            this.age = age1;
            this.height = height1;
            this.currentWeight = weight1;
            this.goalWeight = goalWeight1;
            this.gender = gender1;
            this.activityLevel = actlevel1;
        }

        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public int UserID
        {
            get
            {
                return this.userID;
            }

            set
            {
                this.userID = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's first name.
        /// </summary>
        public string FName
        {
            get
            {
                return this.fName;
            }

            set
            {
                this.fName = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's last name.
        /// </summary>
        public string LName
        {
            get
            {
                return this.lName;
            }

            set
            {
                this.lName = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's gender.
        /// </summary>
        public string Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's activity level.
        /// </summary>
        public string ActivityLevel
        {
            get
            {
                return this.activityLevel;
            }

            set
            {
                this.activityLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's height.
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's starting weight.
        /// </summary>
        public double StartingWeight
        {
            get
            {
                return this.startingWeight;
            }

            set
            {
                this.startingWeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's goal weight.
        /// </summary>
        public double GoalWeight
        {
            get
            {
                return this.goalWeight;
            }

            set
            {
                this.goalWeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's current weight
        /// </summary>
        public double CurrentWeight
        {
            get
            {
                return this.currentWeight;
            }

            set
            {
                this.currentWeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's age.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        /// <summary>
        /// Gets or sets the user's recommended daily calorie intake.
        /// </summary>
        public int RecommendIntake
        {
            get
            {
                return this.recommendIntake;
            }

            set
            {
                this.recommendIntake = value;
            }
        }

        /// <summary>
        /// Method to calculate the user's Basal Metabolic Rate (BMR)
        /// </summary>
        /// <returns>Calculated BMR</returns>
        public double CalculateBMR()
        {
            double bmr = 0; // Double to hold the calculated BMR

            // If-else statement to determine BMR for males or females.
            if (this.gender == "Female")
            {
                // BMR calculation for females, using imperial measurements.
                bmr = 655 + (4.35 * this.currentWeight) + (4.7 * this.height) - (4.7 * this.age);
            }
            else
            {
                // BMR calculation for males, using imperial measurements.
                bmr = 66 + (6.23 * this.currentWeight) + (12.7 * this.height) - (6.8 * this.age);
            }

            double activityLevelAdjustment = 0; // Holds the actvity level adjustment for BMR
            
            // Case/Switch statement to determine BMR adjustment based on activity level.
            switch (this.activityLevel)
            {
                case "Extra Active":
                    {
                        activityLevelAdjustment = 1.9;
                        break;
                    }

                case "Very Active":
                    {
                        activityLevelAdjustment = 1.725;
                        break;
                    }

                case "Moderately Active":
                    {
                        activityLevelAdjustment = 1.55;
                        break;
                    }

                case "Lightly Active":
                    {
                        activityLevelAdjustment = 1.375;
                        break;
                    }

                // Default in based on sedentary activity level
                default:
                    {
                        activityLevelAdjustment = 1.2;
                        break;
                    }
            }

            // Calaculate the adjusted BMR based on activity level
            bmr = bmr * activityLevelAdjustment;

            // Return the BMR calculation.
            return bmr; 
        }

        /// <summary>
        /// Method to calculate the users BMI (Body Mass Index)
        /// </summary>
        /// <returns>Calculated BMI</returns>
        public double CalculateBMI()
        {
            // Convert user height from inches to meters
            double heightInMeters = this.height * 0.0254;

            // Convert user weight from pounds to kilograms
            double weightInKg = this.currentWeight * 0.453592;

            // Calculated BMI based on height and weight
            double bmi = weightInKg / heightInMeters;

            // Return the calculated BMI
            return bmi;
        }

        public int CalculateTargetCalorieIntake()
        {
            // Need the code to calculate this.
            int calorieIntakegoal = 0;
            return calorieIntakegoal;
        }

        /// <summary>
        /// Method to execute events when a user is logged in.
        /// </summary>
        public void Login()
        {
            // Code here
        }

        /// <summary>
        /// Method to execute events when a user logs out.
        /// </summary>
        public void Logout()
        {
            // Code here
        }
    }
}
