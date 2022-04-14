using System;
namespace MadWorld.Functions.Common.Managers.Interfaces
{
	public interface IUserManager
	{
		public bool CreateUser(string azureID, string email);
		public bool CreateUserIfNotExists(string azureID, string email);
	}
}

