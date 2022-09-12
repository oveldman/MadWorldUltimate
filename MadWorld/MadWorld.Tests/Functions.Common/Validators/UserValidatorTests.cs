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
			var roles = userValidator.GetAllRoles(azureId.ToString());

			// Assert
			Assert.True(roles.Count == 3, "Expected a list of 3 role");
			Assert.Equal(RoleTypes.Guest.ToString(), roles[0]);
			Assert.Equal(RoleTypes.Viewer.ToString(), roles[1]);
			Assert.Equal(RoleTypes.Administrator.ToString(), roles[2]);

			// No Teardown
		}
		
		[Theory]
		[AutoDomainData]
		public void GetAllRoles_AzureIDNotValid_NoRoles(
			UserValidator userValidator
		)
		{
			// Test data
			const string randomData = "RandomString";

			// No Setup

			// Act
			var roles = userValidator.GetAllRoles(randomData);

			// Assert
			Assert.True(roles.Count == 0, "Expected a list of 0 role");

			// No Teardown
		}
		
		[Theory]
		[AutoDomainData]
		public void GetAllRoles_AzureIDNoUser_NoRoles(
			Guid azureId,
			[Frozen] Mock<IUserQueries> userQueries,
			UserValidator userValidator
		)
		{
			// No Test data

			// Setup
			userQueries.Setup(uq => uq.FindUser(It.IsAny<string>())).Returns(Option.None<User>());

			// Act
			var roles = userValidator.GetAllRoles(azureId.ToString());

			// Assert
			Assert.True(roles.Count == 0, "Expected a list of 0 role");

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
			var roles = userValidator.GetAllRoles(azureId.ToString());

			// Assert
			Assert.True(roles.Count == 1, "Expected a list of 1 role");
			Assert.Equal(RoleTypes.Guest.ToString(), roles[0]);

			// No Teardown
		}
		
		[Theory]
		[AutoDomainData]
		public void HasRole_AzureIDNotValid_False(
			UserValidator userValidator
		)
		{
			// Test data
			const string randomData = "RandomString";

			// No Setup

			// Act
			var hasRole = userValidator.HasRole(randomData, RoleTypes.Administrator);

			// Assert
			Assert.False(hasRole);

			// No Teardown
		}
		
		[Theory]
		[AutoDomainData]
		public void HasRole_AzureIDNoUser_False(
			Guid azureId,
			UserValidator userValidator,
			[Frozen] Mock<IUserQueries> userQueries
		)
		{
			// No Test data

			// No Setup
			userQueries.Setup(aq => aq.FindUser(It.IsAny<Guid>())).Returns(Option.None<User>());

			// Act
			var hasRole = userValidator.HasRole(azureId.ToString(), RoleTypes.Administrator);

			// Assert
			Assert.False(hasRole);

			// No Teardown
		}

		[Theory]
		[AutoDomainInlineData(RoleTypes.Administrator, true, true, true)]
		[AutoDomainInlineData(RoleTypes.Administrator, false, true, false)]
		[AutoDomainInlineData(RoleTypes.Viewer, false, true, true)]
		[AutoDomainInlineData(RoleTypes.Viewer, false, false, false)]
		[AutoDomainInlineData(RoleTypes.Guest, false, false, true)]
		[AutoDomainInlineData(RoleTypes.None, false, false, true)]
		public void HasRole_AzureIDRole_HasRole(
			RoleTypes role,
			bool isAdministrator,
			bool isViewer,
			bool expectedHasAccess,
			[Frozen] Mock<IUserQueries> userQueries,
			UserValidator userValidator,
			Guid azureId,
			User user
			)
		{
			// Test data
			user.AzureID = azureId;
			user.IsAdminstrator = isAdministrator;
			user.IsViewer = isViewer;

			// Setup
			userQueries.Setup(aq => aq.FindUser(It.IsAny<Guid>())).Returns(Option.Some(user));

			// Act
			var hasAccess = userValidator.HasRole(azureId.ToString(), role);

			// Assert
			Assert.Equal(expectedHasAccess, hasAccess);

			// No Teardown
		}
		
		[Theory]
		[AutoDomainData]
		public void HasRole_AzureIDRoleNotValid_ThrowsException(
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
			const RoleTypes notValidRole = (RoleTypes) (-2);

			// Setup
			userQueries.Setup(aq => aq.FindUser(It.IsAny<Guid>())).Returns(Option.Some(user));

			// Act & Assert
			Assert.Throws<ArgumentOutOfRangeException>(() => userValidator.HasRole(azureId.ToString(), notValidRole));

			// No Teardown
		}
	}
}

