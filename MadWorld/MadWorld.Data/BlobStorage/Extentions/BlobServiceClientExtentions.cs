using System;
using Azure.Storage.Blobs;
using MadWorld.Data.BlobStorage.Interfaces;

namespace MadWorld.Data.BlobStorage.Extentions
{
	public static class BlobServiceClientExtentions
	{
		public static IBlobContainerClient CreateIBlobContainer(this BlobServiceClient client, string name)
        {
			BlobContainerClient container = client.CreateBlobContainer(name);
			return new BlobContainerContext(container);
		}
	}
}

