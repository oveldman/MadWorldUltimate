using System;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Functions.Common.Validators.Interfaces;
using MadWorld.Shared.Enums;

namespace MadWorld.Functions.Common.Validators
{
    public class UserValidator : IUserValidator
    {
        private IUserQueries _userQueries;

        public UserValidator(IUserQueries userQueries)
        {
            _userQueries = userQueries;
        }

        public List<string> GetAllRoles(string azureID)
        {
            if (!Guid.TryParse(azureID, out Guid id))
            {
                return new();
            }

            User user = _userQueries.FindUser(id);
            return CreateRoleListForUser(user);
        }

        public bool HasRole(string azureID, RoleTypes role)
        {
            if (!Guid.TryParse(azureID, out Guid id))
            {
                return false;
            }

            User user = _userQueries.FindUser(id);
            return CheckRole(user, role);
        }

        private List<string> CreateRoleListForUser(User user)
        {
            if (user == null)
            {
                return new();
            }

            List<string> userRoles = new()
            {
                RoleTypes.Guest.ToString(),
                RoleTypes.Viewer.ToString()
            };

            if (user.IsAdminstrator)
            {
                userRoles.Add(RoleTypes.Adminstrator.ToString());
            }

            return userRoles;
        }

        private bool CheckRole(User user, RoleTypes role)
        {
            if (user == null)
            {
                return false;
            }

            if (role == RoleTypes.Adminstrator && user.IsAdminstrator)
            {
                return true;
            }

            if (role == RoleTypes.Guest || role == RoleTypes.Viewer)
            {
                return true;
            }

            return false;
        }
    }
}

