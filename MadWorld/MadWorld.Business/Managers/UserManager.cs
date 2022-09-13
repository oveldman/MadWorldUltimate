using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Business.Managers
{
	public sealed class UserManager : IUserManager
	{
        private readonly IUserMapper _userMapper;
        private readonly IUserQueries _userQueries;

        public UserManager(IUserMapper userMapper, IUserQueries userQueries)
        {
            _userMapper = userMapper;
            _userQueries = userQueries;
        }

        public bool CreateUser(Guid azureId, string email)
        {
            User user = new()
            {
                RowKey = Guid.NewGuid().ToString(),
                AzureID = azureId,
                Email = email,
                IsAdminstrator = false
            };

            return _userQueries.CreateUser(user);
        }

        public bool CreateUserIfNotExists(string azureId, string email)
        {
            if (!Guid.TryParse(azureId, out var id))
            {
                return false;
            }

            var user = _userQueries.FindUser(id);
            return user.HasValue || CreateUser(id, email);
        }

        public UserDetailDto GetUser(string id)
        {
            var user = _userQueries.FindUser(id);
            return _userMapper.Translate<User, UserDetailDto>(user.ValueOr(new User()));
        }

        public List<UserDto> GetUsers()
        {
            var users = _userQueries.GetAllUsers();
            return _userMapper.Translate<List<User>, List<UserDto>>(users);
        }

        public CommonResponse UpdateUser(UserDetailDto userDto)
        {
            var userOption = _userQueries.FindUser(userDto.ID);

            if (!userOption.HasValue)
            {
                return CreateUserNotFoundResponse();
            }

            var user = userOption.ValueOr(new User());
            user = _userMapper.Translate(userDto, user);
            _userQueries.UpdateUser(user);

            return new CommonResponse
            {
                Succeed = true
            };
        }

        private static CommonResponse CreateUserNotFoundResponse()
        {
            return new CommonResponse
            {
                ErrorMessage = "User not found"
            };
        }
    }
}

