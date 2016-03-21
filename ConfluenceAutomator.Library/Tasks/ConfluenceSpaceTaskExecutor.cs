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

        static string credentials = string.Format("{0}:{1}", AppSettingsHelper.GetValue("username"), AppSettingsHelper.GetValue("password"));
        public AllSpaces Execute()
        {
            /*
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(AppSettingsHelper.GetValue("CreateSpaceUrl"));
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(string.Empty, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.GetAsync(client.BaseAddress).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            AllSpaces obj = JsonConvert.DeserializeObject<AllSpaces>(result);
            return obj.results;
            */
            return HttpClientHelper.Execute<AllSpaces>(AppSettingsHelper.GetValue("CreateSpaceUrl"), string.Empty, this.logger);
        }

        public TreeNode CreateSpaceTreeNode(Result space)
        {
            TreeNode result = new TreeNode(space.name);
            if (space == null)
                return result;

            string childUrl = AppSettingsHelper.GetValue("baseUrl") + space._expandable.homepage + "/child/page";
            var rootPages = HttpClientHelper.Execute<ChildPagesOutput>(childUrl, this.logger);
            CreateIndividualTreeNode(result, rootPages.results);

            return result;
        }

        private void CreateIndividualTreeNode(TreeNode currentTreeNode, List<ChildPagesOutput_Result> pages)
        {
            foreach (var item in pages)
            {
                string childUrl = AppSettingsHelper.GetValue("baseUrl") + string.Format("/rest/api/content/{0}/child/page", item.id);

                ChildPagesOutput childPages = HttpClientHelper.Execute<ChildPagesOutput>(childUrl, credentials, this.logger);

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

        private TreeNode CreateTreeNode(string text)
        {
            return new TreeNode(text);
        }


 
    }
}
