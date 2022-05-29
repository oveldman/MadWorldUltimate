using System;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Website.Parts.DragParts;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkItem : DragItem<LinkAdminDto, LinkContainer>
    {
        protected override void HandleDragEnter()
        {
            LastRowTouched = DragObject.Order;
        }

        protected override void EditLinkGroup()
        {
        }

        protected override void DeleteLinkGroup()
        {
            DragObject.IsDeleted = true;
            OnDeleteGroup.InvokeAsync();
        }
    }
}

