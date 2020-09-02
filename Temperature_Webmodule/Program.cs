using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TemperatureModule.Webpage;
using TemperatureModule.Webpage.Datasource;
using TemperatureModuleDatasource;

namespace Temperature_Webmodule
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:6001/") });

            builder.Services.AddScoped<IDataService, Datasource>();
            
            await builder.Build().RunAsync();
        }
    }
}
