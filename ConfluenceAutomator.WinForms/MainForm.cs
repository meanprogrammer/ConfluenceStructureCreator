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
using ConfluenceAutomator.Library;
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

            FormIsWorking(false);


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
                    //Here is the destination
                    var toCopy = map.ToPageTitle;
                    var newContent = string.Format(AppSettingsHelper.GetValue(Strings.INCLUDE_PAGECONTENT_KEY), fromCopy.Text, mappings.FromSpace);

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
                                AppSettingsHelper.GetValue(Strings.CREATE_PAGE_URL_KEY), 
                                JsonConvert.SerializeObject(
                                    task.CreateChildPageInstance(
                                            mappings.FromSpace, funcPage.id, 
                                            string.Format("{0} - {1}",this.NameTextBox.Text.Trim(), bMap.FromPageTitle),
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

            FormIsWorking(true);
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            ChildDeleter deleter = new ChildDeleter(this);
            deleter.ExecuteDelete();
        }

    }
}
