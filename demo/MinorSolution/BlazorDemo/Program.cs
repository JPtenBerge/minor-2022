using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorDemo;
using BlazorDemo.Repositories;
using BlazorDemo.Services;
using IdentityModel;
// using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();

// builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<AntiforgeryHandler>();
builder.Services.AddSingleton<AuthenticationStateProvider, HostAuthenticationStateProvider>();
builder.Services.AddHttpClient("backend", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<AntiforgeryHandler>();
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("backend"));

builder.Services.AddMudServices();

// builder.Services.AddTransient<IKaasRepository, KaasRepository>(); // kortst levend. iedere keer een nieuwe. nadeel: maximaal geheugenverbruik. voordeeL: geen side effects.
builder.Services.AddTransient<IKaasRepository, KaasBackendRepository>(); // kortst levend. iedere keer een nieuwe. nadeel: maximaal geheugenverbruik. voordeeL: geen side effects.
// builder.Services.AddScoped<>()    // iedere request
// builder.Services.AddSingleton<>() // one instance to rule them all. gebruikt weinig geheugen. side effects. 


await builder.Build().RunAsync();