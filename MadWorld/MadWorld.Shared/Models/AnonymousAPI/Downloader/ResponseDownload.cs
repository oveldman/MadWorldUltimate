using System;
namespace MadWorld.Shared.Models.AnonymousAPI.Downloader
{
	public class ResponseDownload
	{
		public bool Found { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Base64 { get; set; } = string.Empty;
		public string ContentType { get; set; } = string.Empty;
	}
}

