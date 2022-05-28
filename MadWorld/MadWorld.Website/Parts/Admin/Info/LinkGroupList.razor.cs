using System;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkGroupList : ComponentBase
    {
        [CascadingParameter] LinkGroupContainer Container { get; set; }
        [Parameter] public int ListColumnOrder { get; set; }
        [Parameter] public int[] AllowedColumnOrders { get; set; }

        List<LinkGroupAdminDto> LinkGroups = new();
        string dropClass = "";

        public int LastTouchedRow = 0;

        protected override void OnParametersSet()
        {
            LinkGroups.Clear();
            LinkGroups.AddRange(Container.LinkGroups.Where(x => x.ColumnOrder == ListColumnOrder && !x.IsDeleted).OrderBy(x => x.RowOrder));
        }

        private void AddNewLinkGroup(int columnOrder)
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

            Container.LinkGroups.Add(newLinkGroup);
            OnParametersSet();
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

        public void LastRowChanged(int indexRow)
        {
            LastTouchedRow = indexRow;
        }

        private async Task HandleDrop(DragEventArgs eventArgs)
        {
            dropClass = "";

            if (AllowedColumnOrders != null && !AllowedColumnOrders.Contains(Container.Payload.ColumnOrder)) return;

            int newRowId = GetRowID(ListColumnOrder, LastTouchedRow);
            UpdateRowOrderInColumn(ListColumnOrder, newRowId);
            await Container.UpdateJobAsync(ListColumnOrder, newRowId);
        }

        private bool ColumnChanged()
        {
            return Container.Payload.ColumnOrder != ListColumnOrder;
        }

        private int GetRowID(int columnOrder, int currentRowID)
        {
            if (currentRowID != -1)
            {
                return currentRowID;
            }

            if (LinkGroups.Any(g => g.ColumnOrder == columnOrder))
            {
                return LinkGroups.Where(g => g.ColumnOrder == columnOrder).Max(g => g.RowOrder) + 1;
            }

            return 0;
        }

        private void UpdateRowOrderInColumn(int columnOrder, int rowOrder)
        {
            LinkGroups.Where(g => g.ColumnOrder == columnOrder && g.RowOrder >= rowOrder)
                .ToList()
                .ForEach(g => g.RowOrder++);

            if (ColumnChanged())
            {
                LinkGroups.Where(g => g.ColumnOrder != columnOrder && g.RowOrder >= rowOrder)
                    .ToList()
                    .ForEach(g => g.RowOrder--);
            }
        }
    }
}

