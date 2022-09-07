using System.Net;
using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor;

namespace MadWorld.Website.Parts;

public partial class ServiceStatus
{
    [Inject] private NavigationManager _navigation { get; set; } = null!;
    private bool IsOnline { get; set; } = true;

    protected override void OnInitialized()
    {
        this.Interceptor.AfterSend += InterceptResponse!;
        
        base.OnInitialized();
    }

    private void InterceptResponse(object sender, HttpClientInterceptorEventArgs e)
    {
        if (!e.Response?.IsSuccessStatusCode ?? true)
        {
            var statusCode = e.Response?.StatusCode ?? HttpStatusCode.ServiceUnavailable;
            switch (statusCode)
            {
                case HttpStatusCode.ServiceUnavailable:
                    IsOnline = false;
                    _navigation.NavigateTo("/ServiceUnavailable");
                    break;
            }
        }
        else
        {
            IsOnline = true;   
        }
        
        StateHasChanged();
    }
}