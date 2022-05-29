using System;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Website.Parts;
using MadWorld.Website.Parts.Models;
using MadWorld.Website.Services.Admin.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Admin.Info
{
    public partial class EditLinks
    {
        [Parameter]
        public string Id { get; set; }

        private LinkGroupAdminDto Group = new();

        private AlertStatus Status = new();
        private BootstrapAlerts _bootstrapAlerts;

        [Inject]
        private ILinkAdminService _linkService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Group = await _linkService.GetLinkFromGroup(Id);
        }

        private void HandleStatusUpdated(LinkAdminDto updatedLink)
        {
            Console.WriteLine(updatedLink.Name);
        }

        private async Task SaveLinks()
        {
            _bootstrapAlerts.Reset();

            var response = await _linkService.SaveLinks(Group);
            Status.ShowMessage = true;
            if (response.Succeed)
            {
                Status.SucceedMessage = "The links are saved now.";
            }
            else
            {
                Status.ErrorMessage = "There went something wrong while saving the links.";
            }
        }
    }
}


