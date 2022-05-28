using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Admin.Info
{
	public partial class DragItemEmpty
	{
        [Parameter]
        public EventCallback<int> OnLastRowTouchedChanged { get; set; }

        private void HandleDragEnter()
        {
            OnLastRowTouchedChanged.InvokeAsync(-1);
        }
    }
}

