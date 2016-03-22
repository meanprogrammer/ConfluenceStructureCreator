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
        static string createSpaceUrl = AppSettingsHelper.GetValue(Strings.CREATE_SPACEURL_KEY);
        static string createPageUrl = AppSettingsHelper.GetValue(Strings.CREATE_PAGE_URL_KEY);

        private List<ConfluencePage> structure;
        private IFormLogger logger;
        public ConfluencePageTreeTaskExecutor(List<ConfluencePage> structure, IFormLogger logger)
        {
            this.structure = structure;
            this.logger = logger;
        }

        public ConfluencePageTreeTaskExecutor() { }


        public void Execute(IFormLogger logger, string name, string key, string description, string parentKey)
        {
            

            logger.Log("Grabbing structure ...");
            var rootSpace = ExecuteNonCurl(createSpaceUrl, JsonConvert.SerializeObject(CreateSpaceInstance(name, key, description)));
            logger.Log("Created Root Space ...");
            foreach (ConfluencePage page in this.structure)
            {
                var rootPage = CreateChildPage(createPageUrl, JsonConvert.SerializeObject(CreateChildPageInstance(rootSpace.key, rootSpace.homepage.id, page.Title, page.Content)));
                logger.Log(string.Format("Created the root page : {0}", page.Title));
                foreach (ConfluencePage t in page.ChildPages)
                {
                    CreateChildPage(createPageUrl, JsonConvert.SerializeObject(CreateChildPageInstance(rootSpace.key, rootPage.id.ToString(), t.Title, t.Content)));
                    logger.Log(string.Format("Created the child page : {0}", t.Title));
                }
            }

            logger.Log("Updating parent Space.");

            var parentBusinessCase = GetPageByKeyAndTitle(parentKey, AppSettingsHelper.GetValue(Strings.PARENT_BUSINESS_CASE_TITLE_KEY));
            if (parentBusinessCase != null)
            {
                if (parentBusinessCase.results.Count() == 1)
                {
                    var r = parentBusinessCase.results.FirstOrDefault();
                    string html = r.body.storage.value;
                    html = html.Replace("\"", @"'");

                    int index = html.IndexOf("</ul>");

                    var childBusinessCase = GetPageByKeyAndTitle(rootSpace.key, AppSettingsHelper.GetValue(Strings.PARENT_BUSINESS_CASE_TITLE_KEY));
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
                    logger.Log("Cannot find the Business Case Parent Page.");
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

        public UpdatePageOutput UpdateParentPage(string pageId, UpdatePageInput param)
        {
            string url = string.Format(AppSettingsHelper.GetValue(Strings.UPDATEPAGE_URL_KEY), pageId);
            return HttpClientHelper.ExecutePut<UpdatePageOutput>(url, JsonConvert.SerializeObject(param), this.logger);
        }

        public PageByTitleAndKeyOutput GetPageByKeyAndTitle(string parentKey, string pageTitle)
        {
            string url = string.Format(AppSettingsHelper.GetValue(Strings.GET_PAGEBY_TITLE_KEY_URL), pageTitle, parentKey);
            return HttpClientHelper.ExecuteGet<PageByTitleAndKeyOutput>(url, this.logger);
        }

        private SpaceOutput ExecuteNonCurl(string url, string payload)
        {
            return HttpClientHelper.ExecutePost<SpaceOutput>(url, payload, this.logger);
        }

        public SpaceOutput CreateChildPage(string url, string payload)
        {
            return HttpClientHelper.ExecutePost<SpaceOutput>(url, payload, this.logger);
        }

        public ChildPageInput CreateChildPageInstance(string key, string rootId, string title, string value)
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