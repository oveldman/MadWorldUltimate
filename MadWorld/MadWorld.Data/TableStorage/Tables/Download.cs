using System;
using Azure;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Info;

namespace MadWorld.Data.TableStorage.Tables
{
	public class Download : ITableEntity
	{
		public string PartitionKey { get; set; } = PartitionKeys.Download;
		public string RowKey { get; set; } = string.Empty;
		public DateTimeOffset? Timestamp { get; set; }
		public ETag ETag { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public string Extention { get; set; } = string.Empty;
		public bool IsDeleted { get; set; }
	}
}

