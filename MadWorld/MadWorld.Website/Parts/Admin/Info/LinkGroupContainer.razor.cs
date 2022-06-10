using System;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Website.Parts.DragParts;
using Microsoft.AspNetCore.Components;
using Optional;
using Optional.Collections;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkGroupContainer : DragContainer<LinkGroupAdminDto>
    {
        protected override bool TryToUpdateItem(int columnOrder, int rowOrder)
        {
            Option<LinkGroupAdminDto> linkGroupOption = DragItems.SingleOrNone(x => x.Id == Payload.Id);

            if (linkGroupOption.HasValue)
            {
                LinkGroupAdminDto linkGroup = linkGroupOption.ValueOr(new LinkGroupAdminDto());

                linkGroup.ColumnOrder = columnOrder;
                linkGroup.RowOrder = rowOrder;
                return true;
            }

            return false;
        }
    }
}

