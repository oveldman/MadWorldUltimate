using System;
using MadWorld.Website.Services;
using MadWorld.Website.Services.Admin;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Services.Interfaces;

namespace MadWorld.Website.Extentions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddInternalClasses(this IServiceCollection services)
		{
			//Services
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IUserService, UserService>();

			return services;
		}
	}
}

