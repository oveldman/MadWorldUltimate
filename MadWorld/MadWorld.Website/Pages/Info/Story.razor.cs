using System;
using MadWorld.Website.Services.Info.Interface;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.Info
{
	public partial class Story
	{
        [Inject]
        private IStoryService _storyService { get; set; } = null!;

        private MarkupString body = new();

        protected override async Task OnInitializedAsync()
        {
            var response = await _storyService.Get();
            body = new MarkupString(response.Body);
            await base.OnInitializedAsync();
        }
    }
}

