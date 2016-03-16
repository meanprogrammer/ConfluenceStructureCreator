using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        private List<ConfluencePage> AlterWithNewContent(List<ConfluencePage> list, string key, string newContent)
        {
            var result = list;
            foreach (ConfluencePage c in list)
            {
                if (c.Title == key)
                {
                    c.Content = newContent;
                    return list;
                }
                if (c.ChildPages.Count > 0)
                {
                    result = AlterWithNewContent(c.ChildPages, key, newContent);
                }
                else
                {
                    continue;
                }
            }
            return result;
        }


        public void Execute(IFormLogger logger, string name, string key, string description, string parentKey, string bcTitle)
        {
            var list = StructureConstant.GetTaxonomy();

            var newContent = string.Format(AppSettingsHelper.GetValue("includePageContent"), bcTitle, parentKey);

            AlterWithNewContent(list, AppSettingsHelper.GetValue("ProjectBusinessCaseTitle"), newContent);

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

            var parentBusinessCase = GetPageByKeyAndTitle(parentKey, "ParentBusinessCaseTitle");
            if (parentBusinessCase != null)
            {
                if (parentBusinessCase.results.Count() == 1)
                {
                    var r = parentBusinessCase.results.FirstOrDefault();
                    string html = r.body.storage.value;
                    html = html.Replace("\"", @"'");

                    int index = html.IndexOf("</ul>");

                    var childBusinessCase = GetPageByKeyAndTitle(rootSpace.key, "ProjectBusinessCaseTitle");
                    string newHtml = html.Insert(index, string.Format(@"<li><a href='{0}'>{1}</a></li>", ExtractLinkFromChildBusinessCase(childBusinessCase), rootSpace.name));

                    UpdatePageInput p = new UpdatePageInput();
                    p.id = r.id;
                    p.body.storage.value = newHtml;
                    p.space.key = parentKey;
                    p.title = r.title;
                    p.version.number = r.version.number + 1;
                    UpdateParentPage(p.id, p);
                    logger.Log("Done updating the project parent page.");



                    
                }
                else
                {
                    logger.Log("Cannot find the parent page.");
                }
            }
            else
            {
                logger.Log("Cannot find the parent page.");
            }
            logger.Log("Task Complete.");
        }

        private static string BuildUrl(SpaceOutput root)
        {
            return string.Format("{0}/display/{1}", root._links.@base, root.key);
        }

        private static string ExtractLinkFromChildBusinessCase(PageByTitleAndKeyOutput result)
        {
            string link = string.Empty;
            if (result != null && result.results.Count > 0)
            {
                var page = result.results.FirstOrDefault();
                link = page._links.webui;
            }
            return link;
        }

        private static void UpdateParentPage(string pageId, UpdatePageInput param)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(string.Format(AppSettingsHelper.GetValue("UpdatePageUrl"), pageId));
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(ConvertToJson(param), UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PutAsync(client.BaseAddress, content).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            //PageByTitleAndKeyResult obj = JsonConvert.DeserializeObject<PageByTitleAndKeyResult>(result);
        }

        public static PageByTitleAndKeyOutput GetPageByKeyAndTitle(string parentKey, string appSettingsKey)
        {
            var pageTitle = AppSettingsHelper.GetValue(appSettingsKey);

            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(string.Format(AppSettingsHelper.GetValue("GetPageByTitleAndKeyUrl"), pageTitle, parentKey));
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(string.Empty, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.GetAsync(client.BaseAddress).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            PageByTitleAndKeyOutput obj = JsonConvert.DeserializeObject<PageByTitleAndKeyOutput>(result);
            return obj;
        }

        private static SpaceOutput ExecuteNonCurl(string url, string payload)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(url);
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(payload, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync(url, content).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            SpaceOutput obj = JsonConvert.DeserializeObject<SpaceOutput>(result);
            return obj;
        }

        private static SpaceOutput CreateChildPage(string url, string payload)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(url);
            byte[] cred = UTF8Encoding.UTF8.GetBytes(credentials);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(payload, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.PostAsync(url, content).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            SpaceOutput obj = JsonConvert.DeserializeObject<SpaceOutput>(result);
            return obj;
        }

        private static ChildPageInput CreateChildPageInstance(string key, string rootId, string title, string value)
        {
            ChildPageInput cp = new ChildPageInput();
            cp.ancestors = new List<ChildPage_Ancestor>();
            cp.ancestors.Add(new ChildPage_Ancestor() { id = int.Parse(rootId) });
            cp.title = title;
            cp.type = "page";
            cp.space = new ChildPage_Space() { key = key };
            cp.body = new ChildPage_Body() { storage = new ChildPage_Storage() { representation = "storage", value = string.Format("<p>{0}</p>", value) } };

            return cp;
        }

        private static SpaceInput CreateSpaceInstance(string name, string key, string description)
        {
            SpaceInput sp = new SpaceInput();
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


/*
                    var pipelineBusinessCase = GetPageByKeyAndTitle(parentKey, "PipelineBusinessCaseTitle");

                    var pbc = pipelineBusinessCase.results.FirstOrDefault();
                    string pipelineHtml = pbc.body.storage.value;
                    pipelineHtml = pipelineHtml.Replace("\"", @"'");

                    int idx = pipelineHtml.IndexOf("</ul>");

                    newHtml = pipelineHtml.Insert(idx, string.Format(@"<li><a href='{0}'>{1}</a></li>", ExtractLinkFromChildBusinessCase(childBusinessCase), rootSpace.name));

                    UpdatePageInput p2 = new UpdatePageInput();
                    p2.id = pbc.id;
                    p2.body.storage.value = newHtml;
                    p2.space.key = parentKey;
                    p2.title = pbc.title;
                    p2.version.number = pbc.version.number + 1;
                    UpdateParentPage(p2.id, p2);
                    logger.Log("Done updating the pipeline parent page.");
                     * 
                    */