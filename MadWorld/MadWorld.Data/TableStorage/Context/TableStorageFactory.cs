using System;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Info;

namespace MadWorld.Data.TableStorage.Context
{
	public class TableStorageFactory
	{
		private TableServiceClient _client;

		public TableStorageFactory(TableServiceClient tableServiceClient)
		{
			_client = tableServiceClient;
		}

		public IResumeContext CreateResumeContext()
        {
            return new TableContext(_client, TableNames.Resumes);
		}

		public IUserContext CreateUserContext()
		{
			return new TableContext(_client, TableNames.Users);
		}
	}
}

