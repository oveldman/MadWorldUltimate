using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Functions.Common.Validators;
using MadWorld.Shared.Enums;

namespace MadWorld.Tests.Functions.Common.Validators
{
	public class UserValidatorTests
	{
		[Theory]
		[AutoDomainData]
		public void GetAllRoles_AzureID_ThreeRoles(
			[Frozen] Mock<IUserQueries> userQueries,
			UserValidator userValidator,
			Guid azureId,
			User user
			)
		{
			// Test data
			user.AzureID = azureId;
			user.IsAdminstrator = true;
			user.IsViewer = true;

			// Setup
			userQueries.Setup(aq => aq.FindUser(It.IsAny<Guid>())).Returns(Option.Some(user));

			// Act
			List<string> roles = userValidator.GetAllRoles(azureId.ToString());

			// Assert
			Assert.True(roles.Count == 3, "Expected a list of 3 role");
			Assert.Equal(RoleTypes.Guest.ToString(), roles[0]);
			Assert.Equal(RoleTypes.Viewer.ToString(), roles[1]);
			Assert.Equal(RoleTypes.Administrator.ToString(), roles[2]);

			// No Teardown
		}

		[Theory]
		[AutoDomainData]
		public void GetAllRoles_AzureID_TwoRoles(
			[Frozen] Mock<IUserQueries> userQueries,
			UserValidator userValidator,
			Guid azureId,
			User user
			)
		{
			// Test data
			user.AzureID = azureId;
			user.IsAdminstrator = false;
			user.IsViewer = true;

			// Setup
			userQueries.Setup(aq => aq.FindUser(It.IsAny<Guid>())).Returns(Option.Some(user));

			// Act
			List<string> roles = userValidator.GetAllRoles(azureId.ToString());

			// Assert
			Assert.True(roles.Count == 2, "Expected a list of 2 role");
			Assert.Equal(RoleTypes.Guest.ToString(), roles[0]);
			Assert.Equal(RoleTypes.Viewer.ToString(), roles[1]);

			// No Teardown
		}

		[Theory]
		[AutoDomainData]
		public void GetAllRoles_AzureID_OneRoles(
			[Frozen] Mock<IUserQueries> userQueries,
			UserValidator userValidator,
			Guid azureId,
			User user
			)
		{
			// Test data
			user.AzureID = azureId;
			user.IsAdminstrator = false;
			user.IsViewer = false;

			// Setup
			userQueries.Setup(aq => aq.FindUser(It.IsAny<Guid>())).Returns(Option.Some(user));

			// Act
			List<string> roles = userValidator.GetAllRoles(azureId.ToString());

			// Assert
			Assert.True(roles.Count == 1, "Expected a list of 1 role");
			Assert.Equal(RoleTypes.Guest.ToString(), roles[0]);

			// No Teardown
		}

		[Theory]
		[AutoDomainInlineData(RoleTypes.Administrator, true, true, true)]
		[AutoDomainInlineData(RoleTypes.Administrator, false, true, false)]
		[AutoDomainInlineData(RoleTypes.Viewer, false, true, true)]
		[AutoDomainInlineData(RoleTypes.Viewer, false, false, false)]
		[AutoDomainInlineData(RoleTypes.Guest, false, false, true)]
		public void HasRole_AzureIDRole_HasRole(
			RoleTypes role,
			bool isAdminstrator,
			bool isViewer,
			bool expectedHasAcces,
			[Frozen] Mock<IUserQueries> userQueries,
			UserValidator userValidator,
			Guid azureId,
			User user
			)
		{
			// Test data
			user.AzureID = azureId;
			user.IsAdminstrator = isAdminstrator;
			user.IsViewer = isViewer;

			// Setup
			userQueries.Setup(aq => aq.FindUser(It.IsAny<Guid>())).Returns(Option.Some(user));

			// Act
			bool hasAccess = userValidator.HasRole(azureId.ToString(), role);

			// Assert
			Assert.Equal(expectedHasAcces, hasAccess);

			// No Teardown
		}
	}
}

