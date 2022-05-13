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
			[Frozen] Mock<IUserContext> userContext,
			UserQueries userQueries,
			Guid azureID,
			User user
			)
		{
			// Test data
			user.PartitionKey = PartitionKeys.User;
			user.AzureID = azureID;

			Pageable<User> users = Pageable<User>.FromPages(new MockPage<User>[] { new(new List<User>() { user }) });

			// Setup
			userContext.Setup(aq => aq.Query(It.IsAny<Expression<Func<User, bool>>>(),
				It.IsAny<int?>(),
				It.IsAny<IEnumerable<string>>(),
				It.IsAny<CancellationToken>()))
					.Returns(users);
			// Act
			User resultUser = userQueries.FindUser(azureID);

			// Assert
			Assert.Equal(azureID, user.AzureID);

			// No Teardown
		}
	}
}

