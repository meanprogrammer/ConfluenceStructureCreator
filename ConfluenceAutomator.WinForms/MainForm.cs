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
            
            ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor();
            List<Result> r = confSpaceService.Execute(this);
            this.ParentSpaceComboBox.ValueMember = "key";
            this.ParentSpaceComboBox.DisplayMember = "name";
            this.ParentSpaceComboBox.DataSource = r;

            ConfluenceBackgroundWorker.RunWorkerAsync();
            ParentSpaceComboBox_SelectedIndexChanged(sender, e);
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

            this.RunButton.Enabled = false;
            this.CancelButton.Enabled = false;

            ConfluencePageTreeTaskExecutor task = new ConfluencePageTreeTaskExecutor();

            ChildPagesOutput_Result bc = this.PipelineBCcomboBox.SelectedItem as ChildPagesOutput_Result;

            task.Execute(this, this.NameTextBox.Text, this.KeyTextbox.Text, this.DescriptionTextBox.Text, this.ParentSpaceComboBox.SelectedValue.ToString(), bc.title);
            this.RunButton.Enabled = true;
            this.CancelButton.Enabled = true;
        }

        public void Log(string message)
        {
            this.LogTextbox.AppendText(message + Environment.NewLine);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ParentSpaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var defaultSelected = this.ParentSpaceComboBox.SelectedItem as Result;
            if (defaultSelected != null)
            {
                PageByTitleAndKeyOutput page = ConfluencePageTreeTaskExecutor.GetPageByKeyAndTitle(defaultSelected.key, "PipelineBusinessCaseTitle");
                if (page != null && page.results.Count == 1)
                {
                    ConfluenceChildPagesTaskExecutor bcChildren = new ConfluenceChildPagesTaskExecutor();
                    List<ChildPagesOutput_Result> rs = bcChildren.Execute(this, page.results.FirstOrDefault().id);

                    if (rs.Count < 1)
                    {
                        return;
                    }
                    else
                    {
                        this.PipelineBCcomboBox.ValueMember = "id";
                        this.PipelineBCcomboBox.DisplayMember = "title";
                        this.PipelineBCcomboBox.DataSource = rs;
                    }
                }
            }
        }

        private void ConfluenceBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor();
            e.Result = confSpaceService.CreateSpaceTreeNode(confSpaceService.Execute(this).Where(x => x.key == "BPM").FirstOrDefault());
        }

        private void ConfluenceBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ConfluencetreeView.Nodes.Add(e.Result as TreeNode);
            //this.ConfluencetreeView.ExpandAll();
        }

        private void ConfluencetreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MessageBox.Show(e.Node.Checked.ToString());
        }
    }
}
