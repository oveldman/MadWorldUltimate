using System;
using MadWorld.Shared.Models.API.Links;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Admin.Info
{
    public partial class LinkGroupItem
    {
        [CascadingParameter]
        LinkGroupContainer Container { get; set; }

        [Parameter]
        public LinkGroupAdminDto LinkGroup { get; set; }

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
        private NavigationManager _navigation { get; set; }

        private void HandleDragStart(LinkGroupAdminDto selectedLinkGroup)
        {
            Container.Payload = selectedLinkGroup;
        }

        private void HandleDragEnter()
        {

            LastRowTouched = LinkGroup.RowOrder;
        }

        private void EditLinkGroup()
        {
            _navigation.NavigateTo($"/Admin/Links/{LinkGroup.Id}");
        }

        private void DeleteLinkGroup()
        {
            LinkGroup.IsDeleted = true;
            OnDeleteGroup.InvokeAsync();
        }
    }
}

