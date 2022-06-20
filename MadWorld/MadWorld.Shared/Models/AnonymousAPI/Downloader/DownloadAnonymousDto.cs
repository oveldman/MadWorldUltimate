using System;
namespace MadWorld.Shared.Models.AnonymousAPI.Downloader
{
	public class DownloadAnonymousDto
	{
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string BodyBase64 { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}

