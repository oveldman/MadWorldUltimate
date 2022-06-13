using System;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MadWorld.Data.BlobStorage.Interfaces;

namespace MadWorld.Data.BlobStorage
{
	public class BlobFileClient : IBlobClient
	{
		private readonly BlobClient _blobClient;

		public BlobFileClient(BlobClient client)
		{
			_blobClient = client;
		}

		public Response<bool> DeleteIfExists()
		{
			return _blobClient.DeleteIfExists();
		}

		public Response<BlobDownloadResult> DownloadContent()
        {
			return _blobClient.DownloadContent();
        }

		public Response<BlobContentInfo> Upload(Stream content, BlobHttpHeaders httpHeaders)
        {
			return _blobClient.Upload(content, httpHeaders);
		}
	}
}

