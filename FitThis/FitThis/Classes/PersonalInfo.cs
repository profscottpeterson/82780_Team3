using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitThis.Classes
{
    class PersonalInfo: FitThisHUB
    {
        public PersonalInfo()
        {
            //Constructor
        }

        //todo fix so that all fields have resolutions on initial creation

        
        // Load Personal Information-ame, Height, Activity Level, Starting Weight, BMR, BMI
        public void LoadUserInfo()
        {
            txtName.Text = currentUser.FName + " " + currentUser.LName;
            txtHeight.Text = currentUser.Height.ToString();
            txtActLvl.Text = currentUser.ActivityLevel;
            txtStrtWght.Text = currentUser.CurrentWeight.ToString();
            txtBMI.Text = currentUser.CalculateBMI().ToString();
            txtBMR.Text = currentUser.CalculateBMR().ToString();
        }
    }
}
