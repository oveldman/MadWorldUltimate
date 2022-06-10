using System;
using Azure;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Info;

namespace MadWorld.Data.TableStorage.Tables
{
	public class User : ITableEntity
    {
        public string PartitionKey { get; set; } = PartitionKeys.User;
        public string RowKey { get; set; } = string.Empty;
        public Guid AzureID { get; set; }
		public string Email { get; set; } = string.Empty;
        public bool IsAdminstrator { get; set; }
        public bool IsViewer { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}

