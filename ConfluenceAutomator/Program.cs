using Newtonsoft.Json;
using SeasideResearch.LibCurlNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator
{
    class Program
    {
        static void Main(string[] args)
        {
            string createSpaceUrl = "http://ldconfluence01.asiandevbank.org:8090/rest/api/space";
            string createPageUrl = "http://ldconfluence01.asiandevbank.org:8090/rest/api/content/";
            string createSpacePayload = "{ \"key\":\"RAID2\", \"name\":\"Raider\", \"type\":\"global\",  \"description\":{\"plain\": { \"value\": \"Raider Space for raiders\",\"representation\": \"plain\" }}}";

            var list = GetTree();

            var rootSpace = ExecuteNonCurl(createSpaceUrl, createSpacePayload);

            foreach (KeyValuePair<string, List<string>> page in list)
            {
                var rootPage = CreateChildPage(createPageUrl, ConvertToJson(CreateChildPageInstance(rootSpace.key, rootSpace.homepage.id, page.Key)));

                foreach (string t in page.Value)
                {
                    CreateChildPage(createPageUrl, ConvertToJson(CreateChildPageInstance(rootSpace.key, rootPage.id.ToString(), t)));
                }
            }

            Console.WriteLine("Done!");
            Console.ReadLine();


            //ChildPage cp = CreateChildPageInstance(rootSpace.key, rootSpace.homepage.id);

            
            //CreateChildPage(createPageUrl, createChildPagePayload);

            /*
            

            Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
            Execute(createSpacePayload, createSpaceUrl);
            Execute(JSON.Basic, createPageUrl);
            Curl.GlobalCleanup();
             * */
        }

        static void Execute(string payload, string url)
        {
            Easy easy = new Easy();
            string payload2 = JSON.payload2;
            easy.SetOpt(CURLoption.CURLOPT_URL, url);
            //easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
            easy.SetOpt(CURLoption.CURLOPT_USERPWD, "vd2:Welcome1");
            Slist s2 = new Slist();
            s2.Append("Content-Type: application/json");
            easy.SetOpt(CURLoption.CURLOPT_HTTPHEADER, s2);
            easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, payload2);

            SeasideResearch.LibCurlNet.Easy.WriteFunction wf = new Easy.WriteFunction(writeresult);
            easy.SetOpt(CURLoption.CURLOPT_WRITEDATA, wf);
            easy.Perform();
            easy.Dispose();
        }

        private static int writeresult(byte[] buf, int size, int nmemb, Object extraData)
        {
            foreach (byte b in buf)
                Console.Write((char)b);

            return buf.Length;
        }

        private static SpaceResult ExecuteNonCurl(string url, string payload)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(url);
            byte[] cred = UTF8Encoding.UTF8.GetBytes("vd2:Welcome1");
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
            byte[] cred = UTF8Encoding.UTF8.GetBytes("vd2:Welcome1");
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
            cp.ancestors.Add(new ChildPageAncestor(){  id=int.Parse(rootId) });
            cp.title = title;
            cp.type = "page";
            cp.space = new ChildPageSpace() { key = key };
            cp.body = new ChildPageBody() { storage = new ChildPageStorage() { representation = "storage", value = "<p>The page content goes here.</p>" } };

            return cp;
        }

        private static string ConvertToJson(ChildPage cp)
        {
            return JsonConvert.SerializeObject(cp);
        }

        private static Dictionary<string, List<string>> GetTree()
        {
            Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();
            list.Add("0. Planning Phase", new List<string>() { "0.01 Concept Paper", "0.02 Business Case", "0.03 High-level Process and Vision Design", "0.04 High Level Solutions Design", "0.05 SDLC Activities and Deliverables Checklist", "0.06 Process and Sub-process Documents", "0.07 Business Scenarios", "0.08 Solution Deployment Strategy" });
            list.Add("1 Operations Analysis Phase", new List<string>() { "1.01 Functional Requirements", "1,02 Non-Functional Requirements", "1.03 Mockup/Prototypes", "1.04 Detailed Use Case Specificatoins", "1.05 Information Models", "1.06 Security Profiles", "1.07 Gap Analysis", "1.08 Application and Infrastructure Design", "1.09 Project Master Test Plan", "1.10 Data Conversion Plan", "1.11 Business Change Management Strategy", "1.12 Needs Analysis", "1.13 High-level Solution Deployment Plan", "1.14 Transition and Maintenance Plan" }); ;
            list.Add("2. Solution Design Phase", new List<string>() { "2.01 Application Setup", "2.02 Application Extensions Functional Design", "2.03 Application Extensions Technilca Design - Database Design", "2.04 Detailed Prototype", "2.05 High Level Solution Design", "2.06 Unit Test Plan", "2.07 Unit Test Scripts", "2.08 SIT Plans", "2.09 SIT Scripts", "2.10 Security Test Plan", "2.11 Security Test Scripts", "2.12 Performance and Stress Test Plan", "2.13 Performance and Stress Test Scripts", "2.14 Regression Test Plan", "2.15 Business Change Management Strategy", "2.16 Needs Analysis", "2.18 Training Plan", "2.19 Training Manual", "2.20 Conversion Data Mapping", "2.21 High-level Solution Deployment Plan", "2.22 Transition and Maintenance Plan" });
            list.Add("3. Build Phase", new List<string>() { "3.01 Unit Test Report", "3.02 SIT Report", "3.03 Security Test Report", "3.04 Performance and Stress Test Report", "3.05 Regression Test Plan", "3.06 Solution Deployment Plan", "3.07 Conversion Program", "3.08 Conversion Test Report", "3.09 UAT Plan", "3.10 UAT Scripts", "3.11 Needs Analysis", "3.12 BCM Communication Plan", "3.13 Training Plan", "3.14 Training Manual", "3.15 Transition and Maintenance Plan" });
            list.Add("4. Transition Phase", new List<string>() { "4.01 UAT Report","4.02 Usability Test Report","4.03 Converted Data Validation Report","4.04 BCM Communication Plan","4.05 Training Plan","4.06 Training Manual","4.07 Solution Deployment Plan","4.08 Transition and Maintenance Procedures" });
            list.Add("5. Production Phase", new List<string>(){ "5.01 Business and Technical Directions Recommendations" });
            list.Add("6. Project Management ", new List<string>() { "6.01 Risk Register", "6.02 Issue Register", "6.03 Status Reports", "6.04 Change Requests", "6.05 Meeting Minutes", "6.06 Stakeholder Matrix", "6.07 Team Roster" });
            return list;
        }
    }
}





