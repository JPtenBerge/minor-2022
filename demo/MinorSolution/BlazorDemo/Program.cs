using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorDemo;
using BlazorDemo.Repositories;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();

// builder.Services.AddTransient<IKaasRepository, KaasRepository>(); // kortst levend. iedere keer een nieuwe. nadeel: maximaal geheugenverbruik. voordeeL: geen side effects.
builder.Services.AddTransient<IKaasRepository, KaasBackendRepository>(); // kortst levend. iedere keer een nieuwe. nadeel: maximaal geheugenverbruik. voordeeL: geen side effects.
// builder.Services.AddScoped<>()    // iedere request
// builder.Services.AddSingleton<>() // one instance to rule them all. gebruikt weinig geheugen. side effects. 


await builder.Build().RunAsync();