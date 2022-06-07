using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MadWorld.API.Attributes;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MadWorld.API.Admin.UserManagement
{
    public class GetUsers
    {
        private readonly IUserManager _userManager;

        public GetUsers(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName(nameof(GetUsers))]
        public ResponseUsers Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            return new()
            {
                Users = _userManager.GetUsers()
            };
        }
    }
}

