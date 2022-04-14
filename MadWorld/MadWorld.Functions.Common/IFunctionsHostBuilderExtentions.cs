using Azure.Data.Tables;
using MadWorld.Business.Managers;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Data.TableStorage.Queries;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Functions.Common.Validators;
using MadWorld.Functions.Common.Validators.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.Functions.Common;
public static class IFunctionsHostBuilderExtentions
{
    public static void AddMadWorldCommonClasses(this IFunctionsHostBuilder builder)
    {
        var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();

        AddInternPackages(builder, configuration);
        AddExternPackages(builder, configuration);
    }

    private static void AddInternPackages(IFunctionsHostBuilder builder, IConfiguration configuration)
    {
        //Common function
        builder.Services.AddScoped<IUserManager, UserManager>();
        builder.Services.AddScoped<IUserValidator, UserValidator>();

        //Business

        //Data
        builder.Services.AddScoped<IUserQueries, UserQueries>();
    }

    private static void AddExternPackages(IFunctionsHostBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddScoped(_ => new TableServiceClient(configuration["AzureWebJobsStorage"]));
    }
}

