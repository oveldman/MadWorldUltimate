using System;
using MadWorld.Shared.Enums;

namespace MadWorld.Functions.Common.Validators.Interfaces
{
	public interface IUserValidator
	{
		public bool HasRole(string azureID, RoleTypes role);
	}
}

