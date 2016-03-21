using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConfluenceAutomator.Library
{
    public class HttpClientHelper
    {
        private static string GetFormattedCredentials()
        {
            return string.Format("{0}:{1}", AppSettingsHelper.GetValue("username"), AppSettingsHelper.GetValue("password"));
        }

        public static T Execute<T>(string url, string credentials, IFormLogger logger)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(url);
            byte[] cred = UTF8Encoding.UTF8.GetBytes(GetFormattedCredentials());
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(string.Empty, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.GetAsync(client.BaseAddress).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            T obj = JsonConvert.DeserializeObject<T>(result);
            return obj;
        }

        public static T Execute<T>(string url, IFormLogger logger)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(url);
            byte[] cred = UTF8Encoding.UTF8.GetBytes(GetFormattedCredentials());
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent(string.Empty, UTF8Encoding.UTF8, "application/json");
            HttpResponseMessage messge = client.GetAsync(client.BaseAddress).Result;
            string result = messge.Content.ReadAsStringAsync().Result;
            T obj = JsonConvert.DeserializeObject<T>(result);
            return obj;
        }
    }
}
