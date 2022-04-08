using System;
using MadWorld.Blazor.Componets.Monaco.Interop;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.Blazor.Componets.Monaco.Extentions
{
	public static class StartupExtentions
	{
        public static IServiceCollection AddMonacoEditor(this IServiceCollection services)
        {
            services.AddScoped<IMonacoJs, MonacoJs>();
            return services;
        }
    }
}

