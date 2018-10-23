namespace FitThis
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    public partial class UserCreationForm : Form
    {
        public UserCreationForm()
        {
            InitializeComponent();
        }

        private void createProfileButton_Click(object sender, EventArgs e)
        {
            // Need to do data validation & pass values onto User class

            // Variables to hold user entered values
            string ucfName = "";
            string ucLName = "";
            int ucAge = 0;
            int ucHeight = 0;
            int ucWeight = 0;
            string ucGender = "";
            string ucActivityLevel = "";
            int ucGoalWeight = 0;

            // bool to determine if error message needs to be displayed
            bool showMessage = false;

            // String for error message concatenation
            string errorMessage = "Check your info --Please enter a valid:";
          
            // Begin variable validation.  If it's not valid, add a line to the error message.

            // first name validation
            if ((fNameTxtBox.Text != null) && (fNameTxtBox.Text != ""))
            {
                ucfName = fNameTxtBox.Text;
                fNameTxtBox.Enabled = false;
            }

            else
            {
                errorMessage += " \n First Name";
                showMessage = true;
            }
         

            // last name validation
            if ((lNameTxtBox.Text != null) && (lNameTxtBox.Text != ""))
            {
                ucLName = lNameTxtBox.Text;
                lNameTxtBox.Enabled = false;
            }
            else
            {
                errorMessage += " \n Last Name";
                showMessage = true;
            }

            // age validation
            if((int.TryParse(ageTxtBox.Text, out ucAge)) && (ucAge < 100) && (ucAge > 5))
            {
                ageTxtBox.Enabled = false;
            }
            else
            {
                errorMessage += " \n Age";
                showMessage = true;

            }

            // height validation
            int feet;
            int inches;
            if ((int.TryParse(heigtFtTxtBox.Text, out feet)) && (int.TryParse(heightInchTxtBox.Text, out inches)))
            {
                // Validate numbers
                if ((feet <= 7) && (feet >=3) && (inches >= 0) && (inches <=12))
                {
                    ucHeight = feet * 12 + inches;
                    heigtFtTxtBox.Enabled = false;
                    heightInchTxtBox.Enabled = false;
                }
                else
                {
                    errorMessage += " \n Height";
                    showMessage = true;
                }
            }
            else
            {
                errorMessage += " \n Height";
                showMessage = true;
            }

            // valid weight
            if ((int.TryParse(weightTxtBox.Text, out ucWeight)) && (ucWeight < 500) && (ucWeight > 50))
            {
                weightTxtBox.Enabled = false;
            }
            else
            {
                errorMessage += " \n Weight";
                showMessage = true;
            }

            // valid goal weight
            if ((int.TryParse(goalWeightTxtBox.Text, out ucGoalWeight)) && (ucGoalWeight < 500) && (ucGoalWeight > 50))
            {
               goalWeightTxtBox.Enabled = false;
            }
            else
            {
                errorMessage += " \n Goal Weight";
                showMessage = true;
            }
            
            // gender
            if (maleRadioButton.Checked == true)
            {
                ucGender = "Male";
            }
            else
            {
                ucGender = "Female";
            }

            // Activity Level
            ucActivityLevel = activityComboBox.Text;

            // Display any error messages or create use if data is valid

            if (showMessage == true)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                User user1 = new User(ucfName, ucLName, ucAge, ucHeight, ucWeight, ucGoalWeight,
                    ucGender, ucActivityLevel);
                user1.AddUsertoDB();
                this.Close();
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
