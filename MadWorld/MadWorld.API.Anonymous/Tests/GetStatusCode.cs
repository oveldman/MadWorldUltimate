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

public class GetStatusCode
{
    [FunctionName(nameof(GetStatusCode))]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, RequestType.Delete, RequestType.Post, RequestType.Put, Route = null)] HttpRequest req,
        ILogger log)
    {
        string statusCode;
        
        Option<StatusCodeDto> statusCodeOption = await req.GetBodyAsync<StatusCodeDto>();
        if (statusCodeOption.HasValue)
        {
            statusCode = statusCodeOption.ValueOr(new StatusCodeDto()).StatusCode;
        }
        else
        {
            statusCode = req.Query[QueryKeys.StatusCode];
        }
        
        var parseSucceed = int.TryParse(statusCode, out int code);
        return parseSucceed ? new StatusCodeResult(code) : new StatusCodeResult(400);
    }
}