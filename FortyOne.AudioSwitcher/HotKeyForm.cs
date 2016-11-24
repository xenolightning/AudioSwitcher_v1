using System;
using System.Windows.Forms;
using AudioSwitcher.AudioApi;
using FortyOne.AudioSwitcher.HotKeyData;

namespace FortyOne.AudioSwitcher
{
    public enum HotKeyFormMode
    {
        Normal,
        Edit
    }

    public partial class HotKeyForm : Form
    {
        private readonly HotKey _hotkey;
        private readonly HotKey _linkedHotKey;
        private readonly HotKeyFormMode _mode = HotKeyFormMode.Normal;
        private bool _firstFocus = true;

        public HotKeyForm()
        {
            InitializeComponent();

            _hotkey = new HotKey();

            cmbDevices.Items.Clear();
            foreach (var ad in AudioDeviceManager.Controller.GetPlaybackDevices())
                cmbDevices.Items.Add(ad);

            foreach (var ad in AudioDeviceManager.Controller.GetCaptureDevices())
                cmbDevices.Items.Add(ad);

            cmbDevices.DisplayMember = "FullName";
            cmbDevices.ValueMember = "ID";
        }

        public HotKeyForm(HotKey hk)
            : this()
        {
            _linkedHotKey = hk;

            _hotkey.DeviceId = hk.DeviceId;
            _hotkey.Key = hk.Key;
            _hotkey.Modifiers = hk.Modifiers;

            txtHotKey.Text = hk.HotKeyString;
            _firstFocus = false;

            _mode = HotKeyFormMode.Edit;

            Text = "Edit Hot Key";
            btnAdd.Text = "Save";
        }

        private void HotKeyForm_Load(object sender, EventArgs e)
        {
            AudioSwitcher.Instance.DisableHotKeyFunction = true;

            foreach (var o in cmbDevices.Items)
            {
                if (((IDevice)o).Id == _hotkey.DeviceId)
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
            if (_firstFocus)
            {
                txtHotKey.Text = "";
                _firstFocus = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_mode == HotKeyFormMode.Normal && HotKeyManager.DuplicateHotKey(_hotkey))
                return;

            if (_mode == HotKeyFormMode.Edit)
                HotKeyManager.DeleteHotKey(_linkedHotKey);

            //Add HK
            if (HotKeyManager.AddHotKey(_hotkey))
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


        private void txtHotKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.Menu)
                return;

            _hotkey.Key = e.KeyCode;
            _hotkey.Modifiers = Modifiers.None;

            if (e.Control)
                _hotkey.Modifiers = _hotkey.Modifiers | Modifiers.Control;

            if (e.Alt)
                _hotkey.Modifiers = _hotkey.Modifiers | Modifiers.Alt;

            if (e.Shift)
                _hotkey.Modifiers = _hotkey.Modifiers | Modifiers.Shift;

            if (e.Modifiers == Keys.LWin || e.Modifiers == Keys.RWin)
                _hotkey.Modifiers = _hotkey.Modifiers | Modifiers.Win;

            txtHotKey.Text = _hotkey.HotKeyString;

            if (_mode != HotKeyFormMode.Edit && HotKeyManager.DuplicateHotKey(_hotkey))
                errorProvider1.SetError(txtHotKey, "Duplicate Hot Key Detected");
        }

        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDevices.SelectedItem == null)
                return;

            _hotkey.DeviceId = ((IDevice)cmbDevices.SelectedItem).Id;
        }

        private void HotKeyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AudioSwitcher.Instance.DisableHotKeyFunction = false;
        }

    }
}