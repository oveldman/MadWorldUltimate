using System;
using MadWorld.Shared.Models.API.Account;

namespace MadWorld.Website.Services.Interfaces
{
	public interface IAccountService
	{
		public Task<List<string>> GetCurrentAccountRoles();
	}
}

