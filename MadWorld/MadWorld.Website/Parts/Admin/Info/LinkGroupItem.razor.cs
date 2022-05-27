using System;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Admin.Info
{
	public partial class LinkGroupItem
	{
        [CascadingParameter] LinkGroupContainer Container { get; set; }
        [Parameter] public LinkGroupAdminDto LinkGroup { get; set; }

        private void HandleDragStart(LinkGroupAdminDto selectedLinkGroup)
        {
            Container.Payload = selectedLinkGroup;
        }
    }
}

