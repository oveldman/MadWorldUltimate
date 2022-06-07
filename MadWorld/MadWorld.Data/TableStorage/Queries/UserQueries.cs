using System;
using Azure;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Info;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries
{
	public class UserQueries : IUserQueries
    {
        private readonly ITableContext _context;

        public UserQueries(ITableStorageFactory tableStorageFactory)
		{
            _context = tableStorageFactory.CreateUserContext();
        }

        public bool CreateUser(User user)
        {
            Response response = _context.AddEntity(user);
            return response.IsError;
        }

        public User FindUser(Guid azureId)
        {
            Pageable<User> users = _context.Query<User>(u => u.PartitionKey == PartitionKeys.User && u.AzureID == azureId);
            return users.FirstOrDefault();
        }

        public User FindUser(string id)
        {
            Pageable<User> users = _context.Query<User>(u => u.PartitionKey == PartitionKeys.User && u.RowKey == id);
            return users.FirstOrDefault();
        }

        public List<User> GetAllUsers()
        {
            return _context.Query<User>(u => u.PartitionKey == PartitionKeys.User).ToList() ?? new();
        }

        public bool UpdateUser(User user)
        {
            Response response = _context.UpdateEntity(user, ETag.All);
            return response.IsError;
        }
    }
}

