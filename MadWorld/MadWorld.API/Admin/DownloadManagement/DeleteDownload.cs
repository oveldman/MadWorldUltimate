using System;
using MadWorld.API.Attributes;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Admin.DownloadManagement
{
	public class DeleteDownload
	{
        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(DeleteDownload))]
        public CommonResponse Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Delete, Route = null)] HttpRequest req,
            ILogger log)
        {
            string id = req.Query[QueryKeys.ID];

            return new()
            {
                Succeed = true
            };
        }
    }
}

