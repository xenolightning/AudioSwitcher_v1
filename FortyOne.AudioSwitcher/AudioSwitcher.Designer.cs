namespace FortyOne.AudioSwitcher
{
    partial class AudioSwitcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioSwitcher));
            this.playbackStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSetPlaybackDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetPlaybackCommunicationDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetPlaybackStartupDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFavouritePlaybackDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.setHotKeyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tapPlayback = new System.Windows.Forms.TabPage();
            this.listBoxPlayback = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnRefreshPlayback = new System.Windows.Forms.Button();
            this.tapRecording = new System.Windows.Forms.TabPage();
            this.recordingStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSetRecordingDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetRecordingCommunicationDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetRecordingStartupDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFavouriteRecordingDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.setHotKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxRecording = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefreshRecording = new System.Windows.Forms.Button();
            this.tapSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheckUpdate = new System.Windows.Forms.Button();
            this.btnDeleteHotKey = new System.Windows.Forms.Button();
            this.btnEditHotKey = new System.Windows.Forms.Button();
            this.btnAddHotKey = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.spinPollMinutes = new System.Windows.Forms.NumericUpDown();
            this.chkPollForUpdates = new System.Windows.Forms.CheckBox();
            this.chkQuickSwitch = new System.Windows.Forms.CheckBox();
            this.chkDisableHotKeys = new System.Windows.Forms.CheckBox();
            this.chkCloseToTray = new System.Windows.Forms.CheckBox();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.chkAutoStartWithWindows = new System.Windows.Forms.CheckBox();
            this.tapAbout = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTestError = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryCleaner = new System.Windows.Forms.Timer(this.components);
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.chkDualSwitchMode = new System.Windows.Forms.CheckBox();
            this.btnSetPlaybackDefault = new FortyOne.AudioSwitcher.Controls.SplitButton();
            this.btnSetRecordingDefault = new FortyOne.AudioSwitcher.Controls.SplitButton();
            this.deviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotKeyStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotKeyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playbackStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tapPlayback.SuspendLayout();
            this.tapRecording.SuspendLayout();
            this.recordingStrip.SuspendLayout();
            this.tapSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinPollMinutes)).BeginInit();
            this.tapAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.notifyIconStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hotKeyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // playbackStrip
            // 
            this.playbackStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetPlaybackDefault,
            this.mnuSetPlaybackCommunicationDefault,
            this.mnuSetPlaybackStartupDevice,
            this.toolStripSeparator2,
            this.mnuFavouritePlaybackDevice,
            this.setHotKeyToolStripMenuItem1});
            this.playbackStrip.Name = "contextMenuStrip1";
            this.playbackStrip.Size = new System.Drawing.Size(338, 160);
            // 
            // mnuSetPlaybackDefault
            // 
            this.mnuSetPlaybackDefault.Name = "mnuSetPlaybackDefault";
            this.mnuSetPlaybackDefault.Size = new System.Drawing.Size(337, 30);
            this.mnuSetPlaybackDefault.Text = "Default Device";
            this.mnuSetPlaybackDefault.Click += new System.EventHandler(this.mnuSetPlaybackDefault_Click);
            // 
            // mnuSetPlaybackCommunicationDefault
            // 
            this.mnuSetPlaybackCommunicationDefault.Name = "mnuSetPlaybackCommunicationDefault";
            this.mnuSetPlaybackCommunicationDefault.Size = new System.Drawing.Size(337, 30);
            this.mnuSetPlaybackCommunicationDefault.Text = "Default Communications Device";
            this.mnuSetPlaybackCommunicationDefault.Click += new System.EventHandler(this.mnuSetPlaybackCommunicationDefault_Click);
            // 
            // mnuSetPlaybackStartupDevice
            // 
            this.mnuSetPlaybackStartupDevice.Name = "mnuSetPlaybackStartupDevice";
            this.mnuSetPlaybackStartupDevice.Size = new System.Drawing.Size(337, 30);
            this.mnuSetPlaybackStartupDevice.Text = "Startup Device";
            this.mnuSetPlaybackStartupDevice.Click += new System.EventHandler(this.mnuSetPlaybackStartupDevice_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(334, 6);
            // 
            // mnuFavouritePlaybackDevice
            // 
            this.mnuFavouritePlaybackDevice.Name = "mnuFavouritePlaybackDevice";
            this.mnuFavouritePlaybackDevice.Size = new System.Drawing.Size(337, 30);
            this.mnuFavouritePlaybackDevice.Text = "Favourite Device";
            this.mnuFavouritePlaybackDevice.Click += new System.EventHandler(this.mnuFavouritePlaybackDevice_Click);
            // 
            // setHotKeyToolStripMenuItem1
            // 
            this.setHotKeyToolStripMenuItem1.Name = "setHotKeyToolStripMenuItem1";
            this.setHotKeyToolStripMenuItem1.Size = new System.Drawing.Size(337, 30);
            this.setHotKeyToolStripMenuItem1.Text = "Set Hot Key";
            this.setHotKeyToolStripMenuItem1.Click += new System.EventHandler(this.setHotKeyToolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tapPlayback);
            this.tabControl1.Controls.Add(this.tapRecording);
            this.tabControl1.Controls.Add(this.tapSettings);
            this.tabControl1.Controls.Add(this.tapAbout);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(412, 572);
            this.tabControl1.TabIndex = 0;
            // 
            // tapPlayback
            // 
            this.tapPlayback.Controls.Add(this.btnSetPlaybackDefault);
            this.tapPlayback.Controls.Add(this.listBoxPlayback);
            this.tapPlayback.Controls.Add(this.btnRefreshPlayback);
            this.tapPlayback.Location = new System.Drawing.Point(4, 29);
            this.tapPlayback.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tapPlayback.Name = "tapPlayback";
            this.tapPlayback.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tapPlayback.Size = new System.Drawing.Size(404, 539);
            this.tapPlayback.TabIndex = 0;
            this.tapPlayback.Text = "Playback";
            this.tapPlayback.UseVisualStyleBackColor = true;
            // 
            // listBoxPlayback
            // 
            this.listBoxPlayback.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPlayback.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listBoxPlayback.ContextMenuStrip = this.playbackStrip;
            this.listBoxPlayback.FullRowSelect = true;
            this.listBoxPlayback.LabelWrap = false;
            this.listBoxPlayback.LargeImageList = this.imageList1;
            this.listBoxPlayback.Location = new System.Drawing.Point(9, 9);
            this.listBoxPlayback.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxPlayback.MultiSelect = false;
            this.listBoxPlayback.Name = "listBoxPlayback";
            this.listBoxPlayback.Size = new System.Drawing.Size(380, 467);
            this.listBoxPlayback.TabIndex = 5;
            this.listBoxPlayback.TileSize = new System.Drawing.Size(200, 50);
            this.listBoxPlayback.UseCompatibleStateImageBehavior = false;
            this.listBoxPlayback.View = System.Windows.Forms.View.Tile;
            this.listBoxPlayback.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listBoxPlayback_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = -2;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = -2;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = -2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "3004.png");
            this.imageList1.Images.SetKeyName(1, "3004d.png");
            this.imageList1.Images.SetKeyName(2, "3010.png");
            this.imageList1.Images.SetKeyName(3, "3010d.png");
            this.imageList1.Images.SetKeyName(4, "3011.png");
            this.imageList1.Images.SetKeyName(5, "3011d.png");
            this.imageList1.Images.SetKeyName(6, "3012.png");
            this.imageList1.Images.SetKeyName(7, "3012d.png");
            this.imageList1.Images.SetKeyName(8, "3013.png");
            this.imageList1.Images.SetKeyName(9, "3013d.png");
            this.imageList1.Images.SetKeyName(10, "3014.png");
            this.imageList1.Images.SetKeyName(11, "3014d.png");
            this.imageList1.Images.SetKeyName(12, "3015.png");
            this.imageList1.Images.SetKeyName(13, "3015d.png");
            this.imageList1.Images.SetKeyName(14, "3016.png");
            this.imageList1.Images.SetKeyName(15, "3016d.png");
            this.imageList1.Images.SetKeyName(16, "3017.png");
            this.imageList1.Images.SetKeyName(17, "3017d.png");
            this.imageList1.Images.SetKeyName(18, "3018.png");
            this.imageList1.Images.SetKeyName(19, "3018d.png");
            this.imageList1.Images.SetKeyName(20, "3019.png");
            this.imageList1.Images.SetKeyName(21, "3019d.png");
            this.imageList1.Images.SetKeyName(22, "3020.png");
            this.imageList1.Images.SetKeyName(23, "3020d.png");
            this.imageList1.Images.SetKeyName(24, "3021.png");
            this.imageList1.Images.SetKeyName(25, "3021d.png");
            this.imageList1.Images.SetKeyName(26, "3030.png");
            this.imageList1.Images.SetKeyName(27, "3030d.png");
            this.imageList1.Images.SetKeyName(28, "3031.png");
            this.imageList1.Images.SetKeyName(29, "3031d.png");
            this.imageList1.Images.SetKeyName(30, "3050.png");
            this.imageList1.Images.SetKeyName(31, "3050d.png");
            this.imageList1.Images.SetKeyName(32, "3051.png");
            this.imageList1.Images.SetKeyName(33, "3051d.png");
            this.imageList1.Images.SetKeyName(34, "unknown.png");
            // 
            // btnRefreshPlayback
            // 
            this.btnRefreshPlayback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshPlayback.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshPlayback.Image")));
            this.btnRefreshPlayback.Location = new System.Drawing.Point(9, 488);
            this.btnRefreshPlayback.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefreshPlayback.Name = "btnRefreshPlayback";
            this.btnRefreshPlayback.Size = new System.Drawing.Size(38, 35);
            this.btnRefreshPlayback.TabIndex = 3;
            this.btnRefreshPlayback.UseVisualStyleBackColor = true;
            this.btnRefreshPlayback.Click += new System.EventHandler(this.btnRefreshPlayback_Click);
            // 
            // tapRecording
            // 
            this.tapRecording.Controls.Add(this.btnSetRecordingDefault);
            this.tapRecording.Controls.Add(this.listBoxRecording);
            this.tapRecording.Controls.Add(this.btnRefreshRecording);
            this.tapRecording.Location = new System.Drawing.Point(4, 29);
            this.tapRecording.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tapRecording.Name = "tapRecording";
            this.tapRecording.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tapRecording.Size = new System.Drawing.Size(404, 539);
            this.tapRecording.TabIndex = 1;
            this.tapRecording.Text = "Recording";
            this.tapRecording.UseVisualStyleBackColor = true;
            // 
            // recordingStrip
            // 
            this.recordingStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetRecordingDefault,
            this.mnuSetRecordingCommunicationDefault,
            this.mnuSetRecordingStartupDevice,
            this.toolStripSeparator3,
            this.mnuFavouriteRecordingDevice,
            this.setHotKeyToolStripMenuItem});
            this.recordingStrip.Name = "contextMenuStrip1";
            this.recordingStrip.Size = new System.Drawing.Size(338, 160);
            // 
            // mnuSetRecordingDefault
            // 
            this.mnuSetRecordingDefault.Name = "mnuSetRecordingDefault";
            this.mnuSetRecordingDefault.Size = new System.Drawing.Size(337, 30);
            this.mnuSetRecordingDefault.Text = "Default Device";
            this.mnuSetRecordingDefault.Click += new System.EventHandler(this.mnuSetRecordingDefault_Click);
            // 
            // mnuSetRecordingCommunicationDefault
            // 
            this.mnuSetRecordingCommunicationDefault.Name = "mnuSetRecordingCommunicationDefault";
            this.mnuSetRecordingCommunicationDefault.Size = new System.Drawing.Size(337, 30);
            this.mnuSetRecordingCommunicationDefault.Text = "Default Communications Device";
            this.mnuSetRecordingCommunicationDefault.Click += new System.EventHandler(this.mnuSetRecordingCommunicationDefault_Click);
            // 
            // mnuSetRecordingStartupDevice
            // 
            this.mnuSetRecordingStartupDevice.Name = "mnuSetRecordingStartupDevice";
            this.mnuSetRecordingStartupDevice.Size = new System.Drawing.Size(337, 30);
            this.mnuSetRecordingStartupDevice.Text = "Startup Device";
            this.mnuSetRecordingStartupDevice.Click += new System.EventHandler(this.mnuSetRecordingStartupDevice_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(334, 6);
            // 
            // mnuFavouriteRecordingDevice
            // 
            this.mnuFavouriteRecordingDevice.Name = "mnuFavouriteRecordingDevice";
            this.mnuFavouriteRecordingDevice.Size = new System.Drawing.Size(337, 30);
            this.mnuFavouriteRecordingDevice.Text = "Favourite Device";
            this.mnuFavouriteRecordingDevice.Click += new System.EventHandler(this.mnuFavouriteRecordingDevice_Click);
            // 
            // setHotKeyToolStripMenuItem
            // 
            this.setHotKeyToolStripMenuItem.Name = "setHotKeyToolStripMenuItem";
            this.setHotKeyToolStripMenuItem.Size = new System.Drawing.Size(337, 30);
            this.setHotKeyToolStripMenuItem.Text = "Set Hot Key";
            this.setHotKeyToolStripMenuItem.Click += new System.EventHandler(this.setHotKeyToolStripMenuItem_Click);
            // 
            // listBoxRecording
            // 
            this.listBoxRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRecording.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listBoxRecording.ContextMenuStrip = this.recordingStrip;
            this.listBoxRecording.LargeImageList = this.imageList1;
            this.listBoxRecording.Location = new System.Drawing.Point(9, 9);
            this.listBoxRecording.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxRecording.MultiSelect = false;
            this.listBoxRecording.Name = "listBoxRecording";
            this.listBoxRecording.Size = new System.Drawing.Size(380, 467);
            this.listBoxRecording.TabIndex = 7;
            this.listBoxRecording.TileSize = new System.Drawing.Size(200, 50);
            this.listBoxRecording.UseCompatibleStateImageBehavior = false;
            this.listBoxRecording.View = System.Windows.Forms.View.Tile;
            this.listBoxRecording.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listBoxRecording_ItemSelectionChanged);
            // 
            // btnRefreshRecording
            // 
            this.btnRefreshRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshRecording.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshRecording.Image")));
            this.btnRefreshRecording.Location = new System.Drawing.Point(9, 488);
            this.btnRefreshRecording.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefreshRecording.Name = "btnRefreshRecording";
            this.btnRefreshRecording.Size = new System.Drawing.Size(38, 35);
            this.btnRefreshRecording.TabIndex = 5;
            this.btnRefreshRecording.UseVisualStyleBackColor = true;
            this.btnRefreshRecording.Click += new System.EventHandler(this.btnRefreshRecording_Click);
            // 
            // tapSettings
            // 
            this.tapSettings.Controls.Add(this.groupBox2);
            this.tapSettings.Controls.Add(this.groupBox1);
            this.tapSettings.Location = new System.Drawing.Point(4, 29);
            this.tapSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tapSettings.Name = "tapSettings";
            this.tapSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tapSettings.Size = new System.Drawing.Size(404, 539);
            this.tapSettings.TabIndex = 3;
            this.tapSettings.Text = "Settings";
            this.tapSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnCheckUpdate);
            this.groupBox2.Controls.Add(this.btnDeleteHotKey);
            this.groupBox2.Controls.Add(this.btnEditHotKey);
            this.groupBox2.Controls.Add(this.btnAddHotKey);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(10, 292);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(381, 231);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hot Keys";
            // 
            // btnCheckUpdate
            // 
            this.btnCheckUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckUpdate.Location = new System.Drawing.Point(9, 184);
            this.btnCheckUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheckUpdate.Name = "btnCheckUpdate";
            this.btnCheckUpdate.Size = new System.Drawing.Size(152, 35);
            this.btnCheckUpdate.TabIndex = 4;
            this.btnCheckUpdate.Text = "Check for Update";
            this.btnCheckUpdate.UseVisualStyleBackColor = true;
            this.btnCheckUpdate.Click += new System.EventHandler(this.btnCheckUpdate_Click);
            // 
            // btnDeleteHotKey
            // 
            this.btnDeleteHotKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHotKey.Image = global::FortyOne.AudioSwitcher.Properties.Resources.delete;
            this.btnDeleteHotKey.Location = new System.Drawing.Point(237, 184);
            this.btnDeleteHotKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteHotKey.Name = "btnDeleteHotKey";
            this.btnDeleteHotKey.Size = new System.Drawing.Size(39, 38);
            this.btnDeleteHotKey.TabIndex = 3;
            this.btnDeleteHotKey.UseVisualStyleBackColor = true;
            this.btnDeleteHotKey.Click += new System.EventHandler(this.btnDeleteHotKey_Click);
            // 
            // btnEditHotKey
            // 
            this.btnEditHotKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditHotKey.Image = global::FortyOne.AudioSwitcher.Properties.Resources.edit;
            this.btnEditHotKey.Location = new System.Drawing.Point(285, 184);
            this.btnEditHotKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditHotKey.Name = "btnEditHotKey";
            this.btnEditHotKey.Size = new System.Drawing.Size(39, 38);
            this.btnEditHotKey.TabIndex = 2;
            this.btnEditHotKey.UseVisualStyleBackColor = true;
            this.btnEditHotKey.Click += new System.EventHandler(this.btnEditHotKey_Click);
            // 
            // btnAddHotKey
            // 
            this.btnAddHotKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHotKey.Image = ((System.Drawing.Image)(resources.GetObject("btnAddHotKey.Image")));
            this.btnAddHotKey.Location = new System.Drawing.Point(333, 184);
            this.btnAddHotKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddHotKey.Name = "btnAddHotKey";
            this.btnAddHotKey.Size = new System.Drawing.Size(39, 38);
            this.btnAddHotKey.TabIndex = 1;
            this.btnAddHotKey.UseVisualStyleBackColor = true;
            this.btnAddHotKey.Click += new System.EventHandler(this.btnAddHotKey_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceNameDataGridViewTextBoxColumn,
            this.hotKeyStringDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.hotKeyBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 29);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(363, 145);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkDualSwitchMode);
            this.groupBox1.Controls.Add(this.spinPollMinutes);
            this.groupBox1.Controls.Add(this.chkPollForUpdates);
            this.groupBox1.Controls.Add(this.chkQuickSwitch);
            this.groupBox1.Controls.Add(this.chkDisableHotKeys);
            this.groupBox1.Controls.Add(this.chkCloseToTray);
            this.groupBox1.Controls.Add(this.chkStartMinimized);
            this.groupBox1.Controls.Add(this.chkAutoStartWithWindows);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(382, 273);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // spinPollMinutes
            // 
            this.spinPollMinutes.Location = new System.Drawing.Point(228, 235);
            this.spinPollMinutes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spinPollMinutes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinPollMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinPollMinutes.Name = "spinPollMinutes";
            this.spinPollMinutes.Size = new System.Drawing.Size(72, 26);
            this.spinPollMinutes.TabIndex = 10;
            this.spinPollMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinPollMinutes.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.spinPollMinutes.ValueChanged += new System.EventHandler(this.spinPollMinutes_ValueChanged);
            // 
            // chkPollForUpdates
            // 
            this.chkPollForUpdates.AutoSize = true;
            this.chkPollForUpdates.Location = new System.Drawing.Point(18, 237);
            this.chkPollForUpdates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkPollForUpdates.Name = "chkPollForUpdates";
            this.chkPollForUpdates.Size = new System.Drawing.Size(341, 24);
            this.chkPollForUpdates.TabIndex = 9;
            this.chkPollForUpdates.Text = "Check for updates every                       Hours";
            this.chkPollForUpdates.UseVisualStyleBackColor = true;
            this.chkPollForUpdates.CheckedChanged += new System.EventHandler(this.chkPollForUpdates_CheckedChanged);
            // 
            // chkQuickSwitch
            // 
            this.chkQuickSwitch.AutoSize = true;
            this.chkQuickSwitch.Location = new System.Drawing.Point(18, 171);
            this.chkQuickSwitch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkQuickSwitch.Name = "chkQuickSwitch";
            this.chkQuickSwitch.Size = new System.Drawing.Size(218, 24);
            this.chkQuickSwitch.TabIndex = 7;
            this.chkQuickSwitch.Text = "Enable quick switch mode";
            this.chkQuickSwitch.UseVisualStyleBackColor = true;
            this.chkQuickSwitch.CheckedChanged += new System.EventHandler(this.chkQuickSwitch_CheckedChanged);
            // 
            // chkDisableHotKeys
            // 
            this.chkDisableHotKeys.AutoSize = true;
            this.chkDisableHotKeys.Location = new System.Drawing.Point(18, 135);
            this.chkDisableHotKeys.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDisableHotKeys.Name = "chkDisableHotKeys";
            this.chkDisableHotKeys.Size = new System.Drawing.Size(151, 24);
            this.chkDisableHotKeys.TabIndex = 6;
            this.chkDisableHotKeys.Text = "Disable hot keys";
            this.chkDisableHotKeys.UseVisualStyleBackColor = true;
            this.chkDisableHotKeys.CheckedChanged += new System.EventHandler(this.chkDisableHotKeys_CheckedChanged);
            // 
            // chkCloseToTray
            // 
            this.chkCloseToTray.AutoSize = true;
            this.chkCloseToTray.Location = new System.Drawing.Point(18, 29);
            this.chkCloseToTray.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkCloseToTray.Name = "chkCloseToTray";
            this.chkCloseToTray.Size = new System.Drawing.Size(127, 24);
            this.chkCloseToTray.TabIndex = 3;
            this.chkCloseToTray.Text = "Close to Tray";
            this.chkCloseToTray.UseVisualStyleBackColor = true;
            this.chkCloseToTray.CheckedChanged += new System.EventHandler(this.chkCloseToTray_CheckedChanged);
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.Location = new System.Drawing.Point(18, 100);
            this.chkStartMinimized.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(144, 24);
            this.chkStartMinimized.TabIndex = 5;
            this.chkStartMinimized.Text = "Start minimized";
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            this.chkStartMinimized.CheckedChanged += new System.EventHandler(this.chkStartMinimized_CheckedChanged);
            // 
            // chkAutoStartWithWindows
            // 
            this.chkAutoStartWithWindows.AutoSize = true;
            this.chkAutoStartWithWindows.Location = new System.Drawing.Point(18, 65);
            this.chkAutoStartWithWindows.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAutoStartWithWindows.Name = "chkAutoStartWithWindows";
            this.chkAutoStartWithWindows.Size = new System.Drawing.Size(224, 24);
            this.chkAutoStartWithWindows.TabIndex = 4;
            this.chkAutoStartWithWindows.Text = "Start when Windows starts";
            this.chkAutoStartWithWindows.UseVisualStyleBackColor = true;
            this.chkAutoStartWithWindows.CheckedChanged += new System.EventHandler(this.chkAutoStartWithWindows_CheckedChanged);
            // 
            // tapAbout
            // 
            this.tapAbout.Controls.Add(this.label7);
            this.tapAbout.Controls.Add(this.label6);
            this.tapAbout.Controls.Add(this.linkLabel1);
            this.tapAbout.Controls.Add(this.label4);
            this.tapAbout.Controls.Add(this.label5);
            this.tapAbout.Controls.Add(this.label3);
            this.tapAbout.Controls.Add(this.btnTestError);
            this.tapAbout.Controls.Add(this.label2);
            this.tapAbout.Controls.Add(this.pictureBox1);
            this.tapAbout.Controls.Add(this.lblCompany);
            this.tapAbout.Controls.Add(this.lblCopyright);
            this.tapAbout.Controls.Add(this.lblVersion);
            this.tapAbout.Controls.Add(this.label1);
            this.tapAbout.Location = new System.Drawing.Point(4, 29);
            this.tapAbout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tapAbout.Name = "tapAbout";
            this.tapAbout.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tapAbout.Size = new System.Drawing.Size(404, 539);
            this.tapAbout.TabIndex = 2;
            this.tapAbout.Text = "About";
            this.tapAbout.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(238, 218);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "@nzxeno";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 218);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Development: Sean Chapman";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(58, 280);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(41, 20);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "here";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 280);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(302, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Click         for all versions of AudioSwitcher";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 246);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Testing: Neven MacEwan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Information:";
            // 
            // btnTestError
            // 
            this.btnTestError.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTestError.Location = new System.Drawing.Point(141, 324);
            this.btnTestError.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTestError.Name = "btnTestError";
            this.btnTestError.Size = new System.Drawing.Size(112, 35);
            this.btnTestError.TabIndex = 6;
            this.btnTestError.Text = "Test Error";
            this.btnTestError.UseVisualStyleBackColor = true;
            this.btnTestError.Visible = false;
            this.btnTestError.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 377);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 60);
            this.label2.TabIndex = 5;
            this.label2.Text = "Audio Switcher is 100% free.\r\nYou can use it wherever and whenever you wish.\r\nIf " +
    "you like my work, please donate :-)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::FortyOne.AudioSwitcher.Properties.Resources.btn_donateCC_LG;
            this.pictureBox1.Location = new System.Drawing.Point(106, 446);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(21, 143);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(76, 20);
            this.lblCompany.TabIndex = 3;
            this.lblCompany.Text = "Company";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(21, 105);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(76, 20);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copyright";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(21, 68);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(67, 20);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Audio Switcher";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyIconStrip;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Audio Switcher";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // notifyIconStrip
            // 
            this.notifyIconStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.notifyIconStrip.Name = "notifyIconStrip";
            this.notifyIconStrip.Size = new System.Drawing.Size(112, 40);
            this.notifyIconStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.notifyIconStrip_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // memoryCleaner
            // 
            this.memoryCleaner.Interval = 3600000;
            this.memoryCleaner.Tick += new System.EventHandler(this.memoryCleaner_Tick);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 60000;
            // 
            // chkDualSwitchMode
            // 
            this.chkDualSwitchMode.AutoSize = true;
            this.chkDualSwitchMode.Location = new System.Drawing.Point(18, 205);
            this.chkDualSwitchMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkDualSwitchMode.Name = "chkDualSwitchMode";
            this.chkDualSwitchMode.Size = new System.Drawing.Size(211, 24);
            this.chkDualSwitchMode.TabIndex = 11;
            this.chkDualSwitchMode.Text = "Enable dual switch mode";
            this.chkDualSwitchMode.UseVisualStyleBackColor = true;
            this.chkDualSwitchMode.CheckedChanged += new System.EventHandler(this.chkDualSwitchMode_CheckedChanged);
            // 
            // btnSetPlaybackDefault
            // 
            this.btnSetPlaybackDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPlaybackDefault.AutoSize = true;
            this.btnSetPlaybackDefault.ContextMenuStrip = this.playbackStrip;
            this.btnSetPlaybackDefault.Location = new System.Drawing.Point(269, 488);
            this.btnSetPlaybackDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetPlaybackDefault.Name = "btnSetPlaybackDefault";
            this.btnSetPlaybackDefault.Size = new System.Drawing.Size(120, 35);
            this.btnSetPlaybackDefault.SplitMenuStrip = this.playbackStrip;
            this.btnSetPlaybackDefault.TabIndex = 6;
            this.btnSetPlaybackDefault.Text = "Set As...";
            this.btnSetPlaybackDefault.UseVisualStyleBackColor = true;
            // 
            // btnSetRecordingDefault
            // 
            this.btnSetRecordingDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetRecordingDefault.AutoSize = true;
            this.btnSetRecordingDefault.ContextMenuStrip = this.recordingStrip;
            this.btnSetRecordingDefault.Location = new System.Drawing.Point(269, 488);
            this.btnSetRecordingDefault.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetRecordingDefault.Name = "btnSetRecordingDefault";
            this.btnSetRecordingDefault.Size = new System.Drawing.Size(120, 35);
            this.btnSetRecordingDefault.SplitMenuStrip = this.recordingStrip;
            this.btnSetRecordingDefault.TabIndex = 8;
            this.btnSetRecordingDefault.Text = "Set As...";
            this.btnSetRecordingDefault.UseVisualStyleBackColor = true;
            // 
            // deviceNameDataGridViewTextBoxColumn
            // 
            this.deviceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deviceNameDataGridViewTextBoxColumn.DataPropertyName = "DeviceName";
            this.deviceNameDataGridViewTextBoxColumn.HeaderText = "Device";
            this.deviceNameDataGridViewTextBoxColumn.Name = "deviceNameDataGridViewTextBoxColumn";
            this.deviceNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hotKeyStringDataGridViewTextBoxColumn
            // 
            this.hotKeyStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hotKeyStringDataGridViewTextBoxColumn.DataPropertyName = "HotKeyString";
            this.hotKeyStringDataGridViewTextBoxColumn.HeaderText = "Hot Key";
            this.hotKeyStringDataGridViewTextBoxColumn.Name = "hotKeyStringDataGridViewTextBoxColumn";
            this.hotKeyStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hotKeyBindingSource
            // 
            this.hotKeyBindingSource.DataSource = typeof(FortyOne.AudioSwitcher.HotKeyData.HotKey);
            // 
            // AudioSwitcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 583);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(439, 585);
            this.Name = "AudioSwitcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Switcher";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.AudioSwitcher_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AudioSwitcher_KeyDown);
            this.playbackStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tapPlayback.ResumeLayout(false);
            this.tapPlayback.PerformLayout();
            this.tapRecording.ResumeLayout(false);
            this.tapRecording.PerformLayout();
            this.recordingStrip.ResumeLayout(false);
            this.tapSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinPollMinutes)).EndInit();
            this.tapAbout.ResumeLayout(false);
            this.tapAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.notifyIconStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hotKeyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tapPlayback;
        private System.Windows.Forms.TabPage tapRecording;
        private System.Windows.Forms.ContextMenuStrip playbackStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuSetPlaybackDefault;
        private System.Windows.Forms.ToolStripMenuItem mnuSetPlaybackCommunicationDefault;
        private System.Windows.Forms.ContextMenuStrip recordingStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuSetRecordingDefault;
        private System.Windows.Forms.ToolStripMenuItem mnuSetRecordingCommunicationDefault;
        private System.Windows.Forms.Button btnRefreshPlayback;
        private System.Windows.Forms.Button btnRefreshRecording;
        private System.Windows.Forms.TabPage tapAbout;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TabPage tapSettings;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifyIconStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkCloseToTray;
        private System.Windows.Forms.CheckBox chkAutoStartWithWindows;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource hotKeyBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddHotKey;
        private System.Windows.Forms.Button btnDeleteHotKey;
        private System.Windows.Forms.Button btnEditHotKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotKeyStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuFavouritePlaybackDevice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuFavouriteRecordingDevice;
        private System.Windows.Forms.CheckBox chkDisableHotKeys;
        private System.Windows.Forms.CheckBox chkQuickSwitch;
        private System.Windows.Forms.Button btnTestError;
        private System.Windows.Forms.ListView listBoxPlayback;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listBoxRecording;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem setHotKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setHotKeyToolStripMenuItem1;
        private System.Windows.Forms.Button btnCheckUpdate;
        private Controls.SplitButton btnSetPlaybackDefault;
        private Controls.SplitButton btnSetRecordingDefault;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer memoryCleaner;
        private System.Windows.Forms.NumericUpDown spinPollMinutes;
        private System.Windows.Forms.CheckBox chkPollForUpdates;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem mnuSetPlaybackStartupDevice;
        private System.Windows.Forms.ToolStripMenuItem mnuSetRecordingStartupDevice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDualSwitchMode;
    }
}

