using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class ChildDeleter
    {
        const string PARENT_SPACE = "BPM";
        const string PARENT_TITLE = "1. Operations Analysis Phase";
        const string DELETE_URL = "http://ldconfluence01.asiandevbank.org:8090/rest/api/content/{0}";
        //const string DELETE_URL = "http://lpconfluence01.asiandevbank.org:8080/rest/api/content/{0}";

        private IFormLogger logger;

        public ChildDeleter(IFormLogger logger)
        {
            this.logger = logger;
        }

        public void ExecuteDelete()
        {
            ConfluencePageTreeTaskExecutor pageTask = new ConfluencePageTreeTaskExecutor();
            PageByTitleAndKeyOutput page = pageTask.GetPageByKeyAndTitle(PARENT_SPACE, PARENT_TITLE);


            ConfluenceChildPagesTaskExecutor childPagesTask = new ConfluenceChildPagesTaskExecutor();
            ChildPagesOutput children = childPagesTask.Execute(page.results.FirstOrDefault().id);

            foreach (var c in children.results)
            {
                ChildPagesOutput children2 = childPagesTask.Execute(c.id);
                foreach (var c2 in children2.results)
                {
                    HttpClientHelper.ExecuteDelete<string>(string.Format(DELETE_URL, c2.id), this.logger);
                }
            }
            logger.Log("Done Deleting.");
        }
    }
}
