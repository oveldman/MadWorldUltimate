using MadWorld.Business.Managers;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Tests.Business.Managers;

public class UserManagerTests
{
    [Theory]
    [AutoDomainData]
    public void UpdateUser(
        UserDetailDto userDto,
        UserManager userManager,
        Mock<IUserQueries> userQueries
        )
    {
        // Test data
        var userOption = Option.None<User>();

        // Setup
        userQueries.Setup(uq => uq.FindUser(It.IsAny<string>())).Returns(userOption);

        // Act
        var result = userManager.UpdateUser(userDto);

        // Assert
        Assert.False(result.Succeed);
        Assert.Equal("User not found", result.ErrorMessage);

        // No Teardown
    }
}