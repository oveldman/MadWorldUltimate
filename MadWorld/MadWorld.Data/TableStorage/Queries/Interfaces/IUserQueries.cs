using System;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries.Interfaces
{
	public interface IUserQueries
	{
		public bool CreateUser(User user);
		public User FindUser(Guid azureId);
		public User FindUser(string id);
		public List<User> GetAllUsers();
	}
}

