using ConfluenceAutomator.Library;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            
            ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor(this);
            AllSpaces r = confSpaceService.Execute();
            this.ParentSpaceComboBox.ValueMember = Strings.KEY;
            this.ParentSpaceComboBox.DisplayMember = Strings.NAME;
            this.ParentSpaceComboBox.DataSource = r.results;

            ParentSpaceComboBox_SelectedIndexChanged(sender, e);

            this.TargetSpaceTreeView.Nodes.Add(StructureConstant.GetStructureAsTreeNode());
            this.TargetSpaceTreeView.ExpandAll();
            this.TargetSpaceTreeView.Nodes[0].EnsureVisible();
        }

        public static string LogAllCheckedNodes(TreeNode treeNode)
        {
            StringBuilder builder = new StringBuilder();
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Checked)
                {
                    builder.AppendFormat("{0}{1}", tn.Text, Environment.NewLine);
                }

                foreach (TreeNode tn2 in tn.Nodes)
                {
                    if (tn2.Checked)
                    {
                        builder.AppendFormat("{0}{1}{2}", "\t", tn2.Text, Environment.NewLine);
                    }

                    foreach (TreeNode tn3 in tn2.Nodes)
                    {
                        if (tn3.Checked)
                        {
                            builder.AppendFormat("{0}{1}{2}", "\t\t", tn3.Text, Environment.NewLine);
                        }
                    }

                }
            }
            return builder.ToString();
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

            ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor(this);
            AllSpaces r = confSpaceService.Execute();

            if (r.results.Where(c => c.key == this.KeyTextbox.Text.Trim()).FirstOrDefault() != null)
            {
                MessageBox.Show("Key is already used. Please try another.", "Validation Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            FormIsWorking(false);

            Logger.Write(LogAllCheckedNodes(this.ConfluencetreeView.Nodes[0]), "General");


            var list = StructureConstant.GetTaxonomy(false);

            var updatedList = StructureConstant.ExtractFromTreeView(this.TargetSpaceTreeView.Nodes[0]);

            foreach (ConfluencePage item in updatedList)
            {
                UpdateContent(item);
                foreach (var cp in item.ChildPages)
                {
                    UpdateContent(cp);
                }
            }

            /* START THE COPY PROCESS */

            PageTreeMapping mappings = MappingHelper.GetMapping(this.KeyTextbox.Text.Trim(), false);


            /* LINKING BPM TO THE CREATED SPACE */
            foreach (PageTreeMappingItem map in mappings.Mappings)
            {
                //Find it on the tree
                TreeNode[] treeNodes = this.ConfluencetreeView.Nodes.Find(map.FromPageTitle, true);
                var found = treeNodes.FirstOrDefault();
                if (found != null && found.Checked)
                {
                    //Now we have the item to copy
                    var fromCopy = TreeNodeHelper.GetFirstCheckedChild(found.Nodes);
                    //Here is the destination
                    var toCopy = map.ToPageTitle;
                    var newContent = string.Format(AppSettingsHelper.GetValue(Strings.INCLUDE_PAGECONTENT_KEY), fromCopy.Text, mappings.FromSpace);

                    StructureHelper.AlterWithNewContent(updatedList, toCopy, newContent);

                }
            }

            

            ConfluencePageTreeTaskExecutor task = new ConfluencePageTreeTaskExecutor(updatedList, this);

            task.Execute(this, this.NameTextBox.Text, this.KeyTextbox.Text, this.DescriptionTextBox.Text, this.ParentSpaceComboBox.SelectedValue.ToString());


            foreach (BackwardPageTreeMapping bMap in mappings.BackwardMappings)
            {
                var parentReq = task.GetPageByKeyAndTitle(mappings.FromSpace, bMap.ToPageTitle);
                if (parentReq != null)
                {
                    if (parentReq.results.Count == 1)
                    {
                        var funcPage = parentReq.results.FirstOrDefault();
                        if (funcPage != null)
                        {
                            task.CreateChildPage(
                                AppSettingsHelper.GetValue(Strings.CREATE_PAGE_URL_KEY), 
                                JsonConvert.SerializeObject(
                                    task.CreateChildPageInstance(
                                            mappings.FromSpace, funcPage.id, 
                                            string.Format("{0} - {1}",this.KeyTextbox.Text.Trim(), bMap.FromPageTitle),
                                            string.Format(AppSettingsHelper.GetValue(Strings.INCLUDE_PAGECONTENT_KEY), bMap.FromPageTitle, this.KeyTextbox.Text.Trim()
                                    )
                                )));
                        }
                    }
                    else
                    {
                        this.Log("Cannot find Functional Requirement Parent Page.");
                    }
                }
            }

            FormIsWorking(true);
        }

        private void UpdateContent(ConfluencePage item)
        {
            StringBuilder content = new StringBuilder();
            if (item.HasAttachmentWidget)
            {
                content.Append(ConstantContent.FILE_LIST_MARKUP);
                content.Append("<br/>");
            }

            if (item.HasContributorSummaryWidget)
            {
                content.Append(ConstantContent.CONTRIBUTOR_MARKUP);
            }
            item.Content = content.ToString();
        }


        public void Log(string message)
        {
            this.LogTextbox.AppendText(message + Environment.NewLine);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Strings.ARE_YOU_SURE_1, Strings.EXIT_CONFIRMATION, MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ParentSpaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormIsWorking(false);

            this.ConfluencetreeView.Nodes.Clear();
            if (!ConfluenceBackgroundWorker.IsBusy)
            {
                string key = string.Empty;
                var selectedItem = this.ParentSpaceComboBox.SelectedItem as Result;
                if(selectedItem != null)
                {
                    key = selectedItem.key;
                }
                ConfluenceBackgroundWorker.RunWorkerAsync(key);
            }
        }

        private void FormIsWorking(bool enabled)
        {
            this.ParentSpaceComboBox.Enabled = enabled;
            this.RunButton.Enabled = enabled;
            this.CancelButton.Enabled = enabled;
            this.CleanUpButton.Enabled = enabled;

            string status = string.Empty;
            status = ((enabled == false) ? "Work in progress." : "Work Complete.");
            this.Log(status);
        }

        private void ClearLog()
        {
            this.LogTextbox.Clear();
        }

        private void ConfluenceBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor(this);
            e.Result = confSpaceService.CreateSpaceTreeNode(confSpaceService.Execute().results.Where(x => x.key == e.Argument.ToString()).FirstOrDefault());
        }

        private void ConfluenceBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ConfluencetreeView.Nodes.Add(e.Result as TreeNode);
            this.ConfluencetreeView.ExpandAll();
            this.ConfluencetreeView.Nodes[0].EnsureVisible();
            FormIsWorking(true);
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            FormIsWorking(false);
            //ChildDeleter deleter = new ChildDeleter(this);
            //deleter.ExecuteDelete();

            CleanUpForm f = new CleanUpForm();
            f.Show();

            FormIsWorking(true);
        }

        private void ColapseExpandButton_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "<<")
            {
                this.Width = this.Width - 460;
                ((Button)sender).Text = ">>";
            }
            else
            {
                this.Width = this.Width + 460;
                ((Button)sender).Text = "<<";
            }
        }

        private void TargetSpaceTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ConfluencePage cp = e.Node.Tag as ConfluencePage;
            if (cp != null)
            {
                this.HasAttachmentcheckBox.Enabled = true;
                this.HasContributorcheckBox.Enabled = true;
                this.HasContributorcheckBox.Checked = cp.HasContributorSummaryWidget;
                this.HasAttachmentcheckBox.Checked = cp.HasAttachmentWidget;
            }
            else
            {
                this.HasAttachmentcheckBox.Enabled = false;
                this.HasContributorcheckBox.Enabled = false;
            }
        }

        private void HasAttachmentcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var selectedNode = this.TargetSpaceTreeView.SelectedNode;
            if (selectedNode != null)
            {
                ConfluencePage cp = selectedNode.Tag as ConfluencePage;
                if (cp != null)
                {
                    ((ConfluencePage)selectedNode.Tag).HasAttachmentWidget = ((CheckBox)sender).Checked;
                }
            }
            else
            {
                this.HasAttachmentcheckBox.Checked = false;
            }
        }

        private void HasContributorcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var selectedNode = this.TargetSpaceTreeView.SelectedNode;
            if (selectedNode != null)
            {
                ConfluencePage cp = selectedNode.Tag as ConfluencePage;
                if (cp != null)
                {
                    ((ConfluencePage)selectedNode.Tag).HasContributorSummaryWidget = ((CheckBox)sender).Checked;
                }
            }
            else
            {
                this.HasContributorcheckBox.Checked = false;
            }
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TargetSpaceHelper.GetStructureFromXml();
        }
    }
}
