using Azure.Data.Tables;
using MadWorld.Business.Managers;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Context;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Queries;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Functions.Common.Validators;
using MadWorld.Functions.Common.Validators.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.Functions.Common.Extentions;
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
        builder.Services.AddScoped<IUserMapper, UserMapper>();

        //Data
        builder.Services.AddScoped<TableStorageFactory>();
        builder.Services.AddScoped<IResumeQueries, ResumeQueries>();
        builder.Services.AddScoped<IUserQueries, UserQueries>();

        AddInternContexts(builder);
    }

    private static void AddInternContexts(IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped(provider =>
        {
            TableStorageFactory factory = provider.GetRequiredService<TableStorageFactory>();
            return factory.CreateResumeContext();
        });

        builder.Services.AddScoped(provider =>
        {
            TableStorageFactory factory = provider.GetRequiredService<TableStorageFactory>();
            return factory.CreateUserContext();
        });
    }

    private static void AddExternPackages(IFunctionsHostBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddScoped(_ => new TableServiceClient(configuration["AzureWebJobsStorage"]));
    }
}

