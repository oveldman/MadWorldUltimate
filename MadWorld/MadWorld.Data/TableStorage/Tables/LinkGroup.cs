using System;
using Azure;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Info;

namespace MadWorld.Data.TableStorage.Tables
{
	public class LinkGroup : ITableEntity
	{
        public string PartitionKey { get; set; } = PartitionKeys.LinkGroup;
        public string RowKey { get; set; } = string.Empty;
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public int ColumnOrder { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RowOrder { get; set; }
    }
}

