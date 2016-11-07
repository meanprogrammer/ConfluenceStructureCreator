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
    public partial class CleanUpForm : Form, IFormLogger
    {
        const string PARENT_SPACE = "BPM";
        const string PARENT_TITLE = "1. Operations Analysis Phase";
        const string DELETE_URL = "http://ldconfluence01.asiandevbank.org:8090/rest/api/content/{0}";

        public CleanUpForm()
        {
            InitializeComponent();
        }

        private void CleanUpForm_Load(object sender, EventArgs e)
        {
            /*
            ConfluencePageTreeTaskExecutor pageTask = new ConfluencePageTreeTaskExecutor();
            PageByTitleAndKeyOutput page = pageTask.GetPageByKeyAndTitle(PARENT_SPACE, PARENT_TITLE);


            ConfluenceChildPagesTaskExecutor childPagesTask = new ConfluenceChildPagesTaskExecutor();
            ChildPagesOutput children = childPagesTask.Execute(page.results.FirstOrDefault().id);

            TreeNode mainNode = new TreeNode("Main Node");

            foreach (var c in children.results)
            {
                TreeNode parentNode = new TreeNode(c.title);
                ChildPagesOutput children2 = childPagesTask.Execute(c.id);
                foreach (var c2 in children2.results)
                {
                    TreeNode childNode = new TreeNode(c2.title);
                    HttpClientHelper.ExecuteDelete<string>(string.Format(DELETE_URL, c2.id), this);
                    parentNode.Nodes.Add(childNode);
                }

                mainNode.Nodes.Add(parentNode);
            }
            logger.Log("Done Deleting.");
            this.ConfluencetreeView.Nodes.Add(mainNode);
             */
        }

        public void Log(string message)
        {
            this.LogTextbox.AppendText(message + Environment.NewLine);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.KeyTextbox.Text))
            {
                MessageBox.Show("Key is required.", "Required.", MessageBoxButtons.OK);
                return;
            }
            ChildDeleter deleter = new ChildDeleter(this);
            deleter.ExecuteDelete(this.KeyTextbox.Text.Trim());
        }

        private void GetChecked(List<string> ids, TreeNodeCollection nodes)
        {
            foreach (TreeNode n in nodes)
            {
                GetChecked(ids, n);
            }
        }

        private void GetChecked(List<string> ids, TreeNode node)
        {
            if (node.Checked) 
            {
                ids.Add(node.Text);
            }

            GetChecked(ids, node.Nodes);
        }

        private void DeleteAllbutton_Click(object sender, EventArgs e)
        {
            ChildDeleter deleter = new ChildDeleter(this);
            deleter.ExecuteDelete();
        }
    }
}
