using System.Threading;
using MadWorld.API.Attributes;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Stories;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Admin.StoryManagement;

public class GetConceptStory
{
    private readonly IStoryAdminManager _storyManager;

    public GetConceptStory(IStoryAdminManager storyManager)
    {
        _storyManager = storyManager;
    }

    [AuthorizeFunction(RoleTypes.Administrator)]
    [FunctionName(nameof(GetConceptStory))]
    public ResponseStory Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
        ILogger log)
    {
        var cancellationToken = req.HttpContext.RequestAborted;
        return _storyManager.GetConcept(cancellationToken);
    }
}