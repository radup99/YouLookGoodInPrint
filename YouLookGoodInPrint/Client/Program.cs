using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace YouLookGoodInPrint.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<TokenContainer>();
            builder.Services.AddSingleton<DocumentsContainer>();
            builder.Services.AddSingleton<PrintContainer>();
            builder.Services.AddSingleton<PaymentsContainer>();

            await builder.Build().RunAsync();
        }
    }
}
