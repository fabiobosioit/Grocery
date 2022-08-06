using Grocery.Client.Services;
using Grocery.UI;
using Grocery.UI.Configurations;
using Grocery.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(typeof(IDataService<,,>), typeof(DataService<,,>));
builder.Services.AddGroceryUIServices();
await builder.Build().RunAsync();
