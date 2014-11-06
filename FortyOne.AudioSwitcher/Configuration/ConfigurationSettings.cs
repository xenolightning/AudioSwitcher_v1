using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FortyOne.AudioSwitcher.Configuration
{
    public static class ConfigurationSettings
    {
        public const string SETTING_CLOSETOTRAY = "CloseToTray";
        public const string SETTING_AUTOSTARTWITHWINDOWS = "AutoStartWithWindows";
        public const string SETTING_STARTMINIMIZED = "StartMinimized";
        public const string SETTING_HOTKEYS = "HotKeys";
        public const string SETTING_FAVOURITEDEVICES = "FavouriteDevices";
        public const string SETTING_WINDOWWIDTH = "WindowWidth";
        public const string SETTING_WINDOWHEIGHT = "WindowHeight";
        public const string SETTING_DISABLEHOTKEYS = "DisableHotKeys";
        public const string SETTING_ENABLEQUICKSWITCH = "EnableQuickSwitch";
        public const string SETTING_CHECKFORUPDATESONSTARTUP = "CheckForUpdatesOnStartup";
        public const string SETTING_POLLFORUPDATES = "PollForUpdates";
        public const string SETTING_STARTUPRECORDINGDEVICE = "StartupRecordingDeviceID";
        public const string SETTING_STARTUPPLAYBACKDEVICE = "StartupPlaybackDeviceID";
        public const string SETTING_DUALSWITCHMODE = "DualSwitchMode";
        private static string SectionName = "Settings";

        static ConfigurationSettings()
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

            if (!SettingExists(SETTING_HOTKEYS))
                HotKeys = "[]";

            if (!SettingExists(SETTING_FAVOURITEDEVICES))
                FavouriteDevices = "[]";

            if (!SettingExists(SETTING_WINDOWHEIGHT))
                WindowHeight = 420;

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
        }

        public static Guid StartupRecordingDeviceID
        {
            get { return new Guid(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_STARTUPRECORDINGDEVICE)); }
            set { ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_STARTUPRECORDINGDEVICE, value.ToString()); }
        }

        public static Guid StartupPlaybackDeviceID
        {
            get { return new Guid(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_STARTUPPLAYBACKDEVICE)); }
            set { ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_STARTUPPLAYBACKDEVICE, value.ToString()); }
        }

        public static int PollForUpdates
        {
            get
            {
                return
                    Convert.ToInt32(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_POLLFORUPDATES));
            }
            set
            {
                ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_POLLFORUPDATES, value.ToString());
            }
        }

        public static bool CheckForUpdatesOnStartup
        {
            get
            {
                return
                    Convert.ToBoolean(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName,
                        SETTING_CHECKFORUPDATESONSTARTUP));
            }
            set
            {
                ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_CHECKFORUPDATESONSTARTUP,
                    value.ToString());
            }
        }

        public static bool DualSwitchMode
        {
            get
            {
                return
                    Convert.ToBoolean(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName,
                        SETTING_DUALSWITCHMODE));
            }
            set
            {
                ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_DUALSWITCHMODE,
                    value.ToString());
            }
        }

        public static int WindowWidth
        {
            get
            {
                return Convert.ToInt32(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_WINDOWWIDTH));
            }
            set { ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_WINDOWWIDTH, value.ToString()); }
        }

        public static int WindowHeight
        {
            get
            {
                return Convert.ToInt32(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_WINDOWHEIGHT));
            }
            set { ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_WINDOWHEIGHT, value.ToString()); }
        }

        public static string FavouriteDevices
        {
            get { return ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_FAVOURITEDEVICES); }
            set { ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_FAVOURITEDEVICES, value); }
        }

        public static string HotKeys
        {
            get { return ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_HOTKEYS); }
            set { ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_HOTKEYS, value); }
        }

        public static bool CloseToTray
        {
            get
            {
                return Convert.ToBoolean(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_CLOSETOTRAY));
            }
            set { ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_CLOSETOTRAY, value.ToString()); }
        }

        public static bool StartMinimized
        {
            get
            {
                return
                    Convert.ToBoolean(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_STARTMINIMIZED));
            }
            set
            {
                ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_STARTMINIMIZED, value.ToString());
            }
        }

        public static bool AutoStartWithWindows
        {
            get
            {
                return
                    Convert.ToBoolean(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName,
                        SETTING_AUTOSTARTWITHWINDOWS));
            }
            set
            {
                ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_AUTOSTARTWITHWINDOWS,
                    value.ToString());

                if (AutoStartWithWindows)
                {
                    RegistryKey add =
                        Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    add.SetValue("AudioSwitcher", "\"" + Application.ExecutablePath + "\"");
                }
                else
                {
                    RegistryKey key =
                        Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                    if (key != null && key.GetValue("AudioSwitcher") != null)
                        key.DeleteValue("AudioSwitcher");
                }
            }
        }

        public static bool DisableHotKeys
        {
            get
            {
                return
                    Convert.ToBoolean(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, SETTING_DISABLEHOTKEYS));
            }
            set
            {
                ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_DISABLEHOTKEYS, value.ToString());
            }
        }

        public static bool EnableQuickSwitch
        {
            get
            {
                return
                    Convert.ToBoolean(ConfigurationWriter.ConfigWriter.IniReadValue(SectionName,
                        SETTING_ENABLEQUICKSWITCH));
            }
            set
            {
                ConfigurationWriter.ConfigWriter.IniWriteValue(SectionName, SETTING_ENABLEQUICKSWITCH, value.ToString());
            }
        }

        public static bool SettingExists(string name)
        {
            try
            {
                ConfigurationWriter.ConfigWriter.IniReadValue(SectionName, name);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}