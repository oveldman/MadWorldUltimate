using System;
using Azure.Storage.Blobs;
using MadWorld.Data.BlobStorage.Interfaces;

namespace MadWorld.Data.BlobStorage
{
	public class BlobStorageFactory : IBlobStorageFactory
	{
        private BlobServiceClient _blobServiceClient;

        public BlobStorageFactory(BlobServiceClient blobServiceClient)
		{
            _blobServiceClient = blobServiceClient;
		}

        public IBlobStorageContainer CreateContainer()
        {
            return new BlobStorageContainer(_blobServiceClient, BlobContainerNames.Download);
        }
    }
}

