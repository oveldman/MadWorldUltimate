using MadWorld.Functions.Common.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(MadWorld.API.Anonymous.Startup))]
namespace MadWorld.API.Anonymous
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddMadWorldCommonClasses();
        }
    }
}

