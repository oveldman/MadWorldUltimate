using System;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Website.Services.Admin.Interfaces
{
	public interface IUserService
	{
		Task<List<UserDto>> GetAllUsers();
		Task<UserDetailDto> GetUser(string id);
		Task<CommonResponse> UpdateUser(UserDetailDto user);
	}
}

