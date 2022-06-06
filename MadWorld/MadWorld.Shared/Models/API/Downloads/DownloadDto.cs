using System;
namespace MadWorld.Shared.Models.API.Downloads
{
	public class DownloadDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }
		public string Extention { get; set; }
		public string BodyBase64 { get; set; }
		public DateTime Created { get; set; }
	}
}

