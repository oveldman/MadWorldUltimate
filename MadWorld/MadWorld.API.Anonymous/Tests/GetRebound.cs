using System.IO;
using System.Threading.Tasks;
using MadWorld.Functions.Common.Extensions;
using MadWorld.Functions.Common.Info;
using MadWorld.Shared.Models.AnonymousAPI.Tests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Optional;

namespace MadWorld.API.Anonymous.Tests;

public class GetRebound
{
    [FunctionName(nameof(GetRebound))]
    public async Task<string> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, RequestType.Delete, RequestType.Post, RequestType.Put, Route = null)] HttpRequest req,
        ILogger log)
    {
        var request = await new StreamReader(req.Body).ReadToEndAsync();
        if (string.IsNullOrEmpty(request))
        {
            request = req.Query[QueryKeys.Request];
        }

        return request;
    }
}