using System;
using MadWorld.Functions.Common.Info;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Anonymous.Info
{
	public class GetStory
	{
        [FunctionName(nameof(GetStory))]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            return new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
            
            /*
            return new()
            {
                Body = "<h1>Story</h1>"
            };
            */
        }
    }
}

