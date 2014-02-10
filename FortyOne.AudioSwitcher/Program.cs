using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FortyOne.AudioSwitcher
{
    internal static class Program
    {
        [DllImport("User32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

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