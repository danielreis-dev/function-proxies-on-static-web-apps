using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Threading.Tasks;

namespace MyStore.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton<ShoppingCart>();
            builder.Services.AddRefitClient<IBackendClient>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri(builder.HostEnvironment.IsDevelopment()
                        ? "http://localhost:7070"
                        : builder.HostEnvironment.BaseAddress);
                });

            await builder.Build().RunAsync();
        }
    }
}
