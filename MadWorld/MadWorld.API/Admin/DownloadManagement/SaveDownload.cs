using System;
using System.Threading.Tasks;
using MadWorld.API.Attributes;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Downloads;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Admin.DownloadManagement
{
	public class SaveDownload
	{
        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(SaveDownload))]
        public async Task<CommonResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Post, Route = null)] HttpRequest req,
            ILogger log)
        {
            DownloadDto download = await req.GetBodyAsync<DownloadDto>();

            return new()
            {
                Succeed = true
            };
        }
    }
}

