using System;
using System.Collections.Generic;
using TempraturModul.Models;
using System.Threading.Tasks;
using Temprature_Datasource;

namespace TempraturModul
{
    public class Datasource
    {
        public async Task<IEnumerable<TempratureDTO>> GetAll()
        {
            var inputs = new API_Inputs()
            {
                StartDate = DateTime.MinValue,
                StopDate = DateTime.Now
            };

            var temperatures = await DatasourceHelper.GetTemperaturesAsync(inputs);
            return temperatures;
        }

        public async Task<TempratureDTO> GetLatestTemperature()
        {
            var inputs = new API_Inputs()
            {
                LastValue = true
            };

            var temperatures = await DatasourceHelper.GetTemperatureAsync(inputs);
            return temperatures;
        }

        public async Task<IEnumerable<TempratureDTO>> GetDay(DateTime date)
        {
            var inputs = new API_Inputs()
            {
                StartDate = date.Date,
                StopDate = date.AddDays(1)
            };

            var temperatures = await DatasourceHelper.GetTemperaturesAsync(inputs);
            return temperatures;
        }
        public async Task<IEnumerable<TempratureDTO>> GetWeek(DateTime date)
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

            var temperatures = await DatasourceHelper.GetTemperaturesAsync(inputs);
            return temperatures;
        }
        
        public async Task<IEnumerable<TempratureDTO>> GetMonth(DateTime date)
        {
            var inputs = new API_Inputs()
            {
                StartDate = date.AddDays(-date.Day),
                StopDate = date.AddDays(DateTime.DaysInMonth(date.Year, date.Month))
            };

            var temperatures = await DatasourceHelper.GetTemperaturesAsync(inputs);
            return temperatures;
        }
    }
}
