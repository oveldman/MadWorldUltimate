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
	public class GetLinkGroups
	{
        public GetLinkGroups()
        {
        }

        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(GetLinkGroups))]
        public ResponseLinkGroups Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            return new()
            {
                LinkGroups = new()
                {
                    new() { Id = Guid.NewGuid(), Name = "Test" },
                    new() { Id = Guid.NewGuid(), Name = "Test 2", ColumnOrder = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Test 3", RowOrder = 1 },
                    new() { Id = Guid.NewGuid(), Name = "Test 4", RowOrder = 1, ColumnOrder = 1 }
                }
            };
        }
    }
}

