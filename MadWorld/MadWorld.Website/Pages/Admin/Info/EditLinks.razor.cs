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

        [Inject]
        private NavigationManager _navigation { get; set; }

        private bool PageLoaded = false;
        private bool GroupFound = false;
        private LinkGroupAdminDto Group = new();

        private AlertStatus Status = new();
        private BootstrapAlerts _bootstrapAlerts = new();

        [Inject]
        private ILinkAdminService _linkService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await _linkService.GetLinkFromGroup(Id);
            Group = response.LinkGroup;
            GroupFound = response.LinkGroupFound;
            PageLoaded = true;

            if (!GroupFound)
            {
                SetGroupNotFoundMessage();
            }
        }

        private void SetGroupNotFoundMessage()
        {
            Status.ShowMessage = true;
            Status.ErrorMessage = $"This group with id {Id} is not found";
        }

        private static void HandleStatusUpdated(LinkAdminDto updatedLink)
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

        private void ReturnLinkGroups()
        {
            _navigation.NavigateTo($"/Admin/LinkGroups");
        }
    }
}


