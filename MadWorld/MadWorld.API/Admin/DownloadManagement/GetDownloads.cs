using System;
using MadWorld.API.Attributes;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Downloads;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Admin.DownloadManagement
{
	public class GetDownloads
	{
        private readonly IDownloadAdminManager _downloadManager;

        public GetDownloads(IDownloadAdminManager downloadManager)
        {
            _downloadManager = downloadManager;
        }

        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(GetDownloads))]
        public ResponseDownloads Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            return _downloadManager.GetAllDownloads();
        }
    }
}

