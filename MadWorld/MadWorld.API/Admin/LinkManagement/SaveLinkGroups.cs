using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MadWorld.API.Attributes;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Optional;

namespace MadWorld.API.Admin.LinkManagement
{
	public class SaveLinkGroups
	{
        private readonly ILinkAdminManager _linkManager;

        public SaveLinkGroups(ILinkAdminManager linkManager)
        {
            _linkManager = linkManager;
        }

        [AuthorizeFunction(RoleTypes.Administrator)]
        [FunctionName(nameof(SaveLinkGroups))]
        public async Task<CommonResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Put, Route = null)] HttpRequest req,
            ILogger log)
        {
            Option<List<LinkGroupAdminDto>> linkGroupsOptions = await req.GetBodyAsync<List<LinkGroupAdminDto>>();

            if (linkGroupsOptions.HasValue)
            {
                return _linkManager.SaveLinkGroups(linkGroupsOptions.ValueOr(new List<LinkGroupAdminDto>()));
            }

            return new()
            {
                Succeed = false,
                ErrorMessage = "List of link groups required"
            };
        }
    }
}

