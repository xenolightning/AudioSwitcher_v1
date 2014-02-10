using System;
using System.Windows.Forms;

namespace FortyOne.AudioSwitcher
{
    public partial class ChangeLogForm : Form
    {
        private ChangeLogForm()
        {
            InitializeComponent();
        }

        public ChangeLogForm(string text)
        {
            InitializeComponent();
            txtLog.Text = text;
        }

        private void ChangeLogForm_Load(object sender, EventArgs e)
        {
            label1.Focus();
        }
    }
}