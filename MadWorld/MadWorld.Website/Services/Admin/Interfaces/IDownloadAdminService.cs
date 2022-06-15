using System;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Downloads;

namespace MadWorld.Website.Services.Admin.Interfaces
{
	public interface IDownloadAdminService
	{
		Task<List<DownloadDto>> GetDownloads();
		Task<ResponseDownload> GetDownload(string id, bool getBody);
		Task<CommonResponse> SaveDownload(DownloadDto download);
		Task<CommonResponse> DeleteDownload(string id);
	}
}

