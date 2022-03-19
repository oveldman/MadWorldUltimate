﻿using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MadWorld.Website;
using MadWorld.Website.Types;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string apiUrl = "https://api.mad-world.nl/api/";

if (builder.HostEnvironment.IsDevelopment())
{
    apiUrl = "http://localhost:7071/api/";
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient(ApiTypes.MadWorldApiAnonymous, client =>
{
    client.BaseAddress = new Uri(apiUrl);
}).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddHttpClient(ApiTypes.MadWorldApiB2C, client =>
{
    client.BaseAddress = new Uri(apiUrl);
}).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();


builder.Services.AddMsalAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://nlMadWorld.onmicrosoft.com/7ea82c29-9d1c-4ecb-9641-5a9e9cf84bb6/Api.ReadWrite");
});

await builder.Build().RunAsync();

