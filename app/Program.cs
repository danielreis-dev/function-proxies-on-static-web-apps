using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyStore.App;
using Refit;
using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddSingleton<ShoppingCart>();
builder.Services.AddRefitClient<IBackendClient>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:7070"));

await builder.Build().RunAsync();