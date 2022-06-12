using System;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Downloads;
using MadWorld.Website.Parts;
using MadWorld.Website.Parts.Models;
using MadWorld.Website.Services;
using MadWorld.Website.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace MadWorld.Website.Pages.Admin.Downloader
{
	public partial class EditDownload
	{
        [Parameter]
		public string ID { get; set; } = string.Empty;
        private int MaxSize = 10240000;

        private DownloadDto _downloadDto = new();

        private AlertStatus Status = new();
        private BootstrapAlerts _bootstrapAlerts = new();
        private bool PageLoaded = false;

        private bool IsNew => string.IsNullOrEmpty(ID);

        private string PageTitle = string.Empty;
        private string SaveButtonText = string.Empty;

        [Inject]
        private IDownloadAdminService _downloadService { get; set; } = new EmptyService();

        protected override async Task OnInitializedAsync()
        {
            PageTitle = IsNew ? "New Download" : "Edit Download";
            SaveButtonText = IsNew ? "Add Download" : "Update Download";

            if (!IsNew)
            {
                await GetDownload();
            }

            PageLoaded = true;
            StateHasChanged();
        }

        private async Task GetDownload()
        {
            ResponseDownload response = await _downloadService.GetDownload(ID);
            _downloadDto = response.Download;

            if (!response.Found)
            {
                SetError("File not found!");
            }
        }

        private async Task UploadFileToMemory(InputFileChangeEventArgs e)
        {
            _bootstrapAlerts.Reset();
            IBrowserFile browserFile = e.File;
            if (Validate(browserFile))
            {
                StreamContent fileContent = new StreamContent(browserFile.OpenReadStream(MaxSize));
                byte[] body = await fileContent.ReadAsByteArrayAsync();
                _downloadDto.BodyBase64 = Convert.ToBase64String(body);
                _downloadDto.Name = browserFile.Name;
                _downloadDto.Content = browserFile.ContentType;
                _downloadDto.Extention = Path.GetExtension(browserFile.Name)?.Replace(".", string.Empty) ?? string.Empty;
            }
        }

        private async Task SaveDownload()
        {
            _bootstrapAlerts.Reset();

            CommonResponse response = await _downloadService.SaveDownload(_downloadDto);

            if (response.Succeed)
            {
                _navigation.NavigateTo($"/Admin/Downloads");
            }
            else
            {
                SetError($"Something went wrong while saving this file.");
            }
        }

        private async Task DeleteDownload()
        {
            _bootstrapAlerts.Reset();
            CommonResponse response = await _downloadService.DeleteDownload(ID);

            if (response.Succeed)
            {
                _navigation.NavigateTo($"/Admin/Downloads");
            }
            else
            {
                SetError($"Something went wrong while deleting this file.");
            }
        }

        private bool Validate(IBrowserFile browserFile)
        {
            bool valid = browserFile.Size < (MaxSize - 1);

            if (!valid)
            {
                SetError($"File size cannot be higher then: {MaxSize / 1024} MB");
            }

            return valid;
        }

        private void SetError(string message)
        {
            Status.ShowMessage = true;
            Status.ErrorMessage = message;
        }
    }
}

