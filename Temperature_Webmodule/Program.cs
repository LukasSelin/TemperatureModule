using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TemperatureModule.Webpage;
using TemperatureModule.Webpage.Datasource;

namespace Temperature_Webmodule
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:6001/") });

            builder.Services.AddSingleton<Datasource>();

            await builder.Build().RunAsync();
        }
    }
}
