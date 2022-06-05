using System;
namespace MadWorld.Shared.Models.API.Links
{
	public class ResponseLinks
	{
		public bool LinkGroupFound { get; set; }
		public LinkGroupAdminDto LinkGroup { get; set; } = new();
	}
}

