using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MadWorld.Website;
using MadWorld.Website.Types;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MadWorld.Website.Extentions;
using MadWorld.Blazor.Componets.Monaco.Extentions;
using MadWorld.Website.Factory;
using System.Security.Claims;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<MadWorldAuthorizationMessageHandler>();

string apiUrlAnonymous = builder.Configuration["ApiUrls:Anonymous"] ;
string apiUrlAuthorized = builder.Configuration["ApiUrls:Authorized"];

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient(ApiTypes.MadWorldApiAnonymous, client =>
{
    client.BaseAddress = new Uri(apiUrlAnonymous);
}).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped<DelegatingHandlerMW>();
builder.Services.AddHttpClient(ApiTypes.MadWorldApiAuthorization, client =>
{
    client.BaseAddress = new Uri(apiUrlAuthorized);
}).AddHttpMessageHandler<DelegatingHandlerMW>();

builder.Services.AddHttpClient(ApiTypes.MadWorldApiB2C, client =>
{
    client.BaseAddress = new Uri(apiUrlAuthorized);
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

builder.Services.AddComponets();
builder.Services.AddInternalClasses();
builder.Services.AddPackages();

await builder.Build().RunAsync();

