using System;
using Azure.Storage.Blobs;
using MadWorld.Data.BlobStorage.Interfaces;

namespace MadWorld.Data.BlobStorage.Extensions
{
	public static class BlobServiceClientExtensions
	{
		public static IBlobContainerClient CreateIBlobContainer(this BlobServiceClient client, string name)
        {
			BlobContainerClient container = CreateContainerIfNotExists(client, name);
			return new BlobContainerContext(container);
		}

		private static BlobContainerClient CreateContainerIfNotExists(BlobServiceClient client, string name)
        {
			var containers = client.GetBlobContainers();
			if (containers.Any(c => c.Name.Equals(name)))
            {
				return client.GetBlobContainerClient(name);
            }

			return client.CreateBlobContainer(name);
		}
	}
}

