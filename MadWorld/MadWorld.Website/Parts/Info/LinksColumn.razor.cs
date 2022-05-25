using System;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts.Info
{
	public partial class LinksColumn
	{
		[Parameter]
		public LinkGroupDto LinkGroup { get; set; } = new();
	}
}

