using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TempraturModul.Models;

namespace TemperatureModule.Datasource.Helper
{
    static class DatasourceHelper
    {
        private static string baseUrl = "https://widdev.wideco.se/WiDetect/XTool_ISAPI.dll/datasnap/rest/TServerMethods1/GetUnitsData?";
#warning exposed baseURL 
        private static string GetRequestURL(API_Inputs inputs)
        {
            string requestUrl = baseUrl + inputs.ToString();

            return requestUrl;
        }

        private static async Task<string> GetResponseAsync(string url)
        {
            using (var client = new HttpClient())
            {
#warning authorization is visable in plain text
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + "bXdlOg==");
                var baseAdress = new Uri("https://widdev.wideco.se/WiDetect/XTool_ISAPI.dll/datasnap/rest/TServerMethods1/GetUnitsData?");
                client.BaseAddress = baseAdress;
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
        }

        public static async Task<TempratureDTO> GetTemperatureAsync(API_Inputs inputs)
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

        public static async Task<IEnumerable<TempratureDTO>> GetTemperaturesAsync (API_Inputs inputs)
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
