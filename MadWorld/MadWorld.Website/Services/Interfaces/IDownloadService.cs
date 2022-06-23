using System;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;

namespace MadWorld.Website.Services.Interfaces
{
	public interface IDownloadService
	{
		Task<ResponseDownloadAnonymous> GetDownload(string id);
        Task<ResponseDownloadsAnonymous> GetDownloads();
    }
}

