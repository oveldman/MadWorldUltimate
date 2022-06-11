using System;
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
	public class SaveLinks
	{
        private readonly ILinkAdminManager _linkManager;

        public SaveLinks(ILinkAdminManager linkManager)
        {
            _linkManager = linkManager;
        }

        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(SaveLinks))]
        public async Task<CommonResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Put, Route = null)] HttpRequest req,
            ILogger log)
        {
            Option<LinkGroupAdminDto> linkGroupOptions = await req.GetBodyAsync<LinkGroupAdminDto>();

            if (linkGroupOptions.HasValue)
            {
                return _linkManager.SaveLinks(linkGroupOptions.ValueOr(new LinkGroupAdminDto()));
            }

            return new()
            {
                Succeed = false,
                ErrorMessage = "Link group is required"
            };
        }
    }
}

