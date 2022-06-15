using System;
using System.ComponentModel.DataAnnotations;

namespace MadWorld.Shared.Models.API.Downloads
{
	public class DownloadDto
	{
		public string Id { get; set; } = string.Empty;
        [Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public string Content { get; set; } = string.Empty;
		[Required]
		public string Extention { get; set; } = string.Empty;
		[Required]
		public string BodyBase64 { get; set; } = string.Empty;
		public DateTimeOffset? Created { get; set; }
		public bool IsNew { get; set; }
	}
}

