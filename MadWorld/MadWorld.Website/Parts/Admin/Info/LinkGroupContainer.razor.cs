using System;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Admin.Info
{
	public partial class LinkGroupContainer : ComponentBase
	{
        [Parameter] public List<LinkGroupAdminDto> LinkGroups { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<LinkGroupAdminDto> OnStatusUpdated { get; set; }

        public LinkGroupAdminDto Payload { get; set; }

        public async Task UpdateJobAsync(int columnOrder, int rowOrder)
        {
            var linkGroup = LinkGroups.SingleOrDefault(x => x.Id == Payload.Id);

            if (linkGroup != null)
            {
                linkGroup.ColumnOrder = columnOrder;
                linkGroup.RowOrder = rowOrder;
                await OnStatusUpdated.InvokeAsync(Payload);
            }
        }
    }
}

