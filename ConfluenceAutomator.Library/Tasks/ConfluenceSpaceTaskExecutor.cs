using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfluenceAutomator.Library
{
    public class ConfluenceSpaceTaskExecutor
    {
        private IFormLogger logger;


        public ConfluenceSpaceTaskExecutor()
        { 

        }

        public ConfluenceSpaceTaskExecutor(IFormLogger logger)
        {
            this.logger = logger;
        }

        static string credentials = string.Format("{0}:{1}", 
                AppSettingsHelper.GetValue(Strings.USERNAME_KEY), 
                AppSettingsHelper.GetValue(Strings.PASSWORD_KEY));

        public AllSpaces Execute()
        {
            return HttpClientHelper.ExecuteGet<AllSpaces>(AppSettingsHelper.GetValue(Strings.CREATE_SPACEURL_KEY), this.logger);
        }

        public AllSpaces ExecuteWeb(string payload, string credentials)
        {
            return HttpClientHelper.ExecuteGet<AllSpaces>(AppSettingsHelper.GetValue(Strings.CREATE_SPACEURL_KEY), payload, credentials, this.logger);
        }

        public TreeNode CreateSpaceTreeNode(Result space)
        {
            TreeNode result = new TreeNode(space.name);
            if (space == null)
                return result;

            string childUrl = AppSettingsHelper.GetValue(Strings.BASEURL_KEY) + space._expandable.homepage + Strings.CHILDPAGE_PATH;
            var rootPages = HttpClientHelper.ExecuteGet<ChildPagesOutput>(childUrl, this.logger);
            CreateIndividualTreeNode(result, rootPages.results);

            return result;
        }

        public System.Web.UI.WebControls.TreeNode CreateSpaceTreeNodeWeb(Result space)
        {
            System.Web.UI.WebControls.TreeNode result = new System.Web.UI.WebControls.TreeNode(space.name);
            if (space == null)
                return result;

            string childUrl = AppSettingsHelper.GetValue(Strings.BASEURL_KEY) + space._expandable.homepage + Strings.CHILDPAGE_PATH;
            var rootPages = HttpClientHelper.ExecuteGet<ChildPagesOutput>(childUrl, string.Empty, "vd2:Welcome4", this.logger);
            CreateIndividualTreeNodeWeb(result, rootPages.results);

            return result;
        }

        private void CreateIndividualTreeNode(TreeNode currentTreeNode, List<ChildPagesOutput_Result> pages)
        {
            foreach (var item in pages)
            {
                string childUrl = AppSettingsHelper.GetValue(Strings.BASEURL_KEY) + string.Format("/rest/api/content/{0}/child/page", item.id);

                ChildPagesOutput childPages = HttpClientHelper.ExecuteGet<ChildPagesOutput>(childUrl, this.logger);

                TreeNode newNode = new TreeNode();
                newNode.Text = item.title;
                newNode.Name = item.title;
                newNode.Tag = item;

                currentTreeNode.Nodes.Add(newNode);

                if (childPages.results.Count > 0)
                {
                    CreateIndividualTreeNode(currentTreeNode.LastNode, childPages.results);
                }
                else
                {
                    CreateIndividualTreeNode(currentTreeNode, childPages.results);
                }
            }
        }

        private void CreateIndividualTreeNodeWeb(System.Web.UI.WebControls.TreeNode currentTreeNode, List<ChildPagesOutput_Result> pages)
        {
            foreach (var item in pages)
            {
                string childUrl = AppSettingsHelper.GetValue(Strings.BASEURL_KEY) + string.Format("/rest/api/content/{0}/child/page", item.id);

                ChildPagesOutput childPages = HttpClientHelper.ExecuteGet<ChildPagesOutput>(childUrl, string.Empty, "vd2:Welcome2", this.logger);

                System.Web.UI.WebControls.TreeNode newNode = new System.Web.UI.WebControls.TreeNode();
                newNode.Text = item.title;
                newNode.Value = JsonConvert.SerializeObject(item);

                currentTreeNode.ChildNodes.Add(newNode);

                if (childPages.results.Count > 0)
                {
                    CreateIndividualTreeNodeWeb(currentTreeNode.ChildNodes[currentTreeNode.ChildNodes.Count -1], childPages.results);
                }
                else
                {
                    CreateIndividualTreeNodeWeb(currentTreeNode, childPages.results);
                }
            }
        }

        private System.Web.UI.WebControls.TreeNode GetLastNode(System.Web.UI.WebControls.TreeNode currentTreeNode)
        {
            return null;
        }
    }
}
