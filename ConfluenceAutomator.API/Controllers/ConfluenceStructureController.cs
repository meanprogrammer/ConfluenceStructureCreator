using ConfluenceAutomator.API.Models;
using ConfluenceAutomator.Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConfluenceAutomator.API.Controllers
{
    public class ConfluenceStructureController : ApiController, IFormLogger
    {
        // GET: api/ConfluenceStructure
        [HttpGet, Route("api/ConfluenceStructure")]
        public IHttpActionResult Get()
        {
            CreateParameter p = new CreateParameter();
            p.Title = "TST 101";
            p.Description = "The Description";
            p.ParentKey = "BPM";
            p.Key = "TS9";

            string json = JsonConvert.SerializeObject(p);


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
            return Ok("Success");
        }

        // GET: api/ConfluenceStructure/5
        [HttpGet, Route("api/ConfluenceStructure/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ConfluenceStructure
        [HttpPost]
        [Route("api/ConfluenceStructure/post")]
        public IHttpActionResult Post([FromBody]CreateParameter data)
        {
            ConfluenceContext.SaveCredentials("vd2", "Welcome2");

            var list = StructureConstant.GetTaxonomy();

            ConfluencePageTreeTaskExecutor task = new ConfluencePageTreeTaskExecutor(list, this);

            task.Execute(this, data.Title, data.Key, data.Description, data.ParentKey);

            PageTreeMapping mappings = MappingHelper.GetMapping(data.Key, true);

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
                                            string.Format("{0} - {1}", data.Title, bMap.FromPageTitle),
                                            string.Format(AppSettingsHelper.GetValue(Strings.INCLUDE_PAGECONTENT_KEY), bMap.FromPageTitle, data.Key
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
            return Ok("Success");
        }

        // PUT: api/ConfluenceStructure/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ConfluenceStructure/5
        public void Delete(int id)
        {
        }

        public void Log(string message)
        {
            
        }
    }
}
