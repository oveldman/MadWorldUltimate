using System;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkGroupList : DragList<LinkGroupAdminDto, LinkGroupContainer>
    {
        protected override void OnParametersSet()
        {
            DragItems.Clear();
            DragItems.AddRange(Container.DragItems.Where(x => x.ColumnOrder == ListColumnOrder && !x.IsDeleted).OrderBy(x => x.RowOrder));
        }

        protected override void AddNewDragItem(int columnOrder)
        {
            LinkGroupAdminDto newLinkGroup = new()
            {
                Id = Guid.NewGuid(),
                ColumnOrder = columnOrder,
                IsNew = true,
                Links = new(),
                Name = string.Empty,
                RowOrder = GetRowID(columnOrder, -1)
            };

            Container.DragItems.Add(newLinkGroup);
            OnParametersSet();
        }

        protected override int GetColumnOrderFromPayload()
        {
            return Container.Payload.ColumnOrder;
        }

        protected override bool HasColumnAnyItem(int columnOrder)
        {
            return DragItems.Any(g => g.ColumnOrder == columnOrder);
        }

        protected override int GetMaxRowNumber(int columnOrder)
        {
            return DragItems.Where(g => g.ColumnOrder == columnOrder).Max(g => g.RowOrder) + 1;
        }

        protected override void UpdateRowOrderInColumn(int columnOrder, int rowOrder)
        {
            DragItems.Where(g => g.ColumnOrder == columnOrder && g.RowOrder >= rowOrder)
                .ToList()
                .ForEach(g => g.RowOrder++);

            if (ColumnChanged())
            {
                DragItems.Where(g => g.ColumnOrder != columnOrder && g.RowOrder >= rowOrder)
                    .ToList()
                    .ForEach(g => g.RowOrder--);
            }
        }
    }
}

