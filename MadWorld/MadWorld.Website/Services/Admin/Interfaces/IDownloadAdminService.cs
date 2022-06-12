using System;
using MadWorld.Shared.Models.API.Downloads;

namespace MadWorld.Website.Services.Admin.Interfaces
{
	public interface IDownloadAdminService
	{
		Task<List<DownloadDto>> GetDownloads();
	}
}

