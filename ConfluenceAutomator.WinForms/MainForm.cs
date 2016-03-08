using ConfluenceAutomator.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfluenceAutomator.WinForms
{
    public partial class MainForm : Form, IFormLogger
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.NameTextBox.Text.Trim()))
            {
                MessageBox.Show("Name must be defined.", "Validation Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.KeyTextbox.Text.Trim()))
            {
                MessageBox.Show("Key must be defined.", "Validation Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConfluencePageTreeTaskExecutor task = new ConfluencePageTreeTaskExecutor();
            task.Execute(this, this.NameTextBox.Text, this.KeyTextbox.Text, this.DescriptionTextBox.Text);
        }

        public void Log(string message)
        {
            this.LogTextbox.AppendText(message + Environment.NewLine);
        }
    }
}
