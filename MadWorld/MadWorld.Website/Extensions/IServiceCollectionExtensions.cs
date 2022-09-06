using System;
using BlazorDownloadFile;
using BlazorTable;
using MadWorld.Blazor.Components.Monaco.Extensions;
using MadWorld.Shared.Factories;
using MadWorld.Shared.Factories.Interfaces;
using MadWorld.Shared.Managers;
using MadWorld.Shared.Managers.Interfaces;
using MadWorld.Website.Services;
using MadWorld.Website.Services.Admin;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Services.Info;
using MadWorld.Website.Services.Info.Interface;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Services.Tester;
using MadWorld.Website.Services.Tester.Interfaces;
using Radzen;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace MadWorld.Website.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddInternalClasses(this IServiceCollection services)
		{
			//Shared
			services.AddScoped<IMeasurementFactory, MeasurementFactory>();
			services.AddScoped<IMeasurementManager, MeasurementManager>();

			//Services
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IDownloadService, DownloadService>();
			services.AddScoped<IDownloadAdminService, DownloadAdminService>();
			services.AddScoped<ILinkService, LinkService>();
			services.AddScoped<ILinkAdminService, LinkAdminService>();
			services.AddScoped<ITesterService, TesterService>();
			services.AddScoped<IStoryService, StoryService>();
			services.AddScoped<IUserService, UserService>();

			return services;
		}

		public static IServiceCollection AddComponents(this IServiceCollection services)
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
			services.AddHttpClientInterceptor(); 

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();

            return services;
		}
	}
}

