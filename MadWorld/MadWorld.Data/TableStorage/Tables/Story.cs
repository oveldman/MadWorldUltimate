using Azure;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Info;

namespace MadWorld.Data.TableStorage.Tables;

public class Story : ITableEntity
{
    public string PartitionKey { get; set; } = PartitionKeys.Story;
    public string RowKey { get; set; } = string.Empty;
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    public string Comment { get; set; } = string.Empty;
    public bool IsConcept { get; set; }

}