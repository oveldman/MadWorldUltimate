using System;
using MadWorld.API.Attributes;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Admin.LinkManagement
{
	public class GetLinks
	{
        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(GetLinks))]
        public ResponseLinks Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            string id = req.Query[QueryKeys.ID];

            return new()
            {
                LinkGroup = new()
                {
                    Links = new()
                    {
                        new() { Id = Guid.NewGuid(), Name = "Test Website", Url = "https://www.google.nl", Order = 0 },
                        new() { Id = Guid.NewGuid(), Name = "Test Website 2", Url = "https://www.google2.nl", Order = 1 },
                        new() { Id = Guid.NewGuid(), Name = "Test Website 3", Url = "https://www.google3.nl", Order = 2 }
                    }
                }
            };
        }
    }
}

