using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TemperatureModuleDatasourceHelper;
using TempraturModul.Models;
using System.Linq;
using TemperatureModule.Webpage.Models;

namespace TemperatureModule.Webpage.Datasource
{
    public class Datasource
    {
        private readonly DatasourceHelper helper;

        public Datasource(HttpClient httpClient)
        {
            helper = new DatasourceHelper(httpClient);
        }

        public async Task<IEnumerable<UnitData>> GetDayAsync(DateTime date)
        {
            var inputs = new API_Inputs()
            {
                StartDate = date.Date,
                StopDate = date.AddDays(1).Date
            };

            var temperatures = (await helper.GetTemperaturesAsync(inputs)).ToArray();

            return temperatures;
        }

        public async Task<IEnumerable<UnitData>> GetDaysAsync(DateTime startDate, DateTime endDate)
        {
            var inputs = new API_Inputs()
            {
                StartDate = startDate.Date,
                StopDate = endDate.Date.AddDays(1)
            };

            var temperatures = (await helper.GetTemperaturesAsync(inputs)).ToArray();
            return temperatures;
        }
    }
}
