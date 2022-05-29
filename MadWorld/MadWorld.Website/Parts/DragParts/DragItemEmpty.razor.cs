using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.DragParts
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

