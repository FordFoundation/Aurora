namespace BagItProcess
{
    partial class frmBagitprocess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBagitprocess));
            this.btnCreate = new System.Windows.Forms.Button();
            this.tabConfiguration = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblof = new System.Windows.Forms.Label();
            this.txtbagcntmax = new System.Windows.Forms.TextBox();
            this.txtBagcnt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBagGrpIdentifier = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecordCreator = new System.Windows.Forms.TextBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.txtExternalId = new System.Windows.Forms.TextBox();
            this.lblRecordCreator = new System.Windows.Forms.Label();
            this.lblExternalId = new System.Windows.Forms.Label();
            this.rdRecodType = new System.Windows.Forms.ComboBox();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblBagGroupIdentifier = new System.Windows.Forms.Label();
            this.lblRecordType = new System.Windows.Forms.Label();
            this.txtInternalSenderDesc = new System.Windows.Forms.TextBox();
            this.lblInternalSenderDescription = new System.Windows.Forms.Label();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.lblDateStart = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSourceOrg = new System.Windows.Forms.TextBox();
            this.lblSourceOrganization = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstBagItProcess = new System.Windows.Forms.ListBox();
            this.lstview = new System.Windows.Forms.ListView();
            this.Files = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.BagitProcessErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.rdFolders = new System.Windows.Forms.RadioButton();
            this.rdFiles = new System.Windows.Forms.RadioButton();
            this.lblselecteditems = new System.Windows.Forms.Label();
            this.btnLstremove = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabConfiguration.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BagitProcessErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreate.Location = new System.Drawing.Point(225, 545);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(107, 24);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "&Create && Validate";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.tabPage2);
            this.tabConfiguration.Controls.Add(this.tabPage1);
            this.tabConfiguration.Location = new System.Drawing.Point(28, 155);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.SelectedIndex = 0;
            this.tabConfiguration.Size = new System.Drawing.Size(556, 384);
            this.tabConfiguration.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblof);
            this.tabPage2.Controls.Add(this.txtbagcntmax);
            this.tabPage2.Controls.Add(this.txtBagcnt);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtBagGrpIdentifier);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtRecordCreator);
            this.tabPage2.Controls.Add(this.cmbLanguage);
            this.tabPage2.Controls.Add(this.txtExternalId);
            this.tabPage2.Controls.Add(this.lblRecordCreator);
            this.tabPage2.Controls.Add(this.lblExternalId);
            this.tabPage2.Controls.Add(this.rdRecodType);
            this.tabPage2.Controls.Add(this.dtEnd);
            this.tabPage2.Controls.Add(this.dtStart);
            this.tabPage2.Controls.Add(this.lblBagGroupIdentifier);
            this.tabPage2.Controls.Add(this.lblRecordType);
            this.tabPage2.Controls.Add(this.txtInternalSenderDesc);
            this.tabPage2.Controls.Add(this.lblInternalSenderDescription);
            this.tabPage2.Controls.Add(this.lblDateEnd);
            this.tabPage2.Controls.Add(this.lblDateStart);
            this.tabPage2.Controls.Add(this.txtTitle);
            this.tabPage2.Controls.Add(this.lblTitle);
            this.tabPage2.Controls.Add(this.txtSourceOrg);
            this.tabPage2.Controls.Add(this.lblSourceOrganization);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(548, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Metadata Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblof
            // 
            this.lblof.AutoSize = true;
            this.lblof.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblof.Location = new System.Drawing.Point(232, 243);
            this.lblof.Name = "lblof";
            this.lblof.Size = new System.Drawing.Size(26, 13);
            this.lblof.TabIndex = 30;
            this.lblof.Text = " of ";
            // 
            // txtbagcntmax
            // 
            this.txtbagcntmax.Location = new System.Drawing.Point(258, 240);
            this.txtbagcntmax.MaxLength = 3;
            this.txtbagcntmax.Name = "txtbagcntmax";
            this.txtbagcntmax.Size = new System.Drawing.Size(30, 20);
            this.txtbagcntmax.TabIndex = 14;
            this.txtbagcntmax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbagcntmax_KeyPress);
            // 
            // txtBagcnt
            // 
            this.txtBagcnt.Location = new System.Drawing.Point(202, 240);
            this.txtBagcnt.MaxLength = 3;
            this.txtBagcnt.Name = "txtBagcnt";
            this.txtBagcnt.Size = new System.Drawing.Size(30, 20);
            this.txtBagcnt.TabIndex = 13;
            this.txtBagcnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBagcnt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Record Creator";
            // 
            // txtBagGrpIdentifier
            // 
            this.txtBagGrpIdentifier.Location = new System.Drawing.Point(202, 270);
            this.txtBagGrpIdentifier.MaxLength = 100;
            this.txtBagGrpIdentifier.Name = "txtBagGrpIdentifier";
            this.txtBagGrpIdentifier.Size = new System.Drawing.Size(312, 20);
            this.txtBagGrpIdentifier.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Bag Group Identifier";
            // 
            // txtRecordCreator
            // 
            this.txtRecordCreator.Location = new System.Drawing.Point(202, 300);
            this.txtRecordCreator.MaxLength = 100;
            this.txtRecordCreator.Name = "txtRecordCreator";
            this.txtRecordCreator.Size = new System.Drawing.Size(312, 20);
            this.txtRecordCreator.TabIndex = 16;
            this.txtRecordCreator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRecordCreator_KeyDown);
            this.txtRecordCreator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecordCreator_KeyPress);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownHeight = 90;
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.IntegralHeight = false;
            this.cmbLanguage.Location = new System.Drawing.Point(202, 330);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(312, 21);
            this.cmbLanguage.TabIndex = 17;
            this.cmbLanguage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbLanguage_KeyPress);
            // 
            // txtExternalId
            // 
            this.txtExternalId.Location = new System.Drawing.Point(202, 210);
            this.txtExternalId.MaxLength = 256;
            this.txtExternalId.Name = "txtExternalId";
            this.txtExternalId.Size = new System.Drawing.Size(312, 20);
            this.txtExternalId.TabIndex = 12;
            this.txtExternalId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExternalId_KeyDown);
            this.txtExternalId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExternalId_KeyPress);
            // 
            // lblRecordCreator
            // 
            this.lblRecordCreator.AutoSize = true;
            this.lblRecordCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCreator.Location = new System.Drawing.Point(17, 240);
            this.lblRecordCreator.Name = "lblRecordCreator";
            this.lblRecordCreator.Size = new System.Drawing.Size(66, 13);
            this.lblRecordCreator.TabIndex = 24;
            this.lblRecordCreator.Text = "Bag Count";
            // 
            // lblExternalId
            // 
            this.lblExternalId.AutoSize = true;
            this.lblExternalId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternalId.Location = new System.Drawing.Point(17, 210);
            this.lblExternalId.Name = "lblExternalId";
            this.lblExternalId.Size = new System.Drawing.Size(70, 13);
            this.lblExternalId.TabIndex = 23;
            this.lblExternalId.Text = "External ID";
            // 
            // rdRecodType
            // 
            this.rdRecodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rdRecodType.FormattingEnabled = true;
            this.rdRecodType.Location = new System.Drawing.Point(202, 180);
            this.rdRecodType.Name = "rdRecodType";
            this.rdRecodType.Size = new System.Drawing.Size(312, 21);
            this.rdRecodType.TabIndex = 11;
            // 
            // dtEnd
            // 
            this.dtEnd.CustomFormat = "yyyy-MM-dd";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEnd.Location = new System.Drawing.Point(407, 150);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(107, 20);
            this.dtEnd.TabIndex = 10;
            this.dtEnd.Value = new System.DateTime(2018, 2, 8, 12, 44, 0, 0);
            this.dtEnd.Validating += new System.ComponentModel.CancelEventHandler(this.dtEnd_Validating);
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "yyyy-MM-dd";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(202, 151);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(102, 20);
            this.dtStart.TabIndex = 9;
            this.dtStart.Value = new System.DateTime(2018, 2, 8, 0, 0, 0, 0);
            this.dtStart.Validating += new System.ComponentModel.CancelEventHandler(this.dtStart_Validating);
            // 
            // lblBagGroupIdentifier
            // 
            this.lblBagGroupIdentifier.AutoSize = true;
            this.lblBagGroupIdentifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBagGroupIdentifier.Location = new System.Drawing.Point(17, 330);
            this.lblBagGroupIdentifier.Name = "lblBagGroupIdentifier";
            this.lblBagGroupIdentifier.Size = new System.Drawing.Size(63, 13);
            this.lblBagGroupIdentifier.TabIndex = 13;
            this.lblBagGroupIdentifier.Text = "Language";
            // 
            // lblRecordType
            // 
            this.lblRecordType.AutoSize = true;
            this.lblRecordType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordType.Location = new System.Drawing.Point(17, 180);
            this.lblRecordType.Name = "lblRecordType";
            this.lblRecordType.Size = new System.Drawing.Size(80, 13);
            this.lblRecordType.TabIndex = 12;
            this.lblRecordType.Text = "Record Type";
            // 
            // txtInternalSenderDesc
            // 
            this.txtInternalSenderDesc.Location = new System.Drawing.Point(202, 37);
            this.txtInternalSenderDesc.MaxLength = 65535;
            this.txtInternalSenderDesc.Multiline = true;
            this.txtInternalSenderDesc.Name = "txtInternalSenderDesc";
            this.txtInternalSenderDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInternalSenderDesc.Size = new System.Drawing.Size(312, 75);
            this.txtInternalSenderDesc.TabIndex = 7;
            this.txtInternalSenderDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInternalSenderDesc_KeyDown);
            this.txtInternalSenderDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInternalSenderDesc_KeyPress);
            this.txtInternalSenderDesc.Validating += new System.ComponentModel.CancelEventHandler(this.txtInternalSenderDescription_Validating);
            // 
            // lblInternalSenderDescription
            // 
            this.lblInternalSenderDescription.AutoSize = true;
            this.lblInternalSenderDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternalSenderDescription.Location = new System.Drawing.Point(18, 37);
            this.lblInternalSenderDescription.Name = "lblInternalSenderDescription";
            this.lblInternalSenderDescription.Size = new System.Drawing.Size(162, 13);
            this.lblInternalSenderDescription.TabIndex = 10;
            this.lblInternalSenderDescription.Text = "Internal Sender Description";
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.AutoSize = true;
            this.lblDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateEnd.Location = new System.Drawing.Point(325, 155);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(64, 13);
            this.lblDateEnd.TabIndex = 7;
            this.lblDateEnd.Text = "End Date ";
            // 
            // lblDateStart
            // 
            this.lblDateStart.AutoSize = true;
            this.lblDateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateStart.Location = new System.Drawing.Point(18, 150);
            this.lblDateStart.Name = "lblDateStart";
            this.lblDateStart.Size = new System.Drawing.Size(69, 13);
            this.lblDateStart.TabIndex = 6;
            this.lblDateStart.Text = "Start Date ";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(202, 121);
            this.txtTitle.MaxLength = 256;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(312, 20);
            this.txtTitle.TabIndex = 8;
            this.txtTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTitle_KeyDown);
            this.txtTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTitle_KeyPress);
            this.txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtTitle_Validating);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(17, 121);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Title";
            // 
            // txtSourceOrg
            // 
            this.txtSourceOrg.Location = new System.Drawing.Point(202, 7);
            this.txtSourceOrg.MaxLength = 150;
            this.txtSourceOrg.Name = "txtSourceOrg";
            this.txtSourceOrg.ReadOnly = true;
            this.txtSourceOrg.Size = new System.Drawing.Size(312, 20);
            this.txtSourceOrg.TabIndex = 6;
            this.txtSourceOrg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSourceOrg_KeyDown);
            this.txtSourceOrg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSourceOrg_KeyPress);
            this.txtSourceOrg.Validating += new System.ComponentModel.CancelEventHandler(this.txtSourceOrga_Validating);
            // 
            // lblSourceOrganization
            // 
            this.lblSourceOrganization.AutoSize = true;
            this.lblSourceOrganization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceOrganization.Location = new System.Drawing.Point(18, 7);
            this.lblSourceOrganization.Name = "lblSourceOrganization";
            this.lblSourceOrganization.Size = new System.Drawing.Size(122, 13);
            this.lblSourceOrganization.TabIndex = 0;
            this.lblSourceOrganization.Text = "Source Organization";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstBagItProcess);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(548, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Result";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstBagItProcess
            // 
            this.lstBagItProcess.BackColor = System.Drawing.SystemColors.Window;
            this.lstBagItProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBagItProcess.FormattingEnabled = true;
            this.lstBagItProcess.Location = new System.Drawing.Point(6, 6);
            this.lstBagItProcess.Name = "lstBagItProcess";
            this.lstBagItProcess.Size = new System.Drawing.Size(539, 173);
            this.lstBagItProcess.TabIndex = 8;
            this.lstBagItProcess.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
            // 
            // lstview
            // 
            this.lstview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Files});
            this.lstview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstview.Location = new System.Drawing.Point(33, 46);
            this.lstview.Name = "lstview";
            this.lstview.ShowItemToolTips = true;
            this.lstview.Size = new System.Drawing.Size(540, 81);
            this.lstview.TabIndex = 31;
            this.lstview.UseCompatibleStateImageBehavior = false;
            this.lstview.View = System.Windows.Forms.View.Details;
            // 
            // Files
            // 
            this.Files.Text = "Selected Files/Folders:";
            this.Files.Width = 523;
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(350, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(33, 131);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(540, 18);
            this.progressBar.TabIndex = 7;
            // 
            // BagitProcessErrorProvider
            // 
            this.BagitProcessErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.BagitProcessErrorProvider.ContainerControl = this;
            // 
            // rdFolders
            // 
            this.rdFolders.AutoSize = true;
            this.rdFolders.Location = new System.Drawing.Point(103, 7);
            this.rdFolders.Name = "rdFolders";
            this.rdFolders.Size = new System.Drawing.Size(59, 17);
            this.rdFolders.TabIndex = 2;
            this.rdFolders.Text = "Folders";
            this.rdFolders.UseVisualStyleBackColor = true;
            // 
            // rdFiles
            // 
            this.rdFiles.AutoSize = true;
            this.rdFiles.Checked = true;
            this.rdFiles.Location = new System.Drawing.Point(42, 7);
            this.rdFiles.Name = "rdFiles";
            this.rdFiles.Size = new System.Drawing.Size(46, 17);
            this.rdFiles.TabIndex = 1;
            this.rdFiles.TabStop = true;
            this.rdFiles.Text = "Files";
            this.rdFiles.UseVisualStyleBackColor = true;
            // 
            // lblselecteditems
            // 
            this.lblselecteditems.AutoSize = true;
            this.lblselecteditems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblselecteditems.Location = new System.Drawing.Point(31, 30);
            this.lblselecteditems.Name = "lblselecteditems";
            this.lblselecteditems.Size = new System.Drawing.Size(138, 13);
            this.lblselecteditems.TabIndex = 28;
            this.lblselecteditems.Text = "Selected Files/Folders:";
            this.lblselecteditems.Visible = false;
            // 
            // btnLstremove
            // 
            this.btnLstremove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLstremove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLstremove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLstremove.Image = global::BagItProcess.Properties.Resources.Remove;
            this.btnLstremove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLstremove.Location = new System.Drawing.Point(498, 18);
            this.btnLstremove.Name = "btnLstremove";
            this.btnLstremove.Size = new System.Drawing.Size(71, 24);
            this.btnLstremove.TabIndex = 5;
            this.btnLstremove.Text = "Remove";
            this.btnLstremove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLstremove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLstremove.UseVisualStyleBackColor = true;
            this.btnLstremove.Click += new System.EventHandler(this.btnLstremove_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = global::BagItProcess.Properties.Resources.FileFldr;
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(168, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(132, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Choose Files/Folders";
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClear
            // 
            this.btnClear.CausesValidation = false;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(441, 545);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 24);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmBagitprocess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 574);
            this.Controls.Add(this.lstview);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblselecteditems);
            this.Controls.Add(this.btnLstremove);
            this.Controls.Add(this.rdFolders);
            this.Controls.Add(this.rdFiles);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabConfiguration);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnBrowse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBagitprocess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RAC Aurora File Sharing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBagitprocess_FormClosing);
            this.Load += new System.EventHandler(this.frmBagitprocess_Load);
            this.tabConfiguration.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BagitProcessErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TabControl tabConfiguration;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox lstBagItProcess;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblSourceOrganization;
        private System.Windows.Forms.TextBox txtSourceOrg;
        private System.Windows.Forms.ErrorProvider BagitProcessErrorProvider;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.Label lblDateStart;
        private System.Windows.Forms.TextBox txtInternalSenderDesc;
        private System.Windows.Forms.Label lblInternalSenderDescription;
        private System.Windows.Forms.Label lblBagGroupIdentifier;
        private System.Windows.Forms.Label lblRecordType;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.ComboBox rdRecodType;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.TextBox txtExternalId;
        private System.Windows.Forms.Label lblRecordCreator;
        private System.Windows.Forms.Label lblExternalId;
        private System.Windows.Forms.Button btnLstremove;
        private System.Windows.Forms.RadioButton rdFolders;
        private System.Windows.Forms.RadioButton rdFiles;
        private System.Windows.Forms.Label lblselecteditems;
        private System.Windows.Forms.TextBox txtRecordCreator;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView lstview;
        private System.Windows.Forms.ColumnHeader Files;
        private System.Windows.Forms.TextBox txtBagcnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBagGrpIdentifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblof;
        private System.Windows.Forms.TextBox txtbagcntmax;
    }
}

