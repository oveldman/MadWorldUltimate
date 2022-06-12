using MadWorld.Business.Mappers;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Tests.Business.Mappers
{
    public class UserMapperTests
    {
        [Theory]
        [AutoDomainData]
        public void Translate_User_UserModel(
            User user)
        {
            // No Test data

            // Setup
            UserMapper userMapper = UserMapper.Create();

            // Act
            UserDto userModel = userMapper.Translate<User, UserDto>(user);

            // Assert
            UserDto expectedModel = new()
            {
                ID = user.RowKey,
                Email = user.Email
            };

            expectedModel.Should().BeEquivalentTo(userModel);

            // No Teardown
        }

        [Theory]
        [AutoDomainData]
        public void Translate_UserAndUserModel_UserModel(
            User user)
        {
            // No Test data
            UserDto testDto = new()
            {
                ID = "Test"
            };

            // Setup
            UserMapper userMapper = UserMapper.Create();

            // Act
            UserDto userModel = userMapper.Translate(user, testDto);

            // Assert
            UserDto expectedModel = new()
            {
                ID = user.RowKey,
                Email = user.Email
            };

            expectedModel.Should().BeEquivalentTo(userModel);

            // No Teardown
        }
    }
}

