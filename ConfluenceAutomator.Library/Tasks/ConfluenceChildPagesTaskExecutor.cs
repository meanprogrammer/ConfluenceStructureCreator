using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class ConfluenceChildPagesTaskExecutor
    {
        private IFormLogger logger;

        public ConfluenceChildPagesTaskExecutor() { }

        public ConfluenceChildPagesTaskExecutor(IFormLogger logger)
        {
            this.logger = logger;
        }

        public ChildPagesOutput Execute(string id)
        {
            return HttpClientHelper.Execute<ChildPagesOutput>(string.Format(AppSettingsHelper.GetValue("GetChildPagesUrl"), id), this.logger);
        }
    }
}
