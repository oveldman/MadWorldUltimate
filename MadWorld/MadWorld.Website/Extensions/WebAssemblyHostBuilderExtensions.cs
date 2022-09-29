using System.Security.Claims;
using Ardalis.GuardClauses;
using MadWorld.Website.Factory;
using MadWorld.Website.Types;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace MadWorld.Website.Extensions;

public static class WebAssemblyHostBuilderExtensions
{
    public static WebAssemblyHostBuilder AddHttpClients(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        
        builder.AddAnonymousHttpClient();
        builder.AddAuthorizedHttpClient();
        builder.AddDevToolsHttpClient();
        
        return builder;
    }

    public static WebAssemblyHostBuilder AddMsal(this WebAssemblyHostBuilder builder)
    {
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

        return builder;
    }

    private static void AddAnonymousHttpClient(this WebAssemblyHostBuilder builder)
    {
        var apiUrlAnonymous = builder.Configuration["ApiUrls:Anonymous"];
        apiUrlAnonymous = Guard.Against.Null(apiUrlAnonymous) ?? string.Empty;
        
        builder.Services.AddHttpClient(ApiTypes.MadWorldApiAnonymous, (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri(apiUrlAnonymous);
            client.EnableIntercept(serviceProvider);
        }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
    }

    private static void AddAuthorizedHttpClient(this WebAssemblyHostBuilder builder)
    {
        var apiUrlAuthorized = builder.Configuration["ApiUrls:Authorized"];
        apiUrlAuthorized = Guard.Against.Null(apiUrlAuthorized) ?? string.Empty;

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
    }

    private static void AddDevToolsHttpClient(this WebAssemblyHostBuilder builder)
    {
        var apiUrlDevTools = builder.Configuration["ApiUrls:DevTools"];
        apiUrlDevTools = Guard.Against.Null(apiUrlDevTools) ?? string.Empty;

        builder.Services.AddHttpClient(ApiTypes.DevTools, (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri(apiUrlDevTools);
            client.EnableIntercept(serviceProvider);
        }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
    }
}