﻿using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Functions.Common.Extensions;
using MadWorld.Functions.Common.Validators.Interfaces;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Exceptions;
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
        private HttpRequest _httpRequest;

        public AuthorizeFunctionAttribute(RoleTypes role)
		{
            _role = role;
		}

        public override Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            ValidateUserRole(executingContext);

            return base.OnExecutingAsync(executingContext, cancellationToken);
        }

        private void ValidateUserRole(FunctionExecutingContext executingContext)
        {
            var defaultHttpRequest = executingContext.Arguments.First().Value as HttpRequest;
            _httpRequest = defaultHttpRequest;

            var identity = defaultHttpRequest?.HttpContext.User.Identity as ClaimsIdentity;
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
            var (azureId, email) = GetClaims(identity);
            var userManager = defaultHttpRequest?.HttpContext.RequestServices.GetService<IUserManager>();
            Guard.Against.Null(userManager);
            userManager.CreateUserIfNotExists(azureId, email);

            var userValidator = defaultHttpRequest?.HttpContext.RequestServices.GetService<IUserValidator>();
            Guard.Against.Null(userValidator);
            if (!userValidator.HasRole(azureId, _role))
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
            var azureId = identity.GetAzureID();
            var email = identity.Claims.FirstOrDefault(c => c.Type == ClaimNames.Emails)?.Value ?? string.Empty;
            return (azureId, email);
        }

        public async Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
            if (exceptionContext.Exception.InnerException is not UnauthorizedAccessException)
            {
                throw exceptionContext.Exception.InnerException ?? new ExceptionNotFoundException();
            }

            ResponseException response = new()
            {
                ErrorMessage = "Not Authorised"
            };

            _httpRequest.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            _httpRequest.HttpContext.Response.ContentType = "application/json";
            await _httpRequest.HttpContext.Response.WriteAsync(response.ToJson(), cancellationToken);
        }
    }
}

