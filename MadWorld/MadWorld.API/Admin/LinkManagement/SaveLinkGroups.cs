﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MadWorld.API.Attributes;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Admin.LinkManagement
{
	public class SaveLinkGroups
	{
        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(SaveLinkGroups))]
        public async Task<CommonResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Put, Route = null)] HttpRequest req,
            ILogger log)
        {
            List<LinkGroupAdminDto> linkGroups = await req.GetBodyAsync<List<LinkGroupAdminDto>>();

            return new()
            {
                Succeed = true
            };
        }
    }
}

