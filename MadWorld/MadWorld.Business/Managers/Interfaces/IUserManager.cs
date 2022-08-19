using System;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Business.Managers.Interfaces
{
	public interface IUserManager
	{
		public bool CreateUser(Guid azureId, string email);
		public bool CreateUserIfNotExists(string azureId, string email);
		public List<UserDto> GetUsers();
		public UserDetailDto GetUser(string id);
		public CommonResponse UpdateUser(UserDetailDto userDto);
	}
}

