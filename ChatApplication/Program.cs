using ChatApplication;
using ChatApplication.Domain.Entities;
using ChatApplication.Domain.Repositories;
using ChatApplication.Infrastructure.Sqlite;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(_ => httpClient);
builder.Services.AddScoped<IDataRepository>(_ => new DataJson(httpClient));
builder.Services.AddSingleton<SessionDataContainer>();
var app = builder.Build();
await app.RunAsync();
