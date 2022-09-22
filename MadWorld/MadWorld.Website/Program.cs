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

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<MadWorldAuthorizationMessageHandler>();

string? apiUrlAnonymous = builder.Configuration["ApiUrls:Anonymous"] ;
string? apiUrlAuthorized = builder.Configuration["ApiUrls:Authorized"];
apiUrlAnonymous = Guard.Against.Null(apiUrlAnonymous) ?? string.Empty;
apiUrlAuthorized = Guard.Against.Null(apiUrlAuthorized) ?? string.Empty;


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient(ApiTypes.MadWorldApiAnonymous, (serviceProvider, client) =>
{
    client.BaseAddress = new Uri(apiUrlAnonymous);
    client.EnableIntercept(serviceProvider);
}).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped<DelegatingHandlerMW>();
builder.Services.AddHttpClient(ApiTypes.MadWorldApiAuthorization, (serviceProvider, client) =>
{
    client.BaseAddress = new Uri(apiUrlAuthorized);
    client.EnableIntercept(serviceProvider);
}).AddHttpMessageHandler<DelegatingHandlerMW>();

builder.Services.AddHttpClient(ApiTypes.MadWorldApiB2C, (serviceProvider, client) =>
{
    client.BaseAddress = new Uri(apiUrlAuthorized);
    client.EnableIntercept(serviceProvider);
}).AddHttpMessageHandler<MadWorldAuthorizationMessageHandler>();

builder.Services.AddMsalAuthentication<RemoteAuthenticationState, RemoteUserAccount>(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://nlMadWorld.onmicrosoft.com/7ea82c29-9d1c-4ecb-9641-5a9e9cf84bb6/Api.ReadWrite");
    options.UserOptions.RoleClaim = ClaimTypes.Role;
}).AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, RemoteUserAccount, AccountClaimsPrincipalFactoryMW>();

builder.Services.AddComponents();
builder.Services.AddInternalClasses();
builder.Services.AddPackages();

await builder.Build().RunAsync();

