using System;
namespace MadWorld.Shared.Models.AnonymousAPI.Info
{
	public class LinkGroupDto
	{
		public string Name { get; set; } = string.Empty;
		public List<LinkDto> Links { get; set; } = new();
	}
}

