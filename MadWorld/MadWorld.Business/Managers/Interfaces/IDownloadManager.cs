using System;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Downloads;

namespace MadWorld.Business.Managers.Interfaces
{
	public interface IDownloadManager
	{
		CommonResponse DeleteDownload(string id);
		ResponseDownloads GetAllDownloads();
		ResponseDownload GetDownload(string id, bool getBody);
		CommonResponse SaveDownload(DownloadDto download);
	}
}

