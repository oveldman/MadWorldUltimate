using System;
using MadWorld.Functions.Common.Validators.Interfaces;
using MadWorld.Shared.Enums;

namespace MadWorld.Functions.Common.Validators
{
    public class UserValidator : IUserValidator
    {
        public bool HasRole(string azureID, RoleTypes role)
        {
            return true;
        }
    }
}

