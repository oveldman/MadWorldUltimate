using System;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Admin.Info
{
	public partial class LinkGroupList : ComponentBase
	{
        [CascadingParameter] LinkGroupContainer Container { get; set; }
        [Parameter] public int ListColumnOrder { get; set; }
        [Parameter] public int[] AllowedColumnOrders { get; set; }

        List<LinkGroupAdminDto> LinkGroups = new();
        string dropClass = "";

        protected override void OnParametersSet()
        {
            LinkGroups.Clear();
            LinkGroups.AddRange(Container.LinkGroups.Where(x => x.ColumnOrder == ListColumnOrder));
        }

        private void HandleDragEnter()
        {
            if (ListColumnOrder == Container.Payload.ColumnOrder) return;

            if (AllowedColumnOrders != null && !AllowedColumnOrders.Contains(Container.Payload.ColumnOrder))
            {
                dropClass = "no-drop";
            }
            else
            {
                dropClass = "can-drop";
            }
        }

        private void HandleDragLeave()
        {
            dropClass = "";
        }

        private async Task HandleDrop()
        {
            dropClass = "";

            if (AllowedColumnOrders != null && !AllowedColumnOrders.Contains(Container.Payload.ColumnOrder)) return;

            await Container.UpdateJobAsync(ListColumnOrder);
        }
    }
}

