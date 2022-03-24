using System;
using MadWorld.Functions.Common;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MadWorld.API.Startup))]
namespace MadWorld.API
{
	public class Startup : FunctionsStartup
	{
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddMadWorldCommonClasses();
        }
    }
}

