using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Admin.Info
{
	public partial class DragContainer<T> : ComponentBase
	{
		[Parameter] public List<T> DragItems { get; set; }
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

        protected virtual bool TryToUpdateItem(int columnOrder, int rowOrder)
        {
            return true;
        }
    }
}

