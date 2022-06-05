﻿using MadWorld.Shared.Models.AnonymousAPI.Info;
using MadWorld.Website.Services.Info.Interface;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Info
{
	public partial class Links
	{
		[Inject] public ILinkService _linkService { get; set; }

		private int MaxRows => _linkGroup.Any() ? GetMaxRows() : 0;
		private List<LinkGroupDto> _linkGroup { get; set; } = new();

		protected override async Task OnInitializedAsync()
		{
			_linkGroup = await _linkService.GetAll();
			_linkGroup = _linkGroup.OrderBy(g => g.ColumnOrder)
									.ThenBy(g => g.RowOrder)
									.ToList();

			await base.OnInitializedAsync();
			StateHasChanged();
		}

		private int GetMaxRows()
        {
			return _linkGroup.Max(g => g.RowOrder) + 1;
		}

		private bool TryFindGroup(int rowNumber, int columnNumber, out LinkGroupDto linkGroup)
        {
			linkGroup = _linkGroup.FirstOrDefault(g => g.RowOrder == rowNumber && g.ColumnOrder == columnNumber);
			return linkGroup is not null;
        }
	}
}

