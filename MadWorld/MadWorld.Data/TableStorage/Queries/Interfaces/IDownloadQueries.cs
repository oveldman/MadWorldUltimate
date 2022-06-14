using System;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries.Interfaces
{
	public interface IDownloadQueries
	{
		bool AddDownload(Download download);
		List<Download> GetDownloads();
		Option<Download> GetDownload(string id);
		bool UpdateDownload(Download download);
	}
}

