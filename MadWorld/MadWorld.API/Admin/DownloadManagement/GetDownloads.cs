﻿using System;
using MadWorld.API.Attributes;
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
                        Extention = "txt",
                        Id = Guid.NewGuid().ToString()
                    },
                    new DownloadDto
                    {
                        Name = "Test 2",
                        Content = "text/plain",
                        Created = DateTime.Now,
                        Extention = "txt",
                        Id = Guid.NewGuid().ToString()
                    }
                }
            };
        }
    }
}

