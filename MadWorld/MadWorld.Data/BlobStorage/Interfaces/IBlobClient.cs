using System;
using Azure;
using Azure.Storage.Blobs.Models;

namespace MadWorld.Data.BlobStorage.Interfaces
{
	public interface IBlobClient
	{
		Response<bool> DeleteIfExists();
		Response<BlobDownloadResult> DownloadContent();
		Response<BlobContentInfo> Upload(Stream content, BlobHttpHeaders httpHeaders);
	}
}

