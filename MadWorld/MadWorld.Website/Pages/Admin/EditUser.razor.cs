using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Users;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin
{
	public partial class EditUser
	{
		[Parameter]
		public string ID { get; set; }

		private string ErrorMessage { get; set; } = string.Empty;

		private UserDetailDto _user = new();

		protected override async Task OnInitializedAsync()
		{
			_user = await _userService.GetUser(ID);
		}

		private async Task SaveUser()
        {
			Reset();
			CommonResponse response = await _userService.UpdateUser(_user);

			if (response.Succeed)
            {
				_navigation.NavigateTo($"/Admin/Users");
			}

			ErrorMessage = "There went something wrong with saving this user";
		}

		private void Reset()
        {
			ErrorMessage = string.Empty;
        }
	}
}

