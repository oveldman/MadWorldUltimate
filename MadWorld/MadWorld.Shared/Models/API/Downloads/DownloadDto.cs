using System;
namespace MadWorld.Shared.Models.API.Downloads
{
	public class DownloadDto
	{
		public string Id { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public string Extention { get; set; } = string.Empty;
		public string BodyBase64 { get; set; } = string.Empty;
		public DateTime Created { get; set; }
	}
}

