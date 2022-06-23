using BlazorDownloadFile;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;
using MadWorld.Website.Services;
using MadWorld.Website.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Downloader
{
	public partial class Download
	{
        [Parameter]
        public string ID { get; set; } = string.Empty;

        [Inject] public IDownloadService _downloadService { get; set; } = null!;

        private bool _downloadFinished;
        private bool _downloadFound;
        private string _fileName = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            ResponseDownloadAnonymous response = await _downloadService.GetDownload(ID);
            _downloadFinished = response.Found;

            if (response.Found)
            {
                _fileName = response.Name;
                await _blazorDownloadFileService.DownloadFile(response.Name, response.BodyBase64, response.Content);
            }

            _downloadFound = true;

            await base.OnInitializedAsync();
        }
    }
}

