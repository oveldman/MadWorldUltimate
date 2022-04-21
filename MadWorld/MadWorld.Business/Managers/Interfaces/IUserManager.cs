using System;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Business.Managers.Interfaces
{
	public interface IUserManager
	{
		public bool CreateUser(Guid azureID, string email);
		public bool CreateUserIfNotExists(string azureID, string email);
		public List<UserModel> GetUsers();
	}
}

