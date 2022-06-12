using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin.Downloader
{
	public partial class EditDownload
	{
        [Parameter]
		public string ID { get; set; } = string.Empty;

		private bool IsNew => string.IsNullOrEmpty(ID);

        private string PageTitle = string.Empty;

        protected override void OnInitialized()
        {
            PageTitle = IsNew ? "New Download" : "Edit Download";
            StateHasChanged();
        }
    }
}

