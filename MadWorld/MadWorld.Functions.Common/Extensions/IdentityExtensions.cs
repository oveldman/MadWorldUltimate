using System;
using System.Security.Claims;
using System.Security.Principal;
using MadWorld.Shared.Info;

namespace MadWorld.Functions.Common.Extensions
{
	public static class IdentityExtensions
	{
		public static string GetAzureID(this IIdentity identity)
		{
			ClaimsIdentity claimsIdentity = identity as ClaimsIdentity ?? new ClaimsIdentity();
			return GetAzureID(claimsIdentity);
		}

		public static string GetAzureID(this ClaimsIdentity identity)
        {
			return identity.Claims.FirstOrDefault(c => c.Type == ClaimNames.ObjectIdentifier)?.Value ?? string.Empty;
		}
	}
}

