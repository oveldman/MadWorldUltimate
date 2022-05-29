using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.DragParts
{
	public abstract partial class DragItem<T,Y> : ComponentBase where Y : DragContainer<T>
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

        protected abstract void HandleDragEnter();

        protected abstract void EditLinkGroup();

        protected abstract void DeleteLinkGroup();

        protected void HandleDragStart(T selectedLinkGroup)
        {
            Container.Payload = selectedLinkGroup;
        }
    }
}

