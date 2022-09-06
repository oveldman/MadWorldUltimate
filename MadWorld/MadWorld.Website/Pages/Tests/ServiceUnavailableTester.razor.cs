using MadWorld.Website.Services.Tester.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Tests;

public partial class ServiceUnavailableTester
{
    [Inject] public ITesterService Service { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await Service.GetServiceUnavailable();
        await base.OnInitializedAsync();
    }
}