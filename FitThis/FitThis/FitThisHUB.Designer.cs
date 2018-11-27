namespace FitThis
{
    partial class FitThisHUB
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FitThisHUB));
            this.tabConsole1 = new System.Windows.Forms.TabControl();
            this.tabDash = new System.Windows.Forms.TabPage();
            this.tabWeight = new System.Windows.Forms.TabPage();
            this.tabFood = new System.Windows.Forms.TabPage();
            this.tabPersonal = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtStrtWght = new System.Windows.Forms.TextBox();
            this.lblStrtWght = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.lblActivity = new System.Windows.Forms.Label();
            this.txtActLvl = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tabActivity = new System.Windows.Forms.TabPage();
            this.dataGridActivity = new System.Windows.Forms.DataGridView();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColActivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCalories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartActivity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCaloriesBurnedDisplay = new System.Windows.Forms.Label();
            this.lblCaloriesBurned = new System.Windows.Forms.Label();
            this.tbxDuration = new System.Windows.Forms.TextBox();
            this.lblSelectDuration = new System.Windows.Forms.Label();
            this.lblSelectActivity = new System.Windows.Forms.Label();
            this.combActivities = new System.Windows.Forms.ComboBox();
            this.btnClearActivity = new System.Windows.Forms.Button();
            this.btnAddActivity = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRemoveActivity = new System.Windows.Forms.Button();
            this.tabConsole1.SuspendLayout();
            this.tabPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // tabConsole1
            // 
            this.tabConsole1.Controls.Add(this.tabDash);
            this.tabConsole1.Controls.Add(this.tabWeight);
            this.tabConsole1.Controls.Add(this.tabFood);
            this.tabConsole1.Controls.Add(this.tabPersonal);
            this.tabConsole1.Controls.Add(this.tabActivity);
            this.tabConsole1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabConsole1.Location = new System.Drawing.Point(196, 12);
            this.tabConsole1.Name = "tabConsole1";
            this.tabConsole1.SelectedIndex = 0;
            this.tabConsole1.Size = new System.Drawing.Size(800, 611);
            this.tabConsole1.TabIndex = 0;
            // 
            // tabDash
            // 
            this.tabDash.BackColor = System.Drawing.Color.Lime;
            this.tabDash.Location = new System.Drawing.Point(4, 27);
            this.tabDash.Name = "tabDash";
            this.tabDash.Padding = new System.Windows.Forms.Padding(3);
            this.tabDash.Size = new System.Drawing.Size(792, 580);
            this.tabDash.TabIndex = 4;
            this.tabDash.Text = "Dashboard";
            // 
            // tabWeight
            // 
            this.tabWeight.BackColor = System.Drawing.Color.Lime;
            this.tabWeight.Location = new System.Drawing.Point(4, 27);
            this.tabWeight.Name = "tabWeight";
            this.tabWeight.Size = new System.Drawing.Size(792, 580);
            this.tabWeight.TabIndex = 2;
            this.tabWeight.Text = "Weight Log";
            // 
            // tabFood
            // 
            this.tabFood.BackColor = System.Drawing.Color.Lime;
            this.tabFood.Location = new System.Drawing.Point(4, 27);
            this.tabFood.Name = "tabFood";
            this.tabFood.Size = new System.Drawing.Size(792, 580);
            this.tabFood.TabIndex = 3;
            this.tabFood.Text = "Food Log";
            // 
            // tabPersonal
            // 
            this.tabPersonal.BackColor = System.Drawing.Color.Lime;
            this.tabPersonal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPersonal.Controls.Add(this.pictureBox1);
            this.tabPersonal.Controls.Add(this.txtStrtWght);
            this.tabPersonal.Controls.Add(this.lblStrtWght);
            this.tabPersonal.Controls.Add(this.lblHeight);
            this.tabPersonal.Controls.Add(this.txtHeight);
            this.tabPersonal.Controls.Add(this.lblActivity);
            this.tabPersonal.Controls.Add(this.txtActLvl);
            this.tabPersonal.Controls.Add(this.lblName);
            this.tabPersonal.Controls.Add(this.txtName);
            this.tabPersonal.Location = new System.Drawing.Point(4, 27);
            this.tabPersonal.Name = "tabPersonal";
            this.tabPersonal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonal.Size = new System.Drawing.Size(792, 580);
            this.tabPersonal.TabIndex = 0;
            this.tabPersonal.Text = "Personal Information";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.OldLace;
            this.pictureBox1.Location = new System.Drawing.Point(136, 148);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 93);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // txtStrtWght
            // 
            this.txtStrtWght.Enabled = false;
            this.txtStrtWght.Location = new System.Drawing.Point(227, 105);
            this.txtStrtWght.Name = "txtStrtWght";
            this.txtStrtWght.Size = new System.Drawing.Size(100, 23);
            this.txtStrtWght.TabIndex = 7;
            // 
            // lblStrtWght
            // 
            this.lblStrtWght.AutoSize = true;
            this.lblStrtWght.BackColor = System.Drawing.Color.Orange;
            this.lblStrtWght.Location = new System.Drawing.Point(18, 108);
            this.lblStrtWght.Name = "lblStrtWght";
            this.lblStrtWght.Size = new System.Drawing.Size(109, 18);
            this.lblStrtWght.TabIndex = 6;
            this.lblStrtWght.Text = "Starting Weight:";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.BackColor = System.Drawing.Color.Orange;
            this.lblHeight.Location = new System.Drawing.Point(18, 54);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(53, 18);
            this.lblHeight.TabIndex = 5;
            this.lblHeight.Text = "Height:";
            // 
            // txtHeight
            // 
            this.txtHeight.Enabled = false;
            this.txtHeight.Location = new System.Drawing.Point(227, 49);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 23);
            this.txtHeight.TabIndex = 4;
            // 
            // lblActivity
            // 
            this.lblActivity.AutoSize = true;
            this.lblActivity.BackColor = System.Drawing.Color.Orange;
            this.lblActivity.Location = new System.Drawing.Point(18, 80);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(198, 18);
            this.lblActivity.TabIndex = 3;
            this.lblActivity.Text = "Usual Activity Level (in hours):";
            // 
            // txtActLvl
            // 
            this.txtActLvl.Enabled = false;
            this.txtActLvl.Location = new System.Drawing.Point(227, 78);
            this.txtActLvl.Name = "txtActLvl";
            this.txtActLvl.Size = new System.Drawing.Size(100, 23);
            this.txtActLvl.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Orange;
            this.lblName.Location = new System.Drawing.Point(18, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(227, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 23);
            this.txtName.TabIndex = 0;
            // 
            // tabActivity
            // 
            this.tabActivity.BackColor = System.Drawing.Color.Lime;
            this.tabActivity.Controls.Add(this.btnRemoveActivity);
            this.tabActivity.Controls.Add(this.dataGridActivity);
            this.tabActivity.Controls.Add(this.chartActivity);
            this.tabActivity.Controls.Add(this.lblCaloriesBurnedDisplay);
            this.tabActivity.Controls.Add(this.lblCaloriesBurned);
            this.tabActivity.Controls.Add(this.tbxDuration);
            this.tabActivity.Controls.Add(this.lblSelectDuration);
            this.tabActivity.Controls.Add(this.lblSelectActivity);
            this.tabActivity.Controls.Add(this.combActivities);
            this.tabActivity.Controls.Add(this.btnClearActivity);
            this.tabActivity.Controls.Add(this.btnAddActivity);
            this.tabActivity.Location = new System.Drawing.Point(4, 27);
            this.tabActivity.Name = "tabActivity";
            this.tabActivity.Padding = new System.Windows.Forms.Padding(3);
            this.tabActivity.Size = new System.Drawing.Size(792, 580);
            this.tabActivity.TabIndex = 5;
            this.tabActivity.Text = "Activity";
            // 
            // dataGridActivity
            // 
            this.dataGridActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridActivity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDate,
            this.ColActivity,
            this.ColDuration,
            this.ColCalories});
            this.dataGridActivity.Location = new System.Drawing.Point(317, 393);
            this.dataGridActivity.Name = "dataGridActivity";
            this.dataGridActivity.ReadOnly = true;
            this.dataGridActivity.Size = new System.Drawing.Size(445, 150);
            this.dataGridActivity.TabIndex = 10;
            // 
            // ColDate
            // 
            this.ColDate.HeaderText = "Date";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
            // 
            // ColActivity
            // 
            this.ColActivity.HeaderText = "Activity";
            this.ColActivity.Name = "ColActivity";
            this.ColActivity.ReadOnly = true;
            // 
            // ColDuration
            // 
            this.ColDuration.HeaderText = "Duration";
            this.ColDuration.Name = "ColDuration";
            this.ColDuration.ReadOnly = true;
            // 
            // ColCalories
            // 
            this.ColCalories.HeaderText = "Calories";
            this.ColCalories.Name = "ColCalories";
            this.ColCalories.ReadOnly = true;
            // 
            // chartActivity
            // 
            chartArea1.Name = "ChartArea1";
            this.chartActivity.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartActivity.Legends.Add(legend1);
            this.chartActivity.Location = new System.Drawing.Point(378, 3);
            this.chartActivity.Name = "chartActivity";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Minutes";
            this.chartActivity.Series.Add(series1);
            this.chartActivity.Size = new System.Drawing.Size(300, 300);
            this.chartActivity.TabIndex = 9;
            this.chartActivity.Text = "chart1";
            title1.Name = "Testing";
            title1.Text = "Activity (minutes)";
            this.chartActivity.Titles.Add(title1);
            // 
            // lblCaloriesBurnedDisplay
            // 
            this.lblCaloriesBurnedDisplay.AutoSize = true;
            this.lblCaloriesBurnedDisplay.Location = new System.Drawing.Point(227, 261);
            this.lblCaloriesBurnedDisplay.Name = "lblCaloriesBurnedDisplay";
            this.lblCaloriesBurnedDisplay.Size = new System.Drawing.Size(0, 18);
            this.lblCaloriesBurnedDisplay.TabIndex = 7;
            // 
            // lblCaloriesBurned
            // 
            this.lblCaloriesBurned.AutoSize = true;
            this.lblCaloriesBurned.Location = new System.Drawing.Point(32, 257);
            this.lblCaloriesBurned.Name = "lblCaloriesBurned";
            this.lblCaloriesBurned.Size = new System.Drawing.Size(148, 18);
            this.lblCaloriesBurned.TabIndex = 6;
            this.lblCaloriesBurned.Text = "Total Calories Burned: ";
            // 
            // tbxDuration
            // 
            this.tbxDuration.Location = new System.Drawing.Point(183, 166);
            this.tbxDuration.Name = "tbxDuration";
            this.tbxDuration.Size = new System.Drawing.Size(100, 23);
            this.tbxDuration.TabIndex = 5;
            // 
            // lblSelectDuration
            // 
            this.lblSelectDuration.AutoSize = true;
            this.lblSelectDuration.Location = new System.Drawing.Point(32, 166);
            this.lblSelectDuration.Name = "lblSelectDuration";
            this.lblSelectDuration.Size = new System.Drawing.Size(124, 18);
            this.lblSelectDuration.TabIndex = 4;
            this.lblSelectDuration.Text = "Duration (minutes)";
            // 
            // lblSelectActivity
            // 
            this.lblSelectActivity.AutoSize = true;
            this.lblSelectActivity.Location = new System.Drawing.Point(32, 120);
            this.lblSelectActivity.Name = "lblSelectActivity";
            this.lblSelectActivity.Size = new System.Drawing.Size(95, 18);
            this.lblSelectActivity.TabIndex = 3;
            this.lblSelectActivity.Text = "Select Activity";
            // 
            // combActivities
            // 
            this.combActivities.FormattingEnabled = true;
            this.combActivities.Items.AddRange(new object[] {
            "Running",
            "Walking",
            "Swimming",
            "Biking",
            "Eliptical",
            ""});
            this.combActivities.Location = new System.Drawing.Point(183, 120);
            this.combActivities.Name = "combActivities";
            this.combActivities.Size = new System.Drawing.Size(121, 26);
            this.combActivities.TabIndex = 2;
            // 
            // btnClearActivity
            // 
            this.btnClearActivity.Location = new System.Drawing.Point(201, 384);
            this.btnClearActivity.Name = "btnClearActivity";
            this.btnClearActivity.Size = new System.Drawing.Size(75, 23);
            this.btnClearActivity.TabIndex = 1;
            this.btnClearActivity.Text = "Clear";
            this.btnClearActivity.UseVisualStyleBackColor = true;
            this.btnClearActivity.Click += new System.EventHandler(this.btnClearActivity_Click);
            // 
            // btnAddActivity
            // 
            this.btnAddActivity.Location = new System.Drawing.Point(91, 384);
            this.btnAddActivity.Name = "btnAddActivity";
            this.btnAddActivity.Size = new System.Drawing.Size(75, 23);
            this.btnAddActivity.TabIndex = 0;
            this.btnAddActivity.Text = "Add Activity";
            this.btnAddActivity.UseVisualStyleBackColor = true;
            this.btnAddActivity.Click += new System.EventHandler(this.btnAddActivity_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(26, 677);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnRemoveActivity
            // 
            this.btnRemoveActivity.Location = new System.Drawing.Point(140, 472);
            this.btnRemoveActivity.Name = "btnRemoveActivity";
            this.btnRemoveActivity.Size = new System.Drawing.Size(126, 34);
            this.btnRemoveActivity.TabIndex = 11;
            this.btnRemoveActivity.Text = "Remove Activity";
            this.btnRemoveActivity.UseVisualStyleBackColor = true;
            this.btnRemoveActivity.Click += new System.EventHandler(this.btnRemoveActivity_Click);
            // 
            // FitThisHUB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabConsole1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FitThisHUB";
            this.Text = "FitThis - Hub";
            this.Load += new System.EventHandler(this.FitThisHUB_Load_1);
            this.tabConsole1.ResumeLayout(false);
            this.tabPersonal.ResumeLayout(false);
            this.tabPersonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabActivity.ResumeLayout(false);
            this.tabActivity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridActivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartActivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabConsole1;
        private System.Windows.Forms.TabPage tabPersonal;
        private System.Windows.Forms.TabPage tabWeight;
        private System.Windows.Forms.TabPage tabFood;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblStrtWght;
        private System.Windows.Forms.TextBox txtStrtWght;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtActLvl;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TabPage tabDash;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabActivity;
        private System.Windows.Forms.Label lblSelectActivity;
        private System.Windows.Forms.Button btnClearActivity;
        private System.Windows.Forms.Button btnAddActivity;
        private System.Windows.Forms.Label lblCaloriesBurnedDisplay;
        private System.Windows.Forms.Label lblCaloriesBurned;
        private System.Windows.Forms.TextBox tbxDuration;
        private System.Windows.Forms.Label lblSelectDuration;
        public System.Windows.Forms.ComboBox combActivities;
        private System.Windows.Forms.Button btnRyanTest;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartActivity;
        private System.Windows.Forms.DataGridView dataGridActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColActivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCalories;
        private System.Windows.Forms.Button btnRemoveActivity;
    }
}