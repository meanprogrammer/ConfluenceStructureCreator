using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfluenceAutomator.Library
{
    public class ConfluencePageTreeTaskExecutor
    {
        static string credentials = string.Format("{0}:{1}", AppSettingsHelper.GetValue("username"), AppSettingsHelper.GetValue("password"));
        static string createSpaceUrl = AppSettingsHelper.GetValue("CreateSpaceUrl");
        static string createPageUrl = AppSettingsHelper.GetValue("CreatePageUrl");

        public void Execute(IFormLogger logger, string name, string key, string description, string parentKey)
        {
            var list = StructureConstant.GetTaxonomy();
            logger.Log("Grabbing structure ...");
            var rootSpace = ExecuteNonCurl(createSpaceUrl, ConvertToJson(CreateSpaceInstance(name, key, description)));
            logger.Log("Created Root Space ...");
            foreach (ConfluencePage page in list)
            {
                var rootPage = CreateChildPage(createPageUrl, ConvertToJson(CreateChildPageInstance(rootSpace.key, rootSpace.homepage.id, page.Title, page.Content)));
                logger.Log(string.Format("Created the root page : {0}", page.Title));
                foreach (ConfluencePage t in page.ChildPages)
                {
                    CreateChildPage(createPageUrl, ConvertToJson(CreateChildPageInstance(rootSpace.key, rootPage.id.ToString(), t.Title, t.Content)));
                    logger.Log(string.Format("Created the child page : {0}", t.Title));
                }
            }

            logger.Log("Updating parent Space.");

            var parentPage = GetPageByKeyAndTitle(parentKey);
            if (parentPage != null)
            {
                if (parentPage.results.Count() == 1)
                {
                    var r = parentPage.results.FirstOrDefault();
                    string html = r.body.storage.value;
                    int index = html.IndexOf("</ul>");
                    string newHtml  = html.Insert(index - 1, "<li><a href=\"http://google.com\">Sample Only</></li>");
                    Console.Write(newHtml);

                    UpdatePageInput p = new UpdatePageInput();
                    p.id = r.id;
                    p.body.storage.value = newHtml;
                    UpdateParentPage(r.id, p);
                }
            }
            logger.Log("Task Complete.");
        }

        private static void UpdateParentPage(string pageId, UpdatePageInput param)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(string.Format("http://localhost:8080/confluence/rest/api/content/{0}", pageId));
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string p = JsonConvert.SerializeObject(param);

            System.Net.Http.HttpContent content = new StringContent(p, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync(client.BaseAddress, content).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            //PageByTitleAndKeyResult obj = JsonConvert.DeserializeObject<PageByTitleAndKeyResult>(result);
        }

        private static PageByTitleAndKeyResult GetPageByKeyAndTitle(string parentKey)
        {
            var pageTitle = AppSettingsHelper.GetValue("BusinessCaseTitle");

            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(string.Format(AppSettingsHelper.GetValue("GetPageByTitleAndKeyUrl"), pageTitle, parentKey));
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(string.Empty, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.GetAsync(client.BaseAddress).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            PageByTitleAndKeyResult obj = JsonConvert.DeserializeObject<PageByTitleAndKeyResult>(result);
            return obj;
        }

        private static SpaceResult ExecuteNonCurl(string url, string payload)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(url);
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(payload, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync(url, content).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            SpaceResult obj = JsonConvert.DeserializeObject<SpaceResult>(result);
            return obj;
        }

        private static SpaceResult CreateChildPage(string url, string payload)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(url);
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(payload, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync(url, content).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            SpaceResult obj = JsonConvert.DeserializeObject<SpaceResult>(result);
            return obj;
        }

        private static ChildPage CreateChildPageInstance(string key, string rootId, string title, string value)
        {
            ChildPage cp = new ChildPage();
            cp.ancestors = new List<ChildPageAncestor>();
            cp.ancestors.Add(new ChildPageAncestor() { id = int.Parse(rootId) });
            cp.title = title;
            cp.type = "page";
            cp.space = new ChildPageSpace() { key = key };
            cp.body = new ChildPageBody() { storage = new ChildPageStorage() { representation = "storage", value = string.Format("<p>{0}</p>", value) } };

            return cp;
        }

        private static Space CreateSpaceInstance(string name, string key, string description)
        {
            Space sp = new Space();
            sp.name = name;
            sp.key = key;
            sp.description.plain.value = description;

            return sp;
        }

        private static string ConvertToJson(object cp)
        {
            return JsonConvert.SerializeObject(cp);
        }
    }
}
