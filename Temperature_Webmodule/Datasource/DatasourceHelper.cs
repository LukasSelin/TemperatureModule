using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TemperatureModule.Webpage.Datasource;
using TemperatureModule.Webpage.Models;

namespace TemperatureModuleDatasourceHelper
{
    public class DatasourceHelper : IDataService
    {
        private static string baseUrl = "https://localhost:44375/WiDetect/XTool_ISAPI.dll/datasnap/rest/TServerMethods1/GetUnitsData?";
#warning exposed baseURL 

        private readonly HttpClient client;
        public DatasourceHelper(HttpClient client)
        {
#warning authorization is visable in plain text
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + "bXdlOg==");
            this.client = client;
        }
        private string GetRequestURL(API_Inputs inputs)
        {
            string requestUrl = baseUrl + inputs.ToString();

            return requestUrl;
        }

        private async Task<string> GetResponseAsync(string url)
        {
            

                //var baseAdress = new Uri("https://widdev.wideco.se/WiDetect/XTool_ISAPI.dll/datasnap/rest/TServerMethods1/GetUnitsData?");
                //client.BaseAddress = baseAdress;
                HttpResponseMessage response = await client.GetAsync(url);
                

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();

                    return responseString;
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        

        public async Task<TempratureDTO> GetTemperatureAsync(API_Inputs inputs)
        {
            var requestURL = GetRequestURL(inputs);
            var response = await GetResponseAsync(requestURL);

            Queue<TempratureDTO> temperatures = JsonConvert.DeserializeObject<Queue<TempratureDTO>>(response);
            
            if(temperatures.Count == 1)
            {
                return temperatures.Dequeue();
            }
            else
            {
                throw new Exception("The response have more OR less than one temperature");
            }
        }

        public async Task<IEnumerable<TempratureDTO>> GetTemperaturesAsync (API_Inputs inputs)
        {
            var requestURL = GetRequestURL(inputs);
            var response = await GetResponseAsync(requestURL);

            IEnumerable<TempratureDTO> temperatures = JsonConvert.DeserializeObject<IEnumerable<TempratureDTO>>(response);

            if (temperatures.Any())
            {
                return temperatures;
            }
            else
            {
                throw new Exception("The response have no recorded temperatures");
            }
        }
    }
}
