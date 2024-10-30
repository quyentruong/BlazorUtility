using Blazored.LocalStorage;
using BlazorUtility;
using CurrieTechnologies.Razor.Clipboard;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient
//{
//    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
//});
builder.Services.AddHttpClient(
    "Local",
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
);
builder.Services.AddHttpClient(
    "YahooFinance",
    client => client.BaseAddress = new Uri("https://yahooapi.qtsanjose.ddnsgeek.com")
);
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;
    config.SnackbarConfiguration.VisibleStateDuration = 500;
});
builder.Services.AddPWAUpdater();
builder.Services.AddClipboard();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
