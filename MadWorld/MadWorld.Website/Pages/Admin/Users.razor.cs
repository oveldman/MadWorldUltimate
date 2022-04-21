using System;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Website.Pages.Admin
{
	public partial class Users
	{
        private List<UserModel> _users = new();

        protected override async Task OnInitializedAsync()
        {
            _users = await _userService.GetAllUsers();
        }
    }
}

