using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace MadWorld.Website.Shared
{
	public partial class LoginDisplay
	{
		[Inject]
		private NavigationManager Navigation { get; set; }
		[Inject]
		SignOutSessionStateManager SignOutManager { get; set; }

		private async Task BeginSignOut(MouseEventArgs args)
		{
			await SignOutManager.SetSignOutState();
			Navigation.NavigateTo("authentication/logout");
		}
	}
}

