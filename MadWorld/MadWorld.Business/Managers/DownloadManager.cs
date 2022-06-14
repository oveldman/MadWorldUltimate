using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;

namespace MadWorld.Business.Managers
{
	public class DownloadManager : IDownloadManager
	{
		private readonly IDownloadQueries _downloadQueries;
		private readonly IDownloadMapper _mapper;

		public DownloadManager(IDownloadMapper mapper, IDownloadQueries downloadQueries)
		{
			_downloadQueries = downloadQueries;
			_mapper = mapper;
		}
	}
}

