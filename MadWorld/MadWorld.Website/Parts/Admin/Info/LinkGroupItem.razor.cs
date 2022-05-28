using System;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkGroupItem : DragItem<LinkGroupAdminDto, LinkGroupContainer>
    {
        private void HandleDragStart(LinkGroupAdminDto selectedLinkGroup)
        {
            Container.Payload = selectedLinkGroup;
        }

        private void HandleDragEnter()
        {

            LastRowTouched = DragObject.RowOrder;
        }

        private void EditLinkGroup()
        {
            _navigation.NavigateTo($"/Admin/Links/{DragObject.Id}");
        }

        private void DeleteLinkGroup()
        {
            DragObject.IsDeleted = true;
            OnDeleteGroup.InvokeAsync();
        }
    }
}

