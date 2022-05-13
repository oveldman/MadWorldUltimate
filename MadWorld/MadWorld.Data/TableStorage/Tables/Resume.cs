using Azure;
using Azure.Data.Tables;
using MadWorld.Data.TableStorage.Info;

namespace MadWorld.Data.TableStorage.Tables
{
    public class Resume : ITableEntity
    {
        public string PartitionKey { get; set; } = PartitionKeys.Resume;
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public string? Adress { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Email { get; set; }
        public string? Firstname { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? Place { get; set; }
        public string? Surname { get; set; }
        public string? Telephone { get; set; }
        public string? Zipcode { get; set; }
    }
}

