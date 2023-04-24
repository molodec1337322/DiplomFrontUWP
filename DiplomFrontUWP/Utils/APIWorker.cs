using DiplomFrontUWP.Utils.Interfaces;
using DiplomFrontUWP.Utils.Responces;
using DiplomFrontUWP.Utils.Responses;
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
        private string host = "http://localhost";
        private string port = "5265";
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
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                request.ContentType = "application/json";
                request.Method = "GET";
                request.Timeout = 5000;

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

        public async Task<List<USBPortsResponse>> GetAvaliableUSBPorts()
        {
            try
            {
                string answer = string.Empty;
                WebRequest request = WebRequest.Create(baseURL + "/api" + "/getCOMPorts");
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                request.ContentType = "application/json";
                request.Method = "GET";
                request.Timeout = 5000;

                WebResponse response = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = await reader.ReadToEndAsync();
                }

                response.Close();

                List<USBPortsResponse> avaliablePorts = JsonConvert.DeserializeObject<List<USBPortsResponse>>(answer);
                //Console.WriteLine("Ответ сервера: " + authResponse.message);

                return avaliablePorts;
            }
            catch (WebException ex)
            {
                Console.Write(ex.Message);
                return new List<USBPortsResponse>();
            }
        }

        public async Task<List<SchemaResponse>> GetSchemasList()
        {
            try
            {
                string answer = string.Empty;
                WebRequest request = WebRequest.Create(baseURL + "/api" + "/experiments" + "/getAllSchemasList");
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                request.ContentType = "application/json";
                request.Method = "GET";
                request.Timeout = 5000;

                WebResponse response = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = await reader.ReadToEndAsync();
                }

                response.Close();

                List<SchemaResponse> schemasListResponse = JsonConvert.DeserializeObject<List<SchemaResponse>>(answer);
                //Console.WriteLine("Ответ сервера: " + authResponse.message);

                return schemasListResponse;
            }
            catch (WebException ex)
            {
                Console.Write(ex.Message);
                return new List<SchemaResponse>();
            }
        }

        public async Task<string> PutNewExperiment(string description, string videoSaveRoot, string schemaText)
        {
            try
            {
                string answer = string.Empty;
                WebRequest request = WebRequest.Create(baseURL + "/api" + "/experiments" + "/createNewSchema");
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                request.ContentType = "application/json";
                request.Method = "POST";
                request.Timeout = 5000;

                Console.WriteLine(baseURL);

                using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = "{\"description\": \"" + description + "\", \"videoSaveFolderPath\": \"" + videoSaveRoot.Replace("\\", "/") + "\", \"schemaText\": \"" + schemaText + "\"}";
                    streamWriter.Write(json);
                }

                WebResponse response = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = await reader.ReadToEndAsync();
                }

                response.Close();
                return answer;
            }
            catch (WebException ex)
            {
                Console.Write(ex.Message);
                return ex.Message;
            }
        }

        public async Task<string> StartExperiment(string USBPort, string Direction, string Deformation, string PauseDuration, string side)
        {
            try
            {
                string answer = string.Empty;
                //string ds = baseURL + "/api" + "/arduino" + "/setCommands?" + "USBPort=" + USBPort + "&Direction=" + Direction + "&Deformation=" + Deformation + "&PauseDuration" + PauseDuration + "&Side=" + side;
                WebRequest request = WebRequest.Create(baseURL + "/api" + "/arduino" + "/setCommands?" + "USBPort=" + USBPort + "&Direction=" + Direction + "&Deformation=" + Deformation + "&PauseDuration=" + PauseDuration + "&Side=" + side);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                request.ContentType = "application/json";
                request.Method = "Get";
                request.Timeout = 500000;

                WebResponse response = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = await reader.ReadToEndAsync();
                }

                response.Close();
                return answer;
            }
            catch (WebException ex)
            {
                Console.Write(ex.Message);
                return ex.Message;
            }
        }

        public async Task<List<ExperimentResponse>> GetExperimentsHistory()
        {
            try
            {
                string answer = string.Empty;
                WebRequest request = WebRequest.Create(baseURL + "/api" + "/experiments" + "/getAllExperimentsList");
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                request.ContentType = "application/json";
                request.Method = "GET";
                request.Timeout = 5000;

                WebResponse response = await request.GetResponseAsync();

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    answer = await reader.ReadToEndAsync();
                }

                response.Close();

                List<ExperimentResponse> experimentsListResponse = JsonConvert.DeserializeObject<List<ExperimentResponse>>(answer);
                //Console.WriteLine("Ответ сервера: " + authResponse.message);

                return experimentsListResponse;
            }
            catch (WebException ex)
            {
                Console.Write(ex.Message);
                return new List<ExperimentResponse>();
            }
        }
    }
}
