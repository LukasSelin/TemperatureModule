﻿using System;
using System.Collections.Generic;
using TempraturModul.Models;
using System.Threading.Tasks;
using TemperatureModule.Datasource.Helper;

namespace TemperatureModuleDatasource
{
    public class Datasource
    {
        public async Task<IEnumerable<TempratureDTO>> GetAllAsync()
        {
            var inputs = new API_Inputs()
            {
                StartDate = DateTime.MinValue,
                StopDate = DateTime.Now
            };

            var temperatures = await DatasourceHelper.GetTemperaturesAsync(inputs);
            return temperatures;
        }

        public async Task<TempratureDTO> GetLatestTemperatureAsync()
        {
            var inputs = new API_Inputs()
            {
                LastValue = true
            };

            var temperatures = await DatasourceHelper.GetTemperatureAsync(inputs);
            return temperatures;
        }

        public async Task<IEnumerable<TempratureDTO>> GetDayAsync(DateTime date)
        {
            var inputs = new API_Inputs()
            {
                StartDate = date.Date,
                StopDate = date.AddDays(1)
            };

            var temperatures = await DatasourceHelper.GetTemperaturesAsync(inputs);
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

            var temperatures = await DatasourceHelper.GetTemperaturesAsync(inputs);
            return temperatures;
        }
        
        public async Task<IEnumerable<TempratureDTO>> GetMonthAsync(DateTime date)
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
