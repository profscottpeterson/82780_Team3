namespace FitThis
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.overviewLabel = new System.Windows.Forms.Label();
            this.weightTabDescLabel = new System.Windows.Forms.Label();
            this.foodTabDescLabel = new System.Windows.Forms.Label();
            this.actTabDescLabel = new System.Windows.Forms.Label();
            this.personTabDescLabel = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(227, 21);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(305, 36);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Welcome to Fit This!";
            // 
            // overviewLabel
            // 
            this.overviewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overviewLabel.Location = new System.Drawing.Point(109, 72);
            this.overviewLabel.Name = "overviewLabel";
            this.overviewLabel.Size = new System.Drawing.Size(534, 52);
            this.overviewLabel.TabIndex = 1;
            this.overviewLabel.Text = "Track your calorie intake and activities using the Fit This!  Set your goals, tra" +
    "ck your progress, and get to it!";
            this.overviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // weightTabDescLabel
            // 
            this.weightTabDescLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weightTabDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightTabDescLabel.Location = new System.Drawing.Point(136, 151);
            this.weightTabDescLabel.Name = "weightTabDescLabel";
            this.weightTabDescLabel.Size = new System.Drawing.Size(481, 52);
            this.weightTabDescLabel.TabIndex = 2;
            this.weightTabDescLabel.Text = "User the weight tab to enter weight records and track your progress towards your " +
    "goal weight";
            // 
            // foodTabDescLabel
            // 
            this.foodTabDescLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.foodTabDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodTabDescLabel.Location = new System.Drawing.Point(136, 216);
            this.foodTabDescLabel.Name = "foodTabDescLabel";
            this.foodTabDescLabel.Size = new System.Drawing.Size(481, 52);
            this.foodTabDescLabel.TabIndex = 3;
            this.foodTabDescLabel.Text = "Record your meals and snacks in the food tab to track your calorie intake.";
            // 
            // actTabDescLabel
            // 
            this.actTabDescLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.actTabDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actTabDescLabel.Location = new System.Drawing.Point(136, 280);
            this.actTabDescLabel.Name = "actTabDescLabel";
            this.actTabDescLabel.Size = new System.Drawing.Size(481, 52);
            this.actTabDescLabel.TabIndex = 4;
            this.actTabDescLabel.Text = "Track your activities and calories burned on the activity tab";
            // 
            // personTabDescLabel
            // 
            this.personTabDescLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.personTabDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personTabDescLabel.Location = new System.Drawing.Point(136, 342);
            this.personTabDescLabel.Name = "personTabDescLabel";
            this.personTabDescLabel.Size = new System.Drawing.Size(481, 52);
            this.personTabDescLabel.TabIndex = 5;
            this.personTabDescLabel.Text = "Need to update your personal info?  You can see your current settings on the pers" +
    "onal info tab.";
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(172)))), ((int)(((byte)(86)))));
            this.btnSignIn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(327, 433);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(89, 33);
            this.btnSignIn.TabIndex = 6;
            this.btnSignIn.Text = "Close";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.closeButton);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(207)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(763, 507);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.personTabDescLabel);
            this.Controls.Add(this.actTabDescLabel);
            this.Controls.Add(this.foodTabDescLabel);
            this.Controls.Add(this.weightTabDescLabel);
            this.Controls.Add(this.overviewLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "AboutForm";
            this.Text = "About Fit This";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label overviewLabel;
        private System.Windows.Forms.Label weightTabDescLabel;
        private System.Windows.Forms.Label foodTabDescLabel;
        private System.Windows.Forms.Label actTabDescLabel;
        private System.Windows.Forms.Label personTabDescLabel;
        private System.Windows.Forms.Button btnSignIn;
    }
}