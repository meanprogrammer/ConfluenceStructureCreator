using ConfluenceAutomator.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfluenceAutomator.WinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            bool valid = false;
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                valid = context.ValidateCredentials(this.UsernametextBox.Text.ToLower().Trim(), this.PasswordtextBox.Text.Trim());
                if (!valid)
                {
                    MessageBox.Show(Strings.INVALID_CREDENTIALS, Strings.LOGIN_ERROR, MessageBoxButtons.OK);
                }
                else
                {
                    ConfluenceContext.SaveCredentials(this.UsernametextBox.Text.ToLower().Trim(), this.PasswordtextBox.Text.Trim());
                    MainForm mf = new MainForm();
                    mf.Show(this);
                    this.Hide();
                }
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Strings.ARE_YOU_SURE_1, Strings.EXIT_CONFIRMATION, MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void PasswordtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Loginbutton_Click(sender, e);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

    }
}
