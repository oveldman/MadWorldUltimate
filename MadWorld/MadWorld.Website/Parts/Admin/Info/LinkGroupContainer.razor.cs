using System;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkGroupContainer : DragContainer<LinkGroupAdminDto>
    {
        protected override bool TryToUpdateItem(int columnOrder, int rowOrder)
        {
            var linkGroup = DragItems.SingleOrDefault(x => x.Id == Payload.Id);

            if (linkGroup != null)
            {
                linkGroup.ColumnOrder = columnOrder;
                linkGroup.RowOrder = rowOrder;
                return true;
            }

            return false;
        }
    }
}

