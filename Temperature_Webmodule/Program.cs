using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TemperatureModule.Webpage;
using TemperatureModule.Webpage.Datasource;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Temperature_Webmodule
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("ServerAPI",
                client =>
                {
                    client.BaseAddress = new Uri(builder.Configuration["ConnectionStrings:DefaultConnection"]);
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Base64Encode("mwe:"));
                });
            
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
                .CreateClient("ServerAPI"));
            
            builder.Services.AddSingleton<Datasource>();

            await builder.Build().RunAsync();
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
