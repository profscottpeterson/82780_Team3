﻿namespace FitThis
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.btnClose = new System.Windows.Forms.Button();
            this.SQLTest = new System.Windows.Forms.TabPage();
            this.CreateConnectDb = new System.Windows.Forms.Button();
            this.btnCreateTestTable = new System.Windows.Forms.Button();
            this.btnViewData = new System.Windows.Forms.Button();
            this.txbResults = new System.Windows.Forms.TextBox();
            this.btnInsertTestData = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SQLTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDash);
            this.tabControl1.Controls.Add(this.tabWeight);
            this.tabControl1.Controls.Add(this.tabFood);
            this.tabControl1.Controls.Add(this.tabPersonal);
            this.tabControl1.Controls.Add(this.SQLTest);
            this.tabControl1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(196, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 611);
            this.tabControl1.TabIndex = 0;
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
            // SQLTest
            // 
            this.SQLTest.BackColor = System.Drawing.Color.Lime;
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
            // CreateConnectDb
            // 
            this.CreateConnectDb.Location = new System.Drawing.Point(61, 71);
            this.CreateConnectDb.Name = "CreateConnectDb";
            this.CreateConnectDb.Size = new System.Drawing.Size(222, 34);
            this.CreateConnectDb.TabIndex = 0;
            this.CreateConnectDb.Text = "Create and collect Database";
            this.CreateConnectDb.UseVisualStyleBackColor = true;
            this.CreateConnectDb.Click += new System.EventHandler(this.CreateConnectDb_Click);
            // 
            // btnCreateTestTable
            // 
            this.btnCreateTestTable.Location = new System.Drawing.Point(99, 184);
            this.btnCreateTestTable.Name = "btnCreateTestTable";
            this.btnCreateTestTable.Size = new System.Drawing.Size(184, 31);
            this.btnCreateTestTable.TabIndex = 1;
            this.btnCreateTestTable.Text = "Create Test Table";
            this.btnCreateTestTable.UseVisualStyleBackColor = true;
            this.btnCreateTestTable.Click += new System.EventHandler(this.btnCreateTestTable_Click);
            // 
            // btnViewData
            // 
            this.btnViewData.Location = new System.Drawing.Point(99, 411);
            this.btnViewData.Name = "btnViewData";
            this.btnViewData.Size = new System.Drawing.Size(163, 40);
            this.btnViewData.TabIndex = 2;
            this.btnViewData.Text = "View Data";
            this.btnViewData.UseVisualStyleBackColor = true;
            this.btnViewData.Click += new System.EventHandler(this.btnViewData_Click);
            // 
            // txbResults
            // 
            this.txbResults.Location = new System.Drawing.Point(344, 95);
            this.txbResults.Multiline = true;
            this.txbResults.Name = "txbResults";
            this.txbResults.Size = new System.Drawing.Size(393, 420);
            this.txbResults.TabIndex = 3;
            // 
            // btnInsertTestData
            // 
            this.btnInsertTestData.Location = new System.Drawing.Point(99, 272);
            this.btnInsertTestData.Name = "btnInsertTestData";
            this.btnInsertTestData.Size = new System.Drawing.Size(149, 60);
            this.btnInsertTestData.TabIndex = 4;
            this.btnInsertTestData.Text = "Insert Test Data";
            this.btnInsertTestData.UseVisualStyleBackColor = true;
            this.btnInsertTestData.Click += new System.EventHandler(this.btnInsertTestData_Click);
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
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FitThisHUB";
            this.Text = "FitThis - Hub";
            this.tabControl1.ResumeLayout(false);
            this.tabPersonal.ResumeLayout(false);
            this.tabPersonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.SQLTest.ResumeLayout(false);
            this.SQLTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
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
    }
}