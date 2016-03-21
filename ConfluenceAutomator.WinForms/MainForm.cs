using ConfluenceAutomator.Library;
using Newtonsoft.Json;
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
            
            ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor(this);
            AllSpaces r = confSpaceService.Execute();
            this.ParentSpaceComboBox.ValueMember = "key";
            this.ParentSpaceComboBox.DisplayMember = "name";
            this.ParentSpaceComboBox.DataSource = r.results;

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

            var list = StructureConstant.GetTaxonomy();

            /* START THE COPY PROCESS */

            PageTreeMapping mappings = MappingHelper.GetMapping(this.KeyTextbox.Text.Trim());

            foreach (PageTreeMappingItem map in mappings.Mappings)
            {
                //Find it on the tree
                TreeNode[] treeNodes = this.ConfluencetreeView.Nodes.Find(map.FromPageTitle, true);
                var found = treeNodes.FirstOrDefault();
                if (found != null && found.Checked)
                {
                    //Now we have the item to copy
                    var fromCopy = TreeNodeHelper.GetFirstCheckedChild(found.Nodes);
                    var s = fromCopy.Text;
                    //Here is the destination
                    var toCopy = map.ToPageTitle;

                    var newContent = string.Format(AppSettingsHelper.GetValue("includePageContent"), s, "BPM");

                    StructureHelper.AlterWithNewContent(list, toCopy, newContent);

                }
            }

            

            ConfluencePageTreeTaskExecutor task = new ConfluencePageTreeTaskExecutor(list, this);

            //ChildPagesOutput_Result bc = this.PipelineBCcomboBox.SelectedItem as ChildPagesOutput_Result;

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
                                AppSettingsHelper.GetValue("CreatePageUrl"), 
                                JsonConvert.SerializeObject(
                                    task.CreateChildPageInstance(
                                            mappings.FromSpace, funcPage.id, 
                                            string.Format("{0} - {1}",this.NameTextBox.Text.Trim(), bMap.FromPageTitle),
                                            string.Format(AppSettingsHelper.GetValue("includePageContent"), bMap.FromPageTitle, this.KeyTextbox.Text.Trim()
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
                ConfluencePageTreeTaskExecutor task = new ConfluencePageTreeTaskExecutor();
                PageByTitleAndKeyOutput page = task.GetPageByKeyAndTitle(defaultSelected.key, "PipelineBusinessCaseTitle");
                if (page != null && page.results.Count == 1)
                {
                    ConfluenceChildPagesTaskExecutor bcChildren = new ConfluenceChildPagesTaskExecutor();
                    List<ChildPagesOutput_Result> rs = bcChildren.Execute(page.results.FirstOrDefault().id).results;

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

        private void ConfluenceBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConfluenceSpaceTaskExecutor confSpaceService = new ConfluenceSpaceTaskExecutor(this);
            e.Result = confSpaceService.CreateSpaceTreeNode(confSpaceService.Execute().results.Where(x => x.key == e.Argument.ToString()).FirstOrDefault());
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

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            var nodes = this.ConfluencetreeView.Nodes;
            foreach (TreeNode tn in nodes)
            {
                if (tn.Checked == true)
                {
          
                }
            }
        }

        private void BuildMapping(TreeNodeCollection nodes, PageTreeItem item)
        {
            foreach (TreeNode tn in nodes)
            {
                if (tn.Checked == true)
                { 

                }
            }
        }

    }
}
