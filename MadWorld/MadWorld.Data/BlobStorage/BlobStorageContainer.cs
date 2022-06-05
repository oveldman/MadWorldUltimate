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

		public Stream Download(string fileName, string path = "")
        {
			string filePath = Path.Combine(path, fileName);

			BlobClient client = _containerClient.GetBlobClient(filePath);

			var result = client.DownloadContent();
			var response = result.GetRawResponse();

			if (response.IsError)
            {
				return new MemoryStream();
            }

			return response.ContentStream ?? new MemoryStream();
		}

		public byte[] DownloadBytes(string fileName, string path = "")
		{
			Stream body = Download(fileName, path);

            using var memoryStream = new MemoryStream();
            body.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

		public string DownloadString(string fileName, string path = "")
        {
			byte[] body = DownloadBytes(fileName, path);
			return Encoding.Default.GetString(body);
		}

		public bool Upload(string fileName, Stream body, string path = "")
        {
			string filePath = Path.Combine(path, fileName);

			BlobClient client = _containerClient.GetBlobClient(filePath);

			var result = client.Upload(body);
			var response = result.GetRawResponse();
			return !response.IsError;
		}

		public bool Upload(string fileName, byte[] body, string path = "")
        {
			return Upload(fileName, new MemoryStream(body), path);
        }

		public bool Upload(string fileName, string body, string path = "")
		{
			byte[] bodyBytes = Encoding.ASCII.GetBytes(body);
			return Upload(fileName, bodyBytes, path);
		}
	}
}

