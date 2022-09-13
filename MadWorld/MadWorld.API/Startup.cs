using MadWorld.Functions.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MadWorld.API.Startup))]
namespace MadWorld.API
{
	public sealed class Startup : FunctionsStartup
	{
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddMadWorldCommonClasses();
        }
    }
}

