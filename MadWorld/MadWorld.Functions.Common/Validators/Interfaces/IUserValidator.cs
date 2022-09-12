using System;
using MadWorld.Shared.Enums;

namespace MadWorld.Functions.Common.Validators.Interfaces
{
	public interface IUserValidator
	{
		public List<string> GetAllRoles(string azureId);
		public bool HasRole(string azureId, RoleTypes role);
	}
}

