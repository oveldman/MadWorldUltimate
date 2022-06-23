using System;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;
using MadWorld.Website.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace MadWorld.Website.Pages.Downloader;

public partial class Downloads
{
    private string ColumnStyleClass = "pointer";

    private IEnumerable<DownloadAnonymousDto> _downloadDtos = new List<DownloadAnonymousDto>();

    [Inject]
    private IDownloadService _downloadService { get; set; } = null!;

    [Inject]
    private NavigationManager _navigation { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        var response = await _downloadService.GetDownloads();
        _downloadDtos = response.Downloads;

        await base.OnInitializedAsync();
    }

    private void GetDownload(DataGridRowMouseEventArgs<DownloadAnonymousDto> downloadEvent)
    {
        _navigation.NavigateTo($"/Download/{downloadEvent.Data.Id}");
    }
}

