using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi;
using FortyOne.AudioSwitcher.AudioSwitcherService;
using FortyOne.AudioSwitcher.Configuration;
using FortyOne.AudioSwitcher.Helpers;
using FortyOne.AudioSwitcher.HotKeyData;
using FortyOne.AudioSwitcher.Properties;

namespace FortyOne.AudioSwitcher
{
    public partial class AudioSwitcher : Form
    {
        /// <summary>
        ///     EASTER EGG! SHHH!
        /// </summary>
        private const string KONAMI_CODE = "UUDDLRLRBA";

        private static AudioSwitcher _instance;
        private readonly Icon _originalTrayIcon;

        private readonly Dictionary<DeviceIcon, string> ICON_MAP = new Dictionary<DeviceIcon, string>
        {
            {DeviceIcon.Speakers, "3010"},
            {DeviceIcon.Headphones, "3011"},
            {DeviceIcon.LineIn, "3012"},
            {DeviceIcon.Digital, "3013"},
            {DeviceIcon.DesktopMicrophone, "3014"},
            {DeviceIcon.Headset, "3015"},
            {DeviceIcon.Phone, "3016"},
            {DeviceIcon.Monitor, "3017"},
            {DeviceIcon.StereoMix, "3018"},
            {DeviceIcon.Kinect, "3020"},
            {DeviceIcon.Unknown, "3020"}
        };

        private readonly string[] YOUTUBE_VIDEOS =
        {
            "http://www.youtube.com/watch?v=QJO3ROT-A4E",
            "http://www.youtube.com/watch?v=fWNaR-rxAic",
            "http://www.youtube.com/watch?v=X2WH8mHJnhM",
            "http://www.youtube.com/watch?v=dQw4w9WgXcQ",
            "http://www.youtube.com/watch?v=2Z4m4lnjxkY"
        };

        private DeviceState _deviceStateFilter = DeviceState.Active;
        private bool _doubleClickHappened;
        private bool _firstStart = true;
        private string _input = "";
        private AudioSwitcherVersionInfo _retrievedVersion;
        private bool _updateAvailable;
        public bool DisableHotKeyFunction = false;

        public AudioSwitcher()
        {
            InitializeComponent();
            HandleCreated += AudioSwitcher_HandleCreated;

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

            _originalTrayIcon = new Icon(notifyIcon1.Icon, 32, 32);

            LoadSettings();

            AudioDeviceManager.Controller.AudioDeviceChanged += AudioDeviceManager_AudioDeviceChanged;

            HotKeyManager.HotKeyPressed += HotKeyManager_HotKeyPressed;
            hotKeyBindingSource.DataSource = HotKeyManager.HotKeys;

            MinimizeFootprint();
        }

        public static AudioSwitcher Instance
        {
            get { return _instance ?? (_instance = new AudioSwitcher()); }
        }

        private IDevice SelectedPlaybackDevice
        {
            get
            {
                if (listBoxPlayback.SelectedItems.Count > 0)
                    return ((IDevice) listBoxPlayback.SelectedItems[0].Tag);
                return null;
            }
        }

        public IDevice SelectedRecordingDevice
        {
            get
            {
                if (listBoxRecording.SelectedItems.Count > 0)
                    return ((IDevice) listBoxRecording.SelectedItems[0].Tag);
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

        public string AssemblyTitle
        {
            get
            {
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute) attributes[0];
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
            get { return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion; }
        }

        public string AssemblyDescription
        {
            get
            {
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute) attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute) attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute) attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var attributes =
                    Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute) attributes[0]).Company;
            }
        }

        private void AudioSwitcher_HandleCreated(object sender, EventArgs e)
        {
            BeginInvoke(new Action(Form_Load));
        }

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        private void Form_Load()
        {
            var dev = AudioDeviceManager.Controller.GetDevice(Program.Settings.StartupPlaybackDeviceID);

            if (dev != null)
                dev.SetAsDefault();

            dev = AudioDeviceManager.Controller.GetDevice(Program.Settings.StartupRecordingDeviceID);

            if (dev != null)
                dev.SetAsDefault();

            //Heartbeat
            Task.Factory.StartNew(CheckForNewVersion);

            BeginInvoke((Action) (() =>
            {
                RefreshPlaybackDevices();
                RefreshRecordingDevices();
            }));
        }

        private void CheckForNewVersion()
        {
            statusLabelUpdate.Visible = false;

            using (var client = ConnectionHelper.GetAudioSwitcherProxy())
            {
                if (client == null)
                    return;

                _retrievedVersion = client.GetUpdateInfo(AssemblyVersion);

                if (_retrievedVersion != null && !string.IsNullOrEmpty(_retrievedVersion.URL))
                {
                    _updateAvailable = true;
                    statusLabelUpdate.Visible = true;
                    statusLabelUpdate.ToolTipText = "New Version Available - " + _retrievedVersion.VersionInfo;

                    BeginInvoke(new Action(RefreshNotifyIconItems));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            btnTestError.Visible = true;
#endif
            MinimizeFootprint();
        }

        private void AudioDeviceManager_AudioDeviceChanged(object sender, DeviceChangedEventArgs e)
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

        protected override void SetVisibleCore(bool value)
        {
            if (Program.Settings.StartMinimized && _firstStart)
            {
                value = false;
                _firstStart = false;
                if (!IsHandleCreated) CreateHandle();
            }

            base.SetVisibleCore(value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Donate();
        }

        private static void Donate()
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Q9TDQPY4B369A");
        }

        private void mnuFavouritePlaybackDevice_Click(object sender, EventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                return;

            var id = SelectedPlaybackDevice.Id;
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

            var id = SelectedRecordingDevice.Id;

            if (mnuFavouriteRecordingDevice.Checked)
                FavouriteDeviceManager.RemoveFavouriteDevice(SelectedRecordingDevice.Id);
            else
                FavouriteDeviceManager.AddFavouriteDevice(SelectedRecordingDevice.Id);

            PostRecordingMenuClick(id);
        }

        private void chkDisableHotKeys_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.DisableHotKeys = chkDisableHotKeys.Checked;
            if (Program.Settings.DisableHotKeys)
            {
                foreach (var hk in HotKeyManager.HotKeys)
                {
                    hk.UnregsiterHotkey();
                }
            }
            else
            {
                foreach (var hk in HotKeyManager.HotKeys)
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
            ((Timer) sender).Stop();
            if (_doubleClickHappened)
                return;

            if (Program.Settings.EnableQuickSwitch)
            {
                if (FavouriteDeviceManager.FavouriteDeviceCount > 0)
                {
                    var devid = FavouriteDeviceManager.GetNextFavouritePlaybackDevice();

                    AudioDeviceManager.Controller.GetDevice(devid).SetAsDefault();

                    if (Program.Settings.DualSwitchMode)
                        AudioDeviceManager.Controller.GetDevice(devid).SetAsDefaultCommunications();
                }
            }
            else
            {
                RefreshNotifyIconItems();
                var mi = typeof (NotifyIcon).GetMethod("ShowContextMenu",
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
                var index = rand.Next(YOUTUBE_VIDEOS.Length);
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
            using (var client = ConnectionHelper.GetAudioSwitcherProxy())
            {
                if (client == null)
                    return;

                var vi = client.GetUpdateInfo(AssemblyVersion);
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
            if (SelectedPlaybackDevice == null)
                return;

            var hotkey = HotKeyManager.HotKeys.FirstOrDefault(x => x.DeviceId == SelectedPlaybackDevice.Id);

            if (hotkey == null)
            {
                hotkey = new HotKey();
                hotkey.DeviceId = SelectedPlaybackDevice.Id;
            }

            var hkf = new HotKeyForm(hotkey);
            hkf.ShowDialog(this);
        }

        private void setHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedRecordingDevice == null)
                return;

            var hotkey = HotKeyManager.HotKeys.FirstOrDefault(x => x.DeviceId == SelectedRecordingDevice.Id);

            if (hotkey == null)
            {
                hotkey = new HotKey();
                hotkey.DeviceId = SelectedRecordingDevice.Id;
            }

            var hkf = new HotKeyForm(hotkey);
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

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("http://services.audioswit.ch/versions/");
        }

        private void mnuSetPlaybackStartupDevice_Click(object sender, EventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                return;

            if (Program.Settings.StartupPlaybackDeviceID == SelectedPlaybackDevice.Id)
                Program.Settings.StartupPlaybackDeviceID = Guid.Empty;
            else
                Program.Settings.StartupPlaybackDeviceID = SelectedPlaybackDevice.Id;

            RefreshPlaybackDropDownButton();
        }

        private void mnuSetRecordingStartupDevice_Click(object sender, EventArgs e)
        {
            if (SelectedRecordingDevice == null)
                return;

            if (Program.Settings.StartupRecordingDeviceID == SelectedRecordingDevice.Id)
                Program.Settings.StartupRecordingDeviceID = Guid.Empty;
            else
                Program.Settings.StartupRecordingDeviceID = SelectedRecordingDevice.Id;

            RefreshRecordingDropDownButton();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://audioswit.ch/er?utm_source=client_1&utm_medium=direct&utm_campaign=client_1");
        }

        private void linkLabelTwitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitter.com/xenolightning");
        }

        private void chkShowDiabledDevices_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ShowDisabledDevices = chkShowDiabledDevices.Checked;

            //Set, or remove the disconnected filter
            if (Program.Settings.ShowDisabledDevices)
                _deviceStateFilter |= DeviceState.Disabled;
            else
                _deviceStateFilter ^= DeviceState.Disabled;

            if (IsHandleCreated)
            {
                BeginInvoke((Action) (() =>
                {
                    RefreshPlaybackDevices();
                    RefreshRecordingDevices();
                }));
            }
        }

        private void chkShowDisconnectedDevices_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ShowDisconnectedDevices = chkShowDisconnectedDevices.Checked;

            //Set, or remove the disconnected filter
            if (Program.Settings.ShowDisconnectedDevices)
                _deviceStateFilter |= DeviceState.Unplugged;
            else
                _deviceStateFilter ^= DeviceState.Unplugged;

            if (IsHandleCreated)
            {
                BeginInvoke((Action) (() =>
                {
                    RefreshPlaybackDevices();
                    RefreshRecordingDevices();
                }));
            }
        }

        private void playbackStrip_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                e.Cancel = true;
        }

        private void recordingStrip_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedRecordingDevice == null)
                e.Cancel = true;
        }

        private void linkIssues_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/xenolightning/AudioSwitcher_v1/issues");
        }

        private void linkWiki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/xenolightning/AudioSwitcher_v1/wiki");
        }

        private void chkShowDPDeviceIconInTray_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.ShowDPDeviceIconInTray = chkShowDPDeviceIconInTray.Checked;
            RefreshTrayIcon();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

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
                var hkf = new HotKeyForm((HotKey) hotKeyBindingSource.Current);
                hkf.ShowDialog(this);
                RefreshGrid();
            }
        }

        private void btnDeleteHotKey_Click(object sender, EventArgs e)
        {
            if (hotKeyBindingSource.Current != null)
            {
                HotKeyManager.DeleteHotKey((HotKey) hotKeyBindingSource.Current);
                RefreshGrid();
            }
        }

        private void btnClearAllHotKeys_Click(object sender, EventArgs e)
        {
            HotKeyManager.ClearAll();
            RefreshGrid();

            MessageBox.Show("Hotkeys Cleared!");
        }

        private void RefreshGrid()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(RefreshGrid));
                return;
            }

            hotKeyBindingSource.ResetBindings(false);
            dataGridView1.Refresh();
        }

        private void LoadSettings()
        {
            //Fix to stop the registry thing being removed and not re-added
            Program.Settings.AutoStartWithWindows = Program.Settings.AutoStartWithWindows;

            chkCloseToTray.Checked = Program.Settings.CloseToTray;
            chkStartMinimized.Checked = Program.Settings.StartMinimized;
            chkAutoStartWithWindows.Checked = Program.Settings.AutoStartWithWindows;
            chkDisableHotKeys.Checked = Program.Settings.DisableHotKeys;
            chkQuickSwitch.Checked = Program.Settings.EnableQuickSwitch;
            chkDualSwitchMode.Checked = Program.Settings.DualSwitchMode;

            chkShowDiabledDevices.Checked = Program.Settings.ShowDisabledDevices;
            chkShowDisconnectedDevices.Checked = Program.Settings.ShowDisconnectedDevices;
            chkShowDPDeviceIconInTray.Checked = Program.Settings.ShowDPDeviceIconInTray;

            Width = Program.Settings.WindowWidth;
            Height = Program.Settings.WindowHeight;

            FavouriteDeviceManager.FavouriteDevicesChanged += AudioDeviceManger_FavouriteDevicesChanged;

            var favDeviceStr = Program.Settings.FavouriteDevices.Split(new[] {",", "[", "]"},
                StringSplitOptions.RemoveEmptyEntries);

            FavouriteDeviceManager.LoadFavouriteDevices(Array.ConvertAll(favDeviceStr, x =>
            {
                var r = new Regex(ConfigurationSettings.GUID_REGEX);
                foreach (var match in r.Matches(x))
                    return new Guid(match.ToString());

                return Guid.Empty;
            }));

            //Ensure to delete the key if it's not set
            Program.Settings.AutoStartWithWindows = Program.Settings.AutoStartWithWindows;

            if (Program.Settings.ShowDisabledDevices)
                _deviceStateFilter |= DeviceState.Disabled;


            if (Program.Settings.ShowDisconnectedDevices)
                _deviceStateFilter |= DeviceState.Unplugged;
        }

        //Subscribe to favourite devices changing to save it to the configuration file instantly
        private void AudioDeviceManger_FavouriteDevicesChanged(List<Guid> IDs)
        {
            Program.Settings.FavouriteDevices = "[" + string.Join("],[", IDs.ToArray()) + "]";
        }

        private void RefreshPlaybackDevices()
        {
            listBoxPlayback.SuspendLayout();
            listBoxPlayback.Items.Clear();
            foreach (var ad in AudioDeviceManager.Controller.GetPlaybackDevices(_deviceStateFilter).ToList())
            {
                var li = new ListViewItem();
                li.Text = ad.Name;
                li.Tag = ad;
                li.SubItems.Add(new ListViewItem.ListViewSubItem(li, ad.InterfaceName));
                try
                {
                    var imageKey = "";
                    var imageMod = "";

                    if (ICON_MAP.ContainsKey(ad.Icon))
                        imageKey = ICON_MAP[ad.Icon];

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
                        var caption = "";
                        switch (ad.State)
                        {
                            case DeviceState.Active:
                                caption = "Ready";
                                break;
                            case DeviceState.Disabled:
                                caption = "Disabled";
                                imageMod += "d";
                                break;
                            case DeviceState.Unplugged:
                                caption = "Not Plugged In";
                                imageMod += "d";
                                break;
                        }
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, caption));
                    }

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

                    var imageToGen = imageKey + imageMod + ".png";

                    if (!imageList1.Images.Keys.Contains(imageToGen) &&
                        imageList1.Images.IndexOfKey(imageKey + ".png") >= 0)
                    {
                        var i = (Image) imageList1.Images[imageKey + ".png"].Clone();

                        if (ad.State == DeviceState.Disabled || ad.State == DeviceState.Unplugged)
                            i = ImageHelper.SetImageOpacity(i, 0.5F);

                        using (var g = Graphics.FromImage(i))
                        {
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

            foreach (var ad in AudioDeviceManager.Controller.GetCaptureDevices(_deviceStateFilter).ToList())
            {
                var li = new ListViewItem();
                li.Text = ad.Name;
                li.Tag = ad;
                li.SubItems.Add(new ListViewItem.ListViewSubItem(li, ad.InterfaceName));
                try
                {
                    var imageKey = "";
                    var imageMod = "";
                    if (ICON_MAP.ContainsKey(ad.Icon))
                        imageKey = ICON_MAP[ad.Icon];

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
                        var caption = "";
                        switch (ad.State)
                        {
                            case DeviceState.Active:
                                caption = "Ready";
                                break;
                            case DeviceState.Disabled:
                                caption = "Disabled";
                                imageMod += "d";
                                break;
                            case DeviceState.Unplugged:
                                caption = "Not Plugged In";
                                imageMod += "d";
                                break;
                        }
                        li.SubItems.Add(new ListViewItem.ListViewSubItem(li, caption));
                    }


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

                    var imageToGen = imageKey + imageMod + ".png";

                    if (!imageList1.Images.Keys.Contains(imageToGen) &&
                        imageList1.Images.IndexOfKey(imageKey + ".png") >= 0)
                    {
                        var i = (Image) imageList1.Images[imageKey + ".png"].Clone();

                        if (ad.State.HasFlag(DeviceState.Disabled) || ad.State == DeviceState.Unplugged)
                            i = ImageHelper.SetImageOpacity(i, 0.5F);

                        using (var g = Graphics.FromImage(i))
                        {
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

            var playbackCount = 0;
            var recordingCount = 0;

            IEnumerable<IDevice> list = AudioDeviceManager.Controller.GetPlaybackDevices(_deviceStateFilter).ToList();

            foreach (var ad in list)
            {
                if (FavouriteDeviceManager.FavouriteDeviceCount > 0 && !FavouriteDeviceManager.IsFavouriteDevice(ad))
                    continue;

                var item = new ToolStripMenuItem
                {
                    Text = ad.FullName,
                    Tag = ad,
                    Checked = ad.IsDefaultDevice
                };

                notifyIconStrip.Items.Add(item);
                playbackCount++;
            }

            if (playbackCount > 0)
                notifyIconStrip.Items.Add(new ToolStripSeparator());

            list = AudioDeviceManager.Controller.GetCaptureDevices(_deviceStateFilter).ToList();

            foreach (var ad in list)
            {
                if (FavouriteDeviceManager.FavouriteDeviceCount > 0 && !FavouriteDeviceManager.IsFavouriteDevice(ad))
                    continue;

                var item = new ToolStripMenuItem
                {
                    Text = ad.FullName,
                    Tag = ad,
                    Checked = ad.IsDefaultDevice
                };

                notifyIconStrip.Items.Add(item);
                recordingCount++;
            }

            if (recordingCount > 0)
                notifyIconStrip.Items.Add(new ToolStripSeparator());

            notifyIconStrip.Items.Add(preferencesToolStripMenuItem);

            if (_updateAvailable)
                notifyIconStrip.Items.Add(updateAvailableToolStripMenuItem);

            notifyIconStrip.Items.Add(exitToolStripMenuItem);

            var defaultDevice = AudioDeviceManager.Controller.DefaultPlaybackDevice;
            var notifyText = "Audio Switcher";

            //The maximum length of the noitfy text is 64 characters. This keeps it under
            if (defaultDevice != null)
            {
                var devName = defaultDevice.FullName ?? defaultDevice.Name ?? notifyText;

                if (notifyText.Length >= 64)
                    notifyText = notifyText.Substring(0, 60) + "...";
                else
                    notifyText = devName;
            }

            notifyIcon1.Text = notifyText;

            RefreshTrayIcon();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        private void RefreshTrayIcon()
        {
            var defaultDevice = AudioDeviceManager.Controller.DefaultPlaybackDevice;
            if (defaultDevice != null && Program.Settings.ShowDPDeviceIconInTray)
            {
                var imageKey = ICON_MAP[defaultDevice.Icon];
                var image = (Bitmap) imageList1.Images[imageList1.Images.IndexOfKey(imageKey + ".png")];
                var iconHandle = image.GetHicon();
                var icon = Icon.FromHandle(iconHandle);

                notifyIcon1.Icon = icon;

                //Clean up the old icon, because WinForms creates a copy of the icon for use
                icon.Dispose();
                DestroyIcon(iconHandle);
            }
            else
            {
                notifyIcon1.Icon = _originalTrayIcon;
            }
        }

        private void RefreshPlaybackDropDownButton()
        {
            if (SelectedPlaybackDevice == null)
            {
                btnSetPlaybackDefault.Enabled = false;
                return;
            }

            mnuSetPlaybackDefault.CheckState = SelectedPlaybackDevice.IsDefaultDevice
                ? CheckState.Checked
                : CheckState.Unchecked;

            mnuSetPlaybackCommunicationDefault.CheckState = SelectedPlaybackDevice.IsDefaultCommunicationsDevice
                ? CheckState.Checked
                : CheckState.Unchecked;

            mnuFavouritePlaybackDevice.CheckState = FavouriteDeviceManager.IsFavouriteDevice(SelectedPlaybackDevice.Id)
                ? CheckState.Checked
                : CheckState.Unchecked;

            mnuSetPlaybackStartupDevice.CheckState = Program.Settings.StartupPlaybackDeviceID ==
                                                     SelectedPlaybackDevice.Id
                ? CheckState.Checked
                : CheckState.Unchecked;

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

            mnuSetRecordingDefault.CheckState = SelectedRecordingDevice.IsDefaultDevice
                ? CheckState.Checked
                : CheckState.Unchecked;

            mnuSetRecordingCommunicationDefault.CheckState = SelectedRecordingDevice.IsDefaultCommunicationsDevice
                ? CheckState.Checked
                : CheckState.Unchecked;

            mnuFavouriteRecordingDevice.CheckState = FavouriteDeviceManager.IsFavouriteDevice(SelectedRecordingDevice.Id)
                ? CheckState.Checked
                : CheckState.Unchecked;

            mnuSetRecordingStartupDevice.CheckState = Program.Settings.StartupRecordingDeviceID ==
                                                      SelectedRecordingDevice.Id
                ? CheckState.Checked
                : CheckState.Unchecked;

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

        private void mnuSetPlaybackCommunicationDefault_Click(object sender, EventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                return;

            var id = SelectedPlaybackDevice.Id;
            SelectedPlaybackDevice.SetAsDefaultCommunications();
            PostPlaybackMenuClick(id);
        }

        private void mnuSetPlaybackDefault_Click(object sender, EventArgs e)
        {
            if (SelectedPlaybackDevice == null)
                return;

            var id = SelectedPlaybackDevice.Id;
            SelectedPlaybackDevice.SetAsDefault();
            PostPlaybackMenuClick(id);
        }

        private void PostPlaybackMenuClick(Guid id)
        {
            RefreshPlaybackDevices();
            RefreshPlaybackDropDownButton();
            for (var i = 0; i < listBoxPlayback.Items.Count; i++)
            {
                if (((IDevice) listBoxPlayback.Items[i].Tag).Id == id)
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

            var id = SelectedRecordingDevice.Id;
            SelectedRecordingDevice.SetAsDefault();
            PostRecordingMenuClick(id);
        }

        private void PostRecordingMenuClick(Guid id)
        {
            RefreshRecordingDevices();
            RefreshRecordingDropDownButton();
            for (var i = 0; i < listBoxRecording.Items.Count; i++)
            {
                if (((IDevice) listBoxRecording.Items[i].Tag).Id == id)
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

            var id = SelectedRecordingDevice.Id;
            SelectedRecordingDevice.SetAsDefaultCommunications();
            PostRecordingMenuClick(id);
        }

        private void HotKeyManager_HotKeyPressed(object sender, EventArgs e)
        {
            //Double check here before handling
            if (DisableHotKeyFunction || Program.Settings.DisableHotKeys)
                return;

            if (sender is HotKey)
            {
                var hk = sender as HotKey;

                if (hk.Device == null || hk.Device.IsDefaultDevice)
                    return;

                hk.Device.SetAsDefault();

                if (Program.Settings.DualSwitchMode)
                    hk.Device.SetAsDefaultCommunications();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (Program.Settings.CloseToTray)
                {
                    e.Cancel = true;
                    Hide();
                    MinimizeFootprint();
                }

                HotKeyManager.SaveHotKeys();
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
                var dev = (IDevice) e.ClickedItem.Tag;
                dev.SetAsDefault();

                if (Program.Settings.DualSwitchMode)
                    dev.SetAsDefaultCommunications();
            }
        }

        private void chkCloseToTray_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.CloseToTray = chkCloseToTray.Checked;
        }

        private void chkAutoStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.AutoStartWithWindows = chkAutoStartWithWindows.Checked;
        }

        private void chkStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.StartMinimized = chkStartMinimized.Checked;
        }

        private void chkQuickSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.EnableQuickSwitch = chkQuickSwitch.Checked;
        }

        private void chkDualSwitchMode_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.DualSwitchMode = chkDualSwitchMode.Checked;
        }

        private void AudioSwitcher_ResizeEnd(object sender, EventArgs e)
        {
            Program.Settings.WindowWidth = Width;
            Program.Settings.WindowHeight = Height;
        }

        private void statusLabelUpdate_Click(object sender, EventArgs e)
        {
            ShowUpdateForm();
        }

        private void ShowUpdateForm(bool topMost = false)
        {
            if (_retrievedVersion == null)
                return;

            var udf = new UpdateForm(_retrievedVersion);
            udf.TopMost = topMost;
            udf.ShowDialog(this);
        }

        private void statusLabelDonate_Click(object sender, EventArgs e)
        {
            Donate();
        }

        private void updateAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUpdateForm(true);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.twitter.com/xenolightning");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://github.com/xenolightning/AudioSwitcher_v1");
        }
    }
}