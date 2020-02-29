using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Base
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
    }
}
