using MadWorld.Functions.Common.Info;
using MadWorld.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Anonymous.Tests;

public static class Ping
{
    [FunctionName(nameof(Ping))]
    public static string Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, RequestType.Delete, RequestType.Post, RequestType.Put, Route = null)] HttpRequest req,
        ILogger log)
    {
        return $"Ping: {SystemTime.Now():dd-MM-yyyy hh:mm:ss}";
    }
}