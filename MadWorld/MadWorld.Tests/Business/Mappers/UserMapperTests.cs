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
			UserMapper userMapper,
			User user)
			{
				// No Test data

				// No Setup

				// Act
				UserModel userModel = userMapper.Translate<User, UserModel>(user);

				// Assert
				UserModel expectedModel = new()
				{
					ID = user.RowKey,
					Email = user.Email
				};

				expectedModel.Should().BeEquivalentTo(userModel);

				// No Teardown
			}
	}
}

