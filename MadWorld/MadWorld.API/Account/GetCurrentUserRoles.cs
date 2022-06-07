using System;
using System.Threading.Tasks;
using MadWorld.API.Attributes;
using MadWorld.Functions.Common.Extentions;
using MadWorld.Functions.Common.Validators.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Account
{
    public class GetCurrentUserRoles
    {
        private readonly IUserValidator _userValidator;

        public GetCurrentUserRoles(IUserValidator userValidator)
        {
            _userValidator = userValidator;
        }

        [AuthorizeFunction(RoleTypes.Guest)]
        [FunctionName(nameof(GetCurrentUserRoles))]
        public ResponseRoles Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            string azureID = req.HttpContext.User.Identity.GetAzureID();

            ResponseRoles response = new()
            {
                Roles = _userValidator.GetAllRoles(azureID)
            };

            return response;
        }
    }
}

