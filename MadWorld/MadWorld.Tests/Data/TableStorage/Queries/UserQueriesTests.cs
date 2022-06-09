using System.Linq.Expressions;
using System.Threading;
using Azure;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Info;
using MadWorld.Data.TableStorage.Queries;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Tests.Data.TableStorage.Mockups;

namespace MadWorld.Tests.Data.TableStorage.Queries
{
	public class UserQueriesTests
	{
		[Theory]
		[AutoDomainData]
		public void FindUser_AzureID_User(
			[Frozen] Mock<ITableStorageFactory> factory,
			[Frozen] Mock<ITableContext> userContext,
			Guid azureID,
			User user
			)
		{
			// Test data
			user.PartitionKey = PartitionKeys.User;
			user.AzureID = azureID;
			Pageable<User> users = Pageable<User>.FromPages(new MockPage<User>[] { new(new List<User>() { user }) });

			// Setup
			userContext.Setup(tc => tc.Query(It.IsAny<Expression<Func<User, bool>>>(),
				It.IsAny<int?>(),
				It.IsAny<IEnumerable<string>>(),
				It.IsAny<CancellationToken>()))
				.Returns(users);

			factory.Setup(f => f.CreateUserContext()).Returns(userContext.Object);

			UserQueries userQueries = new(factory.Object);

			// Act
			Option<User> resultUserOption = userQueries.FindUser(azureID);
			User resultUser = resultUserOption.ValueOr(new User());

			// Assert
			Assert.Equal(azureID, resultUser.AzureID);

			// No Teardown
		}
	}
}

