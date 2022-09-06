using System;
using System.IO;
using MadWorld.Functions.Common.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Anonymous.Tests;

public class Ping
{
    [FunctionName(nameof(Ping))]
    public string Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, RequestType.Delete, RequestType.Post, RequestType.Put, Route = null)] HttpRequest req,
        ILogger log)
    {
        return $"Ping: {DateTime.Now:dd-MM-yyyy hh:mm:ss}";
    }
}