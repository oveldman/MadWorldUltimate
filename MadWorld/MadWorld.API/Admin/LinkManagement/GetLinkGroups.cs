using System;
using MadWorld.API.Attributes;
using MadWorld.Business.Managers.Interfaces;
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
        private readonly ILinkAdminManager _linkManager;

        public GetLinkGroups(ILinkAdminManager linkManager)
        {
            _linkManager = linkManager;
        }

        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(GetLinkGroups))]
        public ResponseLinkGroups Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            return _linkManager.GetLinkGroups();
        }
    }
}

