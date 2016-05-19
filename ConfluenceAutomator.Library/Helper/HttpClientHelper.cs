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
            return ConfluenceContext.GetFormattedCredential();
        }

        public static T ExecuteGet<T>(string url, IFormLogger logger)
        {
            return Execute<T>(url, string.Empty, string.Empty, WebMethod.GET, logger);
        }

        public static T ExecuteGet<T>(string url, string payload, string credential, IFormLogger logger)
        {
            return Execute<T>(url, payload, credential, WebMethod.GET, logger);
        }

        public static T ExecutePost<T>(string url, string payload, IFormLogger logger)
        {
            return Execute<T>(url, payload, string.Empty, WebMethod.POST, logger);
        }

        public static T ExecutePut<T>(string url, string payload, IFormLogger logger)
        {
            return Execute<T>(url, payload, string.Empty, WebMethod.PUT, logger);
        }

        public static T ExecuteDelete<T>(string url, IFormLogger logger)
        {
            return Execute<T>(url, string.Empty, string.Empty, WebMethod.DELETE, logger);
        }

        private static T Execute<T>(string url, string payload, string credential, WebMethod method, IFormLogger logger)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(url);

            //Null check passed credential
            if (string.IsNullOrEmpty(credential))
            {
                credential = GetFormattedCredentials();
            }

            byte[] cred = UTF8Encoding.UTF8.GetBytes(credential);

            //this is default
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Strings.BASIC, Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(Strings.APPLICATION_JSON));

            System.Net.Http.HttpContent content;
            HttpResponseMessage message;
            string result = string.Empty;
            switch (method)
            {
                case WebMethod.POST:
                    content = CreateStringContent(payload);
                    message = client.PostAsync(url, content).Result;
                    result = message.Content.ReadAsStringAsync().Result;
                    break;
                case WebMethod.GET:
                    content = CreateStringContent(string.Empty);
                    message = client.GetAsync(client.BaseAddress).Result;
                    result = message.Content.ReadAsStringAsync().Result;
                    break;
                case WebMethod.PUT:
                    content = CreateStringContent(payload);
                    message = client.PutAsync(client.BaseAddress, content).Result;
                    result = message.Content.ReadAsStringAsync().Result;
                    break;
                case WebMethod.DELETE:
                    message = client.DeleteAsync(client.BaseAddress).Result;
                    result = message.Content.ReadAsStringAsync().Result;
                    break;
                default:
                    content = CreateStringContent(string.Empty);
                    message = client.GetAsync(client.BaseAddress).Result;
                    result = message.Content.ReadAsStringAsync().Result;
                    break;
            }

            if (!message.IsSuccessStatusCode)
            {
                logger.Log(string.Format("Error Occured : {0}", message.ReasonPhrase));
                logger.Log(string.Format("Error Request Uri : {0}", message.RequestMessage.RequestUri.AbsoluteUri));
                return default(T);
            }

            T obj = JsonConvert.DeserializeObject<T>(result);
            return obj;
        }

        private static StringContent CreateStringContent(string param)
        {
            return new StringContent(param, UTF8Encoding.UTF8, Strings.APPLICATION_JSON);
        }
    }
}
