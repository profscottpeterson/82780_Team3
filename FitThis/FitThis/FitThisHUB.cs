using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public FitThisHUB()
        {
            InitializeComponent();
            
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            Activity active = new Activity();
            string act = "";
            int duration = 0;

            if(combActivities.SelectedIndex == -1)
            {
                MessageBox.Show("YOu MUST SELECT A WORKOUT!!!!!!!!!!!!");
                combActivities.Focus();
            }
            else
            {
                act = combActivities.GetItemText(this.combActivities.SelectedItem);
                MessageBox.Show(act);

                if (tbxDuration.Text.All(char.IsDigit))
                {
                    Int32.TryParse(tbxDuration.Text, out duration);
                }
                int cals = active.CaloriesPerHour(act);

                double total;
                total = active.CaloriesBurned(duration, cals);
                lblCaloriesBurnedDisplay.Text = total.ToString();
            }

            

        }

        private void btnClearActivity_Click(object sender, EventArgs e)
        {
            combActivities.SelectedIndex = -1;
            tbxDuration.Clear();
        }
    }
}
