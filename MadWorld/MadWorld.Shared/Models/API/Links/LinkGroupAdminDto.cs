using System;
namespace MadWorld.Shared.Models.API.Links
{
	public class LinkGroupAdminDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int RowOrder { get; set; }
		public int ColumnOrder { get; set; }
		public List<LinkAdminDto> Links { get; set; } = new();
	}
}

