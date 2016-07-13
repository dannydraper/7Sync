using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileCopyProgress
{
    public partial class SyncJob : Form
    {
        private Form1 mainform;

        FileListArgs m_args = new FileListArgs();

        public SyncJob()
        {
            InitializeComponent();
        }

        public void SetMainForm(Form1 form)
        {
            mainform = form;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateForm() == true)
            {
                mainform.SyncJobCompleted_UserEvent(FormToFileListArgs());
                this.Hide();
            }            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool ValidateForm()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("You must enter a name for this Sync Job", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (Directory.Exists(txtSource.Text) == false)
            {
                MessageBox.Show("The source directory you specified does not exist.", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (Directory.Exists(txtDest.Text) == false)
            {
                MessageBox.Show("The destination directory you specified does not exist.", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (optNormalSync.Checked == false && optCumSync.Checked == false && optNormalBackup.Checked == false && optCumBackup.Checked == false)
            {
                MessageBox.Show("You must specify the type of Sync to perform.", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (chkRunonnetwork.Checked == true)
            {
                if (txtComputerName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("You must specify a Computer Name or IP address to check for availability.", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (txtSource.Text == txtDest.Text)
            {
                MessageBox.Show("The source and destination directories cannot be the same.", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void ChangeIntervalOptions(bool display)
        {
            if (display == true)
            {
                optRunminutes.Enabled = true;
                ddlMinutes.Enabled = true;
                optRunweek.Enabled = true;
                ddlDay.Enabled = true;
                ddlTime.Enabled = true;
                ddlMinutes.SelectedIndex = 0;
                ddlDay.SelectedIndex = 0;
                ddlTime.SelectedIndex = 0;
            }
            else
            {
                optRunminutes.Enabled = false;
                ddlMinutes.Enabled = false;
                optRunweek.Enabled = false;
                ddlDay.Enabled = false;
                ddlTime.Enabled = false;
            }
        }

        private void ChangeNetworkOptions (bool display)
        {
            if (display == true) 
            {
                txtComputerName.Enabled = true;
            }
            else 
            {
                txtComputerName.Enabled = false;
            }
        }

        private void chkRunatintervals_CheckedChanged(object sender, EventArgs e)
        {
            ChangeIntervalOptions(chkRunatintervals.Checked);
        }

        private void chkRunonnetwork_CheckedChanged(object sender, EventArgs e)
        {
            ChangeNetworkOptions(chkRunonnetwork.Checked);
        }

        public void SyncTypeToForm(SyncType type)
        {
            if (type == SyncType.NormalSync)
            {
                optNormalSync.Checked = true;
                optCumSync.Checked = false;
                optNormalBackup.Checked = false;
                optCumBackup.Checked = false;
            }
            if (type == SyncType.CumulativeSync)
            {
                optNormalSync.Checked = false;
                optCumSync.Checked = true;
                optNormalBackup.Checked = false;
                optCumBackup.Checked = false;
            }
            if (type == SyncType.NormalBackup)
            {
                optNormalSync.Checked = false;
                optCumSync.Checked = false;
                optNormalBackup.Checked = true;
                optCumBackup.Checked = false;
            }
            if (type == SyncType.CumulativeBackup)
            {
                optNormalSync.Checked = false;
                optCumSync.Checked = false;
                optNormalBackup.Checked = false;
                optCumBackup.Checked = true;
            }
        }

        public SyncType FormToSyncType()
        {
            if (optNormalSync.Checked == true) return SyncType.NormalSync;
            if (optCumSync.Checked == true) return SyncType.CumulativeSync;
            if (optNormalBackup.Checked == true) return SyncType.NormalBackup;
            if (optCumBackup.Checked == true) return SyncType.CumulativeBackup;

            return SyncType.NormalSync;
        }

        public int GetIntervalMinutes()
        {            
            if (ddlMinutes.Text == "10 mins") return 10;
            if (ddlMinutes.Text == "20 mins") return 20;
            if (ddlMinutes.Text == "30 mins") return 30;
            if (ddlMinutes.Text == "40 mins") return 40;
            if (ddlMinutes.Text == "50 mins") return 50;
            if (ddlMinutes.Text == "1 hour") return 60;
            if (ddlMinutes.Text == "2 hours") return 60*2;
            if (ddlMinutes.Text == "3 hours") return 60*3;
            if (ddlMinutes.Text == "4 hours") return 60*4;
            if (ddlMinutes.Text == "5 hours") return 60*5;
            if (ddlMinutes.Text == "6 hours") return 60*6;
            if (ddlMinutes.Text == "7 hours") return 60*7;
            if (ddlMinutes.Text == "8 hours") return 60*8;
            if (ddlMinutes.Text == "9 hours") return 60*9;
            if (ddlMinutes.Text == "10 hours") return 60*10;
            if (ddlMinutes.Text == "11 hours") return 60*11;
            if (ddlMinutes.Text == "12 hours") return 60*12;

            return 60;            
        }

        public DateTime GetWeeklyTime()
        {            
            if (ddlTime.Text == "12 am") return new DateTime(2009, 1, 1, 0, 0, 0);
            if (ddlTime.Text == "1 am") return new DateTime(2009, 1, 1, 1, 0, 0);
            if (ddlTime.Text == "2 am") return new DateTime(2009, 1, 1, 2, 0, 0);
            if (ddlTime.Text == "3 am") return new DateTime(2009, 1, 1, 3, 0, 0);
            if (ddlTime.Text == "4 am") return new DateTime(2009, 1, 1, 4, 0, 0);
            if (ddlTime.Text == "5 am") return new DateTime(2009, 1, 1, 5, 0, 0);
            if (ddlTime.Text == "6 am") return new DateTime(2009, 1, 1, 6, 0, 0);
            if (ddlTime.Text == "7 am") return new DateTime(2009, 1, 1, 7, 0, 0);
            if (ddlTime.Text == "8 am") return new DateTime(2009, 1, 1, 8, 0, 0);
            if (ddlTime.Text == "9 am") return new DateTime(2009, 1, 1, 9, 0, 0);
            if (ddlTime.Text == "10 am") return new DateTime(2009, 1, 1, 10, 0, 0);
            if (ddlTime.Text == "11 am") return new DateTime(2009, 1, 1, 11, 0, 0);
            if (ddlTime.Text == "12 pm") return new DateTime(2009, 1, 1, 12, 0, 0);
            if (ddlTime.Text == "1 pm") return new DateTime(2009, 1, 1, 13, 0, 0);
            if (ddlTime.Text == "2 pm") return new DateTime(2009, 1, 1, 14, 0, 0);
            if (ddlTime.Text == "3 pm") return new DateTime(2009, 1, 1, 15, 0, 0);
            if (ddlTime.Text == "4 pm") return new DateTime(2009, 1, 1, 16, 0, 0);
            if (ddlTime.Text == "5 pm") return new DateTime(2009, 1, 1, 17, 0, 0);
            if (ddlTime.Text == "6 pm") return new DateTime(2009, 1, 1, 18, 0, 0);
            if (ddlTime.Text == "7 pm") return new DateTime(2009, 1, 1, 19, 0, 0);
            if (ddlTime.Text == "8 pm") return new DateTime(2009, 1, 1, 20, 0, 0);
            if (ddlTime.Text == "9 pm") return new DateTime(2009, 1, 1, 21, 0, 0);
            if (ddlTime.Text == "10 pm") return new DateTime(2009, 1, 1, 22, 0, 0);
            if (ddlTime.Text == "11 pm") return new DateTime(2009, 1, 1, 23, 0, 0);

            return new DateTime(2009, 1, 1, 0, 0, 0);
        }

        public void FileListArgsToForm(FileListArgs args)
        {
            m_args = args;

            txtName.Text = args.JobName;
            txtSource.Text = args.SourceDir;
            txtDest.Text = args.DestDir;
            SyncTypeToForm(args.JobType);
            chkRunatstartup.Checked = args.RunAtStartup;

            ChangeIntervalOptions(args.RunAtIntervals);
            chkRunatintervals.Checked = args.RunAtIntervals;

            if (args.RunAtIntervals == true)
            {
                if (args.JobInterval == IntervalType.Regular)
                {
                    optRunminutes.Checked = true;
                    optRunweek.Checked = false;
                    ddlMinutes.Text = args.Text_IntervalMinutes;
                }

                if (args.JobInterval == IntervalType.Weekly)
                {
                    optRunweek.Checked = true;
                    optRunminutes.Checked = false;
                    ddlDay.Text = args.DayofWeek;
                    ddlTime.Text = args.Text_TimeToRun;
                }
            }

            ChangeNetworkOptions(args.CheckNetworkComputer);
            chkRunonnetwork.Checked = args.CheckNetworkComputer;
            chkLowpriority.Checked = args.LowPriority;

        }

        public FileListArgs FormToFileListArgs()
        {
            FileListArgs args = new FileListArgs();

            args.LastRunDate = m_args.LastRunDate;
            args.JobName = txtName.Text;

            if (txtSource.Text.Substring(txtSource.Text.Length - 1, 1) == "\\")
            {
                txtSource.Text = txtSource.Text.Substring(0, txtSource.Text.Length - 1);
            }

            if (txtDest.Text.Substring(txtDest.Text.Length - 1, 1) == "\\")
            {
                txtDest.Text = txtDest.Text.Substring(0, txtDest.Text.Length - 1);
            }

            args.SourceDir = txtSource.Text;
            args.DestDir = txtDest.Text;
            args.JobType = FormToSyncType();
            args.RunAtStartup = chkRunatstartup.Checked;
            args.RunAtIntervals = chkRunatintervals.Checked;

            if (chkRunatintervals.Checked == true)
            {
                if (optRunminutes.Checked == true)
                {
                    args.JobInterval = IntervalType.Regular;
                    args.Text_IntervalMinutes = ddlMinutes.Text;
                    args.IntervalMinutes = GetIntervalMinutes();
                }

                if (optRunweek.Checked == true)
                {
                    args.JobInterval = IntervalType.Weekly;
                    args.DayofWeek = ddlDay.Text;
                    args.Text_TimeToRun = ddlTime.Text;
                    args.TimeToRun = GetWeeklyTime();
                }
            }

            args.CheckNetworkComputer = chkRunonnetwork.Checked;
            if (chkRunonnetwork.Checked == true)
            {
                args.ComputerName = txtComputerName.Text;
            }
            args.LowPriority = chkLowpriority.Checked;

            return args;
        }

        private void SyncJob_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            folderBrowser.Description = "Choose your Source directory...";

            if (Directory.Exists(txtSource.Text) == true)
            {
                folderBrowser.SelectedPath = txtSource.Text;
            }
            
            folderBrowser.ShowDialog();



            if (Directory.Exists(folderBrowser.SelectedPath) == true)
            {
                txtSource.Text = folderBrowser.SelectedPath;
            }

            
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            folderBrowser.Description = "Choose your Destination directory...";

            if (Directory.Exists(txtDest.Text) == true)
            {
                folderBrowser.SelectedPath = txtDest.Text;
            }
            
            folderBrowser.ShowDialog();

            if (Directory.Exists(folderBrowser.SelectedPath) == true)
            {
                txtDest.Text = folderBrowser.SelectedPath;
            }
            
        }
    }
}