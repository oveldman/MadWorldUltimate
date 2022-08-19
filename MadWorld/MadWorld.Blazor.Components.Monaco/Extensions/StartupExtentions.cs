using System;
using MadWorld.Blazor.Components.Monaco.Interop;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.Blazor.Components.Monaco.Extensions
{
	public static class StartupExtensions
	{
        public static IServiceCollection AddMonacoEditor(this IServiceCollection services)
        {
            services.AddScoped<IMonacoJs, MonacoJs>();
            return services;
        }
    }
}

