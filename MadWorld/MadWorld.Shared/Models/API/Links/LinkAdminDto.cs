using System;
namespace MadWorld.Shared.Models.API.Links
{
	public class LinkAdminDto
	{
		public Guid Id { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsNew { get; set; }
		public int Order { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
	}
}

