using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Core.Base
{
    public static class ApiConnector
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<object> CallServiceAsync<T>(string url, object requestBodyObject, string method) where T : class
        {
            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            webReq.Method = method;
            webReq.Accept = "application/json";

            ////Add key to header if operation is supplied
            //if (!string.IsNullOrEmpty(operation))
            //{
            //    webReq.Headers["Operation"] = operation;
            //}

            //Serialize request object as JSON and write to request body
            if (requestBodyObject != null)
            {
                var requestBody = JsonConvert.SerializeObject(requestBodyObject);
                webReq.ContentLength = requestBody.Length;
                var streamWriter = new StreamWriter(webReq.GetRequestStream(), Encoding.ASCII);
                streamWriter.Write(requestBody);
                streamWriter.Close();
            }

            var response = await webReq.GetResponseAsync();

            if (response == null)
            {
                return default;
            }

            var streamReader = new StreamReader(response.GetResponseStream());
            var responseContent = streamReader.ReadToEnd().Trim();
            var jsonObject = JsonConvert.DeserializeObject<T>(responseContent);
            return jsonObject;
        }

        public static void PostAsync(string uri, string api, object objectToPost)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonObject = JsonConvert.SerializeObject(objectToPost);
                var stringContent = new StringContent(jsonObject, UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(api, stringContent).Result;

                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException("Error posting test result to api.");
            }
        }
    }
}
