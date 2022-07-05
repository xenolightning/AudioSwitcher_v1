using System;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace FortyOne.AudioSwitcher.Configuration
{
    public class ConfigurationSettings
    {
        public const string GUID_REGEX = @"([a-z0-9]{8}[-][a-z0-9]{4}[-][a-z0-9]{4}[-][a-z0-9]{4}[-][a-z0-9]{12})";
        public const string SETTING_CLOSETOTRAY = "CloseToTray";
        public const string SETTING_AUTOSTARTWITHWINDOWS = "AutoStartWithWindows";
        public const string SETTING_STARTMINIMIZED = "StartMinimized";
        public const string SETTING_HOTKEYS = "HotKeys";
        public const string SETTING_FAVOURITEDEVICES = "FavouriteDevices";
        public const string SETTING_WINDOWWIDTH = "WindowWidth";
        public const string SETTING_WINDOWHEIGHT = "WindowHeight";
        public const string SETTING_DISABLEHOTKEYS = "DisableHotKeys";
        public const string SETTING_ENABLEQUICKSWITCH = "EnableQuickSwitch";
        public const string SETTING_DISABLEDOUBLECLICK = "DisableDoubleClick";
        public const string SETTING_CHECKFORUPDATESONSTARTUP = "CheckForUpdatesOnStartup";
        public const string SETTING_POLLFORUPDATES = "PollForUpdates";
        public const string SETTING_STARTUPRECORDINGDEVICE = "StartupRecordingDeviceID";
        public const string SETTING_STARTUPPLAYBACKDEVICE = "StartupPlaybackDeviceID";
        public const string SETTING_DUALSWITCHMODE = "DualSwitchMode";
        public const string SETTING_SHOWDISABLEDDEVICES = "ShowDisabledDevices";
        public const string SETTING_SHOWUNKNOWNDEVICESINHOTKEYLIST = "ShowUnknownDevicesInHotkeyList";
        public const string SETTING_SHOWDISCONNECTEDDDEVICES = "ShowDisconnectedDevices";
        public const string SETTING_SHOWDPDEVICEIICONINTRAY = "ShowDPDeviceIconInTray";
        public const string SETTING_UPDATE_NOTIFICATIONS_ENABLED = "UpdateNotificationsEnabled";
        private readonly ISettingsSource _configWriter;

        public ConfigurationSettings(ISettingsSource source)
        {
            _configWriter = source;
            _configWriter.Load();
        }

        public Guid StartupRecordingDeviceID
        {
            get
            {
                var r = new Regex(GUID_REGEX);
                foreach (var match in r.Matches(_configWriter.Get(SETTING_STARTUPRECORDINGDEVICE)))
                    return new Guid(match.ToString());

                return Guid.Empty;
            }
            set { _configWriter.Set(SETTING_STARTUPRECORDINGDEVICE, value.ToString()); }
        }

        public Guid StartupPlaybackDeviceID
        {
            get
            {
                var r = new Regex(GUID_REGEX);
                foreach (var match in r.Matches(_configWriter.Get(SETTING_STARTUPPLAYBACKDEVICE)))
                    return new Guid(match.ToString());

                return Guid.Empty;
            }
            set { _configWriter.Set(SETTING_STARTUPPLAYBACKDEVICE, value.ToString()); }
        }

        public int PollForUpdates
        {
            get
            {
                return
                    Convert.ToInt32(_configWriter.Get(SETTING_POLLFORUPDATES));
            }
            set { _configWriter.Set(SETTING_POLLFORUPDATES, value.ToString()); }
        }

        public bool CheckForUpdatesOnStartup
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_CHECKFORUPDATESONSTARTUP));
            }
            set
            {
                _configWriter.Set(SETTING_CHECKFORUPDATESONSTARTUP,
                    value.ToString());
            }
        }

        public bool DualSwitchMode
        {
            get { return Convert.ToBoolean(_configWriter.Get(SETTING_DUALSWITCHMODE)); }
            set
            {
                _configWriter.Set(SETTING_DUALSWITCHMODE,
                    value.ToString());
            }
        }

        public bool ShowDisabledDevices
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_SHOWDISABLEDDEVICES));
            }
            set { _configWriter.Set(SETTING_SHOWDISABLEDDEVICES, value.ToString()); }
        }

        public bool ShowUnknownDevicesInHotkeyList
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_SHOWUNKNOWNDEVICESINHOTKEYLIST));
            }
            set { _configWriter.Set(SETTING_SHOWUNKNOWNDEVICESINHOTKEYLIST, value.ToString()); }
        }
        
        public bool ShowDisconnectedDevices
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_SHOWDISCONNECTEDDDEVICES));
            }
            set { _configWriter.Set(SETTING_SHOWDISCONNECTEDDDEVICES, value.ToString()); }
        }

        public bool ShowDPDeviceIconInTray
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_SHOWDPDEVICEIICONINTRAY));
            }
            set { _configWriter.Set(SETTING_SHOWDPDEVICEIICONINTRAY, value.ToString()); }
        }

        public int WindowWidth
        {
            get { return Convert.ToInt32(_configWriter.Get(SETTING_WINDOWWIDTH)); }
            set { _configWriter.Set(SETTING_WINDOWWIDTH, value.ToString()); }
        }

        public int WindowHeight
        {
            get { return Convert.ToInt32(_configWriter.Get(SETTING_WINDOWHEIGHT)); }
            set { _configWriter.Set(SETTING_WINDOWHEIGHT, value.ToString()); }
        }

        public string FavouriteDevices
        {
            get { return _configWriter.Get(SETTING_FAVOURITEDEVICES); }
            set { _configWriter.Set(SETTING_FAVOURITEDEVICES, value); }
        }

        public string HotKeys
        {
            get { return _configWriter.Get(SETTING_HOTKEYS); }
            set { _configWriter.Set(SETTING_HOTKEYS, value); }
        }

        public bool CloseToTray
        {
            get { return Convert.ToBoolean(_configWriter.Get(SETTING_CLOSETOTRAY)); }
            set { _configWriter.Set(SETTING_CLOSETOTRAY, value.ToString()); }
        }

        public bool StartMinimized
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_STARTMINIMIZED));
            }
            set { _configWriter.Set(SETTING_STARTMINIMIZED, value.ToString()); }
        }

        public bool AutoStartWithWindows
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_AUTOSTARTWITHWINDOWS));
            }
            set
            {
                try
                {
                    if (value)
                    {
                        var add =
                            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        add.SetValue("AudioSwitcher", "\"" + Assembly.GetEntryAssembly().Location + "\"");
                    }
                    else
                    {
                        var key =
                            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                        if (key != null && key.GetValue("AudioSwitcher") != null)
                            key.DeleteValue("AudioSwitcher");
                    }

                    _configWriter.Set(SETTING_AUTOSTARTWITHWINDOWS, value.ToString());
                }
                catch
                {
                    _configWriter.Set(SETTING_AUTOSTARTWITHWINDOWS, false.ToString());
                }
            }
        }

        public bool DisableHotKeys
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_DISABLEHOTKEYS));
            }
            set { _configWriter.Set(SETTING_DISABLEHOTKEYS, value.ToString()); }
        }

        public bool EnableQuickSwitch
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_ENABLEQUICKSWITCH));
            }
            set { _configWriter.Set(SETTING_ENABLEQUICKSWITCH, value.ToString()); }
        }

        public bool DisableDoubleClick
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_DISABLEDOUBLECLICK));
            }
            set { _configWriter.Set(SETTING_DISABLEDOUBLECLICK, value.ToString()); }
        }

        public bool UpdateNotificationsEnabled
        {
            get
            {
                return
                    Convert.ToBoolean(_configWriter.Get(SETTING_UPDATE_NOTIFICATIONS_ENABLED));
            }
            set { _configWriter.Set(SETTING_UPDATE_NOTIFICATIONS_ENABLED, value.ToString()); }
        }

        public void CreateDefaults()
        {
            if (!SettingExists(SETTING_CLOSETOTRAY))
                CloseToTray = false;

            if (!SettingExists(SETTING_STARTMINIMIZED))
                StartMinimized = false;

            if (!SettingExists(SETTING_AUTOSTARTWITHWINDOWS))
                AutoStartWithWindows = false;

            if (!SettingExists(SETTING_DISABLEHOTKEYS))
                DisableHotKeys = false;

            if (!SettingExists(SETTING_ENABLEQUICKSWITCH))
                EnableQuickSwitch = false;

            if (!SettingExists(SETTING_DISABLEDOUBLECLICK))
                DisableDoubleClick = false;

            if (!SettingExists(SETTING_HOTKEYS))
                HotKeys = "[]";

            if (!SettingExists(SETTING_FAVOURITEDEVICES))
                FavouriteDevices = "[]";

            if (!SettingExists(SETTING_WINDOWHEIGHT))
                WindowHeight = 400;

            if (!SettingExists(SETTING_WINDOWWIDTH))
                WindowWidth = 300;

            if (!SettingExists(SETTING_CHECKFORUPDATESONSTARTUP))
                CheckForUpdatesOnStartup = false;

            if (!SettingExists(SETTING_POLLFORUPDATES) && CheckForUpdatesOnStartup)
                PollForUpdates = 60;
            else if (!SettingExists(SETTING_POLLFORUPDATES) && !CheckForUpdatesOnStartup)
                PollForUpdates = 0;

            if (!SettingExists(SETTING_STARTUPPLAYBACKDEVICE))
                StartupPlaybackDeviceID = Guid.Empty;

            if (!SettingExists(SETTING_STARTUPRECORDINGDEVICE))
                StartupRecordingDeviceID = Guid.Empty;

            if (!SettingExists(SETTING_DUALSWITCHMODE))
                DualSwitchMode = false;

            if (!SettingExists(SETTING_SHOWDISABLEDDEVICES))
                ShowDisabledDevices = false;

            if (!SettingExists(SETTING_SHOWUNKNOWNDEVICESINHOTKEYLIST))
                ShowUnknownDevicesInHotkeyList = false;
            
            if (!SettingExists(SETTING_SHOWDISCONNECTEDDDEVICES))
                ShowDisconnectedDevices = false;

            if (!SettingExists(SETTING_SHOWDPDEVICEIICONINTRAY))
                ShowDPDeviceIconInTray = false;

            if (!SettingExists(SETTING_UPDATE_NOTIFICATIONS_ENABLED))
                UpdateNotificationsEnabled = PollForUpdates > 0;
        }

        public void LoadFrom(ConfigurationSettings otherSettings)
        {
            AutoStartWithWindows = otherSettings.AutoStartWithWindows;
            CheckForUpdatesOnStartup = otherSettings.CheckForUpdatesOnStartup;
            CloseToTray = otherSettings.CloseToTray;
            DisableHotKeys = otherSettings.DisableHotKeys;
            DualSwitchMode = otherSettings.DualSwitchMode;
            EnableQuickSwitch = otherSettings.EnableQuickSwitch;
            DisableDoubleClick = otherSettings.DisableDoubleClick;
            FavouriteDevices = otherSettings.FavouriteDevices;
            HotKeys = otherSettings.HotKeys;
            PollForUpdates = otherSettings.PollForUpdates;
            ShowDisabledDevices = otherSettings.ShowDisabledDevices;
            ShowUnknownDevicesInHotkeyList = otherSettings.ShowUnknownDevicesInHotkeyList;
            ShowDisconnectedDevices = otherSettings.ShowDisconnectedDevices;
            StartMinimized = otherSettings.StartMinimized;
            StartupPlaybackDeviceID = otherSettings.StartupPlaybackDeviceID;
            StartupRecordingDeviceID = otherSettings.StartupRecordingDeviceID;
            WindowHeight = otherSettings.WindowHeight;
            WindowWidth = otherSettings.WindowWidth;
        }

        public bool SettingExists(string name)
        {
            try
            {
                _configWriter.Get(name);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}