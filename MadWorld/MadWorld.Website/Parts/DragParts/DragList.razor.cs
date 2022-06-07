using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.DragParts
{
	public abstract partial class DragList<T, Y> : ComponentBase where Y : DragContainer<T> 
    {
        [CascadingParameter] protected Y Container { get; set; }
        [Parameter] public int ListColumnOrder { get; set; }
        [Parameter] public int[] AllowedColumnOrders { get; set; }

        private int LastTouchedRow = 0;

        protected List<T> DragItems = new();
        protected string dropClass = "";

        protected abstract void AddNewDragItem(int columnOrder);

        protected abstract int GetColumnOrderFromPayload();

        protected abstract int GetMaxRowNumber(int columnOrder);

        protected abstract bool HasColumnAnyItem(int columnOrder);

        protected abstract void UpdateRowOrderInColumn(int columnOrder, int rowOrder);

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
    }
}

