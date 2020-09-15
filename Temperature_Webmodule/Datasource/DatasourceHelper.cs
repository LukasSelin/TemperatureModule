using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TemperatureModule.Webpage.Models;
using TempraturModul.Models;

namespace TemperatureModuleDatasourceHelper
{
    public class DatasourceHelper
    {
        private static string baseUrl = "https://localhost:44375/WiDetect/XTool_ISAPI.dll/datasnap/rest/TServerMethods1/GetUnitsData?";

        private readonly HttpClient client;
        public DatasourceHelper(HttpClient client)
        { 
            this.client = client;
        }

        private string GetRequestURL(API_Inputs inputs)
        {
            string requestUrl = client.BaseAddress + inputs.ToString();

            return requestUrl;
        }

        private async Task<string> GetResponseAsync(string url)
        {
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

        public async Task<IEnumerable<UnitData>> GetTemperaturesAsync(API_Inputs inputs)
        {
            var requestURL = GetRequestURL(inputs);
            var response = await GetResponseAsync(requestURL);

            TempratureDTO[] temperatures = JsonConvert.DeserializeObject<TempratureDTO[]>(response);

            if (temperatures.Any())
            {
                return temperatures.FirstOrDefault().UnitDataPT;
            }
            else
            {
                throw new Exception("The response have no recorded temperatures");
            }
        }
    }
}
