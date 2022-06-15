using System;
using MadWorld.API.Attributes;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Downloads;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Admin.DownloadManagement
{
    public class GetDownload
    {
        private readonly IDownloadAdminManager _downloadManager;

        public GetDownload(IDownloadAdminManager downloadManager)
        {
            _downloadManager = downloadManager;
        }

        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(GetDownload))]
        public ResponseDownload Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            string id = req.Query[QueryKeys.ID];
            string getBodyQuery = req.Query[QueryKeys.GetBody];
            bool getBody = bool.TryParse(getBodyQuery, out bool getBodyParsed) && getBodyParsed;

            return _downloadManager.GetDownload(id, getBody);
        }
    }
}
