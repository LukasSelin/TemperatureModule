using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using TempraturModul;
using TempraturModul.Models;
using System.Linq;

namespace TempratureTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TempratureDTO> temps = GetTempsAsync().GetAwaiter().GetResult();
            Console.WriteLine(temps[0].UnitDataPT[0].DataPTValue);
        }

        static async Task<TempratureDTO> GetTempAsync()
        {
            var testClasss = new Datasource();

            var temps = await testClasss.GetLatestTemperature();
            return temps;
        }
        static async Task<List<TempratureDTO>> GetTempsAsync()
        {
            var testClasss = new Datasource();

            var temps = await testClasss.GetWeek(DateTime.Today);
            return temps.ToList();
        }
    }
}
