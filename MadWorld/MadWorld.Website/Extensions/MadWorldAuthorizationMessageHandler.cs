using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace MadWorld.Website.Extensions
{
    public class MadWorldAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public MadWorldAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager)
            : base(provider, navigationManager)
        {
            ConfigureHandler(
                authorizedUrls: new[] { "https://azurefunctions.mad-world.nl" },
                scopes: new[] {  "https://nlMadWorld.onmicrosoft.com/7ea82c29-9d1c-4ecb-9641-5a9e9cf84bb6/Api.ReadWrite" });
        }
    }

}
