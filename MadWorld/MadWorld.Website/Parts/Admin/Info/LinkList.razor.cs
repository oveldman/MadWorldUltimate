using System;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Website.Parts.DragParts;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkList : DragList<LinkAdminDto, LinkContainer>
    {
        protected override void OnParametersSet()
        {
            DragItems.Clear();
            DragItems.AddRange(Container.DragItems.Where(x => !x.IsDeleted).OrderBy(x => x.Order));
        }

        protected override void AddNewDragItem(int columnOrder)
        {
            LinkAdminDto newLink = new()
            {
                Id = Guid.NewGuid(),
                IsNew = true,
                Name = string.Empty,
                Url = string.Empty,
                Order = GetRowID(columnOrder, -1)
            };

            Container.DragItems.Add(newLink);
            OnParametersSet();
        }

        protected override int GetColumnOrderFromPayload()
        {
            return 0;
        }

        protected override bool HasColumnAnyItem(int columnOrder)
        {
            return true;
        }

        protected override int GetMaxRowNumber(int columnOrder)
        {
            if (!DragItems.Any())
            {
                return 0;
            }


            return DragItems.Max(g => g.Order) + 1;
        }

        protected override void UpdateRowOrderInColumn(int columnOrder, int rowOrder)
        {
            DragItems.Where(g => g.Order >= rowOrder)
                .ToList()
                .ForEach(g => g.Order++);
        }
    }
}

