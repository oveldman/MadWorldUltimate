using System;
using Azure;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Info;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries
{
	public class UserQueries : IUserQueries
	{
        private TableServiceClient _client;
        private TableClient _usersTable;

        public UserQueries(TableServiceClient client)
		{
            _client = client;
            _client.CreateTableIfNotExists(TableNames.Users);
            _usersTable = _client.GetTableClient(TableNames.Users);
        }

        public bool CreateUser(User user)
        {
            _usersTable.AddEntity(user);
            return true;
        }

        public User FindUser(Guid azureId)
        {
            Pageable<User> users = _usersTable.Query<User>(u => u.PartitionKey == PartitionKeys.User && u.AzureID == azureId);
            return users.FirstOrDefault();
        }
    }
}

