using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Shared
{
	public partial class RedirectToLogin
	{
        [Inject]
        private NavigationManager Navigation { get; set; }

        protected override void OnInitialized()
        {
            Navigation.NavigateTo($"authentication/login?returnUrl={Uri.EscapeDataString(Navigation.Uri)}");
        }
    }
}

