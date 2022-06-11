using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Shared
{
	public partial class RedirectToLogin
	{
        protected override void OnInitialized()
        {
            Navigation.NavigateTo($"authentication/login?returnUrl={Uri.EscapeDataString(Navigation.Uri)}");
        }
    }
}

