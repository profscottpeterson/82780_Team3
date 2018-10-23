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
            this.lblCaloriesBurnedDisplay = new System.Windows.Forms.Label();
            this.lblCaloriesBurned = new System.Windows.Forms.Label();
            this.tbxDuration = new System.Windows.Forms.TextBox();
            this.lblSelectDuration = new System.Windows.Forms.Label();
            this.lblSelectActivity = new System.Windows.Forms.Label();
            this.combActivities = new System.Windows.Forms.ComboBox();
            this.btnClearActivity = new System.Windows.Forms.Button();
            this.btnAddActivity = new System.Windows.Forms.Button();
            this.SQLTest = new System.Windows.Forms.TabPage();
            this.btnRyanTest = new System.Windows.Forms.Button();
            this.btnViewFood = new System.Windows.Forms.Button();
            this.btnViewUser = new System.Windows.Forms.Button();
            this.btnInsertData = new System.Windows.Forms.Button();
            this.btnCreateTables = new System.Windows.Forms.Button();
            this.btnInsertTestData = new System.Windows.Forms.Button();
            this.txbResults = new System.Windows.Forms.TextBox();
            this.btnViewData = new System.Windows.Forms.Button();
            this.btnCreateTestTable = new System.Windows.Forms.Button();
            this.CreateConnectDb = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbxWeightLog = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabConsole1.SuspendLayout();
            this.tabWeight.SuspendLayout();
            this.tabPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabActivity.SuspendLayout();
            this.SQLTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabConsole1
            // 
            this.tabConsole1.Controls.Add(this.tabDash);
            this.tabConsole1.Controls.Add(this.tabWeight);
            this.tabConsole1.Controls.Add(this.tabFood);
            this.tabConsole1.Controls.Add(this.tabPersonal);
            this.tabConsole1.Controls.Add(this.tabActivity);
            this.tabConsole1.Controls.Add(this.SQLTest);
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
            this.tabWeight.Controls.Add(this.textBox1);
            this.tabWeight.Controls.Add(this.button2);
            this.tabWeight.Controls.Add(this.button1);
            this.tabWeight.Controls.Add(this.lbxWeightLog);
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
            // SQLTest
            // 
            this.SQLTest.BackColor = System.Drawing.Color.Lime;
            this.SQLTest.Controls.Add(this.btnRyanTest);
            this.SQLTest.Controls.Add(this.btnViewFood);
            this.SQLTest.Controls.Add(this.btnViewUser);
            this.SQLTest.Controls.Add(this.btnInsertData);
            this.SQLTest.Controls.Add(this.btnCreateTables);
            this.SQLTest.Controls.Add(this.btnInsertTestData);
            this.SQLTest.Controls.Add(this.txbResults);
            this.SQLTest.Controls.Add(this.btnViewData);
            this.SQLTest.Controls.Add(this.btnCreateTestTable);
            this.SQLTest.Controls.Add(this.CreateConnectDb);
            this.SQLTest.Location = new System.Drawing.Point(4, 27);
            this.SQLTest.Name = "SQLTest";
            this.SQLTest.Size = new System.Drawing.Size(792, 580);
            this.SQLTest.TabIndex = 5;
            this.SQLTest.Text = "SQLTest";
            // 
            // btnRyanTest
            // 
            this.btnRyanTest.Location = new System.Drawing.Point(194, 297);
            this.btnRyanTest.Name = "btnRyanTest";
            this.btnRyanTest.Size = new System.Drawing.Size(123, 66);
            this.btnRyanTest.TabIndex = 8;
            this.btnRyanTest.Text = "Ryan\'s Test Data";
            this.btnRyanTest.UseVisualStyleBackColor = true;
            this.btnRyanTest.Click += new System.EventHandler(this.btnRyanTest_Click);
            // 
            // btnViewFood
            // 
            this.btnViewFood.Location = new System.Drawing.Point(15, 444);
            this.btnViewFood.Name = "btnViewFood";
            this.btnViewFood.Size = new System.Drawing.Size(110, 30);
            this.btnViewFood.TabIndex = 2;
            this.btnViewFood.Text = "View Food";
            this.btnViewFood.UseVisualStyleBackColor = true;
            this.btnViewFood.Click += new System.EventHandler(this.btnViewFood_Click);
            // 
            // btnViewUser
            // 
            this.btnViewUser.Location = new System.Drawing.Point(15, 403);
            this.btnViewUser.Name = "btnViewUser";
            this.btnViewUser.Size = new System.Drawing.Size(122, 23);
            this.btnViewUser.TabIndex = 7;
            this.btnViewUser.Text = "View User";
            this.btnViewUser.UseVisualStyleBackColor = true;
            this.btnViewUser.Click += new System.EventHandler(this.btnViewUser_Click);
            // 
            // btnInsertData
            // 
            this.btnInsertData.Location = new System.Drawing.Point(20, 346);
            this.btnInsertData.Name = "btnInsertData";
            this.btnInsertData.Size = new System.Drawing.Size(158, 36);
            this.btnInsertData.TabIndex = 6;
            this.btnInsertData.Text = "Insert testing data";
            this.btnInsertData.UseVisualStyleBackColor = true;
            this.btnInsertData.Click += new System.EventHandler(this.btnInsertData_Click);
            // 
            // btnCreateTables
            // 
            this.btnCreateTables.Location = new System.Drawing.Point(0, 297);
            this.btnCreateTables.Name = "btnCreateTables";
            this.btnCreateTables.Size = new System.Drawing.Size(125, 24);
            this.btnCreateTables.TabIndex = 5;
            this.btnCreateTables.Text = "Create Tables";
            this.btnCreateTables.UseVisualStyleBackColor = true;
            this.btnCreateTables.Click += new System.EventHandler(this.btnCreateTables_Click);
            // 
            // btnInsertTestData
            // 
            this.btnInsertTestData.Location = new System.Drawing.Point(3, 129);
            this.btnInsertTestData.Name = "btnInsertTestData";
            this.btnInsertTestData.Size = new System.Drawing.Size(149, 60);
            this.btnInsertTestData.TabIndex = 4;
            this.btnInsertTestData.Text = "Insert Test Data";
            this.btnInsertTestData.UseVisualStyleBackColor = true;
            this.btnInsertTestData.Click += new System.EventHandler(this.btnInsertTestData_Click);
            // 
            // txbResults
            // 
            this.txbResults.Location = new System.Drawing.Point(344, 95);
            this.txbResults.Multiline = true;
            this.txbResults.Name = "txbResults";
            this.txbResults.Size = new System.Drawing.Size(393, 420);
            this.txbResults.TabIndex = 3;
            // 
            // btnViewData
            // 
            this.btnViewData.Location = new System.Drawing.Point(3, 195);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(163, 40);
            this.btnViewData.TabIndex = 2;
            this.btnViewData.Text = "View Data";
            this.btnViewData.UseVisualStyleBackColor = true;
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);
            // 
            // btnCreateTestTable
            // 
            this.btnCreateTestTable.Location = new System.Drawing.Point(3, 92);
            this.btnCreateTestTable.Name = "btnCreateTestTable";
            this.btnCreateTestTable.Size = new System.Drawing.Size(184, 31);
            this.btnCreateTestTable.TabIndex = 1;
            this.btnCreateTestTable.Text = "Create Test Table";
            this.btnCreateTestTable.UseVisualStyleBackColor = true;
            this.btnCreateTestTable.Click += new System.EventHandler(this.btnCreateTestTable_Click);
            // 
            // CreateConnectDb
            // 
            this.CreateConnectDb.Location = new System.Drawing.Point(3, 52);
            this.CreateConnectDb.Name = "CreateConnectDb";
            this.CreateConnectDb.Size = new System.Drawing.Size(222, 34);
            this.CreateConnectDb.TabIndex = 0;
            this.CreateConnectDb.Text = "Create and collect Database";
            this.CreateConnectDb.UseVisualStyleBackColor = true;
            this.CreateConnectDb.Click += new System.EventHandler(this.CreateConnectDb_Click);
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
            // lbxWeightLog
            // 
            this.lbxWeightLog.FormattingEnabled = true;
            this.lbxWeightLog.ItemHeight = 18;
            this.lbxWeightLog.Location = new System.Drawing.Point(310, 206);
            this.lbxWeightLog.Name = "lbxWeightLog";
            this.lbxWeightLog.Size = new System.Drawing.Size(450, 310);
            this.lbxWeightLog.TabIndex = 0;
            this.lbxWeightLog.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(52, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 295);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 3;
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
            this.tabConsole1.ResumeLayout(false);
            this.tabWeight.ResumeLayout(false);
            this.tabWeight.PerformLayout();
            this.tabPersonal.ResumeLayout(false);
            this.tabPersonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabActivity.ResumeLayout(false);
            this.tabActivity.PerformLayout();
            this.SQLTest.ResumeLayout(false);
            this.SQLTest.PerformLayout();
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
        private System.Windows.Forms.TabPage SQLTest;
        private System.Windows.Forms.Button CreateConnectDb;
        private System.Windows.Forms.Button btnViewData;
        private System.Windows.Forms.Button btnCreateTestTable;
        private System.Windows.Forms.TextBox txbResults;
        private System.Windows.Forms.Button btnInsertTestData;
        private System.Windows.Forms.Button btnViewFood;
        private System.Windows.Forms.Button btnViewUser;
        private System.Windows.Forms.Button btnInsertData;
        private System.Windows.Forms.Button btnCreateTables;
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
        private System.Windows.Forms.ListBox lbxWeightLog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}