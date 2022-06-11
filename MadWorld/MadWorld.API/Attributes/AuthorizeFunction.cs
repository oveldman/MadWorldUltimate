using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Functions.Common.Extentions;
using MadWorld.Functions.Common.Validators.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Info;
using MadWorld.Shared.Models.API.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.API.Attributes
{
    public class AuthorizeFunctionAttribute : FunctionInvocationFilterAttribute, IFunctionExceptionFilter
    {
        private readonly RoleTypes _role;
        private HttpRequest httpRequest;

        public AuthorizeFunctionAttribute(RoleTypes role)
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
            httpRequest = defaultHttpRequest;

            ClaimsIdentity identity = defaultHttpRequest.HttpContext.User.Identity as ClaimsIdentity;
            if (!identity?.IsAuthenticated ?? true)
            {
                if (IsLocalHost(defaultHttpRequest))
                {
                    identity = SetLocalHostLogin(defaultHttpRequest);
                }
                else
                {
                    // it isn't needed to set unauthorized result 
                    // as the base class already requires the user to be authenticated
                    return;
                }
            }

            // you can also use registered services
            (string azureID, string email) = GetClaims(identity);
            var userManager = defaultHttpRequest.HttpContext.RequestServices.GetService<IUserManager>();
            userManager.CreateUserIfNotExists(azureID, email);

            var userValidator = defaultHttpRequest.HttpContext.RequestServices.GetService<IUserValidator>();
            if (!userValidator.HasRole(azureID, _role))
            {
                throw new UnauthorizedAccessException();
            }
        }

        private static bool IsLocalHost(HttpRequest httpRequest)
        {
            return httpRequest.Host.Host.Equals("localhost");
        }

        private static ClaimsIdentity SetLocalHostLogin(HttpRequest httpRequest)
        {   
            ClaimsIdentity identity = new();
            identity.AddClaim(new Claim(ClaimNames.ObjectIdentifier, "511f29ed-1fda-4fbc-9c59-5eb0a459c66f"));
            identity.AddClaim(new Claim(ClaimNames.Emails, "localhost@localhost.nl"));
            ClaimsPrincipal user = new(identity);
            httpRequest.HttpContext.User = user;
            return identity;
        }

        private static (string azureID, string email) GetClaims(ClaimsIdentity identity)
        {
            string azureID = identity.GetAzureID();
            string email = identity.Claims.FirstOrDefault(c => c.Type == ClaimNames.Emails)?.Value ?? string.Empty;
            return (azureID, email);
        }

        public async Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
            if (exceptionContext.Exception.InnerException is UnauthorizedAccessException)
            {
                ResponseException response = new()
                {
                    ErrorMessage = "Not Authorised"
                };

                httpRequest.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                httpRequest.HttpContext.Response.ContentType = "application/json";
                await httpRequest.HttpContext.Response.WriteAsync(response.ToJson(), cancellationToken);
                return;
            }

            throw exceptionContext.Exception.InnerException;
        }
    }
}

