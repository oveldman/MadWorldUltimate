using System;
using MadWorld.API.Attributes;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Admin.LinkManagement;
public class GetLinks
{
    private readonly ILinkAdminManager _linkManager;

    public GetLinks(ILinkAdminManager linkManager)
    {
        _linkManager = linkManager;
    }

    [AuthorizeFunction(RoleTypes.Administrator)]
    [FunctionName(nameof(GetLinks))]
    public ResponseLinks Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
        ILogger log)
    {
        string id = req.Query[QueryKeys.Id];

        return _linkManager.TryGetLinks(id);
    }
}

