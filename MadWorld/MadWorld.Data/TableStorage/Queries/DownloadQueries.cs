using System;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;

namespace MadWorld.Data.TableStorage.Queries
{
	public class DownloadQueries : IDownloadQueries
	{
        private readonly ITableContext _context;

        public DownloadQueries(ITableStorageFactory tableStorageFactory)
        {
            _context = tableStorageFactory.CreateDownloadContext();
        }
    }
}

