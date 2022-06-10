using System;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Website.Parts.DragParts;
using Optional;
using Optional.Collections;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkContainer : DragContainer<LinkAdminDto>
    {
        protected override bool TryToUpdateItem(int columnOrder, int rowOrder)
        {
            Option<LinkAdminDto> linkOption = DragItems.SingleOrNone(x => x.Id == Payload.Id);

            if (linkOption.HasValue)
            {
                LinkAdminDto link = linkOption.ValueOr(new LinkAdminDto());
                link.Order = rowOrder;
                return true;
            }

            return false;
        }
    }
}

