using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using AudioSwitcher.AudioApi.CoreAudio;
using FortyOne.AudioSwitcher.Configuration;
using FortyOne.AudioSwitcher.Properties;

namespace FortyOne.AudioSwitcher
{
    internal static class Program
    {
        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        public static ConfigurationSettings Settings
        {
            get;
            private set;
        }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.ThreadException += WinFormExceptionHandler.OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += WinFormExceptionHandler.OnUnhandledCLRException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Environment.OSVersion.Version.Major < 6)
            {
                MessageBox.Show("Audio Switcher only supports Windows Vista and Windows 7",
                    "Unsupported Operating System");
                return;
            }

            Application.ApplicationExit += Application_ApplicationExit;

            //Delete the old updater
            try
            {
                string updaterPath = Application.StartupPath + "AutoUpdater.exe";
                if (File.Exists(updaterPath))
                    File.Delete(updaterPath);
            }
            catch
            {
                //This shouldn't prevent the application from running
            }

            //Delete the new updater
            try
            {
                string updaterPath = Path.Combine(Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName,
                    "AutoUpdater.exe");
                if (File.Exists(updaterPath))
                    File.Delete(updaterPath);
            }
            catch
            {
                //This shouldn't prevent the application from running
            }

            string settingsPath = "";
            try
            {
                //Load/Create default settings
                string oldSettingsPath = "";

                oldSettingsPath = Path.Combine(Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName, Resources.OldConfigFile);
                settingsPath = oldSettingsPath;

                //1. Provide early notification that the user does not have permission to write.
                var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, settingsPath);
                new FileIOPermission(FileIOPermissionAccess.Write, settingsPath).Demand();

                settingsPath = Path.Combine(Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName, Resources.ConfigFile);
                new FileIOPermission(FileIOPermissionAccess.Write, settingsPath).Demand();

                //Open and close the settings file to ensure write access
                File.Open(settingsPath, FileMode.OpenOrCreate, FileAccess.ReadWrite).Close();

                ISettingsSource jsonSource = new JsonSettings();
                jsonSource.SetFilePath(settingsPath);

                Settings = new ConfigurationSettings(jsonSource);

                if (File.Exists(oldSettingsPath))
                {
                    try
                    {
                        //Load old settings and copy them to json
                        ISettingsSource iniSource = new IniSettings();
                        iniSource.SetFilePath(oldSettingsPath);

                        var oldSettings = new ConfigurationSettings(iniSource);
                        Settings.LoadFrom(oldSettings);
                    }
                    catch
                    {
                        Settings.CreateDefaults();
                    }
                    finally
                    {
                        File.Delete(oldSettingsPath);
                    }
                }

                Settings.CreateDefaults();
            }
            catch
            {
                MessageBox.Show(
                    String.Format("Error creating/reading settings file [{0}]. Make sure you have read/write access to this file.\r\nOr try running as Administrator", settingsPath),
                    "Setings File - Cannot Access");
                return;
            }

            try
            {
                Application.Run(AudioSwitcher.Instance);
            }
            catch (Exception ex)
            {
                string title = "An Unexpected Error Occurred";
                string text = ex.Message + Environment.NewLine + Environment.NewLine + ex;

                var edf = new ExceptionDisplayForm(title, text, ex);
                edf.ShowDialog();
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //Ensure the icon disappears from tray
            AudioSwitcher.Instance.TrayIconVisible = false;
        }
    }
}