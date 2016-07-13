using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using System.Xml.Serialization;

namespace FileCopyProgress
{
    
    public enum SyncType
    {
        NormalSync = 1,
        CumulativeSync = 2,
        NormalBackup = 3,
        CumulativeBackup = 4
    }

    public enum IntervalType
    {
        Regular = 1,
        Weekly = 2
    }

    public partial class Form1 : Form
    {
        bool m_progresssizeset = false;
        int m_progressdivider = 1;
        long m_numcompared = 0;
        long m_numtobecopied = 0;
        long m_numtobeupdated = 0;
        long m_numtobedeleted = 0;
        long m_numdeleteactioned = 0;
        long m_numcopiedactioned = 0;
        long m_numerrors = 0;
        long m_numwarnings = 0;

        long m_sizecompared = 0;
        long m_sizetobecopied = 0;
        long m_sizetobeupdated = 0;
        long m_sizetobedeleted = 0;
        long m_sizecopiedactioned = 0;
        long m_sizedeleteactioned = 0;
        

        long m_numsecondselapsed = 0;
        DateTime m_dtTimestarted;

        bool m_bformactivated = false;
        bool m_busercancelled = false;
        bool m_bsyncinprogress = false;
        bool m_blisterror = false;

        AppSettings m_appsettings = new AppSettings();

        // The list of files to be copied - used only by the copy file function which processes this list.
        LinkedList<FileCopyEntry> m_llcopyentries = new LinkedList<FileCopyEntry>();
        LinkedListNode<FileCopyEntry> m_lncurrentcopy;

        // The queue of files to be deleted - after the deletions have been processed, this list will contain
        // all files that should be deleted.
        LinkedList<FileDeleteEntry> m_lldeleteentries = new LinkedList<FileDeleteEntry>();
        LinkedListNode<FileDeleteEntry> m_lncurrentdeletion;

        // The list of extensions to be excluded from syncs or backups
        ArrayList m_alExclusions = new ArrayList();

        // The Backup/Sync entries - which are to be run now
        LinkedList<FileListArgs> m_llsyncentries = new LinkedList<FileListArgs>();
        LinkedListNode<FileListArgs> m_lncurrentgroup;

        // Saved sync entries - loaded from XML file
        LinkedList<FileListArgs> m_llsavedentries = new LinkedList<FileListArgs>();

        // The list of files and directories that are CURRENT - built by the list dirs function
        // This list will then be saved over the previous XML backup but only AFTER the backup file has
        // been processed for possible deletions.
        LinkedList<FileListDBEntry> m_llcurrentfileentries = new LinkedList<FileListDBEntry>();

        // The list of Folder exclusions that exist
        ArrayList m_alFolderexclusions = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        public void ResetStats()
        {
            m_progresssizeset = false;
            m_progressdivider = 1;
            m_numcompared = 0;
            m_numtobecopied = 0;
            m_numtobeupdated = 0;
            m_numtobedeleted = 0;
            m_numdeleteactioned = 0;
            m_numcopiedactioned = 0;
            m_numsecondselapsed = 0;
            m_numerrors = 0;
            m_numwarnings = 0;

            m_sizetobecopied = 0;
            m_sizetobeupdated = 0;
            m_sizetobedeleted = 0;
            m_sizecopiedactioned = 0;
            m_sizedeleteactioned = 0;
            m_sizecompared = 0;
            m_blisterror = false;

            m_llcurrentfileentries.Clear();
            m_llcopyentries.Clear();
            m_lldeleteentries.Clear();

            lblNumCopyActioned.Text = m_numcopiedactioned.ToString();
            lblSizeCopyActioned.Text = FormatFileSize(m_sizecopiedactioned);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //m_lncurrentcopy = m_llcopyentries.First;
            //FileCopyWorker.RunWorkerAsync(new FileCopyArgs(m_lncurrentcopy.Value.SourceFile, m_lncurrentcopy.Value.DestFile));

            FileStream fsOut = new FileStream("C:\\Temp\\Bigfile.dat", FileMode.Create);

            byte[] array = new byte[32768];

            for (int a = 0; a < 32768; a++)
            {
                array[a] = 123;
            }

            long ipointer = 0;

            while (ipointer < 4194304000)
            {
                fsOut.Write(array, 0, 32768);
                ipointer += 32768;
            }

            fsOut.Close();

            MessageBox.Show("Done");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FileCopyWorker.CancelAsync();
            FileListWorker.CancelAsync();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            AddAllSyncEntries();
            SyncSelectedEntries();
        }


        private void tmrSynctimer_Tick(object sender, EventArgs e)
        {
            m_numsecondselapsed++;
            TimeSpan timeelapsed = new TimeSpan();
            timeelapsed = DateTime.Now - m_dtTimestarted;
            DateTime dtelapsed = new DateTime (2009, 1, 1, (int)timeelapsed.Hours, (int)timeelapsed.Minutes, (int)timeelapsed.Seconds, 0);

            lblTimetaken.Text = dtelapsed.ToString("H:mm:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            progressBar2.Visible = false;

            LoadXMLAppSettings();
            AppSettingToForm();

            LoadXMLSyncEntries();
            RefreshSyncJobList();

            LoadXMLFolderExclusions();
            RefreshExcludedFolders();

            LoadXMLFileExclusions();
            RefreshFileExclusions();
        }

        private void tmrJobcheck_Tick(object sender, EventArgs e)
        {
            // Every 30 second this piece of code runs to check if any jobs should be started

            LinkedListNode<FileListArgs> cur;

            if (m_llsavedentries.Count > 0)
            {
                cur = m_llsavedentries.First;

                for (int s = 0; s < m_llsavedentries.Count; s++)
                {
                    if (cur.Value.RunAtIntervals == true)
                    {
                        if (cur.Value.JobInterval == IntervalType.Regular)
                        {

                            TimeSpan ts = new TimeSpan();
                            ts = DateTime.Now - cur.Value.LastRunDate;

                            if (ts.TotalMinutes > cur.Value.IntervalMinutes)
                            {
                                m_llsyncentries.AddLast(cur.Value);
                            }
                        }

                        if (cur.Value.JobInterval == IntervalType.Weekly)
                        {
                            TimeSpan ts = new TimeSpan();
                            ts = DateTime.Now - cur.Value.LastRunDate;

                            DateTime dtRun = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, cur.Value.TimeToRun.Hour, cur.Value.TimeToRun.Minute, 0);

                            if (ts.TotalDays > 2)
                            {
                                if (DateTime.Now.DayOfWeek.ToString().ToUpper() == cur.Value.DayofWeek.ToUpper())
                                {
                                    if (DateTime.Now > dtRun)
                                    {
                                        m_llsyncentries.AddLast(cur.Value);
                                    }
                                }
                            }
                        }
                    }

                    

                    cur = cur.Next;
                }
            }

            if (m_llsyncentries.Count > 0)
            {
                SyncSelectedEntries();
            }
        }

        private void tmrFormStartup_Tick(object sender, EventArgs e)
        {
            tmrFormStartup.Enabled = false;

            if (m_appsettings.ShowWindowOnStartup == true)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                Hide();
            }
        }

        private void tmrStartupJobCheck_Tick(object sender, EventArgs e)
        {
            tmrStartupJobCheck.Enabled = false;



            // Check if any jobs need running at startup. This timer will run after 10 seconds
            // of the application running. All jobs set to run at startup will then be added
            // to the sync queue, and then run.

            LinkedListNode<FileListArgs> cur;

            if (m_llsavedentries.Count > 0)
            {
                cur = m_llsavedentries.First;

                for (int s = 0; s < m_llsavedentries.Count; s++)
                {
                    if (cur.Value.RunAtStartup == true)
                    {                        
                        m_llsyncentries.AddLast(cur.Value);                        
                    }

                    cur = cur.Next;
                }
            }

            if (m_llsyncentries.Count > 0)
            {
                SyncSelectedEntries();
            }
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void syncAllNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAllSyncEntries();
            SyncSelectedEntries();
        }


        #region ApplicationSettings



        public void LoadXMLAppSettings()
        {
            if (File.Exists(GetAppSettingsDir() + "Settings.xml") == true)
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(AppSettings));

                // To read the xml file, create a FileStream.
                FileStream myFileStream = new FileStream(GetAppSettingsDir() + "Settings.xml", FileMode.Open);

                // Call the Deserialize method and cast to the object type.
                m_appsettings = (AppSettings)mySerializer.Deserialize(myFileStream);

                myFileStream.Close();
            }
        }

        public void SaveXMLAppSettings()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(AppSettings));
            StreamWriter myWriter = new StreamWriter(GetAppSettingsDir() + "Settings.xml");

            mySerializer.Serialize(myWriter, m_appsettings);
            myWriter.Close();
        }

        private void AppSettingToForm()
        {
            chkDFSM.Checked = m_appsettings.UseDFSM;
            ddlDelPercent.Text = m_appsettings.DFSMPercent.ToString ();
            chkShowwindow.Checked = m_appsettings.ShowWindowOnStartup;
            chkScanonly.Checked = m_appsettings.Scanonly;
            btnApply.Enabled = false;
        }

        private void FormToAppSettings()
        {
            m_appsettings.UseDFSM = chkDFSM.Checked;
            if (ddlDelPercent.Text.Trim() == "")
            {
                m_appsettings.DFSMPercent = 10;
            }
            else
            {
                m_appsettings.DFSMPercent = Int32.Parse(ddlDelPercent.Text);
            }
            m_appsettings.ShowWindowOnStartup = chkShowwindow.Checked;
            m_appsettings.Scanonly = chkScanonly.Checked;
        }

        private void chkDFSM_CheckedChanged(object sender, EventArgs e)
        {
            lbldfsm.Enabled = chkDFSM.Checked;
            lbldfsm2.Enabled = chkDFSM.Checked;
            ddlDelPercent.Enabled = chkDFSM.Checked;
            btnApply.Enabled = true;
        }

        private void chkShowwindow_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void chkSysicon_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void ddlDelPercent_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }


        private void chkScanonly_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            FormToAppSettings();
            SaveXMLAppSettings();
            btnApply.Enabled = false;
        }


        #endregion


        #region File Extension Exclusion


        private void btnAddExtension_Click(object sender, EventArgs e)
        {
            if (txtFileExclusion.Text.Trim().Length > 0)
            {
                
                String strExclusion = "";
                if (txtFileExclusion.Text.Substring(0, 1) == ".")
                {
                    strExclusion = txtFileExclusion.Text;
                }
                else
                {
                    strExclusion = "." + txtFileExclusion.Text;
                }

                if (DoesFileExclusionExists(strExclusion) == false)
                {

                    m_alExclusions.Add(strExclusion);
                    RefreshFileExclusions();
                    SaveXMLFileExclusions();
                }
                else
                {
                    MessageBox.Show("That file extension is already excluded.", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You must enter a file extension (e.g. .tmp) to exclude from Sync jobs", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnDelExtension_Click(object sender, EventArgs e)
        {
            String strExtension = "";
            if (lstExcludedExtensions.SelectedIndex >= 0)
            {
                strExtension = lstExcludedExtensions.SelectedItem.ToString();
                RemoveFileExclusion(strExtension);
                RefreshFileExclusions();
                SaveXMLFileExclusions();
            }
        }

        private bool DoesFileExclusionExists(String strExclusion)
        {
            for (int a = 0; a < m_alExclusions.Count; a++)
            {
                if ((String)m_alExclusions[a].ToString ().ToUpper ().Trim() == strExclusion.ToUpper ().Trim())
                {
                    return true;
                }
            }

            return false;
        }

        private void RemoveFileExclusion(String strExtension)
        {
            for (int a = 0; a < m_alExclusions.Count; a++)
            {
                if ((String)m_alExclusions[a] == strExtension)
                {
                    m_alExclusions.RemoveAt(a);
                }
            }
        }

        public void RefreshFileExclusions()
        {
            lstExcludedExtensions.Items.Clear();

            for (int a = 0; a < m_alExclusions.Count; a++)
            {
                lstExcludedExtensions.Items.Add((String)m_alExclusions[a]);
            }
        }

        public void LoadXMLFileExclusions()
        {
            m_alExclusions.Clear();

            if (File.Exists(GetAppSettingsDir() + "FileExtExclusions.xml") == true)
            {
                String[] array;
                XmlSerializer mySerializer = new XmlSerializer(typeof(String[]));

                // To read the xml file, create a FileStream.
                FileStream myFileStream = new FileStream(GetAppSettingsDir() + "FileExtExclusions.xml", FileMode.Open);

                // Call the Deserialize method and cast to the object type.
                array = (String[])mySerializer.Deserialize(myFileStream);

                myFileStream.Close();

                // process the array            
                for (long i = 0; i < array.GetLength(0); i++)
                {
                    m_alExclusions.Add(array[i]);
                }
            }
        }

        public void SaveXMLFileExclusions()
        {
            if (m_alExclusions.Count > 0)
            {
                String[] array = new String[m_alExclusions.Count];
                m_alExclusions.CopyTo(array, 0);

                XmlSerializer mySerializer = new XmlSerializer(typeof(String[]));
                StreamWriter myWriter = new StreamWriter(GetAppSettingsDir() + "FileExtExclusions.xml");

                mySerializer.Serialize(myWriter, array);
                myWriter.Close();
            }
            else
            {
                if (File.Exists(GetAppSettingsDir() + "FileExtExclusions.xml") == true)
                {
                    File.Delete(GetAppSettingsDir() + "FileExtExclusions.xml");
                }
            }
        }

        #endregion


        #region FolderExclusionManagement

        private void btnAdd_Click(object sender, EventArgs e)
        {
            folderBrowser.Description = "Specify a folder to exclude...";
            folderBrowser.ShowDialog();

            if (Directory.Exists(folderBrowser.SelectedPath) == true)
            {
                //txtSource.Text = folderBrowser.SelectedPath;
                if (IsFolderExcluded(folderBrowser.SelectedPath) == false)
                {
                    m_alFolderexclusions.Add(folderBrowser.SelectedPath);
                }
                else
                {
                    MessageBox.Show("That folder is already excluded.", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            SaveXMLFolderExclusions();
            RefreshExcludedFolders();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            String strPath = "";
            if (lstFolderExclusions.SelectedIndex >= 0)
            {
                strPath = lstFolderExclusions.SelectedItem.ToString();
                RemoveFolderExclusion(strPath);
                RefreshExcludedFolders();
                SaveXMLFolderExclusions();
            }
        }

        private bool IsFolderExcluded(String strFolderpath)
        {
            for (int a = 0; a < m_alFolderexclusions.Count; a++)
            {
                if ((String)m_alFolderexclusions[a].ToString ().ToUpper () == strFolderpath.ToUpper ())
                {
                    return true;
                }
            }
            return false;
        }

        private void RemoveFolderExclusion(String strPath)
        {
            for (int a = 0; a < m_alFolderexclusions.Count; a++)
            {
                if ((String)m_alFolderexclusions[a] == strPath)
                {
                    m_alFolderexclusions.RemoveAt(a);
                }
            }            
        }

        private void RefreshExcludedFolders()
        {
            lstFolderExclusions.Items.Clear();

            for (int a = 0; a < m_alFolderexclusions.Count; a++)
            {
                lstFolderExclusions.Items.Add((String) m_alFolderexclusions[a]);
            }
        }

        public void LoadXMLFolderExclusions()
        {
            m_alFolderexclusions.Clear();

            if (File.Exists(GetAppSettingsDir() + "FolderExclusions.xml") == true)
            {
                String[] array;
                XmlSerializer mySerializer = new XmlSerializer(typeof(String[]));

                // To read the xml file, create a FileStream.
                FileStream myFileStream = new FileStream(GetAppSettingsDir() + "FolderExclusions.xml", FileMode.Open);

                // Call the Deserialize method and cast to the object type.
                array = (String[])mySerializer.Deserialize(myFileStream);

                myFileStream.Close();

                // process the array            
                for (long i = 0; i < array.GetLength(0); i++)
                {                    
                    m_alFolderexclusions.Add(array[i]);
                }
            }
        }

        public void SaveXMLFolderExclusions()
        {            
            if (m_alFolderexclusions.Count > 0)
            {
                String[] array = new String[m_alFolderexclusions.Count];
                m_alFolderexclusions.CopyTo(array, 0);

                XmlSerializer mySerializer = new XmlSerializer(typeof(String[]));
                StreamWriter myWriter = new StreamWriter(GetAppSettingsDir() + "FolderExclusions.xml");

                mySerializer.Serialize(myWriter, array);
                myWriter.Close();
            }
            else
            {
                if (File.Exists(GetAppSettingsDir() + "FolderExclusions.xml") == true)
                {
                    File.Delete(GetAppSettingsDir() + "FolderExclusions.xml");
                }
            }
        }

        #endregion

        #region CurrentSyncEntries

        private void AddbyEntryName(String strEntryname)
        {
            LinkedListNode<FileListArgs> cur;

            if (m_llsavedentries.Count > 0)
            {
                cur = m_llsavedentries.First;

                for (int s = 0; s < m_llsavedentries.Count; s++)
                {
                    if (cur.Value.JobName == strEntryname)
                    {
                        m_llsyncentries.AddLast(cur.Value);
                    }
                    
                    cur = cur.Next;
                }
            }
        }

        private void AddAllSyncEntries()
        {
            // This is called when a SYNC-ALL is called by the user
            // this adds all saved entries to the current sync entries which will then be
            // run one at a time by the sync'ing code.

            LinkedListNode<FileListArgs> cur;

            if (m_llsavedentries.Count > 0)
            {
                cur = m_llsavedentries.First;

                for (int s = 0; s < m_llsavedentries.Count; s++)
                {
                    m_llsyncentries.AddLast(cur.Value);
                    cur = cur.Next;
                }
            }
        }

        private void SyncSelectedEntries()
        {
            if (m_bsyncinprogress == false)
            {
                m_bsyncinprogress = true;
                if (m_llsyncentries.Count > 0)
                {
                    btnList.Enabled = false;
                    btnCancel.Enabled = true;
                    tmrJobcheck.Enabled = false;
                    tmrStartupJobCheck.Enabled = false;
                    m_dtTimestarted = DateTime.Now;
                    lblTimetaken.Text = "0:00:00";
                    tmrSynctimer.Enabled = true;
                    listBox1.Items.Clear();
                    ResetStats();

                    m_lncurrentgroup = m_llsyncentries.First;
                    lblGroupName.Text = m_lncurrentgroup.Value.JobName;
                    listBox2.Items.Add("Starting " + m_lncurrentgroup.Value.JobName + " at " + DateTime.Now.ToString());
                    FileListWorker.RunWorkerAsync(m_lncurrentgroup.Value);
                }
                else
                {
                    MessageBox.Show("There are no Sync jobs defined. Please define some Sync jobs to be run.", "Sync", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region SyncEntryManagement

        private void btnNewsyncjob_Click(object sender, EventArgs e)
        {
            SyncJob jobform = new SyncJob();

            jobform.SetMainForm(this);
            jobform.Show();
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            if (lvSyncjobs.SelectedItems.Count > 0)
            {
                String strItemName = lvSyncjobs.Items[lvSyncjobs.SelectedIndices[0]].Text;

                if (MessageBox.Show("Delete " + strItemName + " Sync Entry?", "Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteSyncEntry(strItemName);
                    RefreshSyncJobList();
                    SaveXMLSyncEntries();
                }
            }
            
        }

        private void lvSyncjobs_DoubleClick(object sender, EventArgs e)
        {
            String strItemName = lvSyncjobs.Items[lvSyncjobs.SelectedIndices[0]].Text;

            FileListArgs args = GetSyncEntry(strItemName);

            SyncJob jobform = new SyncJob();

            jobform.SetMainForm(this);
            jobform.FileListArgsToForm(args);

            jobform.Show();

        }

        private void btnRunselected_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < lvSyncjobs.SelectedItems.Count; a++)
            {
                if (lvSyncjobs.SelectedItems[a].Selected == true)
                {
                    AddbyEntryName(lvSyncjobs.SelectedItems[a].Text);
                }
            }

            if (m_llsyncentries.Count > 0)
            {
                SyncSelectedEntries();
            }
        }

        public void LoadXMLSyncEntries()
        {
            m_llsavedentries.Clear();

            if (File.Exists(GetAppSettingsDir() + "SyncEntries.xml") == true)
            {
                FileListArgs[] array;
                XmlSerializer mySerializer = new XmlSerializer(typeof(FileListArgs[]));

                // To read the xml file, create a FileStream.
                FileStream myFileStream = new FileStream(GetAppSettingsDir() + "SyncEntries.xml", FileMode.Open);

                // Call the Deserialize method and cast to the object type.
                array = (FileListArgs[])mySerializer.Deserialize(myFileStream);

                myFileStream.Close();

                // process the array            
                for (long i = 0; i < array.GetLength(0); i++)
                {
                    m_llsavedentries.AddLast(array[i]);
                }
            }
        }

        public void SaveXMLSyncEntries()
        {
            if (m_llsavedentries.Count > 0)
            {
                FileListArgs[] array = new FileListArgs[m_llsavedentries.Count];
                m_llsavedentries.CopyTo(array, 0);

                XmlSerializer mySerializer = new XmlSerializer(typeof(FileListArgs[]));
                StreamWriter myWriter = new StreamWriter(GetAppSettingsDir() + "SyncEntries.xml");

                mySerializer.Serialize(myWriter, array);
                myWriter.Close();
            }
            else
            {
                if (File.Exists(GetAppSettingsDir() + "SyncEntries.xml") == true)
                {
                    File.Delete(GetAppSettingsDir() + "SyncEntries.xml");
                }
            }
        }


        private bool DoesSyncJobExist(String JobName)
        {
            LinkedListNode<FileListArgs> cur;

            if (m_llsavedentries.Count > 0)
            {
                cur = m_llsavedentries.First;

                for (int s = 0; s < m_llsavedentries.Count; s++)
                {
                    if (cur.Value.JobName == JobName)
                    {
                        return true;
                    }

                    cur = cur.Next;
                }
            }

            return false;
        }

        private void RefreshSyncJobList()
        {
            LinkedListNode<FileListArgs> cur;
            lvSyncjobs.Clear();

            if (m_llsavedentries.Count > 0)
            {
                cur = m_llsavedentries.First;

                for (int s = 0; s < m_llsavedentries.Count; s++)
                {
                    lvSyncjobs.Items.Add(new ListViewItem(cur.Value.JobName, 0));

                    cur = cur.Next;
                }
            }
        }

        public void SyncJobCompleted_UserEvent(FileListArgs args)
        {
            // The user has clicked OK to the Sync Job form
            // First check if the args already exists in the sync jobs list
            if (DoesSyncJobExist(args.JobName) == true)
            {
                UpdateSyncEntry(args);
            }
            else
            {
                m_llsavedentries.AddLast(args);
            }

            RefreshSyncJobList();
            SaveXMLSyncEntries();
        }

        private FileListArgs GetSyncEntry(String EntryName)
        {
            LinkedListNode<FileListArgs> cur;

            if (m_llsavedentries.Count > 0)
            {
                cur = m_llsavedentries.First;

                for (int s = 0; s < m_llsavedentries.Count; s++)
                {
                    if (cur.Value.JobName == EntryName)
                    {
                        return cur.Value;
                    }

                    cur = cur.Next;
                }
            }

            return new FileListArgs();
        }

        private void UpdateSyncEntry(FileListArgs args)
        {
            LinkedListNode<FileListArgs> cur;

            if (m_llsavedentries.Count > 0)
            {
                cur = m_llsavedentries.First;

                for (int s = 0; s < m_llsavedentries.Count; s++)
                {
                    if (cur.Value.JobName == args.JobName)
                    {
                        cur.Value = args;
                        return;
                    }

                    cur = cur.Next;
                }
            }
        }

        private void DeleteSyncEntry(String strJobName)
        {
            LinkedListNode<FileListArgs> cur;

            if (m_llsavedentries.Count > 0)
            {
                cur = m_llsavedentries.First;

                for (int s = 0; s < m_llsavedentries.Count; s++)
                {
                    if (cur.Value.JobName == strJobName)
                    {
                        m_llsavedentries.Remove(cur);
                        return;
                    }

                    cur = cur.Next;
                }
            }
        }



        #endregion


        #region FileCopyWorkerCode

        private void BuildDestFileDirs(String strDestfile)
        {
            LinkedList<String> pathlist = new LinkedList<String>();
            LinkedListNode<String> curpath;

            String strFullpath = strDestfile;

            String strFilteredpath = Path.GetDirectoryName(strFullpath);

            while (Directory.Exists(strFilteredpath) == false)
            {
                pathlist.AddLast(new LinkedListNode<string>(strFilteredpath));
                strFilteredpath = Path.GetDirectoryName(strFilteredpath);
            }

            curpath = pathlist.Last;
            for (int a = 0; a < pathlist.Count; a++)
            {
                Directory.CreateDirectory(curpath.Value);
                curpath = curpath.Previous;
            }
        }

        private void FileCopyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                FileCopyArgs args = (FileCopyArgs)e.Argument;

                String strSourcedir = Path.GetPathRoot(args.Source);
                String strDestdir = Path.GetPathRoot(args.Destination);

                if (Directory.Exists(strDestdir) == false)
                {
                    e.Result = new FileCopyResult(false, "Destination location no longer exists.", false);
                    m_numerrors++;
                    return;
                }

                if (Directory.Exists(strSourcedir) == false) 
                {
                    e.Result = new FileCopyResult(false, "Source location no longer exists.", false);
                    m_numerrors++;
                    return;
                }


                FileStream fsIn = new FileStream(args.Source, FileMode.Open, FileAccess.Read);
                bool bdestexists = false;



                if (File.Exists(args.Destination) == true)
                {
                    // If this is a file update the rename the destination file to .sbak
                    File.Move(args.Destination, args.Destination + "sbak");
                    bdestexists = true;
                }
                else
                {
                    BuildDestFileDirs(args.Destination);
                }
               
                // The min and max block sizes that are allowed, the blocksize value will be auto
                // adjusted depending on how long a block is taking to copy, in order that we will
                // receive a progress report between our min and max report interval.
                int maxblocksize = 2048000;
                int minblocksize = 256;
                bool cancelled = false;
                bool errorinterupted = false;

                int minreportinterval = 300; // The minimum number of ms that we want a progress report
                int maxreportinterval = 600; // the maximum number of ms that we want a progress report

                int blocksize = 65536; // Starting block size that will either be expanded or shrunk depending on how long each block is taking

                byte[] buffer = new byte[blocksize];

                FileStream fsOut = new FileStream(args.Destination, FileMode.Create, FileAccess.ReadWrite);

                long numblocks = fsIn.Length / blocksize;
                long remaining = fsIn.Length % blocksize;
                long inputfilelength = fsIn.Length;
                int bytesread = 0;
                long filepointer = 0;

                // Block timing variables so we can ensure we get progress reports very often no matter
                // how fast or slow the copy operation is taking.
                long blocktimetaken = 0;
                long beforeblock = 0;
                long afterblock = 0;

                if (remaining > 0) numblocks++;

                //for (long b = 0; b < numblocks; b++)

                while (filepointer < inputfilelength)
                {
                    if (Directory.Exists(strSourcedir) == false || Directory.Exists(strDestdir) == false)
                    {
                        errorinterupted = true;
                        break;
                    }

                    if (FileCopyWorker.CancellationPending == true)
                    {
                        FileCopyWorker.ReportProgress(0, new FileCopyProgress(blocksize, 0, (int)blocktimetaken, inputfilelength, args));
                        cancelled = true;
                        break;
                    }
                    beforeblock = DateTime.Now.Ticks;

                    bytesread = fsIn.Read(buffer, 0, blocksize);
                    filepointer += bytesread;
                    fsOut.Write(buffer, 0, bytesread);
                    Thread.Sleep(100);

                    

                    afterblock = DateTime.Now.Ticks;

                    blocktimetaken = (afterblock - beforeblock) / TimeSpan.TicksPerMillisecond;

                    FileCopyWorker.ReportProgress(0, new FileCopyProgress(blocksize, filepointer, (int)blocktimetaken, inputfilelength, args));


                    if (blocktimetaken < minreportinterval || blocktimetaken > maxreportinterval)
                    {
                        if (blocktimetaken < minreportinterval)
                        {
                            if (blocksize < maxblocksize)
                            {
                                blocksize = blocksize * 2;
                                buffer = new byte[blocksize];
                            }
                        }

                        if (blocktimetaken > maxreportinterval)
                        {
                            if (blocksize > minblocksize)
                            {
                                blocksize = blocksize / 2;
                                buffer = new byte[blocksize];
                            }
                        }
                    }
                }


                fsIn.Close();
                fsOut.Close();

                if (errorinterupted == false)
                {

                    if (cancelled == true)
                    {
                        // If the user cancelled the operation
                        File.Delete(args.Destination);

                        if (bdestexists == true) // If this was an overwrite operation then replace the previous file.
                        {
                            if (File.Exists(args.Destination + "sbak") == true)
                            {
                                File.Move(args.Destination + "sbak", args.Destination);
                            }
                        }

                    }
                    else
                    {
                        if (bdestexists == true) // If this was an overwrite operation then replace the previous file.
                        {
                            if (File.Exists(args.Destination + "sbak") == true)
                            {
                                File.Delete(args.Destination + "sbak");
                            }
                        }

                        File.SetAttributes(args.Destination, File.GetAttributes(args.Source));
                        File.SetCreationTime(args.Destination, File.GetCreationTime(args.Source));
                        File.SetLastAccessTime(args.Destination, File.GetLastAccessTime(args.Source));
                        File.SetLastWriteTime(args.Destination, File.GetLastWriteTime(args.Source));
                    }
                }
                else
                {
                    // Something interrupted the copy, we must abort.
                    e.Result = new FileCopyResult(false, "File copy interrupted, either the source or destination was no longer available.", false);
                }

                
                
                e.Result = new FileCopyResult(true, "", cancelled);
            }
            catch (Exception ex)
            {
                e.Result = new FileCopyResult(false, ex.Message, false);
                m_numerrors++;
            }
            
            
        }

        private String FormatFileSize(long filesize)
        {
            if (filesize > 0 && filesize <= 1000) return Convert.ToString(filesize) + "b";
            if (filesize > 1000 && filesize <= 1000000) return Convert.ToString(filesize / 1000) + "Kb";
            if (filesize > 1000000 && filesize <= 1000000000) return Convert.ToString(filesize / 1000000) + "MB";
            if (filesize > 1000000000) return Convert.ToString(filesize / 1000000000) + "GB";

            return Convert.ToString(filesize / 1000000) + "MB";
        }

        private void FileCopyWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            String strHeading = "Copying files...";

            FileCopyProgress prog = (FileCopyProgress)e.UserState;

            if (prog.filesize < 65535)
            {
                m_progressdivider = 1;
            }
            else
            {
                if (prog.filesize > 1000000000)
                {
                    m_progressdivider = 100000;
                }
                else
                {
                    m_progressdivider = 1000;
                }                
            }

            if (m_progresssizeset == false)
            {
                m_progresssizeset = true;
                progressBar1.Minimum = 0;

                long progmax = prog.filesize / m_progressdivider;                

                progressBar1.Maximum = (int)progmax;

                //lblSource.Text = prog.args.Source;
                //lblDestination.Text = prog.args.Destination;
                lblSubheading.Text = "(" + FormatFileSize (prog.filesize) + ") From: " + FormatPath(prog.args.Source, 50) + "  To: " + FormatPath(prog.args.Destination, 50);
            }

            long progvalue = prog.filepointer / m_progressdivider;

            progressBar1.Value = (int)progvalue;
            lblHeading.Text = strHeading;

            //label1.Text = "Bytes Copied: " + prog.filepointer + "  BlockSize: " + prog.currentblocksize + "  BlockTime: " + prog.blocktimetaken;



        }

        private void SyncCompleted(bool bError)
        {
            m_bsyncinprogress = false;
            tmrSynctimer.Enabled = false;
            progressBar1.Visible = false;
            progressBar2.Visible = false;
            tmrJobcheck.Enabled = true;
            btnList.Enabled = true;
            btnCancel.Enabled = false;
            m_blisterror = false;
            m_llsyncentries.Clear();
            SaveXMLSyncEntries();


            if (bError == true)
            {
                lblHeading.Text = "Sync failed at " + DateTime.Now.ToString();
                lblSubheading.Text = m_numcopiedactioned.ToString() + " files were copied and " + m_numdeleteactioned.ToString() + " files were deleted, and " + m_numerrors.ToString () + " errors.";
                listBox2.Items.Add("Sync failed at " + DateTime.Now.ToString() + "  -  " + m_numcopiedactioned.ToString() + " files were copied and " + m_numdeleteactioned.ToString() + " files were deleted, and " + m_numerrors.ToString () + " errors.");
            }
            else
            {
                lblHeading.Text = "Sync completed at " + DateTime.Now.ToString();
                lblSubheading.Text = m_numcopiedactioned.ToString() + " files were copied and " + m_numdeleteactioned.ToString() + " files were deleted.";
                listBox2.Items.Add("Sync completed at " + DateTime.Now.ToString() + "  -  " + m_numcopiedactioned.ToString() + " files were copied and " + m_numdeleteactioned.ToString() + " files were deleted.");
            }
            

        }

        private void FileCopyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FileCopyResult myresult = (FileCopyResult)e.Result;
            progressBar2.Value++;
            FileInfo finfo;

            if (myresult.cancelled == true)
            {
                lblHeading.Text = "Cancelled at " + DateTime.Now.ToString();                
            }
            else
            {
                if (myresult.success == true)
                {
                    m_numcopiedactioned++;
                    lblNumCopyActioned.Text = m_numcopiedactioned.ToString();
                    

                    finfo = new FileInfo(m_lncurrentcopy.Value.SourceFile);
                    m_sizecopiedactioned += finfo.Length;
                    lblSizeCopyActioned.Text = FormatFileSize(m_sizecopiedactioned);

                    listBox1.Items.Add("*** COPY SUCCESS ***  From: " + m_lncurrentcopy.Value.SourceFile + "   To: " + m_lncurrentcopy.Value.DestFile);
                }
                else
                {
                    lblNumErrors.Text = m_numerrors.ToString();
                    listBox1.Items.Add("*** ERROR COPYING *** From: " + m_lncurrentcopy.Value.SourceFile + "   To: " + m_lncurrentcopy.Value.DestFile + "  Error Reason: " + myresult.ErrorMessage);
                }


                m_lncurrentcopy = m_lncurrentcopy.Next;

                if (m_lncurrentcopy != null)
                {
                    String strSourcedir = Path.GetPathRoot(m_lncurrentcopy.Value.SourceFile);
                    String strDestdir = Path.GetPathRoot(m_lncurrentcopy.Value.DestFile);

                    if (Directory.Exists(strSourcedir) == true)
                    {
                        if (Directory.Exists(strDestdir) == true)
                        {
                            FileCopyWorker.RunWorkerAsync(new FileCopyArgs(m_lncurrentcopy.Value.SourceFile, m_lncurrentcopy.Value.DestFile));
                        }
                        else
                        {
                            listBox1.Items.Add("*** ERROR DESTINATION NO LONGER AVAILABLE *** From: " + m_lncurrentcopy.Value.SourceFile + "   To: " + m_lncurrentcopy.Value.DestFile);
                            m_numerrors++;
                            lblNumErrors.Text = m_numerrors.ToString();
                            SyncCompleted(true);
                        }
                    }
                    else
                    {
                        listBox1.Items.Add("*** ERROR SOURCE NO LONGER AVAILABLE *** From: " + m_lncurrentcopy.Value.SourceFile + "   To: " + m_lncurrentcopy.Value.DestFile);
                        m_numerrors++;
                        lblNumErrors.Text = m_numerrors.ToString();
                        SyncCompleted(true);
                    }
                }
                else
                {
                    SyncCompleted(false);
                }
            }            
            
            m_progresssizeset = false;
        }

        #endregion


        #region FileListingComparisonCode

        private String GetAppSettingsDir()
        {
            // Function to retrieve the applications settings directory which
            // is usually APPDATA\\FileCopyProgress
            String strSavepath = System.Environment.GetEnvironmentVariable("APPDATA") + "\\7Sync";
            Directory.CreateDirectory(strSavepath);
            return strSavepath + "\\";
        }

        private void SaveCurrentXMLListing(String strJobName)
        {
            // This is the function that will save the list of scanned files and directories
            // OVER THE TOP of the last XML file. This will be a current list. But this save
            // MUST BE DONE AFTER the deletions of the previous xml file have been processed.

            // Also, this save function is called if a previous XML list does not exist in which
            // case this will be used as a first instance.

            // Now serialize the file array list into the xml index file.
            //String[] filenamearray;
            //filenamearray = (String[])alfilelist.ToArray(typeof(String));
            FileListDBEntry[] array = new FileListDBEntry[m_llcurrentfileentries.Count];
            m_llcurrentfileentries.CopyTo(array, 0);

            XmlSerializer mySerializer = new XmlSerializer(typeof(FileListDBEntry[]));
            StreamWriter myWriter = new StreamWriter(GetAppSettingsDir () + strJobName + ".xml");

            mySerializer.Serialize(myWriter, array);
            myWriter.Close();
            
        }

        private bool IsFileExcluded(String strFilepath)
        {
            int a = 0;
            String curExc = "";

            if (Path.GetExtension(strFilepath.ToUpper()).Contains("SBAK") == true)
            {
                return true;
            }

            for (a = 0; a < m_alExclusions.Count; a++)
            {
                curExc = (String)m_alExclusions[a];

                if (strFilepath.ToUpper().Contains(curExc.ToUpper()) == true)
                {
                    return true;
                }
            }

            return false;
        }

        FileCompareResults CompareFile(String strSource, String strDest)
        {
            // Remember, strDest is a theoretical destination as it has just been constructed given the 2
            // paths to compare. strSource is the real dir. Also this is a push update function only
            // Which means updates are pushed from Source to dest, but not the other way, it is up to 
            // danhead to call the list function in the reverse direction.

            FileInfo finfo;
            FileCompareResults res = new FileCompareResults();

            if (File.Exists(strDest) == false)
            {
                // File doesn't exist, so it needs to be copied.
                res.bToBeCopied = true;
                if (m_appsettings.Scanonly == false)
                {
                    m_llcopyentries.AddLast(new FileCopyEntry(strSource, strDest, "File does not exist at destination"));
                }
                
            }
            else
            {
                DateTime dtfs = File.GetLastWriteTime (strSource);
                DateTime dtSource = new DateTime(dtfs.Year, dtfs.Month, dtfs.Day, dtfs.Hour, dtfs.Minute, dtfs.Second);

                DateTime dtfd = File.GetLastWriteTime(strDest);
                DateTime dtDest = new DateTime(dtfd.Year, dtfd.Month, dtfd.Day, dtfd.Hour, dtfd.Minute, dtfd.Second);

                FileInfo fi1 = new FileInfo(strSource);
                FileInfo fi2 = new FileInfo(strDest);


                if (dtSource > dtDest)
                {

                    TimeSpan ts = new TimeSpan();
                    ts = dtSource - dtDest;

                    if (ts.TotalSeconds > 5)
                    {
                        res.bToBeUpdated = true;
                        if (m_appsettings.Scanonly == false)
                        {
                            m_llcopyentries.AddLast(new FileCopyEntry(strSource, strDest, "Source file is newer"));
                        }
                    }
                    else
                    {
                        res.bTimeSpanFiltered = true;
                        res.bTimeSpanAmount = (int)ts.TotalSeconds;

                        if (fi1.Length != fi2.Length)
                        {
                            res.FileSizeInconsistent = true;
                            res.SourceSize = fi1.Length;
                            res.DestSize = fi2.Length;
                        }
                    }
                }
                else
                {
                    if (dtSource == dtDest)
                    {
                        if (fi1.Length != fi2.Length)
                        {
                            res.FileSizeInconsistent = true;
                            res.SourceSize = fi1.Length;
                            res.DestSize = fi2.Length;
                        }
                    }
                }
            }

            m_numcompared++;

            finfo = new FileInfo(strSource);
            m_sizecompared += finfo.Length;

            return res;
        }


        void ListDirs(String strSource, String strSourceRoot, String strDest, BackgroundWorker bw)
        {
            String strHeader = "Checking for added and updated files...";

            if (bw.CancellationPending == true)
            {
                return;
            }

            if (m_blisterror == true)
            {
                if (Directory.Exists(strSourceRoot) == false)
                {
                    m_busercancelled = true;
                    bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** BEGIN LIST ERROR - SOURCE NO LONGER AVAILABLE ***  " + strSourceRoot));
                    return;
                }

                if (Directory.Exists(strDest) == false)
                {
                    m_busercancelled = true;
                    bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** BEGIN LIST ERROR - DESTINATION NO LONGER AVAILABLE ***  " + strDest));
                    return;
                }
            }

            try
            {            
                string[] dirs;
                string[] files;

                dirs = Directory.GetDirectories(strSource);
                files = Directory.GetFiles(strSource);
                FileInfo finfo;

                m_llcurrentfileentries.AddLast(new FileListDBEntry(strSource, true));

                for (int f = 0; f < files.Length; f++)
                {
                    //Thread.Sleep(1);
                    //Thread.Sleep(5);
                    if (m_lncurrentgroup.Value.LowPriority == true)
                    {
                        Thread.Sleep(100);
                    }

                    if (bw.CancellationPending == true)
                    {
                        m_busercancelled = true;
                        return;
                    }

                    if (m_blisterror == false)
                    {
                        String strSourcepath = (String)files[f];

                        if (IsFileExcluded(strSourcepath) == false)
                        {
                            m_llcurrentfileentries.AddLast(new FileListDBEntry(strSourcepath, false, File.GetLastWriteTime(strSourcepath)));

                            String strDestpath = strSourcepath.Replace(strSourceRoot, strDest);

                            FileCompareResults CompareResults = CompareFile(strSourcepath, strDestpath);

                            bw.ReportProgress(0, new StandardProgress(true, strHeader, true, FormatPath(strSourcepath, 100)));

                            if (CompareResults.bToBeUpdated == true) // This is a newer/updated file
                            {
                                m_numtobeupdated++;
                                finfo = new FileInfo(strSourcepath);
                                m_sizetobeupdated += finfo.Length;

                                bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** UPDATED FILE ***  " + strSourcepath));
                            }

                            if (CompareResults.bToBeCopied == true) // This is an added file
                            {
                                m_numtobecopied++;
                                finfo = new FileInfo(strSourcepath);
                                m_sizetobecopied += finfo.Length;
                                bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** NEW FILE ***  " + strSourcepath));
                            }

                            if (CompareResults.bTimeSpanFiltered == true) // This file was updated but filtered because it was not new enough.
                            {
                                //bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** UPDATED BUT NOT NEW ENOUGH ***  Diff: " + CompareResults.bTimeSpanAmount.ToString () + " - " + strSourcepath));
                            }

                            if (CompareResults.FileSizeInconsistent == true) // The files have the same modified date, but the sizes don't match - flag it
                            {
                                m_numwarnings++;
                                bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** LAST MODIFIED DATE IS IDENTICAL BUT FILE SIZES DON'T MATCH ***  Source Len: " + CompareResults.SourceSize.ToString() + ", Dest Len: " + CompareResults.DestSize + " - " + strSourcepath));
                            }
                        }
                    }
                    else
                    {
                        if (Directory.Exists(strSourceRoot) == false)
                        {
                            m_busercancelled = true;
                            bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** FILE LISTING ERROR - SOURCE NO LONGER AVAILABLE ***  " + strSourceRoot));
                            return;
                        }

                        if (Directory.Exists(strDest) == false)
                        {
                            m_busercancelled = true;
                            bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** FILE LISTING ERROR - DESTINATION NO LONGER AVAILABLE ***  " + strDest));
                            return;
                        }
                    }
                }

                for (int d = 0; d < dirs.Length; d++)
                {
                    if (m_blisterror == true)
                    {
                        if (Directory.Exists(strSourceRoot) == false)
                        {
                            m_busercancelled = true;
                            bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** DIR LIST ERROR - SOURCE NO LONGER AVAILABLE ***  " + strSourceRoot));
                            return;
                        }

                        if (Directory.Exists(strDest) == false)
                        {
                            m_busercancelled = true;
                            bw.ReportProgress(0, new StandardProgress(false, "", false, "", true, " *** DIR LIST ERROR - DESTINATION NO LONGER AVAILABLE ***  " + strDest));
                            return;
                        }
                    }

                    if (IsFolderExcluded(dirs[d]) == false && IsFolderExcluded(dirs[d].Replace(strSourceRoot, strDest)) == false && IsFolderExcluded(dirs[d].Replace(strDest, strSourceRoot)) == false)
                    {
                        //MessageBox.Show(dirs[d].Replace(strSourceRoot, strDest));
                        //MessageBox.Show(dirs[d].Replace(strDest, strSourceRoot));
                        ListDirs(dirs[d], strSourceRoot, strDest, bw);
                    }
                }
            } 
            catch (Exception ex) 
            {
                //bw.ReportProgress(0, new FileCompareProgress(ex.Message, new FileCompareResults()));
                m_blisterror = true;
                bw.ReportProgress(0, new StandardProgress(false, "", true, ex.Message, true, " *** LIST ERROR ***  " + ex.Message));
                m_numerrors++;
                
            }
        }

        private void DoDeletions(BackgroundWorker bw)
        {
            if (m_appsettings.Scanonly == true)
            {
                return;
            }
            String strHeader = "Deleting files...";

            // Do the files first
            m_lncurrentdeletion = m_lldeleteentries.First;

            FileInfo finfo;


            while (m_lncurrentdeletion != null)
            {
                if (bw.CancellationPending == true)
                {
                    m_busercancelled = true;
                    m_lldeleteentries.Clear();
                    return;
                }

                //Thread.Sleep(1);
                if (m_lncurrentdeletion.Value.bIsDir == false)
                {
                    try
                    {
                        finfo = new FileInfo(m_lncurrentdeletion.Value.DeletePath);
                        m_sizedeleteactioned += finfo.Length;

                        File.Delete(m_lncurrentdeletion.Value.DeletePath);
                        //bw.ReportProgress(0, new FileCompareProgress(m_lncurrentdeletion.Value.DeletePath, new FileCompareResults(false, false, false, true)));
                        m_numdeleteactioned++;

                        bw.ReportProgress(0, new StandardProgress(true, strHeader, true, "Deleted " + FormatPath(m_lncurrentdeletion.Value.DeletePath, 100), true, "** DELETED ** " + m_lncurrentdeletion.Value.DeletePath));
                    }
                    catch (Exception ex1)
                    {                        
                        bw.ReportProgress(0, new StandardProgress(true, strHeader, true, "Error deleting " + FormatPath(m_lncurrentdeletion.Value.DeletePath, 100), true, "** ERROR DELETING ** " + m_lncurrentdeletion.Value.DeletePath + "  -  " + ex1.Message));
                        m_numerrors++;
                    }
                    
                    
                }                
                m_lncurrentdeletion = m_lncurrentdeletion.Next;
            }

            // Now do the directories
            m_lncurrentdeletion = m_lldeleteentries.First;
            while (m_lncurrentdeletion != null)
            {
                if (bw.CancellationPending == true)
                {
                    m_busercancelled = true;
                    m_lldeleteentries.Clear();
                    return;
                }

                //Thread.Sleep(1);
                if (m_lncurrentdeletion.Value.bIsDir == true)
                {
                    try
                    {
                        Directory.Delete(m_lncurrentdeletion.Value.DeletePath, true);
                        bw.ReportProgress(0, new StandardProgress(true, strHeader, true, "Deleted " + FormatPath(m_lncurrentdeletion.Value.DeletePath, 100), true, "** DELETED ** " + m_lncurrentdeletion.Value.DeletePath));
                    }
                    catch (Exception ex2)
                    {
                        bw.ReportProgress(0, new StandardProgress(true, strHeader, true, "Error deleting " + FormatPath(m_lncurrentdeletion.Value.DeletePath, 100), true, "** ERROR DELETING ** " + m_lncurrentdeletion.Value.DeletePath + "  -  " + ex2.Message));
                        m_numerrors++;
                    }
                    
                }
                m_lncurrentdeletion = m_lncurrentdeletion.Next;
            }

            m_lldeleteentries.Clear();
        }

        private void ListDeletions(String JobName, String SourceRoot, String DestRoot, BackgroundWorker bw)
        {
            // This function basically goes through the JobName xml file, looks at each file
            // and directory listed in the XML, then does a check to see if it exists now on the hard disk.
            // If it does not exist now, then the user deleted it, and the file is added to the deletions
            // queue for later processing. - BE CAREFUL though - we must be a bit smart because if the user
            // moved their entire working directory temporarily then this would go and delete everything in the
            // Sync'd directory! - we cannot allow this. Therefore this function should not process the deletions
            // It determines that all files should be deleted.
            String strOutputheader = "Checking for deleted files...";

            FileInfo finfo;

            bw.ReportProgress(0, new StandardProgress(true, strOutputheader));

            if (File.Exists(GetAppSettingsDir() + JobName + ".xml") == true)
            {
                bw.ReportProgress(0, new StandardProgress(true, strOutputheader, true, "Opening XML file listing..."));
                // Only process deletions if we have an XML history file.
                String ConstructedDestDelete = "";

                // Number of deletions to be queued
                long Numdeletions = 0;

                FileListDBEntry[] array;
                XmlSerializer mySerializer = new XmlSerializer(typeof(FileListDBEntry[]));

                // To read the xml file, create a FileStream.
                FileStream myFileStream = new FileStream(GetAppSettingsDir() + JobName + ".xml", FileMode.Open);

                bw.ReportProgress(0, new StandardProgress(true, strOutputheader, true, "Reading XML file list..."));

                // Call the Deserialize method and cast to the object type.
                array = (FileListDBEntry[])mySerializer.Deserialize(myFileStream);

                // process the array            
                for (long i = 0; i < array.GetLength(0); i++)
                {
                    if (m_lncurrentgroup.Value.LowPriority == true)
                    {
                        Thread.Sleep(100);
                    }

                    if (bw.CancellationPending == true)
                    {
                        m_busercancelled = true;
                        m_numtobedeleted = 0;
                        m_lldeleteentries.Clear();
                        m_sizetobedeleted = 0;
                        myFileStream.Close();
                        return;
                    }

                    bw.ReportProgress(0, new StandardProgress(true, strOutputheader, true, "Analysing " +  FormatPath (array[i].FilePath, 100)));
                    
                    
                    if (array[i].IsDir == false)
                    {
                        if (File.Exists(array[i].FilePath) == false) // If the file listed in the xml does not exist in the source
                        { // Then it needs to be deleted from the dest.
                            ConstructedDestDelete = array[i].FilePath.Replace(SourceRoot, DestRoot);
                            Numdeletions++;
                            m_numtobedeleted++;

                            if (File.Exists (ConstructedDestDelete) == true) 
                            {
                                finfo = new FileInfo(ConstructedDestDelete);
                                m_sizetobedeleted += finfo.Length;

                                bw.ReportProgress(0, new StandardProgress(true, strOutputheader, true, "Analysing " + FormatPath(array[i].FilePath, 100), true, "** NEEDS DELETING **  " + array[i].FilePath));

                                if (m_appsettings.Scanonly == false)
                                {
                                    m_lldeleteentries.AddLast(new FileDeleteEntry(ConstructedDestDelete, false, "File deleted from source."));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Directory.Exists(array[i].FilePath) == false) // If the directory listed in the xml does not exist in the source
                        {
                            ConstructedDestDelete = array[i].FilePath.Replace(SourceRoot, DestRoot);

                            if (Directory.Exists(ConstructedDestDelete) == true)
                            {
                                Numdeletions++;
                                m_numtobedeleted++;
                                bw.ReportProgress(0, new StandardProgress(true, strOutputheader, true, "Analysing " + FormatPath(array[i].FilePath, 100), true, "** NEEDS DELETING **  " + array[i].FilePath));
                                if (m_appsettings.Scanonly == false)
                                {
                                    m_lldeleteentries.AddLast(new FileDeleteEntry(ConstructedDestDelete, true, "Directory deleted from source."));
                                }
                            }
                        }
                    }
                }

                myFileStream.Close();

                if (m_appsettings.UseDFSM == true)
                {

                    if (Numdeletions > 0)
                    {
                        // Now the important bit - if we've deleted over a given percentage of the entire source directory then ABORT! This is a safety measure
                        // just incase a directory has been moved.
                        // Work out the percentage of deletions that have occured.
                        int iPercent = ((int)Numdeletions * 100) / array.GetLength(0);

                        if (iPercent > m_appsettings.DFSMPercent)
                        {
                            m_numtobedeleted = 0;
                            m_lldeleteentries.Clear();

                            m_sizetobedeleted = 0;

                            bw.ReportProgress(0, new StandardProgress(true, strOutputheader, true, "Aborted.", true, "*** DELETES ABORTED *** - Number of deleted files exceeded safety amount."));
                        }
                    }
                }
            }
        }

        public String FormatPath(String inPath, int MaxLength)
        {
            if (inPath.Length > MaxLength)
            {
                String strFormatted = inPath.Substring(0, 15) + "....." + inPath.Substring(inPath.Length - (MaxLength-20));
                return strFormatted;
            }
            else
            {
                return inPath;
            }
        }

        private void FileListWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // The SYNC starts here. The first thing we do is look at the saved XML files and work out if the user
            // has deleted any files on either the source of destination. If they have the deletions are processed FIRST.
            // After this the source and dest directories are listed in real time, and any updated/new files are then
            // added to a queue which is the processed by the FileCopyWorker, and all the updated/new files are copied
            // from source to dest and vice versa. The Deletions List function has a safety measure built in so that it does
            // not delete the files if the number of deletions has exceeded a certain percentage.
            FileListArgs args = (FileListArgs)e.Argument;

            m_lncurrentgroup.Value.LastRunDate = DateTime.Now;

            // Before doing anything make sure the source and dest directories exist first
            // network shares may be down or physical disks removed.
            if (Directory.Exists(args.SourceDir) == true)
            {
                if (Directory.Exists(args.DestDir) == true) {

                    if (args.JobType == SyncType.NormalSync || args.JobType == SyncType.NormalBackup)
                    {
                        if (m_busercancelled == false)
                        {
                            ListDeletions(args.JobName + "-Source", args.SourceDir, args.DestDir, FileListWorker);
                        }

                        if (args.JobType == SyncType.NormalSync)
                        {
                            if (m_busercancelled == false)
                            {
                                ListDeletions(args.JobName + "-Dest", args.DestDir, args.SourceDir, FileListWorker);
                            }
                        }

                        if (m_busercancelled == false)
                        {
                            DoDeletions(FileListWorker);
                        }
                        
                    }

                    if (m_blisterror == false)
                    {
                        if (m_busercancelled == false)
                        {
                            ListDirs(args.SourceDir, args.SourceDir, args.DestDir, FileListWorker);
                        }
                    }

                    if (m_blisterror == false)
                    {
                        if (m_busercancelled == false)
                        {
                            SaveCurrentXMLListing(args.JobName + "-Source");
                        }
                    }
                    
                    m_llcurrentfileentries.Clear();

                    
                    if (args.JobType == SyncType.NormalSync || args.JobType == SyncType.CumulativeSync)                    
                    {
                        if (m_blisterror == false)
                        {
                            if (m_busercancelled == false)
                            {
                                ListDirs(args.DestDir, args.DestDir, args.SourceDir, FileListWorker);
                            }
                        }

                        if (m_blisterror == false)
                        {
                            if (m_busercancelled == false)
                            {
                                SaveCurrentXMLListing(args.JobName + "-Dest");
                            }
                        }
                        
                        m_llcurrentfileentries.Clear();
                    }


                } else {
                    m_numerrors++;
                    FileListWorker.ReportProgress(0, new StandardProgress(false, "", true, "Sync aborted - " + FormatPath(args.DestDir, 70) + " not found.", true, "** SYNC ABORTED ** - " + args.DestDir + " not found."));
                }
            }
            else
            {
                m_numerrors++;
                FileListWorker.ReportProgress(0, new StandardProgress(false, "", true, "Sync aborted - " + FormatPath(args.SourceDir, 70) + " not found.", true, "** SYNC ABORTED ** - " + args.SourceDir + " not found."));
            }
            
        }

        private void FileListWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblNumCompared.Text = m_numcompared.ToString();
            lblToBeCopied.Text = m_numtobecopied.ToString();
            lblToBeUpdated.Text = m_numtobeupdated.ToString();
            lblNumDeleted.Text = m_numtobedeleted.ToString();
            lblDeleteActioned.Text = m_numdeleteactioned.ToString();
            lblNumErrors.Text = m_numerrors.ToString();
            lblNumWarnings.Text = m_numwarnings.ToString();

            lblSizecompared.Text = FormatFileSize(m_sizecompared);
            lblSizetobeupdated.Text = FormatFileSize(m_sizetobeupdated);
            lblSizetobecopied.Text = FormatFileSize(m_sizetobecopied);
            lblSizetobedeleted.Text = FormatFileSize(m_sizetobedeleted);

            lblSizeDeleteActioned.Text = FormatFileSize(m_sizedeleteactioned);


            if (e.UserState.GetType () == typeof (StandardProgress)) 
            {
                StandardProgress StdProgress = (StandardProgress)e.UserState;

                if (StdProgress.useHeading == true) lblHeading.Text = StdProgress.Heading;
                if (StdProgress.useSubheading == true) lblSubheading.Text = StdProgress.Subheading;
                if (StdProgress.useListoutput == true) listBox1.Items.Add(StdProgress.ListOutput);
            }
        }

        private void FileListWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_lncurrentgroup = m_lncurrentgroup.Next;
            lblNumErrors.Text = m_numerrors.ToString();

            if (m_lncurrentgroup != null)
            {
                lblGroupName.Text = m_lncurrentgroup.Value.JobName;
                listBox2.Items.Add("Starting " + m_lncurrentgroup.Value.JobName + " at " + DateTime.Now.ToString());
                FileListWorker.RunWorkerAsync(m_lncurrentgroup.Value);
            }
            else
            {
                // Now begin the file copying - basically process the file copy queue, this queue
                // will contain every file copy needed from source to dest or vice versa
                m_lncurrentcopy = m_llcopyentries.First;
                if (m_lncurrentcopy != null)
                {
                    String strSourcedir = Path.GetPathRoot(m_lncurrentcopy.Value.SourceFile);
                    String strDestdir = Path.GetPathRoot(m_lncurrentcopy.Value.DestFile);                    

                    if (Directory.Exists(strSourcedir) == true)
                    {
                        if (Directory.Exists(strDestdir) == true)
                        {
                            progressBar2.Maximum = m_llcopyentries.Count;
                            progressBar2.Value = 0;
                            progressBar1.Visible = true;
                            progressBar2.Visible = true;

                            FileCopyWorker.RunWorkerAsync(new FileCopyArgs(m_lncurrentcopy.Value.SourceFile, m_lncurrentcopy.Value.DestFile));
                        }
                        else
                        {
                            listBox1.Items.Add("*** COPYING ABORTED - ERROR DESTINATION NO LONGER AVAILABLE *** From: " + m_lncurrentcopy.Value.SourceFile + "   To: " + m_lncurrentcopy.Value.DestFile);
                            m_numerrors++;
                            lblNumErrors.Text = m_numerrors.ToString();
                            SyncCompleted(true);
                        }
                    }
                    else
                    {
                        listBox1.Items.Add("*** COPYING ABORTED - ERROR SOURCE NO LONGER AVAILABLE *** From: " + m_lncurrentcopy.Value.SourceFile + "   To: " + m_lncurrentcopy.Value.DestFile);
                        m_numerrors++;
                        lblNumErrors.Text = m_numerrors.ToString();
                        SyncCompleted(true);
                    }

                }
                else
                {
                    m_bsyncinprogress = false;
                    tmrSynctimer.Enabled = false;
                    tmrJobcheck.Enabled = true;
                    btnList.Enabled = true;
                    btnCancel.Enabled = false;
                    SaveXMLSyncEntries();
                    m_llsyncentries.Clear();
                    m_blisterror = false;

                    if (m_busercancelled == true)
                    {
                        lblHeading.Text = "Sync cancelled at " + DateTime.Now.ToString();
                        m_busercancelled = false;
                    }
                    else
                    {
                        lblHeading.Text = "Sync completed at " + DateTime.Now.ToString();
                    }

                    

                    if (m_numdeleteactioned > 0)
                    {
                        lblSubheading.Text = m_numdeleteactioned.ToString () + " files were deleted.";
                        listBox2.Items.Add("Sync completed at " + DateTime.Now.ToString() + "  -  " + m_numdeleteactioned.ToString() + " files were deleted.");
                    }
                    else
                    {
                        if (m_numerrors > 0)
                        {
                            lblSubheading.Text = "No changes were made, but there were " + m_numerrors.ToString () + " errors.";
                            listBox2.Items.Add("Sync completed at " + DateTime.Now.ToString() + "  -  " + "No changes were made, but there were " + m_numerrors.ToString() + " errors.");
                        }
                        else
                        {
                            lblSubheading.Text = "No changes were made.";
                            listBox2.Items.Add("Sync completed at " + DateTime.Now.ToString() + "  -  " + "No changes were made.");
                        }                        
                    }
                }
            }
        }
        #endregion



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }





    }

    #region FileCopyClasses


    public class FileCopyProgress
    {
        public int currentblocksize;
        public long filepointer;
        public int blocktimetaken;
        public long filesize;
        public FileCopyArgs args;

        public FileCopyProgress(int blocksize, long fpointer, int timetaken, long fsize, FileCopyArgs fargs)
        {
            currentblocksize = blocksize;
            filepointer = fpointer;
            blocktimetaken = timetaken;
            filesize = fsize;
            args = fargs;
        }
    }

    public class FileCopyArgs
    {
        public String Source;
        public String Destination;

        public FileCopyArgs()
        {
            Source = "";
            Destination = "";
        }

        public FileCopyArgs(String Src, String Dest)
        {
            Source = Src;
            Destination = Dest;
        }
    }

    public class FileCopyResult
    {
        public bool success;
        public String ErrorMessage;
        public bool cancelled;

        public FileCopyResult(bool succeeded, String ErrMessage, bool cancel)
        {
            success = succeeded;
            ErrorMessage = ErrMessage;
            cancelled = cancel;
        }
    }

    public class FileCopyEntry
    {
        public String SourceFile;
        public String DestFile;
        public String CopyReason;

        public FileCopyEntry(String Src, String Dest, String Reason)
        {
            SourceFile = Src;
            DestFile = Dest;
            CopyReason = Reason;
        }

        public FileCopyEntry()
        {
            SourceFile = "";
            DestFile = "";
            CopyReason = "";
        }
    }

    public class FileDeleteEntry
    {
        public String DeletePath;
        public bool bIsDir;
        public String DeleteReason;

        public FileDeleteEntry(String Path, bool IsDir, String Reason)
        {
            DeletePath = Path;
            bIsDir = IsDir;
            DeleteReason = Reason;
        }

        public FileDeleteEntry()
        {
            DeletePath = "";
            bIsDir = false;
            DeleteReason = "";
        }


    }

    #endregion


    #region FileCompareClasses

    public class FileListDBEntry
    {
        // This is the object that is stored in the XML file
        // for checking deleted files and directories, and for conflicting files (files that have been modified on both sides).
        // All we need is the file path, the type, and the modified date

        public String FilePath;
        public bool IsDir;
        public DateTime ModifiedDate;

        public FileListDBEntry()
        {
            FilePath = "";
            IsDir = false;
            ModifiedDate = new DateTime();
        }

        public FileListDBEntry(String pFilePath, bool pIsDir, DateTime pModifiedDate)
        {
            FilePath = pFilePath;
            IsDir = pIsDir;
            ModifiedDate = pModifiedDate;
        }

        public FileListDBEntry(String pFilePath, bool pIsDir)
        {
            FilePath = pFilePath;
            IsDir = pIsDir;            
        }
    }

    public class FileListArgs
    {
        public String JobName;
        public String SourceDir;
        public String DestDir;
        public SyncType JobType = SyncType.NormalSync;
        public bool RunAtStartup;
        public bool RunAtIntervals;
        public IntervalType JobInterval = IntervalType.Regular;
        public String DayofWeek;
        public DateTime TimeToRun;
        public String Text_TimeToRun;
        public int IntervalMinutes;
        public String Text_IntervalMinutes;        
        public bool CheckNetworkComputer;
        public String ComputerName;
        public bool LowPriority;
        public DateTime LastRunDate;

        public FileListArgs(String Name, String Source, String Dest)
        {
            JobName = Name;
            SourceDir = Source;
            DestDir = Dest;
        }

        public FileListArgs()
        {

        }
    }

    public class FileCompareResults
    {
        public bool bToBeUpdated = false;
        public bool bToBeCopied = false;
        public bool bToBeDeleted = false;
        public bool bDeleteActioned = false;
        public bool bTimeSpanFiltered = false;
        public int bTimeSpanAmount = 0;
        public bool FileSizeInconsistent = false;
        public long SourceSize = 0;
        public long DestSize = 0;

        public FileCompareResults()
        {
            bToBeUpdated = false;
            bToBeCopied = false;
            bToBeDeleted = false;
        }

        public FileCompareResults(bool Updated, bool Copied, bool Deleted)
        {
            bToBeUpdated = Updated;
            bToBeCopied = Copied;
            bToBeDeleted = Deleted;
        }

        public FileCompareResults(bool Updated, bool Copied, bool Deleted, bool DeleteActioned)
        {
            bToBeUpdated = Updated;
            bToBeCopied = Copied;
            bToBeDeleted = Deleted;
            bDeleteActioned = DeleteActioned;
        }
    }

    public class FileCompareProgress
    {
        public FileCompareResults CompareResults;
        public String strFilepath;

        public FileCompareProgress(String Filepath, FileCompareResults compresults)
        {
            CompareResults = compresults;
            strFilepath = Filepath;
        }
    }

    public class StandardProgress
    {
        public String Heading;
        public String Subheading;
        public String ListOutput;

        public bool useHeading;
        public bool useSubheading;
        public bool useListoutput;

        public StandardProgress()
        {

        }

        public StandardProgress(bool useheading, String heading)
        {
            useHeading = useheading;
            Heading = heading;
        }

        public StandardProgress(bool useheading, String heading, bool usesubheading, String subheading)
        {
            useHeading = useheading;
            Heading = heading;
            useSubheading = usesubheading;
            Subheading = subheading;
        }

        public StandardProgress(bool useheading, String heading, bool usesubheading, String subheading, bool uselistoutput, String listoutput)
        {
            useHeading = useheading;
            Heading = heading;
            useSubheading = usesubheading;
            Subheading = subheading;
            useListoutput = uselistoutput;
            ListOutput = listoutput;
        }
    }

    #endregion


    public class AppSettings
    {
        public bool UseDFSM = true;
        public int DFSMPercent = 10;
        public bool ShowWindowOnStartup = true;
        public bool ShowSysTrayIcon = false;
        public bool Scanonly = false;

        public AppSettings()
        {

        }
    }
}