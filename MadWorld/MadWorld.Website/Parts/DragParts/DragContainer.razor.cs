using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.DragParts
{
    public abstract partial class DragContainer<T> : ComponentBase
    {
        [Parameter] public List<T> DragItems { get; set; } = new();
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<T> OnStatusUpdated { get; set; }

        public T Payload { get; set; }

        public async Task UpdateJobAsync(int columnOrder, int rowOrder)
        {
            if (TryToUpdateItem(columnOrder, rowOrder))
            {
                await OnStatusUpdated.InvokeAsync(Payload);
            }
        }

        protected abstract bool TryToUpdateItem(int columnOrder, int rowOrder);
    }
}

