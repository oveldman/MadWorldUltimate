using System;
using MadWorld.API.Attributes;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Downloads;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Admin.DownloadManagement
{
    public class GetDownload
    {
        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(GetDownload))]
        public ResponseDownload Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            string id = req.Query[QueryKeys.ID];

            return new()
            {
                Download = new DownloadDto
                {
                    Name = "Test",
                    Content = "text/plain",
                    Created = DateTime.Now,
                    Extention = "txt",
                    Id = Guid.NewGuid().ToString(),
                    BodyBase64 = "RGl0IGlzIGVlbiB0ZXh0IGZpbGUh"
                }
            };
        }
    }
}
