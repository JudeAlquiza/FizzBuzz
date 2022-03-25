using FizzBuzz.WebAssemblyApp;
using FizzBuzz.WebAssemblyApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<IFizzBuzzService, FizzBuzzService>();

await builder.Build().RunAsync();
