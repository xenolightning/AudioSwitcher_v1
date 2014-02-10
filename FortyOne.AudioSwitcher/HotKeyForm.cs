using System;
using System.Windows.Forms;
using FortyOne.AudioSwitcher.HotKeyData;
using FortyOne.AudioSwitcher.SoundLibrary;

namespace FortyOne.AudioSwitcher
{
    public enum HotKeyFormMode
    {
        Normal,
        Edit
    }

    public partial class HotKeyForm : Form
    {
        private readonly HotKeyFormMode Mode = HotKeyFormMode.Normal;
        private readonly HotKey hotkey;
        private readonly HotKey linkedHotKey;
        private bool FirstFocus = true;
        private bool Recording;

        public HotKeyForm()
        {
            InitializeComponent();

            hotkey = new HotKey();

            cmbDevices.Items.Clear();
            foreach (AudioDevice ad in AudioDeviceManager.PlayBackDevices)
                cmbDevices.Items.Add(ad);

            foreach (AudioDevice ad in AudioDeviceManager.RecordingDevices)
                cmbDevices.Items.Add(ad);

            cmbDevices.DisplayMember = "FullName";
            cmbDevices.ValueMember = "ID";
        }

        public HotKeyForm(HotKey hk)
            : this()
        {
            linkedHotKey = hk;

            hotkey.DeviceID = hk.DeviceID;
            hotkey.Key = hk.Key;
            hotkey.Modifiers = hk.Modifiers;

            txtHotKey.Text = hk.HotKeyString;
            FirstFocus = false;

            Mode = HotKeyFormMode.Edit;

            btnAdd.Text = "Save";
        }

        private void HotKeyForm_Load(object sender, EventArgs e)
        {
            AudioSwitcher.Instance.DisableHotKeyFunction = true;

            foreach (object o in cmbDevices.Items)
            {
                if (((AudioDevice) o).ID == hotkey.DeviceID)
                {
                    cmbDevices.SelectedIndex = cmbDevices.Items.IndexOf(o);
                    break;
                }
            }

            cmbDevices.DisplayMember = "FullName";
            cmbDevices.ValueMember = "ID";
        }

        private void txtHotKey_Enter(object sender, EventArgs e)
        {
            if (FirstFocus)
            {
                txtHotKey.Text = "";
                FirstFocus = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Mode == HotKeyFormMode.Normal && HotKeyManager.DuplicateHotKey(hotkey))
                return;

            if (Mode == HotKeyFormMode.Edit)
                HotKeyManager.DeleteHotKey(linkedHotKey);

            //Add HK
            if (HotKeyManager.AddHotKey(hotkey))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                errorProvider1.SetError(txtHotKey, "Hot Key is already registered");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void txtHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Recording)
            {
                errorProvider1.Clear();
                txtHotKey.Text = "";
                Recording = true;
            }
        }

        private void txtHotKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (Recording)
            {
                hotkey.Key = e.KeyCode;
                hotkey.Modifiers = Modifiers.None;

                if (e.Control)
                    hotkey.Modifiers = hotkey.Modifiers | Modifiers.Control;

                if (e.Alt)
                    hotkey.Modifiers = hotkey.Modifiers | Modifiers.Alt;

                if (e.Shift)
                    hotkey.Modifiers = hotkey.Modifiers | Modifiers.Shift;

                if (e.Modifiers == Keys.LWin || e.Modifiers == Keys.RWin)
                    hotkey.Modifiers = hotkey.Modifiers | Modifiers.Win;

                txtHotKey.Text = hotkey.HotKeyString;

                Recording = false;

                if (Mode != HotKeyFormMode.Edit && HotKeyManager.DuplicateHotKey(hotkey))
                    errorProvider1.SetError(txtHotKey, "Duplicate Hot Key Detected");
            }
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            hotkey.DeviceID = ((AudioDevice) cmbDevices.SelectedItem).ID;
        }

        private void HotKeyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AudioSwitcher.Instance.DisableHotKeyFunction = false;
        }
    }
}