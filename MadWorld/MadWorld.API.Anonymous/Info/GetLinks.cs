using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Functions.Common.Info;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Anonymous.Info
{
    public class GetLinks
    {
        private readonly ILinkManager _linkManager;

        public GetLinks(ILinkManager linkManager)
        {
            _linkManager = linkManager;
        }

        [FunctionName(nameof(GetLinks))]
        public ResponseLinks Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            return new ResponseLinks
            {
                Groups = _linkManager.GetLinks()
            };
        }
    }
}

