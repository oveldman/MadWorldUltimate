﻿using System;
using System.Threading.Tasks;
using MadWorld.API.Attributes;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Downloads;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Optional;

namespace MadWorld.API.Admin.DownloadManagement
{
	public class SaveDownload
	{
        private readonly IDownloadAdminManager _downloadManager;

        public SaveDownload(IDownloadAdminManager downloadManager)
        {
            _downloadManager = downloadManager;
        }

        [AuthorizeFunction(RoleTypes.Administrator)]
        [FunctionName(nameof(SaveDownload))]
        public async Task<CommonResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Post, Route = null)] HttpRequest req,
            ILogger log)
        {
            Option<DownloadDto> downloadOption = await req.GetBodyAsync<DownloadDto>();

            if (downloadOption.HasValue)
            {
                return _downloadManager.SaveDownload(downloadOption.ValueOr(new DownloadDto()));
            }

            return new()
            {
                Succeed = false,
                ErrorMessage = "Download is required"
            };
        }
    }
}

