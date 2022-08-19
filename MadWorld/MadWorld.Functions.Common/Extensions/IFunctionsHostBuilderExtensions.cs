using Ardalis.GuardClauses;
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

namespace MadWorld.Functions.Common.Extensions;
public static class IFunctionsHostBuilderExtensions
{
    public static void AddMadWorldCommonClasses(this IFunctionsHostBuilder builder)
    {
        IConfiguration? configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
        configuration = Guard.Against.Null(configuration, nameof(configuration))!;

        AddInternPackages(builder);
        AddExternPackages(builder, configuration);
    }

    private static void AddInternPackages(IFunctionsHostBuilder builder)
    {
        AddCommonFunctions(builder);
        AddBusinessLayer(builder);
        AddTableStorage(builder);
        AddBlobStorage(builder);
    }

    private static void AddCommonFunctions(IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped<IUserValidator, UserValidator>();
    }

    private static void AddBusinessLayer(IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped<ILinkAdminManager, LinkAdminManager>();
        builder.Services.AddScoped<ILinkManager, LinkManager>();
        builder.Services.AddScoped<IDownloadAdminManager, DownloadAdminManager>();
        builder.Services.AddScoped<IDownloadManager, DownloadManager>();
        builder.Services.AddScoped<IUserManager, UserManager>();
        builder.Services.AddSingleton<IDownloadMapper>(_ => DownloadMapper.Create());
        builder.Services.AddSingleton<ILinkMapper>(_ => LinkMapper.Create());
        builder.Services.AddSingleton<IUserMapper>(_ => UserMapper.Create());
    }

    private static void AddTableStorage(IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped<ITableStorageFactory, TableStorageFactory>();
        builder.Services.AddScoped<IDownloadQueries, DownloadQueries>();
        builder.Services.AddScoped<ILinkQueries, LinkQueries>();
        builder.Services.AddScoped<IResumeQueries, ResumeQueries>();
        builder.Services.AddScoped<IUserQueries, UserQueries>();
    }

    private static void AddBlobStorage(IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped<IBlobStorageContainer>(service => {
            var blobClient = service.GetRequiredService<BlobServiceClient>();
            return new BlobStorageContainer(blobClient, BlobContainerNames.MadWorldWebsite);
        });
    }

    private static void AddExternPackages(IFunctionsHostBuilder builder, IConfiguration configuration)
    {
        var azureStorageConnectionString = configuration["AzureWebJobsStorage"];

        builder.Services.AddScoped(_ => new BlobServiceClient(azureStorageConnectionString));
        builder.Services.AddScoped(_ => new TableServiceClient(azureStorageConnectionString));
    }
}

