using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Business.Managers
{
	public class UserManager : IUserManager
	{
        private IUserQueries _userQueries;

        public UserManager(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }

        public bool CreateUser(Guid azureID, string email)
        {
            User user = new User
            {
                RowKey = Guid.NewGuid().ToString(),
                AzureID = azureID,
                Email = email,
                IsAdminstrator = false
            };

            return _userQueries.CreateUser(user);
        }

        public bool CreateUserIfNotExists(string azureID, string email)
        {
            if (!Guid.TryParse(azureID, out Guid id))
            {
                return false;
            }

            User user = _userQueries.FindUser(id);

            if (user != null)
            {
                return true;
            }

            return CreateUser(id, email);
        }
    }
}

