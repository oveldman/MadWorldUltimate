using System;
namespace MadWorld.Shared.Models.API.Downloads
{
	public class ResponseDownload
	{
		public bool Found { get; set; }
		public DownloadDto Download { get; set; } = new();
	}
}

