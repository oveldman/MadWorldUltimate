using System;
using MadWorld.Shared.Enums;

namespace MadWorld.Functions.Common.Validators.Interfaces
{
	public interface IUserValidator
	{
		public List<string> GetAllRoles(string azureID);
		public bool HasRole(string azureID, RoleTypes role);
	}
}

