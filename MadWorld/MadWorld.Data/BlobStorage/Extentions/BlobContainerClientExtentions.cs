using System;
using Azure.Storage.Blobs;
using MadWorld.Data.BlobStorage.Interfaces;

namespace MadWorld.Data.BlobStorage.Extentions
{
	public static class BlobContainerClientExtentions
	{
		public static IBlobClient GetIBlobClient(this BlobContainerClient containerClient , string blobName)
        {
			var blobClient = containerClient.GetBlobClient(blobName);
			return new BlobFileClient(blobClient);
        }
	}
}

