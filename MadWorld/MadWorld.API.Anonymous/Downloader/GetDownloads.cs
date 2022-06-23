using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Functions.Common.Info;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Anonymous.Downloader
{
	public class GetDownloads
	{
        private readonly IDownloadManager _downloadManager;

        public GetDownloads(IDownloadManager downloadManager)
        {
            _downloadManager = downloadManager;
        }

        [FunctionName(nameof(GetDownloads))]
        public ResponseDownloadsAnonymous Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            return _downloadManager.GetAll();
        }
    }
}

