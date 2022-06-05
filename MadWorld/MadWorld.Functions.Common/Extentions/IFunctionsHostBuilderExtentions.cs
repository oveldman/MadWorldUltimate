using Azure.Data.Tables;
using Azure.Storage.Blobs;
using MadWorld.Business.Managers;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.BlobStorage;
using MadWorld.Data.BlobStorage.Interfaces;
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
        var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>() ?? throw new ArgumentNullException(nameof(IConfiguration), "Not Found");

        AddInternPackages(builder, configuration);
        AddExternPackages(builder, configuration);
    }

    private static void AddInternPackages(IFunctionsHostBuilder builder, IConfiguration configuration)
    {
        //Common function
        builder.Services.AddScoped<IUserValidator, UserValidator>();

        //Business
        builder.Services.AddScoped<ILinkAdminManager, LinkAdminManager>();
        builder.Services.AddScoped<ILinkManager, LinkManager>();
        builder.Services.AddScoped<IUserManager, UserManager>();
        builder.Services.AddScoped<IUserMapper, UserMapper>();
        builder.Services.AddScoped<ILinkMapper, LinkMapper>();

        //Data
        builder.Services.AddScoped<ITableStorageFactory, TableStorageFactory>();
        builder.Services.AddScoped<ILinkQueries, LinkQueries>();
        builder.Services.AddScoped<IResumeQueries, ResumeQueries>();
        builder.Services.AddScoped<IUserQueries, UserQueries>();

        AddBlobStorage(builder);
    }

    private static void AddBlobStorage(IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped<IBlobStorageContainer>(service => {
            var blobClient = service.GetRequiredService<BlobServiceClient>();
            return new BlobStorageContainer(blobClient, BlobContainerNames.MadWorldBlob);
        });
    }

    private static void AddExternPackages(IFunctionsHostBuilder builder, IConfiguration configuration)
    {
        string azureStorageConnectionString = configuration["AzureWebJobsStorage"];

        builder.Services.AddScoped(_ => new BlobServiceClient(azureStorageConnectionString));
        builder.Services.AddScoped(_ => new TableServiceClient(azureStorageConnectionString));
    }
}

