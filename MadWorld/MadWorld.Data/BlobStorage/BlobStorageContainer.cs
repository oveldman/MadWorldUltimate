using System;
using System.Text;
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

		public Stream Download(string fileName)
        {
			BlobClient client = _containerClient.GetBlobClient(fileName);

			var result = client.DownloadContent();
			var response = result.GetRawResponse();

			if (response.IsError)
            {
				return new MemoryStream();
            }

			return response.ContentStream ?? new MemoryStream();
		}

		public byte[] DownloadBytes(string fileName)
		{
			Stream body = Download(fileName);

            using var memoryStream = new MemoryStream();
            body.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

		public string DownloadString(string fileName)
        {
			byte[] body = DownloadBytes(fileName);
			return Encoding.Default.GetString(body);
		}

		public bool Upload(string fileName, Stream body)
        {
			BlobClient client = _containerClient.GetBlobClient(fileName);

			var result = client.Upload(body);
			var response = result.GetRawResponse();
			return !response.IsError;
		}

		public bool Upload(string fileName, byte[] body)
        {
			return Upload(fileName, new MemoryStream(body));
        }

		public bool Upload(string fileName, string body)
		{
			byte[] bodyBytes = Encoding.ASCII.GetBytes(body);
			return Upload(fileName, bodyBytes);
		}
	}
}

