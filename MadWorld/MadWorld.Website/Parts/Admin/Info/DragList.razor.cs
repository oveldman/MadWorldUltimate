using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MadWorld.Website.Parts.Admin.Info
{
	public partial class DragList<T, Y> : ComponentBase where Y : DragContainer<T> 
    {
        [CascadingParameter] protected Y Container { get; set; }
        [Parameter] public int ListColumnOrder { get; set; }
        [Parameter] public int[] AllowedColumnOrders { get; set; }

        public int LastTouchedRow = 0;

        protected List<T> DragItems = new();
        protected string dropClass = "";

        protected override void OnParametersSet()
        {
        }

        protected virtual void AddNewDragItem(int columnOrder)
        {
            OnParametersSet();
        }

        protected virtual int GetColumnOrderFromPayload()
        {
            return 0;
        }

        protected void HandleDragEnter()
        {
            if (ListColumnOrder == GetColumnOrderFromPayload()) return;

            if (AllowedColumnOrders != null && !AllowedColumnOrders.Contains(GetColumnOrderFromPayload()))
            {
                dropClass = "no-drop";
            }
            else
            {
                dropClass = "can-drop";
            }
        }

        protected void HandleDragLeave()
        {
            dropClass = "";
        }

        public void LastRowChanged(int indexRow)
        {
            LastTouchedRow = indexRow;
        }

        protected async Task HandleDrop()
        {
            dropClass = "";

            if (AllowedColumnOrders != null && !AllowedColumnOrders.Contains(GetColumnOrderFromPayload())) return;

            int newRowId = GetRowID(ListColumnOrder, LastTouchedRow);
            UpdateRowOrderInColumn(ListColumnOrder, newRowId);
            await Container.UpdateJobAsync(ListColumnOrder, newRowId);
        }

        protected bool ColumnChanged()
        {
            return GetColumnOrderFromPayload() != ListColumnOrder;
        }

        protected int GetRowID(int columnOrder, int currentRowID)
        {
            if (currentRowID != -1)
            {
                return currentRowID;
            }

            if (HasColumnAnyItem(columnOrder))
            {
                return GetMaxRowNumber(columnOrder);
            }

            return 0;
        }

        protected virtual int GetMaxRowNumber(int columnOrder)
        {
            return 0;
        }

        protected virtual bool HasColumnAnyItem(int columnOrder)
        {
            return true;
        }

        protected virtual void UpdateRowOrderInColumn(int columnOrder, int rowOrder)
        {
        }
    }
}

