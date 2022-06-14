using System;
using Azure;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Info;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries
{
	public class DownloadQueries : IDownloadQueries
	{
        private readonly ITableContext _context;


        public bool AddDownload(Download download)
        {
            Response response = _context.AddEntity(download);
            return response.IsError;
        }

        public DownloadQueries(ITableStorageFactory tableStorageFactory)
        {
            _context = tableStorageFactory.CreateDownloadContext();
        }

        public List<Download> GetDownloads()
        {
           return _context.Query<Download>(d => d.PartitionKey == PartitionKeys.Download).ToList();
        }

        public Option<Download> GetDownload(string id)
        {
            var download = _context.Query<Download>(g => g.PartitionKey == PartitionKeys.Download
                                && g.RowKey == id).ToList();
            return download.FirstOrNone();
        }

        public bool UpdateDownload(Download download)
        {
            Response response = _context.UpdateEntity(download, ETag.All);
            return response.IsError;
        }
    }
}

