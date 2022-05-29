using System;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin.Info
{
	public partial class EditLinks
	{
        [Parameter]
		public string Id { get; set; }

        LinkGroupAdminDto Group = new();

        protected override void OnInitialized()
        {
            Group.Links.Add(new() { Id = Guid.NewGuid(), Name = "Test Website", Url = "https://www.google.nl", Order = 0 });
            Group.Links.Add(new() { Id = Guid.NewGuid(), Name = "Test Website 2", Url = "https://www.google2.nl", Order = 1 });
            Group.Links.Add(new() { Id = Guid.NewGuid(), Name = "Test Website 3", Url = "https://www.google3.nl", Order = 2 });
        }

        private void HandleStatusUpdated(LinkAdminDto updatedLink)
        {
            Console.WriteLine(updatedLink.Name);
        }

        private void SaveLinks()
		{

		}
	}
}

