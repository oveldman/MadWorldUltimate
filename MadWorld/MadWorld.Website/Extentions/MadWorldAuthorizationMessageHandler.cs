using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace MadWorld.Website.Extentions
{
	public class MadWorldAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public MadWorldAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager)
            : base(provider, navigationManager)
        {
            ConfigureHandler(
                authorizedUrls: new[] { "https://api.mad-world.nl" },
                // NOTE: here with "api://"
                scopes: new[] { "https://nlMadWorld.onmicrosoft.com/7ea82c29-9d1c-4ecb-9641-5a9e9cf84bb6/Api.ReadWrite" });
        }
    }
}

