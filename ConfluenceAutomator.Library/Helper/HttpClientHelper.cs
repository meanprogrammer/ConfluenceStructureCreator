﻿using Newtonsoft.Json;
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

        public static T ExecuteGet<T>(string url, IFormLogger logger)
        {
            return Execute<T>(url, string.Empty, string.Empty, WebMethod.GET, logger);
        }

        public static T ExecutePost<T>(string url, string payload, IFormLogger logger)
        {
            return Execute<T>(url, payload, string.Empty, WebMethod.POST, logger);
        }

        public static T ExecutePut<T>(string url, string payload, IFormLogger logger)
        {
            return Execute<T>(url, payload, string.Empty, WebMethod.PUT, logger);
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
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content;
            HttpResponseMessage message;
            string result = string.Empty;
            switch (method)
            {
                case WebMethod.POST:
                    content = new StringContent(payload, UTF8Encoding.UTF8, "application/json");
                    message = client.PostAsync(url, content).Result;
                    result = message.Content.ReadAsStringAsync().Result;
                    break;
                case WebMethod.GET:
                    content = new StringContent(string.Empty, UTF8Encoding.UTF8, "application/json");
                    message = client.GetAsync(client.BaseAddress).Result;
                    result = message.Content.ReadAsStringAsync().Result;
                    break;
                case WebMethod.PUT:
                    content = new StringContent(payload, UTF8Encoding.UTF8, "application/json");
                    message = client.PutAsync(client.BaseAddress, content).Result;
                    result = message.Content.ReadAsStringAsync().Result;
                    break;
                default:
                    content = new StringContent(string.Empty, UTF8Encoding.UTF8, "application/json");
                    message = client.GetAsync(client.BaseAddress).Result;
                    result = message.Content.ReadAsStringAsync().Result;
                    break;
            }
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
