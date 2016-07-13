namespace FileCopyProgress
{
    partial class SyncJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncJob));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseDest = new System.Windows.Forms.Button();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkExplainNormalBak = new System.Windows.Forms.LinkLabel();
            this.lnkExplainCumBak = new System.Windows.Forms.LinkLabel();
            this.lnkExplainCumSync = new System.Windows.Forms.LinkLabel();
            this.lnkExplainNormalSync = new System.Windows.Forms.LinkLabel();
            this.optCumBackup = new System.Windows.Forms.RadioButton();
            this.optNormalBackup = new System.Windows.Forms.RadioButton();
            this.optCumSync = new System.Windows.Forms.RadioButton();
            this.optNormalSync = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkLowpriority = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.chkRunonnetwork = new System.Windows.Forms.CheckBox();
            this.ddlTime = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlDay = new System.Windows.Forms.ComboBox();
            this.optRunweek = new System.Windows.Forms.RadioButton();
            this.ddlMinutes = new System.Windows.Forms.ComboBox();
            this.optRunminutes = new System.Windows.Forms.RadioButton();
            this.chkRunatintervals = new System.Windows.Forms.CheckBox();
            this.chkRunatstartup = new System.Windows.Forms.CheckBox();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseDest);
            this.groupBox1.Controls.Add(this.btnBrowseSource);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDest);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSource);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source and Destination";
            // 
            // btnBrowseDest
            // 
            this.btnBrowseDest.Location = new System.Drawing.Point(632, 83);
            this.btnBrowseDest.Name = "btnBrowseDest";
            this.btnBrowseDest.Size = new System.Drawing.Size(30, 20);
            this.btnBrowseDest.TabIndex = 7;
            this.btnBrowseDest.Text = "...";
            this.btnBrowseDest.UseVisualStyleBackColor = true;
            this.btnBrowseDest.Click += new System.EventHandler(this.btnBrowseDest_Click);
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(632, 57);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(30, 20);
            this.btnBrowseSource.TabIndex = 6;
            this.btnBrowseSource.Text = "...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(565, 20);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // txtDest
            // 
            this.txtDest.Location = new System.Drawing.Point(66, 83);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(565, 20);
            this.txtDest.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(66, 57);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(565, 20);
            this.txtSource.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lnkExplainNormalBak);
            this.groupBox2.Controls.Add(this.lnkExplainCumBak);
            this.groupBox2.Controls.Add(this.lnkExplainCumSync);
            this.groupBox2.Controls.Add(this.lnkExplainNormalSync);
            this.groupBox2.Controls.Add(this.optCumBackup);
            this.groupBox2.Controls.Add(this.optNormalBackup);
            this.groupBox2.Controls.Add(this.optCumSync);
            this.groupBox2.Controls.Add(this.optNormalSync);
            this.groupBox2.Location = new System.Drawing.Point(12, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(665, 66);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Job Type";
            // 
            // lnkExplainNormalBak
            // 
            this.lnkExplainNormalBak.AutoSize = true;
            this.lnkExplainNormalBak.Location = new System.Drawing.Point(330, 39);
            this.lnkExplainNormalBak.Name = "lnkExplainNormalBak";
            this.lnkExplainNormalBak.Size = new System.Drawing.Size(41, 13);
            this.lnkExplainNormalBak.TabIndex = 7;
            this.lnkExplainNormalBak.TabStop = true;
            this.lnkExplainNormalBak.Text = "Explain";
            // 
            // lnkExplainCumBak
            // 
            this.lnkExplainCumBak.AutoSize = true;
            this.lnkExplainCumBak.Location = new System.Drawing.Point(495, 39);
            this.lnkExplainCumBak.Name = "lnkExplainCumBak";
            this.lnkExplainCumBak.Size = new System.Drawing.Size(41, 13);
            this.lnkExplainCumBak.TabIndex = 6;
            this.lnkExplainCumBak.TabStop = true;
            this.lnkExplainCumBak.Text = "Explain";
            // 
            // lnkExplainCumSync
            // 
            this.lnkExplainCumSync.AutoSize = true;
            this.lnkExplainCumSync.Location = new System.Drawing.Point(165, 39);
            this.lnkExplainCumSync.Name = "lnkExplainCumSync";
            this.lnkExplainCumSync.Size = new System.Drawing.Size(41, 13);
            this.lnkExplainCumSync.TabIndex = 5;
            this.lnkExplainCumSync.TabStop = true;
            this.lnkExplainCumSync.Text = "Explain";
            // 
            // lnkExplainNormalSync
            // 
            this.lnkExplainNormalSync.AutoSize = true;
            this.lnkExplainNormalSync.Location = new System.Drawing.Point(25, 39);
            this.lnkExplainNormalSync.Name = "lnkExplainNormalSync";
            this.lnkExplainNormalSync.Size = new System.Drawing.Size(41, 13);
            this.lnkExplainNormalSync.TabIndex = 4;
            this.lnkExplainNormalSync.TabStop = true;
            this.lnkExplainNormalSync.Text = "Explain";
            // 
            // optCumBackup
            // 
            this.optCumBackup.AutoSize = true;
            this.optCumBackup.Location = new System.Drawing.Point(498, 19);
            this.optCumBackup.Name = "optCumBackup";
            this.optCumBackup.Size = new System.Drawing.Size(117, 17);
            this.optCumBackup.TabIndex = 3;
            this.optCumBackup.TabStop = true;
            this.optCumBackup.Text = "Cumulative Backup";
            this.optCumBackup.UseVisualStyleBackColor = true;
            // 
            // optNormalBackup
            // 
            this.optNormalBackup.AutoSize = true;
            this.optNormalBackup.Location = new System.Drawing.Point(333, 19);
            this.optNormalBackup.Name = "optNormalBackup";
            this.optNormalBackup.Size = new System.Drawing.Size(98, 17);
            this.optNormalBackup.TabIndex = 2;
            this.optNormalBackup.TabStop = true;
            this.optNormalBackup.Text = "Normal Backup";
            this.optNormalBackup.UseVisualStyleBackColor = true;
            // 
            // optCumSync
            // 
            this.optCumSync.AutoSize = true;
            this.optCumSync.Location = new System.Drawing.Point(168, 19);
            this.optCumSync.Name = "optCumSync";
            this.optCumSync.Size = new System.Drawing.Size(104, 17);
            this.optCumSync.TabIndex = 1;
            this.optCumSync.TabStop = true;
            this.optCumSync.Text = "Cumulative Sync";
            this.optCumSync.UseVisualStyleBackColor = true;
            // 
            // optNormalSync
            // 
            this.optNormalSync.AutoSize = true;
            this.optNormalSync.Location = new System.Drawing.Point(28, 19);
            this.optNormalSync.Name = "optNormalSync";
            this.optNormalSync.Size = new System.Drawing.Size(85, 17);
            this.optNormalSync.TabIndex = 0;
            this.optNormalSync.TabStop = true;
            this.optNormalSync.Text = "Normal Sync";
            this.optNormalSync.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(583, 419);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(91, 29);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(486, 419);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.chkLowpriority);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtComputerName);
            this.groupBox3.Controls.Add(this.chkRunonnetwork);
            this.groupBox3.Controls.Add(this.ddlTime);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.ddlDay);
            this.groupBox3.Controls.Add(this.optRunweek);
            this.groupBox3.Controls.Add(this.ddlMinutes);
            this.groupBox3.Controls.Add(this.optRunminutes);
            this.groupBox3.Controls.Add(this.chkRunatintervals);
            this.groupBox3.Controls.Add(this.chkRunatstartup);
            this.groupBox3.Location = new System.Drawing.Point(12, 211);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(665, 202);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "How to run";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(165, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(348, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "(job takes more time to scan for changes, but takes much less CPU time)";
            // 
            // chkLowpriority
            // 
            this.chkLowpriority.AutoSize = true;
            this.chkLowpriority.Location = new System.Drawing.Point(28, 150);
            this.chkLowpriority.Name = "chkLowpriority";
            this.chkLowpriority.Size = new System.Drawing.Size(138, 17);
            this.chkLowpriority.TabIndex = 11;
            this.chkLowpriority.Text = "Run in low priority mode";
            this.chkLowpriority.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(491, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "(ComputerName or IP)";
            // 
            // txtComputerName
            // 
            this.txtComputerName.Enabled = false;
            this.txtComputerName.Location = new System.Drawing.Point(348, 114);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.Size = new System.Drawing.Size(137, 20);
            this.txtComputerName.TabIndex = 9;
            // 
            // chkRunonnetwork
            // 
            this.chkRunonnetwork.AutoSize = true;
            this.chkRunonnetwork.Location = new System.Drawing.Point(28, 117);
            this.chkRunonnetwork.Name = "chkRunonnetwork";
            this.chkRunonnetwork.Size = new System.Drawing.Size(314, 17);
            this.chkRunonnetwork.TabIndex = 8;
            this.chkRunonnetwork.Text = "Only run if the following computer is available on the network:";
            this.chkRunonnetwork.UseVisualStyleBackColor = true;
            this.chkRunonnetwork.CheckedChanged += new System.EventHandler(this.chkRunonnetwork_CheckedChanged);
            // 
            // ddlTime
            // 
            this.ddlTime.Enabled = false;
            this.ddlTime.FormattingEnabled = true;
            this.ddlTime.Items.AddRange(new object[] {
            "12 am",
            "1 am",
            "2 am",
            "3 am",
            "4 am",
            "5 am",
            "6 am",
            "7 am",
            "8 am",
            "9 am",
            "10 am",
            "11 am",
            "12 pm",
            "1 pm",
            "2 pm",
            "3 pm",
            "4 pm",
            "5 pm",
            "6 pm",
            "7 pm",
            "8 pm",
            "9 pm",
            "10 pm",
            "11 pm"});
            this.ddlTime.Location = new System.Drawing.Point(522, 70);
            this.ddlTime.Name = "ddlTime";
            this.ddlTime.Size = new System.Drawing.Size(84, 21);
            this.ddlTime.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(500, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "at";
            // 
            // ddlDay
            // 
            this.ddlDay.Enabled = false;
            this.ddlDay.FormattingEnabled = true;
            this.ddlDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.ddlDay.Location = new System.Drawing.Point(384, 70);
            this.ddlDay.Name = "ddlDay";
            this.ddlDay.Size = new System.Drawing.Size(110, 21);
            this.ddlDay.TabIndex = 5;
            // 
            // optRunweek
            // 
            this.optRunweek.AutoSize = true;
            this.optRunweek.Enabled = false;
            this.optRunweek.Location = new System.Drawing.Point(239, 71);
            this.optRunweek.Name = "optRunweek";
            this.optRunweek.Size = new System.Drawing.Size(139, 17);
            this.optRunweek.TabIndex = 4;
            this.optRunweek.TabStop = true;
            this.optRunweek.Text = "Run once a week every";
            this.optRunweek.UseVisualStyleBackColor = true;
            // 
            // ddlMinutes
            // 
            this.ddlMinutes.Enabled = false;
            this.ddlMinutes.FormattingEnabled = true;
            this.ddlMinutes.Items.AddRange(new object[] {
            "10 mins",
            "20 mins",
            "30 mins",
            "40 mins",
            "50 mins",
            "1 hour",
            "2 hours",
            "3 hours",
            "4 hours",
            "5 hours",
            "6 hours",
            "7 hours",
            "8 hours",
            "9 hours",
            "10 hours",
            "11 hours",
            "12 hours"});
            this.ddlMinutes.Location = new System.Drawing.Point(108, 71);
            this.ddlMinutes.Name = "ddlMinutes";
            this.ddlMinutes.Size = new System.Drawing.Size(98, 21);
            this.ddlMinutes.TabIndex = 3;
            // 
            // optRunminutes
            // 
            this.optRunminutes.AutoSize = true;
            this.optRunminutes.Enabled = false;
            this.optRunminutes.Location = new System.Drawing.Point(28, 71);
            this.optRunminutes.Name = "optRunminutes";
            this.optRunminutes.Size = new System.Drawing.Size(74, 17);
            this.optRunminutes.TabIndex = 2;
            this.optRunminutes.TabStop = true;
            this.optRunminutes.Text = "Run every";
            this.optRunminutes.UseVisualStyleBackColor = true;
            // 
            // chkRunatintervals
            // 
            this.chkRunatintervals.AutoSize = true;
            this.chkRunatintervals.Location = new System.Drawing.Point(168, 28);
            this.chkRunatintervals.Name = "chkRunatintervals";
            this.chkRunatintervals.Size = new System.Drawing.Size(145, 17);
            this.chkRunatintervals.TabIndex = 1;
            this.chkRunatintervals.Text = "Run at specified intervals";
            this.chkRunatintervals.UseVisualStyleBackColor = true;
            this.chkRunatintervals.CheckedChanged += new System.EventHandler(this.chkRunatintervals_CheckedChanged);
            // 
            // chkRunatstartup
            // 
            this.chkRunatstartup.AutoSize = true;
            this.chkRunatstartup.Location = new System.Drawing.Point(28, 28);
            this.chkRunatstartup.Name = "chkRunatstartup";
            this.chkRunatstartup.Size = new System.Drawing.Size(93, 17);
            this.chkRunatstartup.TabIndex = 0;
            this.chkRunatstartup.Text = "Run at startup";
            this.chkRunatstartup.UseVisualStyleBackColor = true;
            // 
            // SyncJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 460);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SyncJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SyncJob";
            this.Load += new System.EventHandler(this.SyncJob_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optNormalBackup;
        private System.Windows.Forms.RadioButton optCumSync;
        private System.Windows.Forms.RadioButton optNormalSync;
        private System.Windows.Forms.LinkLabel lnkExplainNormalSync;
        private System.Windows.Forms.RadioButton optCumBackup;
        private System.Windows.Forms.LinkLabel lnkExplainNormalBak;
        private System.Windows.Forms.LinkLabel lnkExplainCumBak;
        private System.Windows.Forms.LinkLabel lnkExplainCumSync;
        private System.Windows.Forms.Button btnBrowseDest;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkRunatintervals;
        private System.Windows.Forms.CheckBox chkRunatstartup;
        private System.Windows.Forms.ComboBox ddlMinutes;
        private System.Windows.Forms.RadioButton optRunminutes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlDay;
        private System.Windows.Forms.RadioButton optRunweek;
        private System.Windows.Forms.ComboBox ddlTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkLowpriority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComputerName;
        private System.Windows.Forms.CheckBox chkRunonnetwork;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}