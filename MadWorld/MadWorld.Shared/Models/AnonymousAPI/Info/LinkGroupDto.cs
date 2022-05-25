using System;
namespace MadWorld.Shared.Models.AnonymousAPI.Info
{
	public class LinkGroupDto
	{
		public string Name = string.Empty;
		public List<LinkDto> Links { get; set; } = new();
	}
}

