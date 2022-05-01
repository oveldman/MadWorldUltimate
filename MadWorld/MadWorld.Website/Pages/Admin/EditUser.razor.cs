using MadWorld.Shared.Models.API.Users;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin
{
	public partial class EditUser
	{
		[Parameter]
		public string ID { get; set; }

		private UserDetailDto _user = new();

		protected override async Task OnInitializedAsync()
		{
			_user = await _userService.GetUser(ID);
		}

		private async Task SaveUser()
        {

        }
	}
}

