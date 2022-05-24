using System;
using MadWorld.Functions.Common.Info;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Anonymous.Downloader
{
	public class Download
	{
        [FunctionName(nameof(Download))]
        public static ResponseDownload Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            string id = req.Query[QueryKeys.ID];

            return new ResponseDownload
            {
                Found = true,
                Name = "Test.txt",
                Base64 = "RGl0IGlzIGVlbiB0ZXh0IGZpbGUh",
                ContentType = "text/plain"
            };
        }
    }
}

