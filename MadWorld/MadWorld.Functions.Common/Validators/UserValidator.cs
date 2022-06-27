using System;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Functions.Common.Validators.Interfaces;
using MadWorld.Shared.Enums;

namespace MadWorld.Functions.Common.Validators
{
    public class UserValidator : IUserValidator
    {
        private readonly IUserQueries _userQueries;

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

            Option<User> user = _userQueries.FindUser(id);
            return CreateRoleListForUser(user);
        }

        public bool HasRole(string azureID, RoleTypes role)
        {
            if (!Guid.TryParse(azureID, out Guid id))
            {
                return false;
            }

            Option<User> user = _userQueries.FindUser(id);
            return CheckRole(user, role);
        }

        private static List<string> CreateRoleListForUser(Option<User> userOption)
        {
            if (!userOption.HasValue)
            {
                return new();
            }

            User user = userOption.ValueOr(new User());

            List<string> userRoles = new()
            {
                RoleTypes.Guest.ToString()
            };

            if (user.IsViewer)
            {
                userRoles.Add(RoleTypes.Viewer.ToString());
            }

            if (user.IsAdminstrator)
            {
                userRoles.Add(RoleTypes.Adminstrator.ToString());
            }

            return userRoles;
        }

        private static bool CheckRole(Option<User> userOption, RoleTypes role)
        {
            if (!userOption.HasValue)
            {
                return false;
            }

            User user = userOption.ValueOr(new User());

            return role switch
            {
                RoleTypes.Adminstrator => user.IsAdminstrator,
                RoleTypes.Viewer => user.IsViewer,
                RoleTypes.Guest or RoleTypes.None => true,
                _ => false,
            };
        }
    }
}

