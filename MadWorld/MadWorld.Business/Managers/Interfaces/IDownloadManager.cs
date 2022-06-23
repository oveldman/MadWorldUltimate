using System;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;

namespace MadWorld.Business.Managers.Interfaces
{
	public interface IDownloadManager
	{
		ResponseDownloadAnonymous Get(string id);
        ResponseDownloadsAnonymous GetAll();
    }
}

