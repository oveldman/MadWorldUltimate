using BlazorDownloadFile;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Downloader
{
	public partial class Download
	{
		[Inject] public IBlazorDownloadFileService _blazorDownloadFileService { get; set; }

        private string TestBase64 = "RGl0IGlzIGVlbiB0ZXh0IGZpbGUh";

        protected override async Task OnInitializedAsync()
        {
            await _blazorDownloadFileService.DownloadFile("Test.txt", TestBase64, "text/plain");
        }
    }
}

