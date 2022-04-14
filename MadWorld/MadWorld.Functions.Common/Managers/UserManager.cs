using System;
using MadWorld.Functions.Common.Managers.Interfaces;

namespace MadWorld.Functions.Common.Managers
{
    public class UserManager : IUserManager
    {
        public bool CreateUser(string azureID, string email)
        {
            return true;
        }

        public bool CreateUserIfNotExists(string azureID, string email)
        {
            return true;
        }
    }
}

