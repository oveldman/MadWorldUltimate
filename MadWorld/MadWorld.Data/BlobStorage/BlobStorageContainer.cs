using System;
using Azure.Storage.Blobs;
using MadWorld.Data.BlobStorage.Interfaces;

namespace MadWorld.Data.BlobStorage
{
	public class BlobStorageContainer : IBlobStorageContainer
	{
		private BlobContainerClient _containerClient;

		public BlobStorageContainer(BlobServiceClient blobServiceClient, string name)
        {
			_containerClient = blobServiceClient.CreateBlobContainer(name);
        }
	}
}

