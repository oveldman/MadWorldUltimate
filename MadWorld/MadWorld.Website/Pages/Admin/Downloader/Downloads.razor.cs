using System;
using MadWorld.Shared.Models.API.Downloads;
using MadWorld.Website.Services;
using MadWorld.Website.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin.Downloader
{
	public partial class Downloads
	{
		private List<DownloadDto> _downloadDtos = new();

		private bool PageLoaded = false;

        [Inject]
		private IDownloadAdminService _downloadService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            _downloadDtos = await _downloadService.GetDownloads();
            PageLoaded = true;
            await base.OnInitializedAsync();
        }

        private void OpenDownload(DownloadDto download)
        {
            _navigation.NavigateTo($"/Admin/EditDownload/{download.Id}");
        }

        private async Task DeleteDownload(DownloadDto download)
        {
            _downloadDtos.Remove(download);
            await _downloadService.DeleteDownload(download.Id);
        }

        private void NewDownload()
        {
            _navigation.NavigateTo($"/Admin/NewDownload");
        }
    }
}

