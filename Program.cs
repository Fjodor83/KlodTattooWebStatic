using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KlodTattooWebStatic;
using KlodTattooWebStatic.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<LocalizationService>();
builder.Services.AddScoped<TattooDataService>();

var host = builder.Build();

// Initialize localization
var localizationService = host.Services.GetRequiredService<LocalizationService>();
await localizationService.InitializeAsync();

await host.RunAsync();
