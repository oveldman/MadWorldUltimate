using System;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Website.Parts.DragParts;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkContainer : DragContainer<LinkAdminDto>
    {
        protected override bool TryToUpdateItem(int columnOrder, int rowOrder)
        {
            var linkGroup = DragItems.SingleOrDefault(x => x.Id == Payload.Id);

            if (linkGroup != null)
            {
                linkGroup.Order = rowOrder;
                return true;
            }

            return false;
        }
    }
}

