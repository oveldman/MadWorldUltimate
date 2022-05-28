using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Admin.Info
{
	public partial class DragItem<T,Y> where Y : DragContainer<T>
	{
        [CascadingParameter]
        protected Y Container { get; set; }

        [Parameter]
        public T DragObject { get; set; }

        [Parameter]
        public EventCallback<int> OnLastRowTouchedChanged { get; set; }

        [Parameter]
        public EventCallback OnDeleteGroup { get; set; }

        private int lastRowTouched = 0;
        public int LastRowTouched
        {
            get => lastRowTouched;
            set
            {
                lastRowTouched = value;
                // Invoke the delegate passing it the changed value
                OnLastRowTouchedChanged.InvokeAsync(value);
            }
        }

        [Inject]
        protected NavigationManager _navigation { get; set; }

        protected void HandleDragStart(T selectedLinkGroup)
        {
            Container.Payload = selectedLinkGroup;
        }

        protected virtual void HandleDragEnter()
        {
        }

        protected virtual void EditLinkGroup()
        {
        }

        protected virtual void DeleteLinkGroup()
        {
            OnDeleteGroup.InvokeAsync();
        }
    }
}

