using Azure;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Info;

namespace MadWorld.Data.TableStorage.Tables
{
	public class Link : ITableEntity
    {
        public string PartitionKey { get; set; } = PartitionKeys.Link;
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Url { get; set; }

        public string LinkGroupId { get; set; }
    }
}

