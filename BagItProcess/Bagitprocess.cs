namespace BagItProcess
{
    using Microsoft.WindowsAPICodePack.Dialogs;
    using Newtonsoft.Json.Linq;
    using Renci.SshNet;
    using Renci.SshNet.Common;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Diagnostics;
    using System.DirectoryServices.AccountManagement;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// This screen used to process the choosen files/folders to Aurora shared location
    /// </summary>
    public partial class frmBagitprocess : Form
    {
        /// <summary>
        /// Defines the HostName
        /// </summary>
        public static string HostName = string.Empty;

        /// <summary>
        /// Defines the PythonDirectory
        /// </summary>
        public static string PythonDirectory = string.Empty;

        /// <summary>
        /// Defines the PythonExePath
        /// </summary>
        public static string PythonExePath = string.Empty;

        /// <summary>
        /// Defines the create_bag_path
        /// </summary>
        public static string create_bag_path = string.Empty;

        /// <summary>
        /// Defines the BagitDirectory
        /// </summary>
        public static string BagitDirectory = string.Empty;

        /// <summary>
        /// Defines the validate_bag_path
        /// </summary>
        public static string validate_bag_path = string.Empty;

        /// <summary>
        /// Defines the ProcessedArchive
        /// </summary>
        public static string ProcessedArchive = string.Empty;

        /// <summary>
        /// Defines the SFTPUserName
        /// </summary>
        public static string SFTPUserName = string.Empty;

        /// <summary>
        /// Defines the SFTPPassword
        /// </summary>
        public static string SFTPPassword = string.Empty;

        /// <summary>
        /// Defines the SFTPPort
        /// </summary>
        public static int SFTPPort = 0;

        /// <summary>
        /// Defines the SFTP_Directory_Path
        /// </summary>
        public static string SFTP_Directory_Path = string.Empty;

        /// <summary>
        /// Defines the Dest_Directory_Path
        /// </summary>
        public static string Dest_Directory_Path = string.Empty;

        /// <summary>
        /// Defines the ProcessPath
        /// </summary>
        public static string ProcessPath = string.Empty;

        /// <summary>
        /// Defines the filesize
        /// </summary>
        public static long filesize = 0;

        /// <summary>
        /// Defines the sftp
        /// </summary>
        public static SftpClient sftp = null;

        /// <summary>
        /// Defines the conInfo
        /// </summary>
        public static ConnectionInfo conInfo = null;

        /// <summary>
        /// Defines the SuccessResult
        /// </summary>
        public string SuccessResult = string.Empty;

        /// <summary>
        /// Defines the SuccessBagMessage
        /// </summary>
        public string SuccessBagMessage = string.Empty;

        /// <summary>
        /// Defines the ErrorsResult
        /// </summary>
        public string ErrorsResult = string.Empty;

        /// <summary>
        /// Defines the Base_processPath
        /// </summary>
        public static string Base_processPath = string.Empty;

        /// <summary>
        /// Defines the bagTemplatepath
        /// </summary>
        public static string bagTemplatepath = string.Empty;

        /// <summary>
        /// Defines the bLoadFlag
        /// </summary>
        public static bool bLoadFlag = false;

        /// <summary>
        /// Defines the bValidateFlag
        /// </summary>
        public static bool bValidateFlag = false;

        /// <summary>
        /// Defines the sToolargeFileDirectory
        /// </summary>
        public static string sToolargeFileDirectory = string.Empty;

        /// <summary>
        /// Defines the BagitProcessDirName
        /// </summary>
        public static string BagitProcessDirName = string.Empty;

        /// <summary>
        /// Defines the DirTimeStamp
        /// </summary>
        public static string DirTimeStamp = string.Empty;

        /// <summary>
        /// Defines the ProcessFolderLength
        /// </summary>
        public static int ProcessFolderLength = 0;

        /// <summary>
        /// Defines the Profile_Json_Url
        /// </summary>
        public static string Profile_Json_Url = string.Empty;

        /// <summary>
        /// Defines the userPrincipal
        /// </summary>
        internal UserPrincipal userPrincipal = UserPrincipal.Current;

        /// <summary>
        /// Defines the MsgWarning
        /// </summary>
        public static string MsgWarning = "RAC Aurora";

        /// <summary>
        /// Defines the Succeed
        /// </summary>
        public static int Succeed = 1;

        /// <summary>
        /// Defines the Failed
        /// </summary>
        public static int Failed = 0;

        /// <summary>
        /// Defines the bReturn
        /// </summary>
        internal Boolean bReturn = false;

        /// <summary>
        /// Defines the bReturnlongFile
        /// </summary>
        internal Boolean bReturnlongFile = false;

        /// <summary>
        /// Defines the objprop
        /// </summary>
        internal Bagit_Props objprop = new Bagit_Props();

        /// <summary>
        /// Initializes a new instance of the <see cref="frmBagitprocess"/> class.
        /// </summary>
        public frmBagitprocess()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validate the directory length
        /// </summary>
        /// <param name="path">The path<see cref="string"/></param>
        /// <returns>The <see cref="Boolean"/></returns>
        private Boolean DirectoryLengthValidate(string path)
        {
            string[] files = Directory.GetDirectories(path,
           "*.*",
           SearchOption.AllDirectories);
            // Display all the files.
            Boolean bretval = true;
            sToolargeFileDirectory = string.Empty;
            int DirectLength = new DirectoryInfo(path).Name.Length + 1;
            int lengthDir = path.Length - DirectLength;
            int InstalledDirLength = ProcessFolderLength;
            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    string Filepath = file.Substring(lengthDir, file.Length - lengthDir);
                    if (Filepath.Length + InstalledDirLength > 248)
                    {
                        sToolargeFileDirectory = path;
                        bretval = false;
                        break;
                    }
                }

            }
            else
            {
                if (DirectLength + InstalledDirLength > 248)
                {
                    sToolargeFileDirectory = path;
                    bretval = false;
                }
            }
            return bretval;
        }

        /// <summary>
        /// To choose the files and folders
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string strEmptyFolderFind = string.Empty;
            try
            {
                lstBagItProcess.BackColor = SystemColors.Window;

                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.InitialDirectory = "C:\\";
                dialog.IsFolderPicker = rdFolders.Checked;
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {

                    var dirlist1 = dialog.FileNames.ToArray();
                    var dirDiclist = FilePathLengthValidate(new List<string>(dirlist1), rdFolders.Checked);

                    foreach (KeyValuePair<string, int> entry in dirDiclist)
                    {

                        if (rdFolders.Checked && Directory.GetFiles(entry.Key).Length == 0 && rdFolders.Checked && Directory.GetDirectories(entry.Key).Length == 0)
                        {
                            strEmptyFolderFind = strEmptyFolderFind + entry.Key + Environment.NewLine;
                        }
                        if ((rdFolders.Checked && Directory.GetFiles(entry.Key).Length > 0 || rdFolders.Checked && Directory.GetDirectories(entry.Key).Length > 0) || (rdFiles.Checked))
                        {
                            ListViewItem item = lstview.FindItemWithText(entry.Key);
                            if (item == null)
                            {
                                var listViewItem = new ListViewItem(entry.Key);
                                lstview.Items.Add(listViewItem);

                                if (entry.Value == 1)
                                    lstview.Items[lstview.Items.Count - 1].BackColor = Color.Yellow;

                            }
                            else if (item.Text != entry.Key)
                            {
                                var listViewItem = new ListViewItem(entry.Key);
                                lstview.Items.Add(listViewItem);

                                if (entry.Value == 1)
                                    lstview.Items[lstview.Items.Count - 1].BackColor = Color.Yellow;
                            }
                        }

                    }

                    if (strEmptyFolderFind.Length > 0)
                        MessageBox.Show("Process will ignore the below empty folder(s): " + strEmptyFolderFind, MsgWarning,
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                lstBagItProcess.Items.Clear();

            }
            catch (Exception ex)
            {
                Logger.LogException("Exception while choosing the files/folders:" + ex.Message);
                throw;
            }
        }
       

        /// <summary>
        /// To validate the selected file path
        /// </summary>
        /// <param name="dirlist">The dirlist<see cref="List{string}"/></param>
        /// <param name="FolderChecked">The FolderChecked<see cref="Boolean"/></param>
        /// <returns>The <see cref="Dictionary{string, int}"/></returns>
        private Dictionary<string, int> FilePathLengthValidate(List<string> dirlist, Boolean FolderChecked)
        {
            Dictionary<string, int> Diritem = new Dictionary<string, int>();
            try
            {

                string strIssueFile = string.Empty;
                sToolargeFileDirectory = string.Empty;
                if (FolderChecked)
                {

                    for (var i = 0; i < dirlist.Count; i++)
                    {
                        bReturnlongFile = true;
                        sToolargeFileDirectory = string.Empty;
                        bReturnlongFile = DirectoryLengthValidate(dirlist[i]);


                        if (bReturnlongFile)
                        {
                            Diritem.Add(dirlist[i], 0);
                        }
                        else
                        {
                            strIssueFile = strIssueFile + sToolargeFileDirectory;
                            Diritem.Add(dirlist[i], 1);
                        }

                    }
                }
                else
                {
                    for (var i = 0; i < dirlist.Count; i++)
                    {
                        string DirectName = new FileInfo(dirlist[0]).DirectoryName;
                        int InstalledDirLength = ProcessFolderLength;
                        string FileName = new DirectoryInfo(dirlist[i]).Name;
                        string FilePath = @"\\?\" + DirectName + "\\" + FileName;
                        try
                        {
                            if (!File.Exists(FilePath))
                            {
                                strIssueFile = strIssueFile + FilePath + Environment.NewLine;
                                dirlist.Remove(FilePath);
                                i--;
                            }

                            if (File.Exists(FilePath))
                            {
                                Diritem.Add(FilePath.TrimStart("\\?\"".ToCharArray()), 0);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogException("Error on FilePathLengthValidate method: " + ex.Message);
                        }
                    }

                }

                if (strIssueFile.Length > 0)
                    MessageBox.Show("Process will ignore these below folder(s), too long sub folder: " + strIssueFile, MsgWarning,
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                return Diritem;
            }
            catch (Exception)
            {
                return Diritem;
            }
        }

        /// <summary>
        /// The btnClose_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Logger.LogInformation("------------------------------------------------------");
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Close();
        }

        /// <summary>
        /// Logging Input parameters
        /// </summary>
        private void LoggingInput()
        {
            Logger.LogInformation("Source Organization:" + txtSourceOrg.Text);
            Logger.LogInformation("Internal Sender Description:" + txtInternalSenderDesc.Text);
            Logger.LogInformation("Title:" + txtTitle.Text);
            Logger.LogInformation("Start Date:" + dtStart.Text);
            Logger.LogInformation("End Date:" + dtEnd.Text);
            Logger.LogInformation("Record Type:" + rdRecodType.Text);
        }

        /// <summary>
        /// The DeleteDirectory
        /// </summary>
        /// <param name="target_dir">The target_dir<see cref="string"/></param>
        private void DeleteDirectory(string target_dir)
        {
            try
            {
                string[] files = Directory.GetFiles(target_dir);
                string[] dirs = Directory.GetDirectories(target_dir);

                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    DeleteDirectory(dir);
                }

                Directory.Delete(target_dir, false);
            }
            catch (Exception ex) { Logger.LogInformation("Error on while deleting the directory:" + ex.Message); }
        }

        /// <summary>
        /// The btnCreate_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var langs = ConfigurationManager.GetSection("ISOLanguages") as NameValueCollection;

                lstBagItProcess.BackColor = SystemColors.Window;
                tabConfiguration.SelectedIndex = 0;
                string PyExepath = string.Empty;
                string path = string.Empty;
                string[] subDirs;
                lstBagItProcess.Items.Clear();
                this.progressBar.Visible = true;
                PythonExeCheck();

                bValidateFlag = true;


                if (lstview.Items.Count == 0)
                {
                    MessageBox.Show("Please choose files/folders for process", MsgWarning,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                    return;
                }
                if (Convert.ToDateTime(dtStart.Text) > Convert.ToDateTime(dtEnd.Text))
                {
                    MessageBox.Show("Start date is greater than End date", MsgWarning,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                    return;
                }
                if (txtbagcntmax.Text != string.Empty || txtBagcnt.Text.Trim() != string.Empty)
                {

                    if (txtbagcntmax.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please eneter the total number of bag in the 'Bag Count' field,If not known specifiy '?'", MsgWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (txtBagcnt.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please eneter the ordinal number of bag in the 'Bag Count' field", MsgWarning,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (txtbagcntmax.Text != "?" && txtbagcntmax.Text != string.Empty)
                    {
                        if (Convert.ToInt32(txtBagcnt.Text) > Convert.ToInt32(txtbagcntmax.Text))
                        {
                            MessageBox.Show(txtBagcnt.Text + " of " + txtbagcntmax.Text + ", Please enter a valid bag count", MsgWarning,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    if (txtBagGrpIdentifier.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter the Bag group Identifier, if Bag Count text has value", MsgWarning,
                               MessageBoxButtons.OK, MessageBoxIcon.Warning,
                               MessageBoxDefaultButton.Button1);
                        return;

                    }
                }                
                if (txtBagGrpIdentifier.Text.Trim() != string.Empty)
                {
                    if (txtBagcnt.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter the bag count, if Bag group Identifier text has value", MsgWarning,
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                   MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                if (rdRecodType.Items.Count == 0)
                {
                    MessageBox.Show("Record Types are not able to load from Aurora API", MsgWarning,
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (lstview.Items.Count == 0)
                    BagitProcessErrorProvider.SetError(lstview, lblselecteditems.Text + " " + "Required");
                else
                    BagitProcessErrorProvider.SetError(lstview, null);


                if (this.ValidateChildren() == true)
                {

                    if (PythonExePath == string.Empty)
                        MessageBox.Show("Python exe is not exist in " + PythonDirectory + " drive", MsgWarning,
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);

                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        LoggingInput();
                        string strBagcnt = string.Empty;
                        txtTitle.Text = txtTitle.Text.Replace("'", "").Trim();
                        txtInternalSenderDesc.Text = txtInternalSenderDesc.Text.Replace(Environment.NewLine, " ").Replace("'", "").Trim();
                        txtExternalId.Text = txtExternalId.Text.Replace("'", "").Trim();
                        txtRecordCreator.Text = txtRecordCreator.Text.Replace("'", "").Trim();
                        txtBagcnt.Text = txtBagcnt.Text.Replace("'", "").Trim();
                        txtBagGrpIdentifier.Text = txtBagGrpIdentifier.Text.Replace("'", "").Trim();
                        if (txtBagcnt.Text.Trim() != string.Empty)
                        {
                            strBagcnt = txtBagcnt.Text + " of " + txtbagcntmax.Text;
                            if (txtbagcntmax.Text.Trim() == string.Empty)
                            {
                                strBagcnt = txtBagcnt.Text + " of ?";
                            }
                        }
                        string readFileText = File.ReadAllText(bagTemplatepath);
                        readFileText = readFileText.Replace("##" + txtTitle.Name + "##", "'" + txtTitle.Text + "'");
                        readFileText = readFileText.Replace("##" + txtSourceOrg.Name + "##", "'" + txtSourceOrg.Text.Trim() + "'");
                        readFileText = readFileText.Replace("##" + txtInternalSenderDesc.Name + "##", "'" + txtInternalSenderDesc.Text.Trim() + "'");
                        readFileText = readFileText.Replace("##" + dtStart.Name + "##", "'" + dtStart.Text + "'");
                        readFileText = readFileText.Replace("##" + dtEnd.Name + "##", "'" + dtEnd.Text + "'");
                        readFileText = readFileText.Replace("##" + rdRecodType.Name + "##", "'" + rdRecodType.Text + "'");
                        readFileText = readFileText.Replace("##" + txtExternalId.Name + "##", "'" + txtExternalId.Text.Trim() + "'");
                        readFileText = readFileText.Replace("##" + txtRecordCreator.Name + "##", "'" + txtRecordCreator.Text + "'");
                        readFileText = readFileText.Replace("##" + cmbLanguage.Name + "##", "'" + langs[cmbLanguage.Text].ToString() + "'");
                        readFileText = readFileText.Replace("##" + txtBagcnt.Name + "##", "'" + strBagcnt + "'");
                        readFileText = readFileText.Replace("##" + txtBagGrpIdentifier.Name + "##", "'" + txtBagGrpIdentifier.Text + "'");

                        if (File.Exists(create_bag_path))
                        {
                            // Create a file to write to.
                            File.Delete(create_bag_path);
                        }
                        File.WriteAllText(create_bag_path, readFileText);

                        if (lstview.Items.Count > 0)
                        {
                            subDirs = System.IO.Directory.GetDirectories(ProcessPath);
                            if (subDirs.Length > 0)
                            {
                                try
                                {
                                    for (int loop = 0; loop < subDirs.Length; loop++)
                                        DeleteDirectory(subDirs[loop]);

                                }
                                catch (Exception ex)
                                { Logger.LogInformation("Deleting the exist directory from process path: " + ProcessPath + " :" + ex.Message); }
                            }

                            string ProcessTempPath = DateTime.Now.ToString(BagitProcessDirName);
                            System.IO.Directory.CreateDirectory(ProcessPath + "\\" + ProcessTempPath);
                            foreach (ListViewItem item in this.lstview.Items)
                            {
                                String temp = @"\\?\" + Convert.ToString(item.Text);
                                // copy the directory from Browse selected folder to ProcessPath folder.                              
                                if (File.Exists(temp))
                                {
                                    string fname = string.Empty;
                                    try
                                    {
                                        FileInfo fileInfo = new FileInfo(temp);
                                        fname = fileInfo.Name;
                                        fileInfo.CopyTo(string.Format(@"{0}\{1}", ProcessPath + "\\" + ProcessTempPath, fileInfo.Name), true);
                                    }
                                    catch (Exception ex) { Logger.LogInformation("File Copy to process:Destination filename path is too long: " + ProcessPath + "\\" + ProcessTempPath + "\\" + fname + " " + ex.Message); }
                                }
                                else
                                {
                                    string dname = string.Empty;
                                    try
                                    {
                                        if (Directory.Exists(temp))
                                        {
                                            DirectoryInfo directoryInfo = new DirectoryInfo(temp);
                                            dname = directoryInfo.Name;
                                            Directory.CreateDirectory(ProcessPath + "\\" + ProcessTempPath + "\\" + directoryInfo.Name);
                                            CopyFolderContents(temp, ProcessPath + "\\" + ProcessTempPath + "\\" + directoryInfo.Name);
                                        }
                                    }
                                    catch (Exception ex)
                                    { Logger.LogInformation("Directory file Copy to process:Destination Directory path is too long: " + ProcessPath + "\\" + ProcessTempPath + "\\" + dname + " " + ex.Message); }
                                }
                            }
                            subDirs = System.IO.Directory.GetDirectories(ProcessPath);
                            progressBar.Minimum = 1;
                            progressBar.Value = 1;
                            progressBar.Step = 1;

                            if (Directory.Exists(ProcessPath + "\\" + ProcessTempPath))
                            {

                                //Copy the Mainpath folder one by one into process directory.
                                ProcessPath = ProcessPath + "\\" + ProcessTempPath;
                                this.progressBar.Value = 20;
                                List<string> fileEntries = Directory.EnumerateFiles(ProcessPath, "*.*", SearchOption.AllDirectories).ToList();

                                if (fileEntries.Count == 0)
                                {
                                    MessageBox.Show("There is no files in the processing diectory.This might be due to long file/directory name", MsgWarning,
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                            MessageBoxDefaultButton.Button1);
                                    return;
                                }
                                bReturn = CreateValidateBag(ProcessPath);
                                this.progressBar.Value = 50;
                                if (bReturn)
                                {
                                    AddListViewResult("This " + Path.GetFileName(ProcessPath) + " Bag creation/validation completed.", Succeed);
                                }
                                else
                                {
                                    AddListViewResult("This " + Path.GetFileName(ProcessPath) + " Bag creation/validation failed.", Failed);

                                }

                                if (bReturn)
                                {
                                    bReturn = SFTPBagTransfer(ProcessPath);
                                    this.progressBar.Value = 75;
                                    if (bReturn)
                                    {
                                        AddListViewResult(Path.GetFileName(ProcessPath) + ": Bag transferred to SFTP server.", Succeed);
                                        clearControls();

                                    }
                                    else
                                    {
                                        AddListViewResult(Path.GetFileName(ProcessPath) + ":Failed while transferring to SFTP server. ", Failed);
                                    }
                                }
                                //Move the processed directory to Processed_Archive directory
                                try
                                {
                                    ProcessedArchive = ProcessedArchive + @"\" + Path.GetFileName(ProcessPath);

                                    Directory.Move(ProcessPath, ProcessedArchive);
                                }
                                catch (Exception ex)
                                {
                                    Logger.LogInformation("Error while moving the Processed folder to Archive:" + ex.Message);
                                }

                                this.progressBar.Value = 100;

                                AddListViewResult(Path.GetFileName(ProcessPath) + " moved to Processed Archive folder.", 2);
                                 progressBar.PerformStep();
                            }

                            if (subDirs.Length > 0)
                            {
                                tabConfiguration.SelectedIndex = 1;
                            }
                            else
                            {
                                tabConfiguration.SelectedIndex = 0;
                                Logger.LogInformation(" There is no folder to create bag in the Main Directory ");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("Main method Exception :" + ex.Message);                
            }
            finally
            {
                LoadProperties();
                bValidateFlag = false;
                Cursor.Current = Cursors.Default;
                Logger.LogInformation("Bagit process execution completed:" + DateTime.Now);
                Logger.LogInformation("--------------------------------------------------------------");
            }
        }

        /// <summary>
        /// To clear the Controls value
        /// </summary>
        public void clearControls()
        {
            lstview.Items.Clear();
            txtInternalSenderDesc.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtExternalId.Text = string.Empty;
            txtBagcnt.Text = string.Empty;
            txtbagcntmax.Text = string.Empty;
            txtBagGrpIdentifier.Text = string.Empty;
            txtRecordCreator.Text = userPrincipal.GivenName + " " + userPrincipal.Surname;
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            if (rdRecodType.Items.Count > 0)
                rdRecodType.SelectedIndex = 0;

            if (cmbLanguage.Items.Contains("English"))
                cmbLanguage.Text = "English";
            else
                 if (cmbLanguage.Items.Count > 0)
                cmbLanguage.SelectedIndex = 0;
        }

        /// <summary>
        /// The Add the result to ListView
        /// </summary>
        /// <param name="Item">The Item<see cref="string"/></param>
        /// <param name="flag">The flag<see cref="int"/></param>
        public void AddListViewResult(string Item, int flag)
        {
            lstBagItProcess.Items.Add(Item);
            lstBagItProcess.HorizontalScrollbar = true;
            if (flag == Succeed)
            {
                lstBagItProcess.BackColor = Color.LightGreen;
                Logger.LogInformation(Item);
            }
            else if (flag == Failed)
            {
                lstBagItProcess.BackColor = Color.LightCoral;
                Logger.LogException(Item);
            }
        }

        /// <summary>
        /// To transfer the valid to bag to SFTP location
        /// </summary>
        /// <param name="ProcessPath">The ProcessPath<see cref="string"/></param>
        /// <returns>The <see cref="Boolean"/></returns>
        private static Boolean SFTPBagTransfer(string ProcessPath)
        {
            Boolean bretrunval = false;
            try
            {
                Logger.LogInformation("SFTP Process started");
                KeyboardInteractiveAuthenticationMethod keybAuth = new KeyboardInteractiveAuthenticationMethod(SFTPUserName);
                keybAuth.AuthenticationPrompt += new EventHandler<AuthenticationPromptEventArgs>(HandleKeyEvent);
                conInfo = new ConnectionInfo(HostName, SFTPPort, SFTPUserName, keybAuth);
                using (sftp = new SftpClient(HostName, SFTPPort, SFTPUserName, SFTPPassword))
                {
                    sftp.Connect();
                    if (sftp.IsConnected)
                    {
                        Logger.LogInformation("SFTP connected");
                        if (Directory.Exists(ProcessPath))
                        {
                            sftp.ChangeDirectory(SFTP_Directory_Path);
                            RecurseDirectorySearch(ProcessPath);                        
                        }
                    }
                    bretrunval = true;
                    sftp.Disconnect();
                }
            }
            catch (Exception ex)
            {
                bretrunval = false;
                Logger.LogException(ProcessPath + ": Failed Bag file transfer to SFTP server. Exception: " + ex.Message);
            }
            return bretrunval;
        }

        /// <summary>
        /// To create and validate the bag from the selected files/folders
        /// </summary>
        /// <param name="ProcessPath">The ProcessPath<see cref="string"/></param>
        /// <returns>The <see cref="Boolean"/></returns>
        private Boolean CreateValidateBag(string ProcessPath)
        {
            Boolean bReturnval = false;
            Boolean successflag = true;
            string[] successmsg = SuccessBagMessage.Split('|');
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(@"cmd.exe")
                {
                    UseShellExecute = false,
                    RedirectStandardInput = true
                };
                Process proc = new Process() { StartInfo = psi };
                psi.CreateNoWindow = true;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                proc.Start();
                proc.StandardInput.WriteLine(CommandScript(ProcessPath));
                proc.StandardInput.Flush();
                proc.StandardInput.Close();
                proc.WaitForExit();
                SuccessResult = proc.StandardOutput.ReadToEnd();
                ErrorsResult = proc.StandardError.ReadToEnd();
                proc.Close();

                Logger.LogInformation("Success Result:" + SuccessResult);
                if (ErrorsResult != string.Empty)
                {
                    Logger.LogInformation("Error:" + ErrorsResult);
                }
                else
                {
                    for (int loop = 0; loop < successmsg.Length; loop++)
                    {
                        if (!SuccessResult.Contains(successmsg[loop]))
                            successflag = false;
                    }
                    if (!successflag)                    
                        ErrorsResult = "Error Occurs";
                    
                }

                if (ErrorsResult == string.Empty)
                    bReturnval = true;

                 return bReturnval;
            }
            catch (Exception ex)
            {                
                Logger.LogException(ProcessPath + ": Bag creation/validation failed. Exception: " + ex.Message  +Environment.NewLine + "ErrorsResult: " + ErrorsResult);
                Logger.LogException(ProcessPath + ": Bag creation/validation failed. Result: " + SuccessResult);
                return bReturnval;
            }
        }

        /// <summary>
        /// To build the python script 
        /// </summary>
        /// <param name="bagpath">The bagpath<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        private static string CommandScript(string bagpath)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(PythonExePath + Environment.NewLine);
            sb.Append(PythonDirectory + Environment.NewLine);
            sb.Append("python.exe " + "\"" + create_bag_path + "\"" + " " + "\"" + bagpath + "\"" + Environment.NewLine);
            sb.Append("python.exe " + "\"" + validate_bag_path + "\"" + " " + "\"" + bagpath + "\"" + Environment.NewLine);
            return sb.ToString();
        }

        /// <summary>
        /// To loop the inner directory from main directory
        /// </summary>
        /// <param name="dir">The dir<see cref="string"/></param>
        public static void RecurseDirectorySearch(string dir)
        {
            string Dirpath = string.Empty;
            string SFTPPATH = string.Empty;
            string sftpDirec = string.Empty;
            string parentDirect = string.Empty;
            int intindex = 0;
            try
            {
                Dirpath = Path.GetFullPath(dir).Replace(Path.GetFullPath(dir).Substring(0, Base_processPath.Length), "");
                if (Dirpath.Length > 0 && Dirpath.StartsWith("\\"))
                {
                    intindex = Dirpath.LastIndexOf("\\");
                    sftpDirec = Dirpath.Substring(intindex + 1);
                    if (intindex > 0)
                    {
                        parentDirect = Dirpath.Substring(0, Dirpath.LastIndexOf("\\"));
                        string[] parentDircs = parentDirect.Split(new char[] { '\\' });
                        sftp.ChangeDirectory("/");
                        sftp.ChangeDirectory(SFTP_Directory_Path);
                        foreach (var dirc in parentDircs)
                        {
                            if (dirc != string.Empty)
                                sftp.ChangeDirectory(dirc);
                        }
                    }
                    if (!IsDirectoryExists(sftpDirec))
                    {
                        sftp.CreateDirectory(sftpDirec);
                        sftp.ChangeDirectory(sftpDirec);
                    }
                }

                foreach (string f in Directory.GetFiles(dir))
                {
                    using (FileStream fs = new FileStream(f, FileMode.Open))
                    {
                        sftp.BufferSize = 4 * 1024;
                        sftp.UploadFile(fs, Path.GetFileName(f), true); //overrite if file exist
                    }

                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    RecurseDirectorySearch(d);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("RecurseDirectorySearch: " + Base_processPath + " :" + ex.Message);
            }
        }
              

        /// <summary>
        /// To copy the files/folders to process directory
        /// </summary>
        /// <param name="SourcePath">The SourcePath<see cref="string"/></param>
        /// <param name="DestinationPath">The DestinationPath<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private static bool CopyFolderContents(string SourcePath, string DestinationPath)
        {
            int destflaglarge = 0;
            SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
            DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";
            try
            {
                if (Directory.Exists(SourcePath))
                {
                    if (DestinationPath.Length > 235)
                    {
                        destflaglarge = 1;
                        Logger.LogInformation("Destination path is too long:" + DestinationPath);
                    }
                    if (destflaglarge == 0)
                    {
                        if (Directory.Exists(DestinationPath) == false)
                        {
                            Directory.CreateDirectory(DestinationPath);
                        }
                        foreach (string files in Directory.GetFiles(SourcePath))
                        {
                            try
                            {
                                if (File.Exists(files))
                                {
                                    FileInfo fileInfo = new FileInfo(files);
                                    string destFile = System.IO.Path.Combine(DestinationPath, fileInfo.Name);
                                    fileInfo.CopyTo(destFile, true);
                                }
                            }
                            catch (Exception ex) { Logger.LogException("CopyFolderContents:File path is too long: " + files + " :Error Message" + ex.Message); }
                        }
                    }

                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(drs);
                        if (CopyFolderContents(drs, DestinationPath + directoryInfo.Name) == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogException("CopyFolderContents: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// The IsDirectoryExists
        /// </summary>
        /// <param name="path">The path<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private static bool IsDirectoryExists(string path)
        {
            bool isDirectoryExist = false;
            try
            {
                sftp.ChangeDirectory(path);
                isDirectoryExist = true;
            }
            catch (SftpPathNotFoundException)
            {
                return false;
            }
            return isDirectoryExist;
        }

        /// <summary>
        /// The HandleKeyEvent
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="AuthenticationPromptEventArgs"/></param>
        private static void HandleKeyEvent(object sender, AuthenticationPromptEventArgs e)
        {
            try
            {
                foreach (AuthenticationPrompt prompt in e.Prompts)
                {
                    if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                    {
                        prompt.Response = SFTPPassword;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// The frmBagitprocess_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void frmBagitprocess_Load(object sender, EventArgs e)
        {
            try
            {
                Logger.LogInformation("------------------------------------------------------");
                Logger.LogInformation("Bagit process execution Started:" + DateTime.Now);
                dtStart.Value = DateTime.Now;
                dtEnd.Value = DateTime.Now;
                LoadProperties();
                bLoadFlag = true;
                PythonExeCheck();
            }

            catch (Exception ex)
            {
                Logger.LogException("Main Exception :" + ex.Message);
            }
        }

        /// <summary>
        /// The PythonExeCheck
        /// </summary>
        private void PythonExeCheck()
        {
            try
            {
                string Pythonpath = PythonExePath.Replace("cd", "").Trim();
                PythonExePath = string.Empty;
                if (!Directory.Exists(Pythonpath))
                {
                    string[] getDir = Pythonpath.Split('/');
                    string prgPath = @PythonDirectory + "/Program Files/" + getDir[1];
                    string prgPath86 = @PythonDirectory + "/Program Files (x86)/" + getDir[1];
                    if (Directory.Exists(prgPath))
                    {
                        PythonExePath = "cd " + prgPath;
                    }
                    else if (Directory.Exists(prgPath86))
                    {
                        PythonExePath = "cd " + prgPath86;
                    }
                }
                else
                {
                    PythonExePath = "cd " + Pythonpath;
                }
                if (PythonExePath == string.Empty)
                    Logger.LogInformation("There is no Python EXE location:" + PythonExePath);
                else
                    Logger.LogInformation("Python EXE location:" + PythonExePath);

            }
            catch (Exception ex)
            {
                Logger.LogException("Python exe verfication :" + ex.Message);
            }
        }

        /// <summary>
        /// The LoadProperties
        /// </summary>
        private void LoadProperties()
        {
            try
            {
                this.progressBar.Value = 1;
                this.progressBar.Step = 1;
                this.progressBar.Visible = false;

                SFTP_Directory_Path = objprop.SFTPDirectory;
                SFTPUserName = objprop.SFTPUserName;
                HostName = objprop.HostName;
                SFTPPassword = objprop.SFTPPassword;
                SFTPPort = Convert.ToInt32(objprop.SFTPPort);
                PythonDirectory = objprop.PythonDirectory;
                PythonExePath = objprop.PythonExePath;
                BagitProcessDirName = objprop.BagitDirectoryName;
                ProcessFolderLength = Application.StartupPath.Length + BagitProcessDirName.Length + 15;

                ProcessPath = @"\\?\" + Application.StartupPath + "\\" + objprop.ProcessDirectory;
                ProcessedArchive = @"\\?\" + Application.StartupPath + "\\" + objprop.ProcessArchiveDirectory;
                bagTemplatepath = @"\\?\" + Application.StartupPath + "\\" + objprop.BagitDirectory + "\\" + objprop.Template_bag;
                create_bag_path = @"\\?\" + Application.StartupPath + "\\" + objprop.BagitDirectory + "\\" + objprop.Create_bag;
                validate_bag_path = @"\\?\" + Application.StartupPath + "\\" + objprop.BagitDirectory + "\\" + objprop.Validate_bag;
                SuccessBagMessage = objprop.SuccessBagMessage;
                Base_processPath = ProcessPath;
                Profile_Json_Url = objprop.Profile_Json;
                if (!bLoadFlag)
                {
                    txtSourceOrg.Text = objprop.SourceOrganization;

                    Logger.LogInformation("ProcessPath:" + ProcessPath);
                    Logger.LogInformation("ProcessedArchive:" + ProcessedArchive);
                    Logger.LogInformation("bagTemplatepath:" + bagTemplatepath);
                    Logger.LogInformation("create_bag_path:" + create_bag_path);
                    Logger.LogInformation("validate_bag_path:" + validate_bag_path);
                    Logger.LogInformation("SFTP_Directory_Path:" + SFTP_Directory_Path);

                    if (!Directory.Exists(ProcessPath))
                    { Directory.CreateDirectory(ProcessPath); }

                    if (!Directory.Exists(ProcessedArchive))
                    { Directory.CreateDirectory(ProcessedArchive); }

                    ReadRecordType();

                    var LangCollection = ConfigurationManager.GetSection("ISOLanguages") as NameValueCollection;

                    foreach (var kv in LangCollection.AllKeys.OrderBy(k => k))//ConfigurationManager.GetSection("ISOLanguages") as Enumerable())
                    {
                        if (!cmbLanguage.Items.Contains(kv))
                        {
                            cmbLanguage.Items.Add(kv);
                        }
                    }
                    if (cmbLanguage.Items.Contains("English"))
                        cmbLanguage.Text = "English";
                    else
                        if (cmbLanguage.Items.Count > 0)
                        cmbLanguage.SelectedIndex = 0;
                }
                txtRecordCreator.Text = userPrincipal.GivenName + " " + userPrincipal.Surname;
            }
            catch (Exception ex)
            {
                Logger.LogException("Load Properties Exception :" + ex.Message);
            }
        }

        /// <summary>
        /// The listBox1_MouseMove
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="MouseEventArgs"/></param>
        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                string strTip = "";
                int nIdx = lstBagItProcess.IndexFromPoint(e.Location);
                if ((nIdx >= 0) && (nIdx < lstBagItProcess.Items.Count))
                    strTip = lstBagItProcess.Items[nIdx].ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// The txtSourceOrga_Validating
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="CancelEventArgs"/></param>
        private void txtSourceOrga_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;

            if ((objTextBox.Text.Trim() == string.Empty) && (bValidateFlag))
            {
                e.Cancel = true;
                BagitProcessErrorProvider.SetError(objTextBox, lblSourceOrganization.Text + " " + "Required");
            }
            else
            {
                BagitProcessErrorProvider.SetError(objTextBox, null);
            }
        }

        /// <summary>
        /// The txtInternalSenderDescription_Validating
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="CancelEventArgs"/></param>
        private void txtInternalSenderDescription_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            if ((objTextBox.Text.Trim() == string.Empty) && (bValidateFlag))
            {
                e.Cancel = true;
                BagitProcessErrorProvider.SetError(objTextBox, lblInternalSenderDescription.Text + " " + "Required");
            }
            else
            {
                BagitProcessErrorProvider.SetError(objTextBox, null);
            }
        }

        /// <summary>
        /// The txtTitle_Validating
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="CancelEventArgs"/></param>
        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            if ((objTextBox.Text.Trim() == string.Empty) && (bValidateFlag))
            {
                e.Cancel = true;
                BagitProcessErrorProvider.SetError(objTextBox, lblTitle.Text + " " + "Required");
            }
            else
            {
                BagitProcessErrorProvider.SetError(objTextBox, null);
            }
        }

        /// <summary>
        /// The dtStart_Validating
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="CancelEventArgs"/></param>
        private void dtStart_Validating(object sender, CancelEventArgs e)
        {
            DateTimePicker objTextBox = (DateTimePicker)sender;
            if (objTextBox.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                BagitProcessErrorProvider.SetError(objTextBox, lblDateStart.Text + " " + "Required");
            }
            else
            {
                BagitProcessErrorProvider.SetError(objTextBox, null);
            }
        }

        /// <summary>
        /// The dtEnd_Validating
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="CancelEventArgs"/></param>
        private void dtEnd_Validating(object sender, CancelEventArgs e)
        {
            DateTimePicker objTextBox = (DateTimePicker)sender;
            if (objTextBox.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                BagitProcessErrorProvider.SetError(objTextBox, lblDateEnd.Text + " " + "Required");
            }
            else
            {
                BagitProcessErrorProvider.SetError(objTextBox, null);
            }
        }

        /// <summary>
        /// The txtRecordType_Validating
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="CancelEventArgs"/></param>
        private void txtRecordType_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            if (objTextBox.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                BagitProcessErrorProvider.SetError(objTextBox, lblRecordType.Text + " " + "Required");
            }
            else
            {
                BagitProcessErrorProvider.SetError(objTextBox, null);
            }
        }

        /// <summary>
        /// The txtBagGroupIdentifier_Validating
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="CancelEventArgs"/></param>
        private void txtBagGroupIdentifier_Validating(object sender, CancelEventArgs e)
        {
            TextBox objTextBox = (TextBox)sender;
            if (objTextBox.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                BagitProcessErrorProvider.SetError(objTextBox, lblBagGroupIdentifier.Text + " " + "Required");
            }
            else
            {
                BagitProcessErrorProvider.SetError(objTextBox, null);
            }
        }

        /// <summary>
        /// The frmBagitprocess_FormClosing
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FormClosingEventArgs"/></param>
        private void frmBagitprocess_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
        }

        /// <summary>
        /// The txtInternalSenderDesc_KeyDown
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyEventArgs"/></param>
        private void txtInternalSenderDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        /// <summary>
        /// The txtInternalSenderDesc_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void txtInternalSenderDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
                e.Handled = true;
        }

        /// <summary>
        /// The txtSourceOrg_KeyDown
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyEventArgs"/></param>
        private void txtSourceOrg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        /// <summary>
        /// The txtSourceOrg_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void txtSourceOrg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
                e.Handled = true;
        }

        /// <summary>
        /// The txtTitle_KeyDown
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyEventArgs"/></param>
        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        /// <summary>
        /// The txtTitle_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
                e.Handled = true;
        }

        /// <summary>
        /// The txtExternalId_KeyDown
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyEventArgs"/></param>
        private void txtExternalId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        /// <summary>
        /// The txtExternalId_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void txtExternalId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
                e.Handled = true;
        }

        /// <summary>
        /// The cmbRecordCreator_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void cmbRecordCreator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
                e.Handled = true;
        }

        /// <summary>
        /// The cmbLanguage_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void cmbLanguage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
                e.Handled = true;
        }

        /// <summary>
        /// The txtRecordCreator_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void txtRecordCreator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\'')
                e.Handled = true;
        }

        /// <summary>
        /// The txtRecordCreator_KeyDown
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyEventArgs"/></param>
        private void txtRecordCreator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
        }

        /// <summary>
        /// The btnLstremove_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnLstremove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem itemSelected in lstview.SelectedItems)
                {
                    lstview.Items.Remove(itemSelected);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("Error while deleting the list item:" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The btnClear_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearControls();
        }

        /// <summary>
        /// The ReadRecordType
        /// </summary>
        private void ReadRecordType()
        {
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Profile_Json_Url);
                request.ContentType = "application/json";
                request.Accept = "application/json";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                string profileJson = reader.ReadToEnd();
                dynamic array = JObject.Parse(profileJson);
                JObject jObject = JObject.Parse(profileJson);

                string version = (string)jObject["BagIt-Profile-Info"]["Version"];
                string type = (string)jObject["Bag-Info"]["Record-Type"]["Values"];

                JArray jsonvl = jObject["Bag-Info"]["Record-Type"]["values"] as JArray;
                foreach (dynamic array1 in jsonvl)
                {
                    rdRecodType.Items.Add(array1.Value);

                }
                rdRecodType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Logger.LogException("Error while reading ReadRecordType from URL:" + Profile_Json_Url + ",Error " + ex.Message);

            }
        }

        /// <summary>
        /// The txtBagcnt_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void txtBagcnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// The txtbagcntmax_KeyPress
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="KeyPressEventArgs"/></param>
        private void txtbagcntmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '?'))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '?')
                {
                    txtbagcntmax.Text = string.Empty;
                }
                else
                { txtbagcntmax.Text = txtbagcntmax.Text.Replace('?', ' ').Trim(); }
            }
            catch (Exception) { }
        }
    }
}
