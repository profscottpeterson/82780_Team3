using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitThis
{
    public partial class UserCreationForm : Form
    {
        public UserCreationForm()
        {
            InitializeComponent();
        }

        private void createProfileButton_Click(object sender, EventArgs e)
        {
            // Need to do data validation & pass values onto User class

            string ucfName;
            string ucLName;
            int ucAge;
            int ucHeight;
            int ucWeight;
            string ucGender;
            string ucActivityLevel;
            int ucGoalWeight;
        }
    }
}
