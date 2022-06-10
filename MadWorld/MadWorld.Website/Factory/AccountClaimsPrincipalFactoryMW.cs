using System;
using System.Security.Claims;
using MadWorld.Shared.Models.API.Account;
using MadWorld.Website.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;

namespace MadWorld.Website.Factory
{
	public class AccountClaimsPrincipalFactoryMW  : AccountClaimsPrincipalFactory<RemoteUserAccount>
	{
        private IAccountService _service { get; }

        public AccountClaimsPrincipalFactoryMW(IAccessTokenProviderAccessor accessor, IAccountService service) : base(accessor)
        {
            _service = service;
        }

        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account,
            RemoteAuthenticationUserOptions options)
        {
            ClaimsPrincipal user = await base.CreateUserAsync(account, options);

            if (user?.Identity?.IsAuthenticated ?? false)
            {
                ClaimsIdentity claimsIdentity = (ClaimsIdentity)user.Identity;
                List<string> roles = await _service.GetCurrentAccountRoles();
                foreach (string role in roles)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }

            return user ?? new ClaimsPrincipal();
        }
    }
}

