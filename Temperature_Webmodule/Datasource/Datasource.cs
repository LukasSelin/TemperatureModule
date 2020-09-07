using System;
using System.Collections.Generic;
using TempraturModul.Models;
using System.Threading.Tasks;
using TemperatureModuleDatasourceHelper;
using TemperatureModule.Webpage.Datasource;
using System.Net.Http;

namespace TemperatureModuleDatasource
{
    public class Datasource : IDataService
    {
        private readonly DatasourceHelper helper;

        public Datasource(HttpClient httpClient)
        {
            helper = new DatasourceHelper(httpClient);
        }
        public async Task<IEnumerable<TempratureDTO>> GetAllAsync()
        {
            var inputs = new API_Inputs()
            {
                StartDate = DateTime.MinValue,
                StopDate = DateTime.Now
            };

            var temperatures = await helper.GetTemperaturesAsync(inputs);
            return temperatures;
        }

        public async Task<TempratureDTO> GetLatestTemperatureAsync()
        {
            var inputs = new API_Inputs()
            {
                LastValue = true
            };

            var temperatures = await helper.GetTemperatureAsync(inputs);
            return temperatures;
        }

        public async Task<IEnumerable<TempratureDTO>> GetDayAsync(DateTime date)
        {
            var inputs = new API_Inputs()
            {
                StartDate = date.Date,
                StopDate = date.AddDays(1).Date
            };

            var temperatures = await helper.GetTemperaturesAsync(inputs);
            return temperatures;
        }

        public async Task<IEnumerable<TempratureDTO>> GetDaysAsync(DateTime startDate, DateTime endDate)
        {
            var inputs = new API_Inputs()
            {
                StartDate = startDate.Date,
                StopDate = endDate.Date.AddDays(1)
            };

            var temperatures = await helper.GetTemperaturesAsync(inputs);
            return temperatures;
        }
        public async Task<IEnumerable<TempratureDTO>> GetWeekAsync(DateTime date)
        {
            int offsetDays;
            if(date.DayOfWeek != DayOfWeek.Sunday)
            {
                offsetDays = -(int)date.DayOfWeek + 1;
            }
            else
            {
                offsetDays = -7;
            }

            var inputs = new API_Inputs()
            {
                StartDate = date.AddDays(offsetDays),
                StopDate = date.AddDays(7)
            };

            var temperatures = await helper.GetTemperaturesAsync(inputs);
            return temperatures;
        }
        
        public async Task<IEnumerable<TempratureDTO>> GetMonthAsync(DateTime date)
        {
            var inputs = new API_Inputs()
            {
                StartDate = date.AddDays(-date.Day),
                StopDate = date.AddDays(DateTime.DaysInMonth(date.Year, date.Month))
            };

            var temperatures = await helper.GetTemperaturesAsync(inputs);
            return temperatures;
        }
    }
}
