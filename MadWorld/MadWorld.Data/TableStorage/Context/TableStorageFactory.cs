using System;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Info;

namespace MadWorld.Data.TableStorage.Context
{
	public class TableStorageFactory : ITableStorageFactory
	{
		private readonly TableServiceClient _client;

		public TableStorageFactory(TableServiceClient tableServiceClient)
		{
			_client = tableServiceClient;
		}

		public ITableContext CreateDownloadContext()
		{
			return new TableContext(_client, TableNames.Downloads);
		}

		public ITableContext CreateLinkContext()
        {
			return new TableContext(_client, TableNames.Links);
		}

        public ITableContext CreateResumeContext()
        {
            return new TableContext(_client, TableNames.Resumes);
		}

		public ITableContext CreateUserContext()
		{
			return new TableContext(_client, TableNames.Users);
		}
	}
}

