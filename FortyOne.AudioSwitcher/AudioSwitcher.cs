using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using FortyOne.AudioSwitcher.AudioSwitcherService;
using FortyOne.AudioSwitcher.Configuration;
using FortyOne.AudioSwitcher.Helpers;
using FortyOne.AudioSwitcher.HotKeyData;
using FortyOne.AudioSwitcher.Properties;
using FortyOne.AudioSwitcher.SoundLibrary;
using Microsoft.Win32;
using Timer = System.Windows.Forms.Timer;

namespace FortyOne.AudioSwitcher
{
    public partial class AudioSwitcher : Form
    {
        #region Properties

        private static AudioSwitcher _instance;
        public bool DisableHotKeyFunction = false;

        public static AudioSwitcher Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AudioSwitcher();

                return _instance;
            }
        }

        public AudioDevice SelectedPlaybackDevice
        {
            get
            {
                if (listBoxPlayback.SelectedItems.Count > 0)
                    return ((AudioDevice)listBoxPlayback.SelectedItems[0].Tag);
                return null;
            }
        }

        public AudioDevice SelectedRecordingDevice
        {
            get
            {
                if (listBoxRecording.SelectedItems.Count > 0)
                    return ((AudioDevice)listBoxRecording.SelectedItems[0].Tag);
                return null;
            }
        }

        public bool TrayIconVisible
        {
            get { return notifyIcon1.Visible; }
            set
            {
                try
                {
                    notifyIcon1.Visible = value;
                }
                catch
                {
                } // rubbish error
            }
        }

        #endregion

        /// <summary>
        /// EASTER EGG! SHHH!
        /// </summary>
        private const string KonamiCode = "UUDDLRLRBA";

        private readonly string[] YouTube_Videos =
        {
            "http://www.youtube.com/watch?v=QJO3ROT-A4E",
            "http://www.youtube.com/watch?v=fWNaR-rxAic",
            "http://www.youtube.com/watch?v=X2WH8mHJnhM",
            "http://www.youtube.com/watch?v=2Z4m4lnjxkY"
        };

        private bool DoubleClickHappened;
        private bool FirstStart = true;
        private string Input = "";
        private AudioSwitcherVersionInfo retrievedVersion;

        public AudioSwitcher()
        {
            InitializeComponent();

            try
            {
                //try make it look pretty
                SetWindowTheme(listBoxPlayback.Handle, "Explorer", null);
                SetWindowTheme(listBoxRecording.Handle, "Explorer", null);
            }
            catch
            {
            }

            //Set up the config
            ConfigurationWriter.ConfigWriter.SetPath(
                Path.Combine(Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName,
                    Resources.ConfigurationFile));

            lblVersion.Text = "Version: " + AssemblyVersion;
            lblCopyright.Text = AssemblyCopyright;

            LoadSettings();

            RefreshRecordingDevices();
            RefreshPlaybackDevices();

            HotKeyManager.HotKeyPressed += HotKeyManager_HotKeyPressed;
            hotKeyBindingSource.DataSource = HotKeyManager.HotKeys;

            if (ConfigurationSettings.CheckForUpdatesOnStartup || ConfigurationSettings.PollForUpdates >= 1)
            {
                var t = new Thread(CheckForUpdates);
                t.Start();
            }

            try
            {
                AudioDevice dev = AudioDeviceManager.GetAudioDevice(ConfigurationSettings.StartupPlaybackDeviceID);

                if (dev != null)
                    dev.SetAsDefaultDevice();

                dev = AudioDeviceManager.GetAudioDevice(ConfigurationSettings.StartupRecordingDeviceID);

                if (dev != null)
                    dev.SetAsDefaultDevice();
            }
            catch
            {
            }

            MinimizeFootprint();
        }

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            btnTestError.Visible = true;
#endif

            AudioDeviceManager.AudioDeviceChanged += AudioDeviceManager_AudioDeviceChanged;

            MinimizeFootprint();
        }

        private void AudioDeviceManager_AudioDeviceChanged(object sender, AudioDeviceChangedEventArgs e)
        {
            if (e.Device.IsPlaybackDevice)
                RefreshPlaybackDevices();
            else if (e.Device.IsRecordingDevice)
                RefreshRecordingDevices();
        }

        private void CheckForUpdates()
        {
            CheckForUpdates(null, null);
        }

        private void CheckForUpdates(object o, EventArgs ae)
        {
            try
            {
                using (AudioSwitcherService.AudioSwitcher client = ConnectionHelper.GetAudioSwitcherProxy())
                {
                    if (client == null)
                        return;

                    retrievedVersion = client.GetUpdateInfo(AssemblyVersion);
                    if (retrievedVersion != null && !string.IsNullOrEmpty(retrievedVersion.URL))
                    {
                        notifyIcon1.BalloonTipText = "Click here to download.";
                        notifyIcon1.BalloonTipTitle = "New version available.";
                        notifyIcon1.BalloonTipClicked += notifyIcon1_BalloonTipClicked;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                }
            }
            catch
            {
            }
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            UpdateForm udf;
            if (retrievedVersion != null)
                udf = new UpdateForm(retrievedVersion);
            else
                udf = new UpdateForm();

            udf.ShowDialog(this);
        }

        protected override void SetVisibleCore(bool value)
        {
            if (ConfigurationSettings.StartMinimized && FirstStart)
            {
                value = false;
                FirstStart = false;
            }

            base.SetVisibleCore(value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Q9TDQPY4B369A");
        }

        private void mnuFavouritePlaybackDevice_Click(object sender, EventArgs e)
        {
            string id = SelectedPlaybackDevice.ID;
            //if checked then we need to remove

            if (mnuFavouritePlaybackDevice.Checked)
                FavouriteDeviceManager.RemoveFavouriteDevice(SelectedPlaybackDevice.ID);
            else
                FavouriteDeviceManager.AddFavouriteDevice(SelectedPlaybackDevice.ID);

            PostPlaybackMenuClick(id);
        }

        private void mnuFavouriteRecordingDevice_Click(object sender, EventArgs e)
        {
            string id = SelectedRecordingDevice.ID;

            if (mnuFavouriteRecordingDevice.Checked)
                FavouriteDeviceManager.RemoveFavouriteDevice(SelectedRecordingDevice.ID);
            else
                FavouriteDeviceManager.AddFavouriteDevice(SelectedRecordingDevice.ID);

            PostRecordingMenuClick(id);
        }

        private void chkDisableHotKeys_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurationSettings.DisableHotKeys = chkDisableHotKeys.Checked;
            if (ConfigurationSettings.DisableHotKeys)
            {
                foreach (HotKey hk in HotKeyManager.HotKeys)
                {
                    hk.UnregsiterHotkey();
                }
            }
            else
            {
                foreach (HotKey hk in HotKeyManager.HotKeys)
                {
                    if (!hk.IsRegistered)
                        hk.RegisterHotkey();
                }
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            DoubleClickHappened = false;

            if (e.Button == MouseButtons.Left)
            {
                var t = new Timer();
                t.Tick += t_Tick;
                t.Interval = SystemInformation.DoubleClickTime;
                t.Start();
            }
        }

        private void t_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            if (DoubleClickHappened)
                return;

            if (ConfigurationSettings.EnableQuickSwitch)
            {
                if (FavouriteDeviceManager.FavouriteDeviceCount > 0)
                {
                    string devid = FavouriteDeviceManager.GetNextFavouritePlaybackDevice();

                    AudioDeviceManager.GetAudioDevice(devid).SetAsDefaultDevice();

                    if (ConfigurationSettings.DualSwitchMode)
                        AudioDeviceManager.GetAudioDevice(devid).SetAsDefaultCommunicationDevice();

                    RefreshPlaybackDevices();
                }
            }
            else
            {
                RefreshNotifyIconItems();
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu",
                    BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon1, null);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClickHappened = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new Exception("Fail Message");
        }

        private void AudioSwitcher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                Input += "U";
            else if (e.KeyCode == Keys.Down)
                Input += "D";
            else if (e.KeyCode == Keys.Left)
                Input += "L";
            else if (e.KeyCode == Keys.Right)
                Input += "R";
            else if (e.KeyCode == Keys.A)
                Input += "A";
            else if (e.KeyCode == Keys.B)
                Input += "B";

            if (Input.Length > KonamiCode.Length)
            {
                Input = Input.Substring(1);
            }

            if (Input == KonamiCode)
            {
                var rand = new Random();
                int index = rand.Next(YouTube_Videos.Length);
                Process.Start(YouTube_Videos[index]);
            }
        }

        private void listBoxPlayback_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            RefreshPlaybackDropDownButton();
        }

        private void listBoxRecording_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            RefreshRecordingDropDownButton();
        }

        private void btnCheckUpdate_Click(object sender, EventArgs e)
        {
            using (AudioSwitcherService.AudioSwitcher client = ConnectionHelper.GetAudioSwitcherProxy())
            {
                if (client == null)
                    return;

                AudioSwitcherVersionInfo vi = client.GetUpdateInfo(AssemblyVersion);
                if (vi != null && !string.IsNullOrEmpty(vi.URL))
                {
                    var udf = new UpdateForm(vi);
                    udf.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show(this, "You have the latest version!");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:codex.nz@gmail.com");
        }

        private void setHotKeyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HotKeyForm hkf = null;
            foreach (HotKey hk in HotKeyManager.HotKeys)
            {
                if (hk.DeviceID == SelectedPlaybackDevice.ID)
                {
                    hkf = new HotKeyForm(hk);
                    hkf.ShowDialog(this);
                    return;
                }
            }

            var newHotKey = new HotKey();
            newHotKey.DeviceID = SelectedPlaybackDevice.ID;
            hkf = new HotKeyForm(newHotKey);
            hkf.ShowDialog(this);
        }

        private void setHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotKeyForm hkf = null;
            foreach (HotKey hk in HotKeyManager.HotKeys)
            {
                if (hk.DeviceID == SelectedRecordingDevice.ID)
                {
                    hkf = new HotKeyForm(hk);
                    hkf.ShowDialog(this);
                    return;
                }
            }
            var newHotKey = new HotKey();
            newHotKey.DeviceID = SelectedRecordingDevice.ID;
            hkf = new HotKeyForm(newHotKey);
            hkf.ShowDialog(this);
        }

        [DllImport("psapi.dll")]
        private static extern int EmptyWorkingSet(IntPtr hwProc);

        private static void MinimizeFootprint()
        {
            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }

        private void memoryCleaner_Tick(object sender, EventArgs e)
        {
            MinimizeFootprint();
        }

        private void chkPollForUpdates_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPollForUpdates.Checked)
            {
                spinPollMinutes.Enabled = true;

                if (ConfigurationSettings.PollForUpdates < 0)
                    ConfigurationSettings.PollForUpdates = ConfigurationSettings.PollForUpdates * -1;

                if (ConfigurationSettings.PollForUpdates < spinPollMinutes.Minimum)
                    ConfigurationSettings.PollForUpdates = (int)spinPollMinutes.Value;

                spinPollMinutes.Value = ConfigurationSettings.PollForUpdates;
            }
            else
            {
                spinPollMinutes.Enabled = false;
                ConfigurationSettings.PollForUpdates = (int)(-1 * spinPollMinutes.Value);
            }
        }

        private void spinPollMinutes_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateTimer.Stop();
                UpdateTimer.Dispose();
            }
            catch
            {
            }

            UpdateTimer = new Timer();

            ConfigurationSettings.PollForUpdates = (int)spinPollMinutes.Value;

            if (ConfigurationSettings.PollForUpdates > 0)
            {
                UpdateTimer.Interval = (int)TimeSpan.FromHours(ConfigurationSettings.PollForUpdates).TotalMilliseconds;
                UpdateTimer.Tick += CheckForUpdates;
                UpdateTimer.Enabled = true;
                UpdateTimer.Start();
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("http://services.fortyone.net.nz/audioswitcher/versions/");
        }

        private void mnuSetPlaybackStartupDevice_Click(object sender, EventArgs e)
        {
            if (ConfigurationSettings.StartupPlaybackDeviceID == SelectedPlaybackDevice.ID)
                ConfigurationSettings.StartupPlaybackDeviceID = "[]";
            else
                ConfigurationSettings.StartupPlaybackDeviceID = SelectedPlaybackDevice.ID;

            RefreshPlaybackDropDownButton();
        }

        private void mnuSetRecordingStartupDevice_Click(object sender, EventArgs e)
        {
            if (ConfigurationSettings.StartupRecordingDeviceID == SelectedRecordingDevice.ID)
                ConfigurationSettings.StartupRecordingDeviceID = "[]";
            else
                ConfigurationSettings.StartupRecordingDeviceID = SelectedRecordingDevice.ID;

            RefreshRecordingDropDownButton();
        }

        #region HotKeyButtons

        private void btnAddHotKey_Click(object sender, EventArgs e)
        {
            var hkf = new HotKeyForm();
            hkf.ShowDialog(this);
            RefreshGrid();
        }

        private void btnEditHotKey_Click(object sender, EventArgs e)
        {
            if (hotKeyBindingSource.Current != null)
            {
                var hkf = new HotKeyForm((HotKey)hotKeyBindingSource.Current);
                hkf.ShowDialog(this);
                RefreshGrid();
            }
        }

        private void btnDeleteHotKey_Click(object sender, EventArgs e)
        {
            if (hotKeyBindingSource.Current != null)
            {
                HotKeyManager.DeleteHotKey((HotKey)hotKeyBindingSource.Current);
                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            if (InvokeRequired)
                Invoke(new Action(RefreshGrid));
            else
                dataGridView1.Refresh();
        }

        #endregion

        #region Methods

        private void LoadSettings()
        {
            //Fix to stop the registry thing being removed and not re-added
            ConfigurationSettings.AutoStartWithWindows = ConfigurationSettings.AutoStartWithWindows;

            chkCloseToTray.Checked = ConfigurationSettings.CloseToTray;
            chkStartMinimized.Checked = ConfigurationSettings.StartMinimized;
            chkAutoStartWithWindows.Checked = ConfigurationSettings.AutoStartWithWindows;
            chkDisableHotKeys.Checked = ConfigurationSettings.DisableHotKeys;
            chkQuickSwitch.Checked = ConfigurationSettings.EnableQuickSwitch;
            chkDualSwitchMode.Checked = ConfigurationSettings.DualSwitchMode;
            //chkNotifyUpdates.Checked = ConfigurationSettings.CheckForUpdatesOnStartup;
            chkPollForUpdates.Checked = ConfigurationSettings.PollForUpdates >= 1;
            spinPollMinutes.Enabled = chkPollForUpdates.Checked;

            Width = ConfigurationSettings.WindowWidth;
            Height = ConfigurationSettings.WindowHeight;

            FavouriteDeviceManager.FavouriteDevicesChanged += AudioDeviceManger_FavouriteDevicesChanged;
            FavouriteDeviceManager.LoadFavouriteDevices(
                ConfigurationSettings.FavouriteDevices.Split(new[] { ",", "[", "]" },
                    StringSplitOptions.RemoveEmptyEntries));


            //Ensure the registry key is added/removed
            if (ConfigurationSettings.AutoStartWithWindows)
            {
                RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
                    true);
                add.SetValue("AudioSwitcher", "\"" + Application.ExecutablePath + "\"");
            }
            else
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
                    true);
                try
                {
                    key.DeleteValue("AudioSwitcher");
                }
                catch
                {
                } //Don't care as it isn't found
            }
        }

        //Subscribe to favourite devices changing to save it to the configuration file instantly
        private void AudioDeviceManger_FavouriteDevicesChanged(List<string> IDs)
        {
            ConfigurationSettings.FavouriteDevices = "[" + string.Join("],[", IDs.ToArray()) + "]";
        }

        #endregion

        #region RefreshHandling

        private void RefreshPlaybackDevices()
        {
            listBoxPlayback.SuspendLayout();
            listBoxPlayback.Items.Clear();
            foreach (AudioDevice ad in AudioDeviceManager.PlayBackDevices)
            {
                var li = new ListViewItem();
                li.Text = ad.DeviceDescription;
                li.Tag = ad;
                li.SubItems.Add(new ListViewItem.ListViewSubItem(li, ad.DeviceName));
                try
                {
                    string imageKey = ad.Icon;
                    if (AudioDeviceManager.DefaultPlaybackDevice.ID == ad.ID)
                    {
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, "Default Device"));
                        li.EnsureVisible();
                    }
                    else if (AudioDeviceManager.DefaultPlaybackCommDevice.ID == ad.ID)
                    {
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, "Default Communications Device"));
                        li.EnsureVisible();
                    }
                    else
                    {
                        string caption = "";
                        switch (ad.State)
                        {
                            case AudioDeviceState.Active:
                                caption = "Ready";
                                break;
                            case AudioDeviceState.Disabled:
                                caption = "Disabled";
                                imageKey += "d";
                                break;
                            case AudioDeviceState.Unplugged:
                                caption = "Not Plugged In";
                                imageKey += "d";
                                break;
                        }
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, caption));
                    }

                    string imageMod = "";

                    if (ad.State != AudioDeviceState.Unplugged && FavouriteDeviceManager.IsFavouriteDevice(ad))
                    {
                        imageMod += "f";
                    }

                    if (AudioDeviceManager.DefaultPlaybackDevice.ID == ad.ID ||
                        AudioDeviceManager.DefaultRecordingDevice.ID == ad.ID)
                    {
                        imageMod += "e";
                    }
                    else if (AudioDeviceManager.DefaultPlaybackCommDevice.ID == ad.ID ||
                             AudioDeviceManager.DefaultRecordingCommDevice.ID == ad.ID)
                    {
                        imageMod += "c";
                    }

                    string imageToGen = imageKey + imageMod + ".png";

                    if (!imageList1.Images.Keys.Contains(imageToGen) &&
                        imageList1.Images.IndexOfKey(imageKey + ".png") >= 0)
                    {
                        Image i = imageList1.Images[imageList1.Images.IndexOfKey(imageKey + ".png")];
                        Graphics g = Graphics.FromImage(i);
                        if (imageMod.Contains("f"))
                        {
                            g.DrawImage(Resources.f, i.Width - 12, 0);
                        }

                        if (imageMod.Contains("c"))
                        {
                            g.DrawImage(Resources.c, i.Width - 12, i.Height - 12);
                        }

                        if (imageMod.Contains("e"))
                        {
                            g.DrawImage(Resources.e, i.Width - 12, i.Height - 12);
                        }

                        imageList1.Images.Add(imageToGen, i);
                    }

                    if (imageList1.Images.IndexOfKey(imageToGen) >= 0)
                        li.ImageKey = imageToGen;
                }
                catch
                {
                    li.ImageKey = "unknown.png";
                }

                listBoxPlayback.Items.Add(li);
            }

            RefreshNotifyIconItems();
            listBoxPlayback.ResumeLayout();
        }

        private void RefreshRecordingDevices()
        {
            listBoxRecording.SuspendLayout();
            listBoxRecording.Items.Clear();

            foreach (AudioDevice ad in AudioDeviceManager.RecordingDevices)
            {
                var li = new ListViewItem();
                li.Text = ad.DeviceDescription;
                li.Tag = ad;
                li.SubItems.Add(new ListViewItem.ListViewSubItem(li, ad.DeviceName));
                try
                {
                    string imageKey = ad.Icon;
                    if (AudioDeviceManager.DefaultRecordingDevice.ID == ad.ID)
                    {
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, "Default Device"));
                        li.EnsureVisible();
                    }
                    else if (AudioDeviceManager.DefaultRecordingCommDevice.ID == ad.ID)
                    {
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, "Default Communications Device"));
                        li.EnsureVisible();
                    }
                    else
                    {
                        string caption = "";
                        switch (ad.State)
                        {
                            case AudioDeviceState.Active:
                                caption = "Ready";
                                break;
                            case AudioDeviceState.Disabled:
                                caption = "Disabled";
                                imageKey += "d";
                                break;
                            case AudioDeviceState.Unplugged:
                                caption = "Not Plugged In";
                                imageKey += "d";
                                break;
                        }
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, caption));
                    }

                    string imageMod = "";

                    if (ad.State != AudioDeviceState.Unplugged && FavouriteDeviceManager.IsFavouriteDevice(ad))
                    {
                        imageMod += "f";
                    }

                    if (AudioDeviceManager.DefaultPlaybackDevice.ID == ad.ID ||
                        AudioDeviceManager.DefaultRecordingDevice.ID == ad.ID)
                    {
                        imageMod += "e";
                    }
                    else if (AudioDeviceManager.DefaultPlaybackCommDevice.ID == ad.ID ||
                             AudioDeviceManager.DefaultRecordingCommDevice.ID == ad.ID)
                    {
                        imageMod += "c";
                    }

                    string imageToGen = imageKey + imageMod + ".png";

                    if (!imageList1.Images.Keys.Contains(imageToGen) &&
                        imageList1.Images.IndexOfKey(imageKey + ".png") >= 0)
                    {
                        Image i = imageList1.Images[imageList1.Images.IndexOfKey(imageKey + ".png")];
                        Graphics g = Graphics.FromImage(i);
                        if (imageMod.Contains("f"))
                        {
                            g.DrawImage(Resources.f, i.Width - 12, 0);
                        }

                        if (imageMod.Contains("c"))
                        {
                            g.DrawImage(Resources.c, i.Width - 12, i.Height - 12);
                        }

                        if (imageMod.Contains("e"))
                        {
                            g.DrawImage(Resources.e, i.Width - 12, i.Height - 12);
                        }

                        imageList1.Images.Add(imageToGen, i);
                    }

                    if (imageList1.Images.IndexOfKey(imageToGen) >= 0)
                        li.ImageKey = imageToGen;
                }
                catch
                {
                    li.ImageKey = "unknown.png";
                }

                listBoxRecording.Items.Add(li);
            }

            RefreshNotifyIconItems();
            listBoxRecording.ResumeLayout();
        }

        private void RefreshNotifyIconItems()
        {
            notifyIconStrip.Items.Clear();

            int playbackCount = 0;
            int recordingCount = 0;

            ReadOnlyCollection<AudioDevice> list = AudioDeviceManager.PlayBackDevices;

            foreach (AudioDevice ad in list)
            {
                if (FavouriteDeviceManager.FavouriteDeviceCount > 0 && !FavouriteDeviceManager.IsFavouriteDevice(ad))
                    continue;

                var item = new ToolStripMenuItem(ad.FullName);
                item.Tag = ad;
                item.Checked = ad.ID == AudioDeviceManager.DefaultPlaybackDevice.ID;
                notifyIconStrip.Items.Add(item);
                playbackCount++;
            }

            if (playbackCount > 0)
                notifyIconStrip.Items.Add(new ToolStripSeparator());

            list = AudioDeviceManager.RecordingDevices;

            foreach (AudioDevice ad in AudioDeviceManager.RecordingDevices)
            {
                if (FavouriteDeviceManager.FavouriteDeviceCount > 0 && !FavouriteDeviceManager.IsFavouriteDevice(ad))
                    continue;

                var item = new ToolStripMenuItem(ad.FullName);
                item.Tag = ad;
                item.Checked = ad.ID == AudioDeviceManager.DefaultRecordingDevice.ID;
                notifyIconStrip.Items.Add(item);
                recordingCount++;
            }

            if (recordingCount > 0)
                notifyIconStrip.Items.Add(new ToolStripSeparator());

            notifyIconStrip.Items.Add(exitToolStripMenuItem);

            notifyIcon1.Text = AudioDeviceManager.DefaultPlaybackDevice.FullName;
        }

        private void RefreshPlaybackDropDownButton()
        {
            if (SelectedPlaybackDevice == null)
            {
                btnSetPlaybackDefault.Enabled = false;
                return;
            }

            if (SelectedPlaybackDevice.ID == AudioDeviceManager.DefaultPlaybackDevice.ID)
                mnuSetPlaybackDefault.CheckState = CheckState.Checked;
            else
                mnuSetPlaybackDefault.CheckState = CheckState.Unchecked;

            if (SelectedPlaybackDevice.ID == AudioDeviceManager.DefaultPlaybackCommDevice.ID)
                mnuSetPlaybackCommunicationDefault.CheckState = CheckState.Checked;
            else
                mnuSetPlaybackCommunicationDefault.CheckState = CheckState.Unchecked;

            if (FavouriteDeviceManager.IsFavouriteDevice(SelectedPlaybackDevice.ID))
                mnuFavouritePlaybackDevice.CheckState = CheckState.Checked;
            else
                mnuFavouritePlaybackDevice.CheckState = CheckState.Unchecked;

            if (ConfigurationSettings.StartupPlaybackDeviceID == SelectedPlaybackDevice.ID)
                mnuSetPlaybackStartupDevice.CheckState = CheckState.Checked;
            else
                mnuSetPlaybackStartupDevice.CheckState = CheckState.Unchecked;

            if (SelectedPlaybackDevice.State == AudioDeviceState.Unplugged)
            {
                btnSetPlaybackDefault.Enabled = false;
                mnuFavouritePlaybackDevice.Enabled = false;
            }
            else
            {
                btnSetPlaybackDefault.Enabled = true;
                mnuFavouritePlaybackDevice.Enabled = true;
            }
        }

        private void RefreshRecordingDropDownButton()
        {
            if (SelectedRecordingDevice == null)
            {
                btnSetRecordingDefault.Enabled = false;
                return;
            }

            if (SelectedRecordingDevice.ID == AudioDeviceManager.DefaultRecordingDevice.ID)
                mnuSetRecordingDefault.CheckState = CheckState.Checked;
            else
                mnuSetRecordingDefault.CheckState = CheckState.Unchecked;

            if (SelectedRecordingDevice.ID == AudioDeviceManager.DefaultRecordingCommDevice.ID)
                mnuSetRecordingCommunicationDefault.CheckState = CheckState.Checked;
            else
                mnuSetRecordingCommunicationDefault.CheckState = CheckState.Unchecked;

            if (FavouriteDeviceManager.IsFavouriteDevice(SelectedRecordingDevice.ID))
                mnuFavouriteRecordingDevice.CheckState = CheckState.Checked;
            else
                mnuFavouriteRecordingDevice.CheckState = CheckState.Unchecked;

            if (ConfigurationSettings.StartupRecordingDeviceID == SelectedRecordingDevice.ID)
                mnuSetRecordingStartupDevice.CheckState = CheckState.Checked;
            else
                mnuSetRecordingStartupDevice.CheckState = CheckState.Unchecked;

            if (SelectedRecordingDevice.State == AudioDeviceState.Unplugged)
            {
                btnSetRecordingDefault.Enabled = false;
                mnuFavouriteRecordingDevice.Enabled = false;
            }
            else
            {
                btnSetRecordingDefault.Enabled = true;
                mnuFavouriteRecordingDevice.Enabled = true;
            }
        }

        #endregion

        #region Events

        private void btnRefreshRecording_Click(object sender, EventArgs e)
        {
            RefreshRecordingDevices();
        }

        private void btnRefreshPlayback_Click(object sender, EventArgs e)
        {
            RefreshPlaybackDevices();
        }

        private void mnuSetPlaybackCommunicationDefault_Click(object sender, EventArgs e)
        {
            string id = SelectedPlaybackDevice.ID;
            SelectedPlaybackDevice.SetAsDefaultCommunicationDevice();
            PostPlaybackMenuClick(id);
        }

        private void mnuSetPlaybackDefault_Click(object sender, EventArgs e)
        {
            string id = SelectedPlaybackDevice.ID;
            SelectedPlaybackDevice.SetAsDefaultDevice();
            PostPlaybackMenuClick(id);
        }

        private void PostPlaybackMenuClick(string id)
        {
            RefreshPlaybackDevices();
            RefreshPlaybackDropDownButton();
            for (int i = 0; i < listBoxPlayback.Items.Count; i++)
            {
                if (((AudioDevice)listBoxPlayback.Items[i].Tag).ID == id)
                {
                    listBoxPlayback.Items[i].Selected = true;
                    break;
                }
            }
        }

        private void listBoxPlayback_MouseDown(object sender, MouseEventArgs e)
        {
            //listBoxPlayback.SelectedIndex = listBoxPlayback.IndexFromPoint(e.X, e.Y);
        }

        private void listBoxRecording_MouseDown(object sender, MouseEventArgs e)
        {
            //listBoxRecording.SelectedIndex = listBoxRecording.IndexFromPoint(e.X, e.Y);
        }

        private void mnuSetRecordingDefault_Click(object sender, EventArgs e)
        {
            string id = SelectedRecordingDevice.ID;
            SelectedRecordingDevice.SetAsDefaultDevice();
            PostRecordingMenuClick(id);
        }

        private void PostRecordingMenuClick(string id)
        {
            RefreshRecordingDevices();
            RefreshRecordingDropDownButton();
            for (int i = 0; i < listBoxRecording.Items.Count; i++)
            {
                if (((AudioDevice)listBoxRecording.Items[i].Tag).ID == id)
                {
                    listBoxRecording.Items[i].Selected = true;
                    break;
                }
            }
        }

        private void mnuSetRecordingCommunicationDefault_Click(object sender, EventArgs e)
        {
            string id = SelectedRecordingDevice.ID;
            SelectedRecordingDevice.SetAsDefaultCommunicationDevice();
            PostRecordingMenuClick(id);
        }

        private void HotKeyManager_HotKeyPressed(object sender, EventArgs e)
        {
            //Double check here before handling
            if (DisableHotKeyFunction || ConfigurationSettings.DisableHotKeys)
                return;

            if (sender is HotKey)
            {
                var hk = sender as HotKey;

                if (hk.DeviceID == AudioDeviceManager.DefaultRecordingDevice.ID ||
                    hk.DeviceID == AudioDeviceManager.DefaultPlaybackDevice.ID)
                    return;

                hk.Device.SetAsDefaultDevice();

                if (ConfigurationSettings.DualSwitchMode)
                    hk.Device.SetAsDefaultCommunicationDevice();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (ConfigurationSettings.CloseToTray)
                    e.Cancel = true;
                Hide();
                MinimizeFootprint();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            BringToFront();
            SetForegroundWindow(Handle);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            RefreshPlaybackDevices();
            RefreshRecordingDevices();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIconStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null && e.ClickedItem.Tag is AudioDevice)
            {
                var dev = (AudioDevice)e.ClickedItem.Tag;
                dev.SetAsDefaultDevice();

                if (ConfigurationSettings.DualSwitchMode)
                    dev.SetAsDefaultCommunicationDevice();
            }
        }

        private void chkCloseToTray_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurationSettings.CloseToTray = chkCloseToTray.Checked;
        }

        private void chkAutoStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurationSettings.AutoStartWithWindows = chkAutoStartWithWindows.Checked;
        }

        private void chkStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurationSettings.StartMinimized = chkStartMinimized.Checked;
        }


        private void chkQuickSwitch_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurationSettings.EnableQuickSwitch = chkQuickSwitch.Checked;
        }

        private void chkDualSwitchMode_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurationSettings.DualSwitchMode = chkDualSwitchMode.Checked;
        }

        private void AudioSwitcher_ResizeEnd(object sender, EventArgs e)
        {
            ConfigurationSettings.WindowWidth = Width;
            ConfigurationSettings.WindowHeight = Height;
        }

        #endregion

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        private void label7_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/xenolightning");
        }
    }
}