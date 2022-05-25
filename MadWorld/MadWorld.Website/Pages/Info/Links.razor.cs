using MadWorld.Shared.Models.AnonymousAPI.Info;
using MadWorld.Website.Services.Info.Interface;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Info
{
	public partial class Links
	{
		[Inject] public ILinkService _linkService { get; set; }

		private List<LinkGroupDto> _linkGroup { get; set; } = new();

		protected override async Task OnInitializedAsync()
		{
			_linkGroup = await _linkService.GetAll();

			await base.OnInitializedAsync();
		}
	}
}

