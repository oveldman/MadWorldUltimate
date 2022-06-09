using System;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries.Interfaces
{
	public interface IUserQueries
	{
		bool CreateUser(User user);
		Option<User> FindUser(Guid azureId);
		Option<User> FindUser(string id);
		List<User> GetAllUsers();
		bool UpdateUser(User user);
	}
}

