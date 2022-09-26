using System;
using Azure;
using Azure.Storage.Blobs.Models;

namespace MadWorld.Data.BlobStorage.Interfaces
{
	public interface IBlobClient
	{
		Response<bool> DeleteIfExists();
		Response<BlobDownloadStreamingResult> DownloadStreaming(CancellationToken cancellationToken = default);
		Response<BlobContentInfo> Upload(Stream content, BlobHttpHeaders httpHeaders);
	}
}

