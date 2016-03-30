using ConfluenceAutomator.Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConfluenceAutomator.WebClient
{
    public partial class index : System.Web.UI.Page, IFormLogger
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            ConfluenceContext.SaveCredentials("vd2", "Welcome2");

            var list = StructureConstant.GetTaxonomy();

            ConfluencePageTreeTaskExecutor task = new ConfluencePageTreeTaskExecutor(list, this);

            task.Execute(this, "TST 101", "TS9", "Desc", "BPM");
            
            PageTreeMapping mappings = MappingHelper.GetMapping("TS9", true);

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
                                            string.Format("{0} - {1}", "TST 101", bMap.FromPageTitle),
                                            string.Format(AppSettingsHelper.GetValue(Strings.INCLUDE_PAGECONTENT_KEY), bMap.FromPageTitle, "TS9"
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
            */
        }

        public void Log(string message)
        {
            
        }
    }
}