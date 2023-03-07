using DiplomFrontUWP.Utils.Interfaces;
using DiplomFrontUWP.Utils.Responces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiplomFrontUWP.Utils
{
    public class APIWorker : IAPIWorker
    {
        private string host = "https://localhost";
        private string port = "7001";
        private string baseURL;

        public APIWorker()
        {
            baseURL = host + ":" + port;
        }

        public async Task<string> GetTest()
        {
            try
            {
                string answer = string.Empty;
                WebRequest request = WebRequest.Create(baseURL + "/api" + "/handler" + "/test");
                request.ContentType = "application/json";
                request.Method = "GET";
                request.Timeout = 5000;

                /*
                using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = "{\"email\": \"" + email + "\", \"password\": \"" + password + "\", \"nickname\": \"" + nickname + "\"}";
                    streamWriter.Write(json);
                }
                */

                WebResponse response = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = await reader.ReadToEndAsync();
                }

                response.Close();

                TestReponse testResponse = JsonConvert.DeserializeObject<TestReponse>(answer);
                //Console.WriteLine("Ответ сервера: " + authResponse.message);

                return testResponse.Content;
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
    }
}
