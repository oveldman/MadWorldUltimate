using System;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Website.Parts;
using MadWorld.Website.Parts.Models;
using MadWorld.Website.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin.Info
{
	public partial class EditLinkGroups
	{
        private List<LinkGroupAdminDto> LinkGroups = new();
        private AlertStatus Status = new();
        private BootstrapAlerts _bootstrapAlerts = new();

        [Inject]
        private ILinkAdminService _linkService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LinkGroups = await _linkService.GetLinkGroups();
        }

        private static void HandleStatusUpdated(LinkGroupAdminDto  updatedLinkGroup)
        {
            Console.WriteLine(updatedLinkGroup.Name);
        }

        private async Task SaveLinkGroups()
        {
            _bootstrapAlerts.Reset();
            var response = await _linkService.SaveGroupLinks(LinkGroups);

            Status.ShowMessage = true;
            if (response.Succeed)
            {
                Status.SucceedMessage = "The link groups are saved now.";
            }
            else
            {
                Status.ErrorMessage = "There went something wrong while saving the groups.";
            }
        }
    }
}

