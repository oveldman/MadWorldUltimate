using MadWorld.Functions.Common.Managers;
using MadWorld.Functions.Common.Managers.Interfaces;
using MadWorld.Functions.Common.Validators;
using MadWorld.Functions.Common.Validators.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.Functions.Common;
public static class IFunctionsHostBuilderExtentions
{
    public static void AddMadWorldCommonClasses(this IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped<IUserManager, UserManager>();
        builder.Services.AddScoped<IUserValidator, UserValidator>();
    }
}

