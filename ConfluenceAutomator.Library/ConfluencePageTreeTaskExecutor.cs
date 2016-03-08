using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class ConfluencePageTreeTaskExecutor
    {
        static string credentials = string.Format("{0}:{1}", AppSettingsHelper.GetValue("username"), AppSettingsHelper.GetValue("password"));
        static string createSpaceUrl = AppSettingsHelper.GetValue("CreateSpaceUrl");
        static string createPageUrl = AppSettingsHelper.GetValue("CreatePageUrl");

        public void Execute(IFormLogger logger, string name, string key, string description)
        {
            var list = StructureConstant.GetStructure();
            logger.Log("Grabbing structure ...");
            var rootSpace = ExecuteNonCurl(createSpaceUrl, ConvertToJson(CreateSpaceInstance(name, key, description)));
            logger.Log("Created Root Space ...");
            foreach (KeyValuePair<string, List<string>> page in list)
            {
                var rootPage = CreateChildPage(createPageUrl, ConvertToJson(CreateChildPageInstance(rootSpace.key, rootSpace.homepage.id, page.Key)));
                logger.Log(string.Format("Created the root page : {0}", page.Key));
                foreach (string t in page.Value)
                {
                    CreateChildPage(createPageUrl, ConvertToJson(CreateChildPageInstance(rootSpace.key, rootPage.id.ToString(), t)));
                    logger.Log(string.Format("Created the child page : {0}", t));    
                }
            }

            
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

        private static ChildPage CreateChildPageInstance(string key, string rootId, string title)
        {
            ChildPage cp = new ChildPage();
            cp.ancestors = new List<ChildPageAncestor>();
            cp.ancestors.Add(new ChildPageAncestor() { id = int.Parse(rootId) });
            cp.title = title;
            cp.type = "page";
            cp.space = new ChildPageSpace() { key = key };
            cp.body = new ChildPageBody() { storage = new ChildPageStorage() { representation = "storage", value = "<p></p>" } };

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
