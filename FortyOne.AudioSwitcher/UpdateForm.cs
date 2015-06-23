using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using FortyOne.AudioSwitcher.AudioSwitcherService;
using FortyOne.AudioSwitcher.Helpers;
using FortyOne.AudioSwitcher.Properties;

namespace FortyOne.AudioSwitcher
{
    public partial class UpdateForm : Form
    {
        private readonly string changelog = "";
        private readonly string url = "";

        public UpdateForm()
        {
            InitializeComponent();
            using (var client = ConnectionHelper.GetAudioSwitcherProxy())
            {
                if (client == null)
                    return;

                url = client.CheckForUpdate(AudioSwitcher.Instance.AssemblyVersion);
            }
        }

        public UpdateForm(AudioSwitcherVersionInfo vi)
        {
            InitializeComponent();
            url = vi.URL;
            changelog = vi.ChangeLog;
            toolTip1.SetToolTip(linkLabel1, url);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdateNow_Click(object sender, EventArgs e)
        {
            try
            {
                var updaterPath = Path.Combine(Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName,
                    "AutoUpdater.exe");
                if (!File.Exists(updaterPath))
                    File.WriteAllBytes(updaterPath, Resources.AutoUpdater);

                Process.Start(updaterPath,
                    Process.GetCurrentProcess().Id + " \"" + Assembly.GetEntryAssembly().Location + "\"");
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("Cannot Update Automatically.\r\nPlease manually download update.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var clf = new ChangeLogForm(changelog.Replace("\n", Environment.NewLine));
            clf.ShowDialog(this);
        }
    }
}