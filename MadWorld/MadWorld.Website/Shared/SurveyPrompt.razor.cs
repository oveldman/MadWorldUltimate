using System;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Shared
{
	public partial class SurveyPrompt
	{
		[Parameter]
		public string? Title { get; set; }
	}
}

