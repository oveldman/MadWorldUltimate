using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MadWorld.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Azure.WebJobs.Host;

namespace MadWorld.API.Attributes
{
    public class AuthorizeFunction : FunctionInvocationFilterAttribute
    {
        private readonly RoleTypes _role;

        public AuthorizeFunction(RoleTypes role)
		{
            _role = role;
		}

        public override Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            ValidateUserRole(executingContext);

            return base.OnExecutingAsync(executingContext, cancellationToken);
        }

        public void ValidateUserRole(FunctionExecutingContext executingContext)
        {
            var defaultHttpRequest = executingContext.Arguments.First().Value as HttpRequest;

            ClaimsIdentity identity = defaultHttpRequest.HttpContext.User.Identity as ClaimsIdentity;
            if (!identity?.IsAuthenticated ?? true)
            {
                // it isn't needed to set unauthorized result 
                // as the base class already requires the user to be authenticated
                return;
            }

            // you can also use registered services
            (string azureID, string email) = GetClaims(identity);
            var isAuthorized = true;
            if (!isAuthorized)
            {
                throw new Exception("Not authorized!");
            }
        }

        private static (string azureID, string email) GetClaims(ClaimsIdentity identity)
        {
            string azureID = identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value ?? string.Empty;
            string email = identity.Claims.FirstOrDefault(c => c.Type == "emails")?.Value ?? string.Empty;
            return (azureID, email);
        }
    }
}

