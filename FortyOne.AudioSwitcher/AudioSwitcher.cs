using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi;
using FortyOne.AudioSwitcher.AudioSwitcherService;
using FortyOne.AudioSwitcher.Configuration;
using FortyOne.AudioSwitcher.Helpers;
using FortyOne.AudioSwitcher.HotKeyData;
using FortyOne.AudioSwitcher.Properties;
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
                return _instance ?? (_instance = new AudioSwitcher());
            }
        }

        private IDevice SelectedPlaybackDevice
        {
            get
            {
                if (listBoxPlayback.SelectedItems.Count > 0)
                    return ((IDevice)listBoxPlayback.SelectedItems[0].Tag);
                return null;
            }
        }

        public IDevice SelectedRecordingDevice
        {
            get
            {
                if (listBoxRecording.SelectedItems.Count > 0)
                    return ((IDevice)listBoxRecording.SelectedItems[0].Tag);
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
        private const string KONAMI_CODE = "UUDDLRLRBA";

        private readonly string[] YOUTUBE_VIDEOS =
        {
            "http://www.youtube.com/watch?v=QJO3ROT-A4E",
            "http://www.youtube.com/watch?v=fWNaR-rxAic",
            "http://www.youtube.com/watch?v=X2WH8mHJnhM",
            "http://www.youtube.com/watch?v=2Z4m4lnjxkY"
        };

        private bool _doubleClickHappened;
        private bool _firstStart = true;
        private string _input = "";
        private AudioSwitcherVersionInfo _retrievedVersion;

        private DeviceState DeviceStateFilter = DeviceState.Active;

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

            lblVersion.Text = "Version: " + AssemblyVersion;
            lblCopyright.Text = AssemblyCopyright;

            LoadSettings();

            RefreshRecordingDevices();
            RefreshPlaybackDevices();

            HotKeyManager.HotKeyPressed += HotKeyManager_HotKeyPressed;
            hotKeyBindingSource.DataSource = HotKeyManager.HotKeys;

            if (ConfigurationSettings.CheckForUpdatesOnStartup || ConfigurationSettings.PollForUpdates >= 1)
            {
                Task.Factory.StartNew(CheckForUpdates);
            }

            IDevice dev = AudioDeviceManager.Controller.GetAudioDevice(ConfigurationSettings.StartupPlaybackDeviceID);

            if (dev != null)
                dev.SetAsDefault();

            dev = AudioDeviceManager.Controller.GetAudioDevice(ConfigurationSettings.StartupRecordingDeviceID);

            if (dev != null)
                dev.SetAsDefault();

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

            AudioDeviceManager.Controller.AudioDeviceChanged += AudioDeviceManager_AudioDeviceChanged;

            MinimizeFootprint();
        }

        private void AudioDeviceManager_AudioDeviceChanged(object sender, AudioDeviceChangedEventArgs e)
        {
            Action refreshAction = () => { };

            if (e.Device.IsPlaybackDevice)
                refreshAction = RefreshPlaybackDevices;
            else if (e.Device.IsCaptureDevice)
                refreshAction = RefreshRecordingDevices;

            if (InvokeRequired)
                BeginInvoke(refreshAction);
            else
                refreshAction();
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

                    _retrievedVersion = client.GetUpdateInfo(AssemblyVersion);
                    if (_retrievedVersion != null && !string.IsNullOrEmpty(_retrievedVersion.URL))
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
            if (_retrievedVersion != null)
                udf = new UpdateForm(_retrievedVersion);
            else
                udf = new UpdateForm();

            udf.ShowDialog(this);
        }

        protected override void SetVisibleCore(bool value)
        {
            if (ConfigurationSettings.StartMinimized && _firstStart)
            {
                value = false;
                _firstStart = false;
            }

            base.SetVisibleCore(value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Q9TDQPY4B369A");
        }

        private void mnuFavouritePlaybackDevice_Click(object sender, EventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                return;

            Guid id = SelectedPlaybackDevice.Id;
            //if checked then we need to remove

            if (mnuFavouritePlaybackDevice.Checked)
                FavouriteDeviceManager.RemoveFavouriteDevice(SelectedPlaybackDevice.Id);
            else
                FavouriteDeviceManager.AddFavouriteDevice(SelectedPlaybackDevice.Id);

            PostPlaybackMenuClick(id);
        }

        private void mnuFavouriteRecordingDevice_Click(object sender, EventArgs e)
        {
            if (SelectedRecordingDevice == null)
                return;

            Guid id = SelectedRecordingDevice.Id;

            if (mnuFavouriteRecordingDevice.Checked)
                FavouriteDeviceManager.RemoveFavouriteDevice(SelectedRecordingDevice.Id);
            else
                FavouriteDeviceManager.AddFavouriteDevice(SelectedRecordingDevice.Id);

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
            _doubleClickHappened = false;

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
            if (_doubleClickHappened)
                return;

            if (ConfigurationSettings.EnableQuickSwitch)
            {
                if (FavouriteDeviceManager.FavouriteDeviceCount > 0)
                {
                    Guid devid = FavouriteDeviceManager.GetNextFavouritePlaybackDevice();

                    AudioDeviceManager.Controller.GetAudioDevice(devid).SetAsDefault();

                    if (ConfigurationSettings.DualSwitchMode)
                        AudioDeviceManager.Controller.GetAudioDevice(devid).SetAsDefaultCommunications();
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
            _doubleClickHappened = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new Exception("Fail Message");
        }

        private void AudioSwitcher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                _input += "U";
            else if (e.KeyCode == Keys.Down)
                _input += "D";
            else if (e.KeyCode == Keys.Left)
                _input += "L";
            else if (e.KeyCode == Keys.Right)
                _input += "R";
            else if (e.KeyCode == Keys.A)
                _input += "A";
            else if (e.KeyCode == Keys.B)
                _input += "B";

            if (_input.Length > KONAMI_CODE.Length)
            {
                _input = _input.Substring(1);
            }

            if (_input == KONAMI_CODE)
            {
                var rand = new Random();
                int index = rand.Next(YOUTUBE_VIDEOS.Length);
                Process.Start(YOUTUBE_VIDEOS[index]);
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

        private void setHotKeyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HotKeyForm hkf;
            foreach (HotKey hk in HotKeyManager.HotKeys)
            {
                if (hk.DeviceId == SelectedPlaybackDevice.Id)
                {
                    hkf = new HotKeyForm(hk);
                    hkf.ShowDialog(this);
                    return;
                }
            }

            var newHotKey = new HotKey();
            newHotKey.DeviceId = SelectedPlaybackDevice.Id;
            hkf = new HotKeyForm(newHotKey);
            hkf.ShowDialog(this);
        }

        private void setHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HotKeyForm hkf = null;
            foreach (HotKey hk in HotKeyManager.HotKeys)
            {
                if (hk.DeviceId == SelectedRecordingDevice.Id)
                {
                    hkf = new HotKeyForm(hk);
                    hkf.ShowDialog(this);
                    return;
                }
            }
            var newHotKey = new HotKey();
            newHotKey.DeviceId = SelectedRecordingDevice.Id;
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
            Process.Start("http://services.audioswit.ch/versions/");
        }

        private void mnuSetPlaybackStartupDevice_Click(object sender, EventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                return;

            if (ConfigurationSettings.StartupPlaybackDeviceID == SelectedPlaybackDevice.Id)
                ConfigurationSettings.StartupPlaybackDeviceID = Guid.Empty;
            else
                ConfigurationSettings.StartupPlaybackDeviceID = SelectedPlaybackDevice.Id;

            RefreshPlaybackDropDownButton();
        }

        private void mnuSetRecordingStartupDevice_Click(object sender, EventArgs e)
        {
            if (SelectedRecordingDevice == null)
                return;

            if (ConfigurationSettings.StartupRecordingDeviceID == SelectedRecordingDevice.Id)
                ConfigurationSettings.StartupRecordingDeviceID = Guid.Empty;
            else
                ConfigurationSettings.StartupRecordingDeviceID = SelectedRecordingDevice.Id;

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

            chkShowDiabledDevices.Checked = ConfigurationSettings.ShowDisabledDevices;
            chkShowDisconnectedDevices.Checked = ConfigurationSettings.ShowDisconnectedDevices;

            Width = ConfigurationSettings.WindowWidth;
            Height = ConfigurationSettings.WindowHeight;

            FavouriteDeviceManager.FavouriteDevicesChanged += AudioDeviceManger_FavouriteDevicesChanged;

            var favDeviceStr = ConfigurationSettings.FavouriteDevices.Split(new[] { ",", "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

            FavouriteDeviceManager.LoadFavouriteDevices(Array.ConvertAll(favDeviceStr, x =>
            {
                var r = new Regex(ConfigurationSettings.GUID_REGEX);
                foreach (var match in r.Matches(x))
                    return new Guid(match.ToString());

                return Guid.Empty;
            }));

            RegistryKey runKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //Ensure the registry key is added/removed
            if (ConfigurationSettings.AutoStartWithWindows)
            {
                if (runKey != null)
                    runKey.SetValue("AudioSwitcher", "\"" + Application.ExecutablePath + "\"");
            }
            else
            {
                if (runKey != null && runKey.GetValue("AudioSwitcher") != null)
                    runKey.DeleteValue("AudioSwitcher");
            }

            if (ConfigurationSettings.ShowDisabledDevices)
                DeviceStateFilter |= DeviceState.Disabled;


            if (ConfigurationSettings.ShowDisconnectedDevices)
                DeviceStateFilter |= DeviceState.Unplugged;
        }

        //Subscribe to favourite devices changing to save it to the configuration file instantly
        private void AudioDeviceManger_FavouriteDevicesChanged(List<Guid> IDs)
        {
            ConfigurationSettings.FavouriteDevices = "[" + string.Join("],[", IDs.ToArray()) + "]";
        }

        #endregion

        #region RefreshHandling

        private void RefreshPlaybackDevices()
        {
            listBoxPlayback.SuspendLayout();
            listBoxPlayback.Items.Clear();
            foreach (IDevice ad in AudioDeviceManager.Controller.GetPlaybackDevices(DeviceStateFilter).ToList())
            {
                var li = new ListViewItem();
                li.Text = ad.Name;
                li.Tag = ad;
                li.SubItems.Add(new ListViewItem.ListViewSubItem(li, ad.InterfaceName));
                try
                {
                    string imageKey = ad.IconPath.Substring(ad.IconPath.IndexOf("-") + 1);
                    if (ad.IsDefaultDevice)
                    {
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, "Default Device"));
                        li.EnsureVisible();
                    }
                    else if (ad.IsDefaultCommunicationsDevice)
                    {
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, "Default Communications Device"));
                        li.EnsureVisible();
                    }
                    else
                    {
                        string caption = "";
                        switch (ad.State)
                        {
                            case DeviceState.Active:
                                caption = "Ready";
                                break;
                            case DeviceState.Disabled:
                                caption = "Disabled";
                                imageKey += "d";
                                break;
                            case DeviceState.Unplugged:
                                caption = "Not Plugged In";
                                imageKey += "d";
                                break;
                        }
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, caption));
                    }

                    string imageMod = "";

                    if (ad.State != DeviceState.Unplugged && FavouriteDeviceManager.IsFavouriteDevice(ad))
                    {
                        imageMod += "f";
                    }

                    if (ad.IsDefaultDevice)
                    {
                        imageMod += "e";
                    }
                    else if (ad.IsDefaultCommunicationsDevice)
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

            foreach (IDevice ad in AudioDeviceManager.Controller.GetCaptureDevices(DeviceStateFilter).ToList())
            {
                var li = new ListViewItem();
                li.Text = ad.Name;
                li.Tag = ad;
                li.SubItems.Add(new ListViewItem.ListViewSubItem(li, ad.InterfaceName));
                try
                {
                    string imageKey = ad.IconPath.Substring(ad.IconPath.IndexOf("-") + 1);
                    if (ad.IsDefaultDevice)
                    {
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, "Default Device"));
                        li.EnsureVisible();
                    }
                    else if (ad.IsDefaultCommunicationsDevice)
                    {
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, "Default Communications Device"));
                        li.EnsureVisible();
                    }
                    else
                    {
                        string caption = "";
                        switch (ad.State)
                        {
                            case DeviceState.Active:
                                caption = "Ready";
                                break;
                            case DeviceState.Disabled:
                                caption = "Disabled";
                                imageKey += "d";
                                break;
                            case DeviceState.Unplugged:
                                caption = "Not Plugged In";
                                imageKey += "d";
                                break;
                        }
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, caption));
                    }

                    string imageMod = "";

                    if (ad.State != DeviceState.Unplugged && FavouriteDeviceManager.IsFavouriteDevice(ad))
                    {
                        imageMod += "f";
                    }

                    if (ad.IsDefaultDevice)
                    {
                        imageMod += "e";
                    }
                    else if (ad.IsDefaultCommunicationsDevice)
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

            IEnumerable<IDevice> list = AudioDeviceManager.Controller.GetPlaybackDevices(DeviceStateFilter).ToList();

            foreach (IDevice ad in list)
            {
                if (FavouriteDeviceManager.FavouriteDeviceCount > 0 && !FavouriteDeviceManager.IsFavouriteDevice(ad))
                    continue;

                var item = new ToolStripMenuItem(ad.FullName);
                item.Tag = ad;
                item.Checked = ad.IsDefaultDevice;
                notifyIconStrip.Items.Add(item);
                playbackCount++;
            }

            if (playbackCount > 0)
                notifyIconStrip.Items.Add(new ToolStripSeparator());

            list = AudioDeviceManager.Controller.GetCaptureDevices(DeviceStateFilter).ToList();

            foreach (IDevice ad in list)
            {
                if (FavouriteDeviceManager.FavouriteDeviceCount > 0 && !FavouriteDeviceManager.IsFavouriteDevice(ad))
                    continue;

                var item = new ToolStripMenuItem(ad.FullName);
                item.Tag = ad;
                item.Checked = ad.IsDefaultDevice;
                notifyIconStrip.Items.Add(item);
                recordingCount++;
            }

            if (recordingCount > 0)
                notifyIconStrip.Items.Add(new ToolStripSeparator());

            notifyIconStrip.Items.Add(exitToolStripMenuItem);

            //The maximum length of the noitfy text is 64 characters. This keeps it under

            var notifyText = AudioDeviceManager.Controller.DefaultPlaybackDevice.FullName;

            if (notifyText.Length > 64)
                notifyText = notifyText.Substring(0, 60) + "...";

            notifyIcon1.Text = notifyText;
        }

        private void RefreshPlaybackDropDownButton()
        {
            if (SelectedPlaybackDevice == null)
            {
                btnSetPlaybackDefault.Enabled = false;
                return;
            }

            if (SelectedPlaybackDevice.IsDefaultDevice)
                mnuSetPlaybackDefault.CheckState = CheckState.Checked;
            else
                mnuSetPlaybackDefault.CheckState = CheckState.Unchecked;

            if (SelectedPlaybackDevice.IsDefaultCommunicationsDevice)
                mnuSetPlaybackCommunicationDefault.CheckState = CheckState.Checked;
            else
                mnuSetPlaybackCommunicationDefault.CheckState = CheckState.Unchecked;

            if (FavouriteDeviceManager.IsFavouriteDevice(SelectedPlaybackDevice.Id))
                mnuFavouritePlaybackDevice.CheckState = CheckState.Checked;
            else
                mnuFavouritePlaybackDevice.CheckState = CheckState.Unchecked;

            if (ConfigurationSettings.StartupPlaybackDeviceID == SelectedPlaybackDevice.Id)
                mnuSetPlaybackStartupDevice.CheckState = CheckState.Checked;
            else
                mnuSetPlaybackStartupDevice.CheckState = CheckState.Unchecked;

            if (SelectedPlaybackDevice.State == DeviceState.Unplugged)
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

            if (SelectedRecordingDevice.IsDefaultDevice)
                mnuSetRecordingDefault.CheckState = CheckState.Checked;
            else
                mnuSetRecordingDefault.CheckState = CheckState.Unchecked;

            if (SelectedRecordingDevice.IsDefaultCommunicationsDevice)
                mnuSetRecordingCommunicationDefault.CheckState = CheckState.Checked;
            else
                mnuSetRecordingCommunicationDefault.CheckState = CheckState.Unchecked;

            if (FavouriteDeviceManager.IsFavouriteDevice(SelectedRecordingDevice.Id))
                mnuFavouriteRecordingDevice.CheckState = CheckState.Checked;
            else
                mnuFavouriteRecordingDevice.CheckState = CheckState.Unchecked;

            if (ConfigurationSettings.StartupRecordingDeviceID == SelectedRecordingDevice.Id)
                mnuSetRecordingStartupDevice.CheckState = CheckState.Checked;
            else
                mnuSetRecordingStartupDevice.CheckState = CheckState.Unchecked;

            if (SelectedRecordingDevice.State == DeviceState.Unplugged)
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

        private void mnuSetPlaybackCommunicationDefault_Click(object sender, EventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                return;

            Guid id = SelectedPlaybackDevice.Id;
            SelectedPlaybackDevice.SetAsDefaultCommunications();
            PostPlaybackMenuClick(id);
        }

        private void mnuSetPlaybackDefault_Click(object sender, EventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                return;

            Guid id = SelectedPlaybackDevice.Id;
            SelectedPlaybackDevice.SetAsDefault();
            PostPlaybackMenuClick(id);
        }

        private void PostPlaybackMenuClick(Guid id)
        {
            //RefreshPlaybackDevices();
            //RefreshPlaybackDropDownButton();
            for (int i = 0; i < listBoxPlayback.Items.Count; i++)
            {
                if (((IDevice)listBoxPlayback.Items[i].Tag).Id == id)
                {
                    listBoxPlayback.Items[i].Selected = true;
                    break;
                }
            }
        }

        private void mnuSetRecordingDefault_Click(object sender, EventArgs e)
        {
            if (SelectedRecordingDevice == null)
                return;

            Guid id = SelectedRecordingDevice.Id;
            SelectedRecordingDevice.SetAsDefault();
            PostRecordingMenuClick(id);
        }

        private void PostRecordingMenuClick(Guid id)
        {
            //RefreshRecordingDevices();
            //RefreshRecordingDropDownButton();
            for (int i = 0; i < listBoxRecording.Items.Count; i++)
            {
                if (((IDevice)listBoxRecording.Items[i].Tag).Id == id)
                {
                    listBoxRecording.Items[i].Selected = true;
                    break;
                }
            }
        }

        private void mnuSetRecordingCommunicationDefault_Click(object sender, EventArgs e)
        {
            if (SelectedRecordingDevice == null)
                return;

            Guid id = SelectedRecordingDevice.Id;
            SelectedRecordingDevice.SetAsDefaultCommunications();
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

                if (hk.DeviceId == AudioDeviceManager.Controller.DefaultCaptureDevice.Id ||
                    hk.DeviceId == AudioDeviceManager.Controller.DefaultPlaybackDevice.Id)
                    return;

                hk.Device.SetAsDefault();

                if (ConfigurationSettings.DualSwitchMode)
                    hk.Device.SetAsDefaultCommunications();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (ConfigurationSettings.CloseToTray)
                {
                    e.Cancel = true;
                    Hide();
                    MinimizeFootprint();
                }
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
            //RefreshPlaybackDevices();
            //RefreshRecordingDevices();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIconStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null && e.ClickedItem.Tag is IDevice)
            {
                var dev = (IDevice)e.ClickedItem.Tag;
                dev.SetAsDefault();

                if (ConfigurationSettings.DualSwitchMode)
                    dev.SetAsDefaultCommunications();
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://audioswit.ch/er");
        }

        private void chkShowDiabledDevices_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurationSettings.ShowDisabledDevices = chkShowDiabledDevices.Checked;

            //Set, or remove the disconnected filter
            if (ConfigurationSettings.ShowDisabledDevices)
                DeviceStateFilter |= DeviceState.Disabled;
            else
                DeviceStateFilter ^= DeviceState.Disabled;

            if (this.IsHandleCreated)
            {
                this.BeginInvoke((Action)(() =>
                {
                    RefreshPlaybackDevices();
                    RefreshRecordingDevices();
                }));
            }
        }

        private void chkShowDisconnectedDevices_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurationSettings.ShowDisconnectedDevices = chkShowDisconnectedDevices.Checked;

            //Set, or remove the disconnected filter
            if (ConfigurationSettings.ShowDisconnectedDevices)
                DeviceStateFilter |= DeviceState.Unplugged;
            else
                DeviceStateFilter ^= DeviceState.Unplugged;

            if (this.IsHandleCreated)
            {
                this.BeginInvoke((Action)(() =>
                {
                    RefreshPlaybackDevices();
                    RefreshRecordingDevices();
                }));
            }
        }

        private void playbackStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                e.Cancel = true;
        }

        private void recordingStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SelectedRecordingDevice == null)
                e.Cancel = true;
        }
    }
}