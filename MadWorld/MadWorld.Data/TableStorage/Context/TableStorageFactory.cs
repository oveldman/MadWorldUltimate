﻿using System;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Info;

namespace MadWorld.Data.TableStorage.Context
{
	public class TableStorageFactory : ITableStorageFactory
	{
		private TableServiceClient _client;

		public TableStorageFactory(TableServiceClient tableServiceClient)
		{
			_client = tableServiceClient;
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

