using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Business.Managers
{
	public class UserManager : IUserManager
	{
        private readonly IUserMapper _userMapper;
        private readonly IUserQueries _userQueries;

        public UserManager(IUserMapper userMapper, IUserQueries userQueries)
        {
            _userMapper = userMapper;
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

            Option<User> user = _userQueries.FindUser(id);

            if (user.HasValue)
            {
                return true;
            }

            return CreateUser(id, email);
        }

        public UserDetailDto GetUser(string id)
        {
            Option<User> user = _userQueries.FindUser(id);
            return _userMapper.Translate<User, UserDetailDto>(user.ValueOr(new User()));
        }

        public List<UserDto> GetUsers()
        {
            List<User> users = _userQueries.GetAllUsers();
            return _userMapper.Translate<List<User>, List<UserDto>>(users);
        }

        public CommonResponse UpdateUser(UserDetailDto userDto)
        {
            Option<User> userOption = _userQueries.FindUser(userDto.ID);

            if (!userOption.HasValue)
            {
                return CreateUserNotFoundResponse();
            }

            User user = userOption.ValueOr(new User());
            user = _userMapper.Translate(userDto, user);
            _userQueries.UpdateUser(user);

            return new()
            {
                Succeed = true
            };
        }

        private static CommonResponse CreateUserNotFoundResponse()
        {
            return new()
            {
                ErrorMessage = "User not found"
            };
        }
    }
}

