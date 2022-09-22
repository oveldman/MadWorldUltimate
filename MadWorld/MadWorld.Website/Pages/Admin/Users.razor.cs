using System;
using MadWorld.Shared.Models.API.Users;
using MadWorld.Website.Services;
using MadWorld.Website.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin
{
	public partial class Users
	{
        private bool PageLoaded = false;

        private IEnumerable<UserDto> _users = Enumerable.Empty<UserDto>();

        [Inject]
        private IUserService _userService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            _users = await _userService.GetAllUsers();
            PageLoaded = true;
        }

        private void OpenUser(UserDto user)
        {
            _navigation.NavigateTo($"/Admin/EditUser/{user.ID}");
        }
    }
}

