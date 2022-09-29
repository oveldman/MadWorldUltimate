using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MadWorld.Website;
using MadWorld.Website.Types;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MadWorld.Website.Extensions;
using MadWorld.Website.Factory;
using System.Security.Claims;
using Ardalis.GuardClauses;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<MadWorldAuthorizationMessageHandler>();

builder.AddHttpClients();
builder.AddMsal();
builder.Services.AddComponents();
builder.Services.AddInternalClasses();
builder.Services.AddPackages();

await builder.Build().RunAsync();

