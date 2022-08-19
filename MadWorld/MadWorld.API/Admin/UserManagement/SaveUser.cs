using System;
using System.Threading.Tasks;
using MadWorld.API.Attributes;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Optional;

namespace MadWorld.API.Admin.UserManagement
{
	public class SaveUser
	{
        private readonly IUserManager _userManager;

        public SaveUser(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [AuthorizeFunction(RoleTypes.Administrator)]
        [FunctionName(nameof(SaveUser))]
        public async Task<CommonResponse> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Put, Route = null)] HttpRequest req,
            ILogger log)
        {
            Option<RequestUser> requestUserOption = await req.GetBodyAsync<RequestUser>();

            if (requestUserOption.HasValue)
            {
                RequestUser requestUser = requestUserOption.ValueOr(new RequestUser());
                return _userManager.UpdateUser(requestUser.User);
            }

            return new()
            {
                Succeed = false,
                ErrorMessage = "User is required"
            };
        }
    }
}

