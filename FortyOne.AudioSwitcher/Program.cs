using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using FortyOne.AudioSwitcher.Configuration;
using FortyOne.AudioSwitcher.Properties;

namespace FortyOne.AudioSwitcher
{
    internal static class Program
    {

        public static string AppDataDirectory { get; private set; }

        public static ConfigurationSettings Settings { get; private set; }

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
                MessageBox.Show("Audio Switcher only supports Windows Vista and above", "Unsupported Operating System");
                return;
            }

            Application.ApplicationExit += Application_ApplicationExit;
            AppDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AudioSwitcher");

            if (!Directory.Exists(AppDataDirectory))
                Directory.CreateDirectory(AppDataDirectory);

            var settingsPath = Path.Combine(AppDataDirectory, Resources.ConfigFile);

            //Delete the old updater
            try
            {
                //v1.5 and less
                var updaterPath = Application.StartupPath + "AutoUpdater.exe";
                if (File.Exists(updaterPath))
                    File.Delete(updaterPath);

                //v1.6
                updaterPath = Path.Combine(Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName, "AutoUpdater.exe");
                if (File.Exists(updaterPath))
                    File.Delete(updaterPath);

                //v1.6.7
                updaterPath = Path.Combine(AppDataDirectory, "AutoUpdater.exe");
                if (File.Exists(updaterPath))
                    File.Delete(updaterPath);
            }
            catch
            {
                //This shouldn't prevent the application from running
            }

            try
            {
                var iniSettingsPath = Path.Combine(Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName, Resources.OldConfigFile);

                if (File.Exists(iniSettingsPath))
                    File.Delete(iniSettingsPath);
            }
            catch
            {
                // ignored
            }

            try
            {

                //old json settings
                var oldJsonSettingsPath = Path.Combine(Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName, Resources.ConfigFile);

                ISettingsSource jsonSource = new JsonSettings();
                jsonSource.SetFilePath(settingsPath);

                Settings = new ConfigurationSettings(jsonSource);

                if (File.Exists(oldJsonSettingsPath))
                {
                    try
                    {
                        //Load old settings
                        ISettingsSource oldSource = new JsonSettings();
                        oldSource.SetFilePath(oldJsonSettingsPath);

                        var oldSettings = new ConfigurationSettings(oldSource);
                        Settings.LoadFrom(oldSettings);
                    }
                    finally
                    {
                        File.Delete(oldJsonSettingsPath);
                    }
                }

                Settings.CreateDefaults();
            }
            catch
            {
                var errorMessage = String.Format("Error creating/reading settings file [{0}]. Make sure you have read/write access to this file.\r\nOr try running as Administrator",
                        settingsPath);
                MessageBox.Show(errorMessage, "Settings File - Cannot Access");
                return;
            }

            try
            {
                Application.Run(AudioSwitcher.Instance);
            }
            catch (Exception ex)
            {
                var title = "An Unexpected Error Occurred";

                var edf = new ExceptionDisplayForm(title, ex);
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
