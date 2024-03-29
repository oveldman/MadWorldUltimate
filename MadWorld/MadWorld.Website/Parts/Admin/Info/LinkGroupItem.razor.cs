﻿using System;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Website.Parts.DragParts;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkGroupItem : DragItem<LinkGroupAdminDto, LinkGroupContainer>
    {
        protected override void HandleDragEnter()
        {
            LastRowTouched = DragObject.RowOrder;
        }

        protected override void EditLinkGroup()
        {
            _navigation.NavigateTo($"/Admin/Links/{DragObject.Id}");
        }

        protected override void DeleteLinkGroup()
        {
            DragObject.IsDeleted = true;
            OnDeleteGroup.InvokeAsync();
        }
    }
}

