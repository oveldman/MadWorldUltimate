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
        private readonly IDownloadManager _downloadManager;

        public GetDownloads(IDownloadManager downloadManager)
        {
            _downloadManager = downloadManager;
        }

        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(GetDownloads))]
        public ResponseDownloads Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            return new()
            {
                Downloads = new()
                {
                    new DownloadDto
                    {
                        Name = "Test",
                        Content = "text/plain",
                        Created = DateTime.Now,
                        Id = Guid.NewGuid().ToString()
                    },
                    new DownloadDto
                    {
                        Name = "Test 2",
                        Content = "text/plain",
                        Created = DateTime.Now,
                        Id = Guid.NewGuid().ToString()
                    }
                }
            };
        }
    }
}

