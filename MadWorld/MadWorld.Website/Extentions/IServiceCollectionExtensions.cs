using System;
using BlazorDownloadFile;
using BlazorTable;
using MadWorld.Blazor.Componets.Monaco.Extentions;
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

		public static IServiceCollection AddComponets(this IServiceCollection services)
		{
			//Services
			services.AddMonacoEditor();

			return services;
		}

		public static IServiceCollection AddPackages(this IServiceCollection services)
		{
			//Services
			services.AddBlazorTable();
			services.AddBlazorDownloadFile();

			return services;
		}
	}
}

