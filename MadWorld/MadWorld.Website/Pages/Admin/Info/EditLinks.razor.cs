using System;
using MadWorld.Shared.Models.API.Links;

namespace MadWorld.Website.Pages.Admin.Info
{
	public partial class EditLinks
	{
        List<LinkGroupAdminDto> LinkGroups = new();

        protected override void OnInitialized()
        {
            LinkGroups.Add(new() { Id = Guid.NewGuid(), Name = "Test" });
            LinkGroups.Add(new() { Id = Guid.NewGuid(), Name = "Test 2", ColumnOrder = 1 });
            LinkGroups.Add(new() { Id = Guid.NewGuid(), Name = "Test 3", RowOrder = 1 });
            LinkGroups.Add(new() { Id = Guid.NewGuid(), Name = "Test 4", RowOrder = 1, ColumnOrder = 1 });
        }

        void HandleStatusUpdated(LinkGroupAdminDto  updatedLinkGroup)
        {
            Console.WriteLine(updatedLinkGroup.Name);
        }
    }
}

