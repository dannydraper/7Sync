namespace FileCopyProgress
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.FileCopyWorker = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.FileListWorker = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblNumWarnings = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblNumErrors = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTimetaken = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNumCopyActioned = new System.Windows.Forms.Label();
            this.lblSizeCopyActioned = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSizeDeleteActioned = new System.Windows.Forms.Label();
            this.lblSizecompared = new System.Windows.Forms.Label();
            this.lblSizetobeupdated = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSizetobecopied = new System.Windows.Forms.Label();
            this.lblSizetobedeleted = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumCompared = new System.Windows.Forms.Label();
            this.lblToBeCopied = new System.Windows.Forms.Label();
            this.lblToBeUpdated = new System.Windows.Forms.Label();
            this.lblDeleteActioned = new System.Windows.Forms.Label();
            this.lblNumDeleted = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblSubheading = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnRunselected = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.btnNewsyncjob = new System.Windows.Forms.Button();
            this.lvSyncjobs = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDelExtension = new System.Windows.Forms.Button();
            this.btnAddExtension = new System.Windows.Forms.Button();
            this.txtFileExclusion = new System.Windows.Forms.TextBox();
            this.lstExcludedExtensions = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstFolderExclusions = new System.Windows.Forms.ListBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.chkScanonly = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbldfsm2 = new System.Windows.Forms.Label();
            this.ddlDelPercent = new System.Windows.Forms.ComboBox();
            this.lbldfsm = new System.Windows.Forms.Label();
            this.chkDFSM = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkShowwindow = new System.Windows.Forms.CheckBox();
            this.tmrSynctimer = new System.Windows.Forms.Timer(this.components);
            this.tmrJobcheck = new System.Windows.Forms.Timer(this.components);
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrStartupJobCheck = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncAllNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrFormStartup = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Copy File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FileCopyWorker
            // 
            this.FileCopyWorker.WorkerReportsProgress = true;
            this.FileCopyWorker.WorkerSupportsCancellation = true;
            this.FileCopyWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FileCopyWorker_DoWork);
            this.FileCopyWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileCopyWorker_RunWorkerCompleted);
            this.FileCopyWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FileCopyWorker_ProgressChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(461, 361);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(564, 361);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(100, 29);
            this.btnList.TabIndex = 7;
            this.btnList.Text = "Sync Now";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // FileListWorker
            // 
            this.FileListWorker.WorkerReportsProgress = true;
            this.FileListWorker.WorkerSupportsCancellation = true;
            this.FileListWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FileListWorker_DoWork);
            this.FileListWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FileListWorker_RunWorkerCompleted);
            this.FileListWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FileListWorker_ProgressChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(654, 350);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.progressBar2);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(646, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Summary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblNumWarnings);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.lblNumErrors);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lblTimetaken);
            this.groupBox4.Location = new System.Drawing.Point(187, 247);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(453, 49);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General Statistics";
            // 
            // lblNumWarnings
            // 
            this.lblNumWarnings.AutoSize = true;
            this.lblNumWarnings.Location = new System.Drawing.Point(239, 22);
            this.lblNumWarnings.Name = "lblNumWarnings";
            this.lblNumWarnings.Size = new System.Drawing.Size(13, 13);
            this.lblNumWarnings.TabIndex = 35;
            this.lblNumWarnings.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(173, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Warnings";
            // 
            // lblNumErrors
            // 
            this.lblNumErrors.AutoSize = true;
            this.lblNumErrors.Location = new System.Drawing.Point(382, 22);
            this.lblNumErrors.Name = "lblNumErrors";
            this.lblNumErrors.Size = new System.Drawing.Size(13, 13);
            this.lblNumErrors.TabIndex = 33;
            this.lblNumErrors.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Time Taken";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(320, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Errors";
            // 
            // lblTimetaken
            // 
            this.lblTimetaken.AutoSize = true;
            this.lblTimetaken.Location = new System.Drawing.Point(123, 22);
            this.lblTimetaken.Name = "lblTimetaken";
            this.lblTimetaken.Size = new System.Drawing.Size(13, 13);
            this.lblTimetaken.TabIndex = 31;
            this.lblTimetaken.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SyncV7.Properties.Resources.Banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 327);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNumCopyActioned);
            this.groupBox2.Controls.Add(this.lblSizeCopyActioned);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblSizeDeleteActioned);
            this.groupBox2.Controls.Add(this.lblSizecompared);
            this.groupBox2.Controls.Add(this.lblSizetobeupdated);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblSizetobecopied);
            this.groupBox2.Controls.Add(this.lblSizetobedeleted);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblNumCompared);
            this.groupBox2.Controls.Add(this.lblToBeCopied);
            this.groupBox2.Controls.Add(this.lblToBeUpdated);
            this.groupBox2.Controls.Add(this.lblDeleteActioned);
            this.groupBox2.Controls.Add(this.lblNumDeleted);
            this.groupBox2.Location = new System.Drawing.Point(187, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 109);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Numbers of files";
            // 
            // lblNumCopyActioned
            // 
            this.lblNumCopyActioned.AutoSize = true;
            this.lblNumCopyActioned.Location = new System.Drawing.Point(320, 51);
            this.lblNumCopyActioned.Name = "lblNumCopyActioned";
            this.lblNumCopyActioned.Size = new System.Drawing.Size(13, 13);
            this.lblNumCopyActioned.TabIndex = 29;
            this.lblNumCopyActioned.Text = "0";
            // 
            // lblSizeCopyActioned
            // 
            this.lblSizeCopyActioned.AutoSize = true;
            this.lblSizeCopyActioned.Location = new System.Drawing.Point(382, 51);
            this.lblSizeCopyActioned.Name = "lblSizeCopyActioned";
            this.lblSizeCopyActioned.Size = new System.Drawing.Size(13, 13);
            this.lblSizeCopyActioned.TabIndex = 36;
            this.lblSizeCopyActioned.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(216, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Actually copied";
            // 
            // lblSizeDeleteActioned
            // 
            this.lblSizeDeleteActioned.AutoSize = true;
            this.lblSizeDeleteActioned.Location = new System.Drawing.Point(382, 76);
            this.lblSizeDeleteActioned.Name = "lblSizeDeleteActioned";
            this.lblSizeDeleteActioned.Size = new System.Drawing.Size(13, 13);
            this.lblSizeDeleteActioned.TabIndex = 33;
            this.lblSizeDeleteActioned.Text = "0";
            // 
            // lblSizecompared
            // 
            this.lblSizecompared.AutoSize = true;
            this.lblSizecompared.Location = new System.Drawing.Point(382, 25);
            this.lblSizecompared.Name = "lblSizecompared";
            this.lblSizecompared.Size = new System.Drawing.Size(13, 13);
            this.lblSizecompared.TabIndex = 38;
            this.lblSizecompared.Text = "0";
            // 
            // lblSizetobeupdated
            // 
            this.lblSizetobeupdated.AutoSize = true;
            this.lblSizetobeupdated.Location = new System.Drawing.Point(173, 50);
            this.lblSizetobeupdated.Name = "lblSizetobeupdated";
            this.lblSizetobeupdated.Size = new System.Drawing.Size(13, 13);
            this.lblSizetobeupdated.TabIndex = 28;
            this.lblSizetobeupdated.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(216, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Actually deleted";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "To be deleted";
            // 
            // lblSizetobecopied
            // 
            this.lblSizetobecopied.AutoSize = true;
            this.lblSizetobecopied.Location = new System.Drawing.Point(173, 25);
            this.lblSizetobecopied.Name = "lblSizetobecopied";
            this.lblSizetobecopied.Size = new System.Drawing.Size(13, 13);
            this.lblSizetobecopied.TabIndex = 27;
            this.lblSizetobecopied.Text = "0";
            // 
            // lblSizetobedeleted
            // 
            this.lblSizetobedeleted.AutoSize = true;
            this.lblSizetobedeleted.Location = new System.Drawing.Point(173, 75);
            this.lblSizetobedeleted.Name = "lblSizetobedeleted";
            this.lblSizetobedeleted.Size = new System.Drawing.Size(13, 13);
            this.lblSizetobedeleted.TabIndex = 29;
            this.lblSizetobedeleted.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "To be updated";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "To be copied";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Files Compared";
            // 
            // lblNumCompared
            // 
            this.lblNumCompared.AutoSize = true;
            this.lblNumCompared.Location = new System.Drawing.Point(320, 25);
            this.lblNumCompared.Name = "lblNumCompared";
            this.lblNumCompared.Size = new System.Drawing.Size(13, 13);
            this.lblNumCompared.TabIndex = 18;
            this.lblNumCompared.Text = "0";
            // 
            // lblToBeCopied
            // 
            this.lblToBeCopied.AutoSize = true;
            this.lblToBeCopied.Location = new System.Drawing.Point(123, 25);
            this.lblToBeCopied.Name = "lblToBeCopied";
            this.lblToBeCopied.Size = new System.Drawing.Size(13, 13);
            this.lblToBeCopied.TabIndex = 19;
            this.lblToBeCopied.Text = "0";
            // 
            // lblToBeUpdated
            // 
            this.lblToBeUpdated.AutoSize = true;
            this.lblToBeUpdated.Location = new System.Drawing.Point(123, 50);
            this.lblToBeUpdated.Name = "lblToBeUpdated";
            this.lblToBeUpdated.Size = new System.Drawing.Size(13, 13);
            this.lblToBeUpdated.TabIndex = 20;
            this.lblToBeUpdated.Text = "0";
            // 
            // lblDeleteActioned
            // 
            this.lblDeleteActioned.AutoSize = true;
            this.lblDeleteActioned.Location = new System.Drawing.Point(320, 76);
            this.lblDeleteActioned.Name = "lblDeleteActioned";
            this.lblDeleteActioned.Size = new System.Drawing.Size(13, 13);
            this.lblDeleteActioned.TabIndex = 22;
            this.lblDeleteActioned.Text = "0";
            // 
            // lblNumDeleted
            // 
            this.lblNumDeleted.AutoSize = true;
            this.lblNumDeleted.Location = new System.Drawing.Point(123, 75);
            this.lblNumDeleted.Name = "lblNumDeleted";
            this.lblNumDeleted.Size = new System.Drawing.Size(13, 13);
            this.lblNumDeleted.TabIndex = 21;
            this.lblNumDeleted.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGroupName);
            this.groupBox1.Controls.Add(this.lblHeading);
            this.groupBox1.Controls.Add(this.lblSubheading);
            this.groupBox1.Location = new System.Drawing.Point(187, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 120);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Operation";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGroupName.Location = new System.Drawing.Point(10, 28);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(106, 13);
            this.lblGroupName.TabIndex = 24;
            this.lblGroupName.Text = "Welcome to Sync";
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 55);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(98, 13);
            this.lblHeading.TabIndex = 17;
            this.lblHeading.Text = "No Sync started";
            // 
            // lblSubheading
            // 
            this.lblSubheading.Location = new System.Drawing.Point(10, 79);
            this.lblSubheading.Name = "lblSubheading";
            this.lblSubheading.Size = new System.Drawing.Size(437, 38);
            this.lblSubheading.TabIndex = 23;
            this.lblSubheading.Text = "No changes have been made.";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(187, 302);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(213, 16);
            this.progressBar2.TabIndex = 24;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(406, 302);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(234, 16);
            this.progressBar1.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(646, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Detailed Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(6, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(617, 28);
            this.label13.TabIndex = 9;
            this.label13.Text = "When files are due to be copied or deleted they will be logged here. If an error " +
                "occurs it will also be listed here including all information about the file.";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(2, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(641, 277);
            this.listBox1.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnRunselected);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.btnDeleteEntry);
            this.tabPage3.Controls.Add(this.btnNewsyncjob);
            this.tabPage3.Controls.Add(this.lvSyncjobs);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(646, 324);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sync Jobs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRunselected
            // 
            this.btnRunselected.Location = new System.Drawing.Point(172, 6);
            this.btnRunselected.Name = "btnRunselected";
            this.btnRunselected.Size = new System.Drawing.Size(102, 23);
            this.btnRunselected.TabIndex = 9;
            this.btnRunselected.Text = "Run selected";
            this.btnRunselected.UseVisualStyleBackColor = true;
            this.btnRunselected.Click += new System.EventHandler(this.btnRunselected_Click);
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(5, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(427, 14);
            this.label12.TabIndex = 8;
            this.label12.Text = "These are all of your Sync jobs. To add a new Sync job, click New.";
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(89, 6);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(77, 23);
            this.btnDeleteEntry.TabIndex = 2;
            this.btnDeleteEntry.Text = "Delete";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // btnNewsyncjob
            // 
            this.btnNewsyncjob.Location = new System.Drawing.Point(6, 6);
            this.btnNewsyncjob.Name = "btnNewsyncjob";
            this.btnNewsyncjob.Size = new System.Drawing.Size(77, 23);
            this.btnNewsyncjob.TabIndex = 1;
            this.btnNewsyncjob.Text = "New";
            this.btnNewsyncjob.UseVisualStyleBackColor = true;
            this.btnNewsyncjob.Click += new System.EventHandler(this.btnNewsyncjob_Click);
            // 
            // lvSyncjobs
            // 
            this.lvSyncjobs.LargeImageList = this.imageList1;
            this.lvSyncjobs.Location = new System.Drawing.Point(6, 55);
            this.lvSyncjobs.Name = "lvSyncjobs";
            this.lvSyncjobs.Size = new System.Drawing.Size(637, 263);
            this.lvSyncjobs.TabIndex = 0;
            this.lvSyncjobs.UseCompatibleStateImageBehavior = false;
            this.lvSyncjobs.DoubleClick += new System.EventHandler(this.lvSyncjobs_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "FolderIcon48-2.png");
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.listBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(646, 324);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Sync Log";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(6, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(617, 28);
            this.label14.TabIndex = 10;
            this.label14.Text = "This is a log of all Jobs that have been run. This will include dates and times o" +
                "f all jobs that have been run including jobs that are set to run at specified in" +
                "tervals.";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.Location = new System.Drawing.Point(4, 42);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(636, 277);
            this.listBox2.TabIndex = 8;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox5);
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(646, 324);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Exclusions";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.btnDelExtension);
            this.groupBox5.Controls.Add(this.btnAddExtension);
            this.groupBox5.Controls.Add(this.txtFileExclusion);
            this.groupBox5.Controls.Add(this.lstExcludedExtensions);
            this.groupBox5.Location = new System.Drawing.Point(451, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(189, 312);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Excluded File Extensions";
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(5, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 28);
            this.label10.TabIndex = 6;
            this.label10.Text = "File extensions added here will be excluded from all Sync jobs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "File Ext:";
            // 
            // btnDelExtension
            // 
            this.btnDelExtension.Location = new System.Drawing.Point(158, 281);
            this.btnDelExtension.Name = "btnDelExtension";
            this.btnDelExtension.Size = new System.Drawing.Size(22, 22);
            this.btnDelExtension.TabIndex = 4;
            this.btnDelExtension.Text = "-";
            this.btnDelExtension.UseVisualStyleBackColor = true;
            this.btnDelExtension.Click += new System.EventHandler(this.btnDelExtension_Click);
            // 
            // btnAddExtension
            // 
            this.btnAddExtension.Location = new System.Drawing.Point(117, 281);
            this.btnAddExtension.Name = "btnAddExtension";
            this.btnAddExtension.Size = new System.Drawing.Size(40, 22);
            this.btnAddExtension.TabIndex = 3;
            this.btnAddExtension.Text = "Add";
            this.btnAddExtension.UseVisualStyleBackColor = true;
            this.btnAddExtension.Click += new System.EventHandler(this.btnAddExtension_Click);
            // 
            // txtFileExclusion
            // 
            this.txtFileExclusion.Location = new System.Drawing.Point(59, 281);
            this.txtFileExclusion.Name = "txtFileExclusion";
            this.txtFileExclusion.Size = new System.Drawing.Size(52, 20);
            this.txtFileExclusion.TabIndex = 2;
            // 
            // lstExcludedExtensions
            // 
            this.lstExcludedExtensions.FormattingEnabled = true;
            this.lstExcludedExtensions.Location = new System.Drawing.Point(6, 45);
            this.lstExcludedExtensions.Name = "lstExcludedExtensions";
            this.lstExcludedExtensions.Size = new System.Drawing.Size(177, 225);
            this.lstExcludedExtensions.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btnRemove);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.lstFolderExclusions);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 312);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Excluded Folders";
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(6, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(427, 14);
            this.label11.TabIndex = 7;
            this.label11.Text = "Folders added here will be excluded from all Sync jobs";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(72, 279);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(60, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 279);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstFolderExclusions
            // 
            this.lstFolderExclusions.FormattingEnabled = true;
            this.lstFolderExclusions.Location = new System.Drawing.Point(6, 32);
            this.lstFolderExclusions.Name = "lstFolderExclusions";
            this.lstFolderExclusions.Size = new System.Drawing.Size(427, 238);
            this.lstFolderExclusions.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.chkScanonly);
            this.tabPage6.Controls.Add(this.btnApply);
            this.tabPage6.Controls.Add(this.groupBox7);
            this.tabPage6.Controls.Add(this.groupBox6);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(646, 324);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Settings";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // chkScanonly
            // 
            this.chkScanonly.AutoSize = true;
            this.chkScanonly.Location = new System.Drawing.Point(27, 214);
            this.chkScanonly.Name = "chkScanonly";
            this.chkScanonly.Size = new System.Drawing.Size(182, 17);
            this.chkScanonly.TabIndex = 3;
            this.chkScanonly.Text = "Scan only - do not copy or delete";
            this.chkScanonly.UseVisualStyleBackColor = true;
            this.chkScanonly.CheckedChanged += new System.EventHandler(this.chkScanonly_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(564, 292);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(76, 26);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lbldfsm2);
            this.groupBox7.Controls.Add(this.ddlDelPercent);
            this.groupBox7.Controls.Add(this.lbldfsm);
            this.groupBox7.Controls.Add(this.chkDFSM);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Location = new System.Drawing.Point(6, 79);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(634, 118);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Deleted Files Safety Mechanism";
            // 
            // lbldfsm2
            // 
            this.lbldfsm2.AutoSize = true;
            this.lbldfsm2.Location = new System.Drawing.Point(502, 74);
            this.lbldfsm2.Name = "lbldfsm2";
            this.lbldfsm2.Size = new System.Drawing.Size(15, 13);
            this.lbldfsm2.TabIndex = 12;
            this.lbldfsm2.Text = "%";
            // 
            // ddlDelPercent
            // 
            this.ddlDelPercent.FormattingEnabled = true;
            this.ddlDelPercent.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60",
            "65",
            "70",
            "75",
            "80",
            "85",
            "90",
            "95"});
            this.ddlDelPercent.Location = new System.Drawing.Point(435, 71);
            this.ddlDelPercent.Name = "ddlDelPercent";
            this.ddlDelPercent.Size = new System.Drawing.Size(61, 21);
            this.ddlDelPercent.TabIndex = 11;
            this.ddlDelPercent.SelectedIndexChanged += new System.EventHandler(this.ddlDelPercent_SelectedIndexChanged);
            // 
            // lbldfsm
            // 
            this.lbldfsm.AutoSize = true;
            this.lbldfsm.Location = new System.Drawing.Point(120, 74);
            this.lbldfsm.Name = "lbldfsm";
            this.lbldfsm.Size = new System.Drawing.Size(309, 13);
            this.lbldfsm.TabIndex = 10;
            this.lbldfsm.Text = "Do not sync deletions if the percentage of deleted data exceeds";
            // 
            // chkDFSM
            // 
            this.chkDFSM.AutoSize = true;
            this.chkDFSM.Checked = true;
            this.chkDFSM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDFSM.Location = new System.Drawing.Point(21, 73);
            this.chkDFSM.Name = "chkDFSM";
            this.chkDFSM.Size = new System.Drawing.Size(78, 17);
            this.chkDFSM.TabIndex = 9;
            this.chkDFSM.Text = "Use DFSM";
            this.chkDFSM.UseVisualStyleBackColor = true;
            this.chkDFSM.CheckedChanged += new System.EventHandler(this.chkDFSM_CheckedChanged);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(18, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(602, 44);
            this.label15.TabIndex = 8;
            this.label15.Text = resources.GetString("label15.Text");
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkShowwindow);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(634, 67);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Application Startup";
            // 
            // chkShowwindow
            // 
            this.chkShowwindow.AutoSize = true;
            this.chkShowwindow.Location = new System.Drawing.Point(21, 28);
            this.chkShowwindow.Name = "chkShowwindow";
            this.chkShowwindow.Size = new System.Drawing.Size(185, 17);
            this.chkShowwindow.TabIndex = 0;
            this.chkShowwindow.Text = "Show the main window on startup";
            this.chkShowwindow.UseVisualStyleBackColor = true;
            this.chkShowwindow.CheckedChanged += new System.EventHandler(this.chkShowwindow_CheckedChanged);
            // 
            // tmrSynctimer
            // 
            this.tmrSynctimer.Interval = 1000;
            this.tmrSynctimer.Tick += new System.EventHandler(this.tmrSynctimer_Tick);
            // 
            // tmrJobcheck
            // 
            this.tmrJobcheck.Enabled = true;
            this.tmrJobcheck.Interval = 30000;
            this.tmrJobcheck.Tick += new System.EventHandler(this.tmrJobcheck_Tick);
            // 
            // tmrStartupJobCheck
            // 
            this.tmrStartupJobCheck.Enabled = true;
            this.tmrStartupJobCheck.Interval = 10000;
            this.tmrStartupJobCheck.Tick += new System.EventHandler(this.tmrStartupJobCheck_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "7 Sync";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.syncAllNowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 48);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // syncAllNowToolStripMenuItem
            // 
            this.syncAllNowToolStripMenuItem.Name = "syncAllNowToolStripMenuItem";
            this.syncAllNowToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.syncAllNowToolStripMenuItem.Text = "Sync All Now";
            this.syncAllNowToolStripMenuItem.Click += new System.EventHandler(this.syncAllNowToolStripMenuItem_Click);
            // 
            // tmrFormStartup
            // 
            this.tmrFormStartup.Enabled = true;
            this.tmrFormStartup.Interval = 500;
            this.tmrFormStartup.Tick += new System.EventHandler(this.tmrFormStartup_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 401);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sync v7.061";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker FileCopyWorker;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnList;
        private System.ComponentModel.BackgroundWorker FileListWorker;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label lblSubheading;
        private System.Windows.Forms.Label lblDeleteActioned;
        private System.Windows.Forms.Label lblNumDeleted;
        private System.Windows.Forms.Label lblToBeUpdated;
        private System.Windows.Forms.Label lblToBeCopied;
        private System.Windows.Forms.Label lblNumCompared;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumCopyActioned;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTimetaken;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer tmrSynctimer;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNumErrors;
        private System.Windows.Forms.Label lblSizetobecopied;
        private System.Windows.Forms.Label lblSizetobeupdated;
        private System.Windows.Forms.Label lblSizetobedeleted;
        private System.Windows.Forms.Label lblSizeCopyActioned;
        private System.Windows.Forms.Label lblSizeDeleteActioned;
        private System.Windows.Forms.Label lblSizecompared;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnNewsyncjob;
        private System.Windows.Forms.ListView lvSyncjobs;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Timer tmrJobcheck;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstFolderExclusions;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAddExtension;
        private System.Windows.Forms.TextBox txtFileExclusion;
        private System.Windows.Forms.ListBox lstExcludedExtensions;
        private System.Windows.Forms.Button btnDelExtension;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkShowwindow;
        private System.Windows.Forms.Label lbldfsm;
        private System.Windows.Forms.CheckBox chkDFSM;
        private System.Windows.Forms.Label lbldfsm2;
        private System.Windows.Forms.ComboBox ddlDelPercent;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Timer tmrStartupJobCheck;
        private System.Windows.Forms.Button btnRunselected;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncAllNowToolStripMenuItem;
        private System.Windows.Forms.Timer tmrFormStartup;
        private System.Windows.Forms.CheckBox chkScanonly;
        private System.Windows.Forms.Label lblNumWarnings;
        private System.Windows.Forms.Label label16;
    }
}

