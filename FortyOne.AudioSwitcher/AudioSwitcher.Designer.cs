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
            this.openControlPanelPlayback = new System.Windows.Forms.PictureBox();
            this.btnSetPlaybackDefault = new FortyOne.AudioSwitcher.Controls.SplitButton();
            this.listBoxPlayback = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tapRecording = new System.Windows.Forms.TabPage();
            this.openControlPanelRecording = new System.Windows.Forms.PictureBox();
            this.btnSetRecordingDefault = new FortyOne.AudioSwitcher.Controls.SplitButton();
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
            this.tapSettings = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkCloseToTray = new System.Windows.Forms.CheckBox();
            this.chkAutoStartWithWindows = new System.Windows.Forms.CheckBox();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.chkDisableHotKeys = new System.Windows.Forms.CheckBox();
            this.chkQuickSwitch = new System.Windows.Forms.CheckBox();
            this.chkDualSwitchMode = new System.Windows.Forms.CheckBox();
            this.chkShowDiabledDevices = new System.Windows.Forms.CheckBox();
            this.chkShowUnknownDevicesInHotkeyList = new System.Windows.Forms.CheckBox();
            this.chkShowDisconnectedDevices = new System.Windows.Forms.CheckBox();
            this.chkShowDPDeviceIconInTray = new System.Windows.Forms.CheckBox();
            this.chkNotifyUpdates = new System.Windows.Forms.CheckBox();
            this.btnCheckUpdate = new System.Windows.Forms.Button();
            this.tapHotkeys = new System.Windows.Forms.TabPage();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnDeleteHotKey = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.deviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotKeyStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotKeyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnEditHotKey = new System.Windows.Forms.Button();
            this.btnAddHotKey = new System.Windows.Forms.Button();
            this.tapAbout = new System.Windows.Forms.TabPage();
            this.twitterLink = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkWiki = new System.Windows.Forms.LinkLabel();
            this.linkIssues = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTestError = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryCleaner = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelDonate = new System.Windows.Forms.ToolStripStatusLabel();
            this.playbackStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tapPlayback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openControlPanelPlayback)).BeginInit();
            this.tapRecording.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openControlPanelRecording)).BeginInit();
            this.recordingStrip.SuspendLayout();
            this.tapSettings.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tapHotkeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotKeyBindingSource)).BeginInit();
            this.tapAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.notifyIconStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playbackStrip
            // 
            this.playbackStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.playbackStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetPlaybackDefault,
            this.mnuSetPlaybackCommunicationDefault,
            this.mnuSetPlaybackStartupDevice,
            this.toolStripSeparator2,
            this.mnuFavouritePlaybackDevice,
            this.setHotKeyToolStripMenuItem1});
            this.playbackStrip.Name = "contextMenuStrip1";
            this.playbackStrip.Size = new System.Drawing.Size(435, 190);
            this.playbackStrip.Opening += new System.ComponentModel.CancelEventHandler(this.playbackStrip_Opening);
            // 
            // mnuSetPlaybackDefault
            // 
            this.mnuSetPlaybackDefault.Name = "mnuSetPlaybackDefault";
            this.mnuSetPlaybackDefault.Size = new System.Drawing.Size(434, 36);
            this.mnuSetPlaybackDefault.Text = "Default Device";
            this.mnuSetPlaybackDefault.Click += new System.EventHandler(this.mnuSetPlaybackDefault_Click);
            // 
            // mnuSetPlaybackCommunicationDefault
            // 
            this.mnuSetPlaybackCommunicationDefault.Name = "mnuSetPlaybackCommunicationDefault";
            this.mnuSetPlaybackCommunicationDefault.Size = new System.Drawing.Size(434, 36);
            this.mnuSetPlaybackCommunicationDefault.Text = "Default Communications Device";
            this.mnuSetPlaybackCommunicationDefault.Click += new System.EventHandler(this.mnuSetPlaybackCommunicationDefault_Click);
            // 
            // mnuSetPlaybackStartupDevice
            // 
            this.mnuSetPlaybackStartupDevice.Name = "mnuSetPlaybackStartupDevice";
            this.mnuSetPlaybackStartupDevice.Size = new System.Drawing.Size(434, 36);
            this.mnuSetPlaybackStartupDevice.Text = "Startup Device";
            this.mnuSetPlaybackStartupDevice.Click += new System.EventHandler(this.mnuSetPlaybackStartupDevice_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(431, 6);
            // 
            // mnuFavouritePlaybackDevice
            // 
            this.mnuFavouritePlaybackDevice.Name = "mnuFavouritePlaybackDevice";
            this.mnuFavouritePlaybackDevice.Size = new System.Drawing.Size(434, 36);
            this.mnuFavouritePlaybackDevice.Text = "Favourite Device";
            this.mnuFavouritePlaybackDevice.Click += new System.EventHandler(this.mnuFavouritePlaybackDevice_Click);
            // 
            // setHotKeyToolStripMenuItem1
            // 
            this.setHotKeyToolStripMenuItem1.Name = "setHotKeyToolStripMenuItem1";
            this.setHotKeyToolStripMenuItem1.Size = new System.Drawing.Size(434, 36);
            this.setHotKeyToolStripMenuItem1.Text = "Set Hot Key";
            this.setHotKeyToolStripMenuItem1.Click += new System.EventHandler(this.setHotKeyToolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tapPlayback);
            this.tabControl1.Controls.Add(this.tapRecording);
            this.tabControl1.Controls.Add(this.tapSettings);
            this.tabControl1.Controls.Add(this.tapHotkeys);
            this.tabControl1.Controls.Add(this.tapAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1117, 719);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tapPlayback
            // 
            this.tapPlayback.Controls.Add(this.openControlPanelPlayback);
            this.tapPlayback.Controls.Add(this.btnSetPlaybackDefault);
            this.tapPlayback.Controls.Add(this.listBoxPlayback);
            this.tapPlayback.Location = new System.Drawing.Point(8, 40);
            this.tapPlayback.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapPlayback.Name = "tapPlayback";
            this.tapPlayback.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapPlayback.Size = new System.Drawing.Size(1101, 671);
            this.tapPlayback.TabIndex = 0;
            this.tapPlayback.Text = "Playback";
            this.tapPlayback.UseVisualStyleBackColor = true;
            // 
            // openControlPanelPlayback
            // 
            this.openControlPanelPlayback.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openControlPanelPlayback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openControlPanelPlayback.Location = new System.Drawing.Point(5, 614);
            this.openControlPanelPlayback.Name = "openControlPanelPlayback";
            this.openControlPanelPlayback.Size = new System.Drawing.Size(48, 48);
            this.openControlPanelPlayback.TabIndex = 8;
            this.openControlPanelPlayback.TabStop = false;
            this.toolTip1.SetToolTip(this.openControlPanelPlayback, "Open Sounds in Control Panel");
            this.openControlPanelPlayback.Click += new System.EventHandler(this.openControlPanelPlayback_Click);
            // 
            // btnSetPlaybackDefault
            // 
            this.btnSetPlaybackDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPlaybackDefault.AutoSize = true;
            this.btnSetPlaybackDefault.ContextMenuStrip = this.playbackStrip;
            this.btnSetPlaybackDefault.Enabled = false;
            this.btnSetPlaybackDefault.Location = new System.Drawing.Point(974, 630);
            this.btnSetPlaybackDefault.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSetPlaybackDefault.Name = "btnSetPlaybackDefault";
            this.btnSetPlaybackDefault.Size = new System.Drawing.Size(123, 36);
            this.btnSetPlaybackDefault.SplitMenuStrip = this.playbackStrip;
            this.btnSetPlaybackDefault.TabIndex = 6;
            this.btnSetPlaybackDefault.Text = "Set As...";
            this.btnSetPlaybackDefault.UseVisualStyleBackColor = true;
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
            this.listBoxPlayback.HideSelection = false;
            this.listBoxPlayback.LabelWrap = false;
            this.listBoxPlayback.LargeImageList = this.imageList1;
            this.listBoxPlayback.Location = new System.Drawing.Point(4, 6);
            this.listBoxPlayback.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxPlayback.MultiSelect = false;
            this.listBoxPlayback.Name = "listBoxPlayback";
            this.listBoxPlayback.Size = new System.Drawing.Size(1100, 602);
            this.listBoxPlayback.TabIndex = 5;
            this.listBoxPlayback.TileSize = new System.Drawing.Size(200, 50);
            this.listBoxPlayback.UseCompatibleStateImageBehavior = false;
            this.listBoxPlayback.View = System.Windows.Forms.View.Tile;
            this.listBoxPlayback.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listBoxPlayback_ItemSelectionChanged);
            this.listBoxPlayback.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPlayback_MouseDoubleClick);
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
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tapRecording
            // 
            this.tapRecording.Controls.Add(this.openControlPanelRecording);
            this.tapRecording.Controls.Add(this.btnSetRecordingDefault);
            this.tapRecording.Controls.Add(this.listBoxRecording);
            this.tapRecording.Location = new System.Drawing.Point(8, 40);
            this.tapRecording.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapRecording.Name = "tapRecording";
            this.tapRecording.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapRecording.Size = new System.Drawing.Size(1101, 671);
            this.tapRecording.TabIndex = 1;
            this.tapRecording.Text = "Recording";
            this.tapRecording.UseVisualStyleBackColor = true;
            // 
            // openControlPanelRecording
            // 
            this.openControlPanelRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.openControlPanelRecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openControlPanelRecording.Location = new System.Drawing.Point(5, 620);
            this.openControlPanelRecording.Name = "openControlPanelRecording";
            this.openControlPanelRecording.Size = new System.Drawing.Size(48, 48);
            this.openControlPanelRecording.TabIndex = 9;
            this.openControlPanelRecording.TabStop = false;
            this.toolTip1.SetToolTip(this.openControlPanelRecording, "Open Sounds in Control Panel");
            this.openControlPanelRecording.Click += new System.EventHandler(this.openControlPanelRecording_Click);
            // 
            // btnSetRecordingDefault
            // 
            this.btnSetRecordingDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetRecordingDefault.AutoSize = true;
            this.btnSetRecordingDefault.ContextMenuStrip = this.recordingStrip;
            this.btnSetRecordingDefault.Enabled = false;
            this.btnSetRecordingDefault.Location = new System.Drawing.Point(974, 629);
            this.btnSetRecordingDefault.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSetRecordingDefault.Name = "btnSetRecordingDefault";
            this.btnSetRecordingDefault.Size = new System.Drawing.Size(123, 36);
            this.btnSetRecordingDefault.SplitMenuStrip = this.recordingStrip;
            this.btnSetRecordingDefault.TabIndex = 8;
            this.btnSetRecordingDefault.Text = "Set As...";
            this.btnSetRecordingDefault.UseVisualStyleBackColor = true;
            // 
            // recordingStrip
            // 
            this.recordingStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.recordingStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetRecordingDefault,
            this.mnuSetRecordingCommunicationDefault,
            this.mnuSetRecordingStartupDevice,
            this.toolStripSeparator3,
            this.mnuFavouriteRecordingDevice,
            this.setHotKeyToolStripMenuItem});
            this.recordingStrip.Name = "contextMenuStrip1";
            this.recordingStrip.Size = new System.Drawing.Size(435, 190);
            this.recordingStrip.Opening += new System.ComponentModel.CancelEventHandler(this.recordingStrip_Opening);
            // 
            // mnuSetRecordingDefault
            // 
            this.mnuSetRecordingDefault.Name = "mnuSetRecordingDefault";
            this.mnuSetRecordingDefault.Size = new System.Drawing.Size(434, 36);
            this.mnuSetRecordingDefault.Text = "Default Device";
            this.mnuSetRecordingDefault.Click += new System.EventHandler(this.mnuSetRecordingDefault_Click);
            // 
            // mnuSetRecordingCommunicationDefault
            // 
            this.mnuSetRecordingCommunicationDefault.Name = "mnuSetRecordingCommunicationDefault";
            this.mnuSetRecordingCommunicationDefault.Size = new System.Drawing.Size(434, 36);
            this.mnuSetRecordingCommunicationDefault.Text = "Default Communications Device";
            this.mnuSetRecordingCommunicationDefault.Click += new System.EventHandler(this.mnuSetRecordingCommunicationDefault_Click);
            // 
            // mnuSetRecordingStartupDevice
            // 
            this.mnuSetRecordingStartupDevice.Name = "mnuSetRecordingStartupDevice";
            this.mnuSetRecordingStartupDevice.Size = new System.Drawing.Size(434, 36);
            this.mnuSetRecordingStartupDevice.Text = "Startup Device";
            this.mnuSetRecordingStartupDevice.Click += new System.EventHandler(this.mnuSetRecordingStartupDevice_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(431, 6);
            // 
            // mnuFavouriteRecordingDevice
            // 
            this.mnuFavouriteRecordingDevice.Name = "mnuFavouriteRecordingDevice";
            this.mnuFavouriteRecordingDevice.Size = new System.Drawing.Size(434, 36);
            this.mnuFavouriteRecordingDevice.Text = "Favourite Device";
            this.mnuFavouriteRecordingDevice.Click += new System.EventHandler(this.mnuFavouriteRecordingDevice_Click);
            // 
            // setHotKeyToolStripMenuItem
            // 
            this.setHotKeyToolStripMenuItem.Name = "setHotKeyToolStripMenuItem";
            this.setHotKeyToolStripMenuItem.Size = new System.Drawing.Size(434, 36);
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
            this.listBoxRecording.HideSelection = false;
            this.listBoxRecording.LargeImageList = this.imageList1;
            this.listBoxRecording.Location = new System.Drawing.Point(4, 6);
            this.listBoxRecording.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBoxRecording.MultiSelect = false;
            this.listBoxRecording.Name = "listBoxRecording";
            this.listBoxRecording.Size = new System.Drawing.Size(1093, 608);
            this.listBoxRecording.TabIndex = 7;
            this.listBoxRecording.TileSize = new System.Drawing.Size(200, 50);
            this.listBoxRecording.UseCompatibleStateImageBehavior = false;
            this.listBoxRecording.View = System.Windows.Forms.View.Tile;
            this.listBoxRecording.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listBoxRecording_ItemSelectionChanged);
            this.listBoxRecording.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxRecording_MouseDoubleClick);
            // 
            // tapSettings
            // 
            this.tapSettings.Controls.Add(this.flowLayoutPanel1);
            this.tapSettings.Controls.Add(this.btnCheckUpdate);
            this.tapSettings.Location = new System.Drawing.Point(8, 40);
            this.tapSettings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapSettings.Name = "tapSettings";
            this.tapSettings.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapSettings.Size = new System.Drawing.Size(1101, 671);
            this.tapSettings.TabIndex = 3;
            this.tapSettings.Text = "Settings";
            this.tapSettings.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.chkCloseToTray);
            this.flowLayoutPanel1.Controls.Add(this.chkAutoStartWithWindows);
            this.flowLayoutPanel1.Controls.Add(this.chkStartMinimized);
            this.flowLayoutPanel1.Controls.Add(this.chkDisableHotKeys);
            this.flowLayoutPanel1.Controls.Add(this.chkQuickSwitch);
            this.flowLayoutPanel1.Controls.Add(this.chkDualSwitchMode);
            this.flowLayoutPanel1.Controls.Add(this.chkShowDiabledDevices);
            this.flowLayoutPanel1.Controls.Add(this.chkShowUnknownDevicesInHotkeyList);
            this.flowLayoutPanel1.Controls.Add(this.chkShowDisconnectedDevices);
            this.flowLayoutPanel1.Controls.Add(this.chkShowDPDeviceIconInTray);
            this.flowLayoutPanel1.Controls.Add(this.chkNotifyUpdates);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1093, 617);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // chkCloseToTray
            // 
            this.chkCloseToTray.AutoSize = true;
            this.chkCloseToTray.Location = new System.Drawing.Point(2, 3);
            this.chkCloseToTray.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkCloseToTray.Name = "chkCloseToTray";
            this.chkCloseToTray.Size = new System.Drawing.Size(172, 30);
            this.chkCloseToTray.TabIndex = 3;
            this.chkCloseToTray.Text = "Close to Tray";
            this.toolTip1.SetToolTip(this.chkCloseToTray, "Closes Audio Switcher main window to the system tray");
            this.chkCloseToTray.UseVisualStyleBackColor = true;
            this.chkCloseToTray.CheckedChanged += new System.EventHandler(this.chkCloseToTray_CheckedChanged);
            // 
            // chkAutoStartWithWindows
            // 
            this.chkAutoStartWithWindows.AutoSize = true;
            this.chkAutoStartWithWindows.Location = new System.Drawing.Point(2, 39);
            this.chkAutoStartWithWindows.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkAutoStartWithWindows.Name = "chkAutoStartWithWindows";
            this.chkAutoStartWithWindows.Size = new System.Drawing.Size(302, 30);
            this.chkAutoStartWithWindows.TabIndex = 4;
            this.chkAutoStartWithWindows.Text = "Start when Windows starts";
            this.toolTip1.SetToolTip(this.chkAutoStartWithWindows, "Starts Audio Switcher when Windows starts");
            this.chkAutoStartWithWindows.UseVisualStyleBackColor = true;
            this.chkAutoStartWithWindows.CheckedChanged += new System.EventHandler(this.chkAutoStartWithWindows_CheckedChanged);
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.Location = new System.Drawing.Point(2, 75);
            this.chkStartMinimized.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(196, 30);
            this.chkStartMinimized.TabIndex = 5;
            this.chkStartMinimized.Text = "Start minimized";
            this.toolTip1.SetToolTip(this.chkStartMinimized, "Hides the Main Window when started");
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            this.chkStartMinimized.CheckedChanged += new System.EventHandler(this.chkStartMinimized_CheckedChanged);
            // 
            // chkDisableHotKeys
            // 
            this.chkDisableHotKeys.AutoSize = true;
            this.chkDisableHotKeys.Location = new System.Drawing.Point(2, 111);
            this.chkDisableHotKeys.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkDisableHotKeys.Name = "chkDisableHotKeys";
            this.chkDisableHotKeys.Size = new System.Drawing.Size(204, 30);
            this.chkDisableHotKeys.TabIndex = 6;
            this.chkDisableHotKeys.Text = "Disable hot keys";
            this.toolTip1.SetToolTip(this.chkDisableHotKeys, "Globally disables hotkeys, good if you don\'t use this feature.");
            this.chkDisableHotKeys.UseVisualStyleBackColor = true;
            this.chkDisableHotKeys.CheckedChanged += new System.EventHandler(this.chkDisableHotKeys_CheckedChanged);
            // 
            // chkQuickSwitch
            // 
            this.chkQuickSwitch.AutoSize = true;
            this.chkQuickSwitch.Location = new System.Drawing.Point(2, 147);
            this.chkQuickSwitch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkQuickSwitch.Name = "chkQuickSwitch";
            this.chkQuickSwitch.Size = new System.Drawing.Size(297, 30);
            this.chkQuickSwitch.TabIndex = 7;
            this.chkQuickSwitch.Text = "Enable quick switch mode";
            this.toolTip1.SetToolTip(this.chkQuickSwitch, "Left click on the Tray Icon will cycle through favourite playback devices");
            this.chkQuickSwitch.UseVisualStyleBackColor = true;
            this.chkQuickSwitch.CheckedChanged += new System.EventHandler(this.chkQuickSwitch_CheckedChanged);
            // 
            // chkDualSwitchMode
            // 
            this.chkDualSwitchMode.AutoSize = true;
            this.chkDualSwitchMode.Location = new System.Drawing.Point(2, 183);
            this.chkDualSwitchMode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkDualSwitchMode.Name = "chkDualSwitchMode";
            this.chkDualSwitchMode.Size = new System.Drawing.Size(287, 30);
            this.chkDualSwitchMode.TabIndex = 11;
            this.chkDualSwitchMode.Text = "Enable dual switch mode";
            this.toolTip1.SetToolTip(this.chkDualSwitchMode, "Whenever the Default Device is changed, also change the default communications de" +
        "vice");
            this.chkDualSwitchMode.UseVisualStyleBackColor = true;
            this.chkDualSwitchMode.CheckedChanged += new System.EventHandler(this.chkDualSwitchMode_CheckedChanged);
            // 
            // chkShowDiabledDevices
            // 
            this.chkShowDiabledDevices.AutoSize = true;
            this.chkShowDiabledDevices.Location = new System.Drawing.Point(2, 219);
            this.chkShowDiabledDevices.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkShowDiabledDevices.Name = "chkShowDiabledDevices";
            this.chkShowDiabledDevices.Size = new System.Drawing.Size(274, 30);
            this.chkShowDiabledDevices.TabIndex = 12;
            this.chkShowDiabledDevices.Text = "Show Disabled Devices";
            this.chkShowDiabledDevices.UseVisualStyleBackColor = true;
            this.chkShowDiabledDevices.CheckedChanged += new System.EventHandler(this.chkShowDiabledDevices_CheckedChanged);
            // 
            // chkShowUnknownDevicesInHotkeyList
            // 
            this.chkShowUnknownDevicesInHotkeyList.AutoSize = true;
            this.chkShowUnknownDevicesInHotkeyList.Location = new System.Drawing.Point(2, 255);
            this.chkShowUnknownDevicesInHotkeyList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkShowUnknownDevicesInHotkeyList.Name = "chkShowUnknownDevicesInHotkeyList";
            this.chkShowUnknownDevicesInHotkeyList.Size = new System.Drawing.Size(418, 30);
            this.chkShowUnknownDevicesInHotkeyList.TabIndex = 16;
            this.chkShowUnknownDevicesInHotkeyList.Text = "Show Unknown Devices In Hotkey List";
            this.chkShowUnknownDevicesInHotkeyList.UseVisualStyleBackColor = true;
            this.chkShowUnknownDevicesInHotkeyList.CheckedChanged += new System.EventHandler(this.chkShowUnknownDevicesInHotkeyList_CheckedChanged);
            // 
            // chkShowDisconnectedDevices
            // 
            this.chkShowDisconnectedDevices.AutoSize = true;
            this.chkShowDisconnectedDevices.Location = new System.Drawing.Point(2, 291);
            this.chkShowDisconnectedDevices.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkShowDisconnectedDevices.Name = "chkShowDisconnectedDevices";
            this.chkShowDisconnectedDevices.Size = new System.Drawing.Size(321, 30);
            this.chkShowDisconnectedDevices.TabIndex = 13;
            this.chkShowDisconnectedDevices.Text = "Show Disconnected Devices";
            this.chkShowDisconnectedDevices.UseVisualStyleBackColor = true;
            this.chkShowDisconnectedDevices.CheckedChanged += new System.EventHandler(this.chkShowDisconnectedDevices_CheckedChanged);
            // 
            // chkShowDPDeviceIconInTray
            // 
            this.chkShowDPDeviceIconInTray.AutoSize = true;
            this.chkShowDPDeviceIconInTray.Location = new System.Drawing.Point(2, 327);
            this.chkShowDPDeviceIconInTray.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkShowDPDeviceIconInTray.Name = "chkShowDPDeviceIconInTray";
            this.chkShowDPDeviceIconInTray.Size = new System.Drawing.Size(453, 30);
            this.chkShowDPDeviceIconInTray.TabIndex = 14;
            this.chkShowDPDeviceIconInTray.Text = "Show Default Playback Device icon in tray";
            this.chkShowDPDeviceIconInTray.UseVisualStyleBackColor = true;
            this.chkShowDPDeviceIconInTray.CheckedChanged += new System.EventHandler(this.chkShowDPDeviceIconInTray_CheckedChanged);
            // 
            // chkNotifyUpdates
            // 
            this.chkNotifyUpdates.AutoSize = true;
            this.chkNotifyUpdates.Location = new System.Drawing.Point(2, 363);
            this.chkNotifyUpdates.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkNotifyUpdates.Name = "chkNotifyUpdates";
            this.chkNotifyUpdates.Size = new System.Drawing.Size(345, 30);
            this.chkNotifyUpdates.TabIndex = 15;
            this.chkNotifyUpdates.Text = "Tell me when there\'s an update";
            this.chkNotifyUpdates.UseVisualStyleBackColor = true;
            this.chkNotifyUpdates.CheckedChanged += new System.EventHandler(this.chkNotifyUpdates_CheckedChanged);
            // 
            // btnCheckUpdate
            // 
            this.btnCheckUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckUpdate.Location = new System.Drawing.Point(875, 629);
            this.btnCheckUpdate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCheckUpdate.Name = "btnCheckUpdate";
            this.btnCheckUpdate.Size = new System.Drawing.Size(221, 39);
            this.btnCheckUpdate.TabIndex = 7;
            this.btnCheckUpdate.Text = "Check for Update";
            this.btnCheckUpdate.UseVisualStyleBackColor = true;
            this.btnCheckUpdate.Click += new System.EventHandler(this.btnCheckUpdate_Click);
            // 
            // tapHotkeys
            // 
            this.tapHotkeys.Controls.Add(this.btnClearAll);
            this.tapHotkeys.Controls.Add(this.btnDeleteHotKey);
            this.tapHotkeys.Controls.Add(this.dataGridView1);
            this.tapHotkeys.Controls.Add(this.btnEditHotKey);
            this.tapHotkeys.Controls.Add(this.btnAddHotKey);
            this.tapHotkeys.Location = new System.Drawing.Point(8, 40);
            this.tapHotkeys.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapHotkeys.Name = "tapHotkeys";
            this.tapHotkeys.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapHotkeys.Size = new System.Drawing.Size(1101, 671);
            this.tapHotkeys.TabIndex = 4;
            this.tapHotkeys.Text = "Hotkeys";
            this.tapHotkeys.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearAll.Location = new System.Drawing.Point(4, 627);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(127, 38);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "Clear All";
            this.toolTip1.SetToolTip(this.btnClearAll, "Clear all hotkeys");
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAllHotKeys_Click);
            // 
            // btnDeleteHotKey
            // 
            this.btnDeleteHotKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHotKey.Image = global::FortyOne.AudioSwitcher.Properties.Resources.delete;
            this.btnDeleteHotKey.Location = new System.Drawing.Point(1014, 634);
            this.btnDeleteHotKey.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDeleteHotKey.Name = "btnDeleteHotKey";
            this.btnDeleteHotKey.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteHotKey.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnDeleteHotKey, "Delete the selected hotkey");
            this.btnDeleteHotKey.UseVisualStyleBackColor = true;
            this.btnDeleteHotKey.Click += new System.EventHandler(this.btnDeleteHotKey_Click);
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
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceNameDataGridViewTextBoxColumn,
            this.hotKeyStringDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.hotKeyBindingSource;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(4, 6);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1093, 615);
            this.dataGridView1.TabIndex = 0;
            // 
            // deviceNameDataGridViewTextBoxColumn
            // 
            this.deviceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deviceNameDataGridViewTextBoxColumn.DataPropertyName = "DeviceName";
            this.deviceNameDataGridViewTextBoxColumn.FillWeight = 130F;
            this.deviceNameDataGridViewTextBoxColumn.HeaderText = "Device";
            this.deviceNameDataGridViewTextBoxColumn.Name = "deviceNameDataGridViewTextBoxColumn";
            this.deviceNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.deviceNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // hotKeyStringDataGridViewTextBoxColumn
            // 
            this.hotKeyStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hotKeyStringDataGridViewTextBoxColumn.DataPropertyName = "HotKeyString";
            this.hotKeyStringDataGridViewTextBoxColumn.HeaderText = "Hot Key";
            this.hotKeyStringDataGridViewTextBoxColumn.Name = "hotKeyStringDataGridViewTextBoxColumn";
            this.hotKeyStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.hotKeyStringDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // hotKeyBindingSource
            // 
            this.hotKeyBindingSource.DataSource = typeof(FortyOne.AudioSwitcher.HotKeyData.HotKey);
            // 
            // btnEditHotKey
            // 
            this.btnEditHotKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditHotKey.Image = global::FortyOne.AudioSwitcher.Properties.Resources.edit;
            this.btnEditHotKey.Location = new System.Drawing.Point(1043, 634);
            this.btnEditHotKey.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEditHotKey.Name = "btnEditHotKey";
            this.btnEditHotKey.Size = new System.Drawing.Size(25, 25);
            this.btnEditHotKey.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnEditHotKey, "Edit the selected hotkey");
            this.btnEditHotKey.UseVisualStyleBackColor = true;
            this.btnEditHotKey.Click += new System.EventHandler(this.btnEditHotKey_Click);
            // 
            // btnAddHotKey
            // 
            this.btnAddHotKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHotKey.Image = ((System.Drawing.Image)(resources.GetObject("btnAddHotKey.Image")));
            this.btnAddHotKey.Location = new System.Drawing.Point(1072, 634);
            this.btnAddHotKey.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddHotKey.Name = "btnAddHotKey";
            this.btnAddHotKey.Size = new System.Drawing.Size(25, 25);
            this.btnAddHotKey.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnAddHotKey, "Add a hotkey");
            this.btnAddHotKey.UseVisualStyleBackColor = true;
            this.btnAddHotKey.Click += new System.EventHandler(this.btnAddHotKey_Click);
            // 
            // tapAbout
            // 
            this.tapAbout.Controls.Add(this.twitterLink);
            this.tapAbout.Controls.Add(this.pictureBox2);
            this.tapAbout.Controls.Add(this.pictureBox1);
            this.tapAbout.Controls.Add(this.linkWiki);
            this.tapAbout.Controls.Add(this.linkIssues);
            this.tapAbout.Controls.Add(this.label3);
            this.tapAbout.Controls.Add(this.linkLabel2);
            this.tapAbout.Controls.Add(this.label6);
            this.tapAbout.Controls.Add(this.linkLabel1);
            this.tapAbout.Controls.Add(this.label4);
            this.tapAbout.Controls.Add(this.btnTestError);
            this.tapAbout.Controls.Add(this.label2);
            this.tapAbout.Controls.Add(this.lblCopyright);
            this.tapAbout.Controls.Add(this.lblVersion);
            this.tapAbout.Controls.Add(this.label1);
            this.tapAbout.Location = new System.Drawing.Point(8, 40);
            this.tapAbout.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapAbout.Name = "tapAbout";
            this.tapAbout.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tapAbout.Size = new System.Drawing.Size(1101, 671);
            this.tapAbout.TabIndex = 2;
            this.tapAbout.Text = "About";
            this.tapAbout.UseVisualStyleBackColor = true;
            // 
            // twitterLink
            // 
            this.twitterLink.AutoSize = true;
            this.twitterLink.Location = new System.Drawing.Point(306, 137);
            this.twitterLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.twitterLink.Name = "twitterLink";
            this.twitterLink.Size = new System.Drawing.Size(162, 26);
            this.twitterLink.TabIndex = 23;
            this.twitterLink.TabStop = true;
            this.twitterLink.Text = "@xenolightning";
            this.twitterLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.twitterLink_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::FortyOne.AudioSwitcher.Properties.Resources.twitter;
            this.pictureBox2.Location = new System.Drawing.Point(544, 538);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::FortyOne.AudioSwitcher.Properties.Resources.github;
            this.pictureBox1.Location = new System.Drawing.Point(580, 538);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // linkWiki
            // 
            this.linkWiki.BackColor = System.Drawing.Color.Transparent;
            this.linkWiki.Location = new System.Drawing.Point(348, 163);
            this.linkWiki.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkWiki.Name = "linkWiki";
            this.linkWiki.Size = new System.Drawing.Size(56, 26);
            this.linkWiki.TabIndex = 18;
            this.linkWiki.TabStop = true;
            this.linkWiki.Text = "wiki";
            this.linkWiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWiki_LinkClicked);
            // 
            // linkIssues
            // 
            this.linkIssues.BackColor = System.Drawing.Color.Transparent;
            this.linkIssues.Location = new System.Drawing.Point(235, 163);
            this.linkIssues.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkIssues.Name = "linkIssues";
            this.linkIssues.Size = new System.Drawing.Size(77, 26);
            this.linkIssues.TabIndex = 17;
            this.linkIssues.TabStop = true;
            this.linkIssues.Text = "issues";
            this.linkIssues.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIssues_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Having trouble? Check              or  ";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(7, 59);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(211, 26);
            this.linkLabel2.TabIndex = 15;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://audioswit.ch/er";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "Development: Sean Chapman";
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(68, 189);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 33);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "here";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(442, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "Click            for all versions of AudioSwitcher";
            // 
            // btnTestError
            // 
            this.btnTestError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestError.Location = new System.Drawing.Point(948, 6);
            this.btnTestError.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTestError.Name = "btnTestError";
            this.btnTestError.Size = new System.Drawing.Size(149, 43);
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
            this.label2.Location = new System.Drawing.Point(320, 587);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(485, 78);
            this.label2.TabIndex = 5;
            this.label2.Text = "Audio Switcher is 100% free.\r\nYou can use it wherever and whenever you wish.\r\nIf " +
    "you like the app, please donate :-)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(7, 111);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(105, 26);
            this.lblCopyright.TabIndex = 2;
            this.lblCopyright.Text = "Copyright";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(7, 85);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(92, 26);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 46);
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
            this.notifyIconStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.notifyIconStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.preferencesToolStripMenuItem,
            this.updateAvailableToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyIconStrip.Name = "notifyIconStrip";
            this.notifyIconStrip.Size = new System.Drawing.Size(333, 118);
            this.notifyIconStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.notifyIconStrip_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(329, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(332, 36);
            this.preferencesToolStripMenuItem.Text = "Open Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // updateAvailableToolStripMenuItem
            // 
            this.updateAvailableToolStripMenuItem.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.updateAvailableToolStripMenuItem.Name = "updateAvailableToolStripMenuItem";
            this.updateAvailableToolStripMenuItem.Size = new System.Drawing.Size(332, 36);
            this.updateAvailableToolStripMenuItem.Text = "New Update Available!";
            this.updateAvailableToolStripMenuItem.Click += new System.EventHandler(this.updateAvailableToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(332, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // memoryCleaner
            // 
            this.memoryCleaner.Interval = 3600000;
            this.memoryCleaner.Tick += new System.EventHandler(this.memoryCleaner_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelUpdate,
            this.toolStripStatusLabel1,
            this.statusLabelDonate});
            this.statusStrip1.Location = new System.Drawing.Point(2, 721);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1117, 34);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelUpdate
            // 
            this.statusLabelUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabelUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusLabelUpdate.IsLink = true;
            this.statusLabelUpdate.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.statusLabelUpdate.LinkColor = System.Drawing.Color.Red;
            this.statusLabelUpdate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.statusLabelUpdate.Name = "statusLabelUpdate";
            this.statusLabelUpdate.Size = new System.Drawing.Size(202, 32);
            this.statusLabelUpdate.Text = "Update Available!";
            this.statusLabelUpdate.Click += new System.EventHandler(this.statusLabelUpdate_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(807, 29);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // statusLabelDonate
            // 
            this.statusLabelDonate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabelDonate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusLabelDonate.IsLink = true;
            this.statusLabelDonate.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.statusLabelDonate.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.statusLabelDonate.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.statusLabelDonate.Name = "statusLabelDonate";
            this.statusLabelDonate.Size = new System.Drawing.Size(93, 32);
            this.statusLabelDonate.Text = "Donate";
            this.statusLabelDonate.ToolTipText = "Donate via PayPal";
            this.statusLabelDonate.Click += new System.EventHandler(this.statusLabelDonate_Click);
            // 
            // AudioSwitcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1119, 755);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(290, 400);
            this.Name = "AudioSwitcher";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.openControlPanelPlayback)).EndInit();
            this.tapRecording.ResumeLayout(false);
            this.tapRecording.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openControlPanelRecording)).EndInit();
            this.recordingStrip.ResumeLayout(false);
            this.tapSettings.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tapHotkeys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotKeyBindingSource)).EndInit();
            this.tapAbout.ResumeLayout(false);
            this.tapAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.notifyIconStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TabPage tapAbout;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tapSettings;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifyIconStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkCloseToTray;
        private System.Windows.Forms.CheckBox chkAutoStartWithWindows;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.BindingSource hotKeyBindingSource;
        private System.Windows.Forms.Label label2;
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
        private Controls.SplitButton btnSetPlaybackDefault;
        private Controls.SplitButton btnSetRecordingDefault;
        private System.Windows.Forms.Timer memoryCleaner;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem mnuSetPlaybackStartupDevice;
        private System.Windows.Forms.ToolStripMenuItem mnuSetRecordingStartupDevice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkDualSwitchMode;
        private System.Windows.Forms.TabPage tapHotkeys;
        private System.Windows.Forms.Button btnDeleteHotKey;
        private System.Windows.Forms.Button btnEditHotKey;
        private System.Windows.Forms.Button btnAddHotKey;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCheckUpdate;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.CheckBox chkShowDisconnectedDevices;
        private System.Windows.Forms.CheckBox chkShowDiabledDevices;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkWiki;
        private System.Windows.Forms.LinkLabel linkIssues;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkShowDPDeviceIconInTray;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelUpdate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelDonate;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotKeyStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem updateAvailableToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel twitterLink;
        private System.Windows.Forms.CheckBox chkNotifyUpdates;
        private System.Windows.Forms.PictureBox openControlPanelPlayback;
        private System.Windows.Forms.PictureBox openControlPanelRecording;
		private System.Windows.Forms.CheckBox chkShowUnknownDevicesInHotkeyList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

