using System.IO;
using System.Threading.Tasks;
using MadWorld.Functions.Common.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Anonymous.Tests;

public static class GetRebound
{
    [FunctionName(nameof(GetRebound))]
    public static async Task<string> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, RequestType.Delete, RequestType.Post, RequestType.Put, Route = null)] HttpRequest req,
        ILogger log)
    {
        var request = await new StreamReader(req.Body).ReadToEndAsync();
        if (string.IsNullOrEmpty(request))
        {
            request = req.Query[QueryKeys.Request];
        }

        return request ?? "No data";
    }
}