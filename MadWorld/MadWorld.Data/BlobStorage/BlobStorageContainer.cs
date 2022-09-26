using System;
using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MadWorld.Data.BlobStorage.Extensions;
using MadWorld.Data.BlobStorage.Interfaces;

namespace MadWorld.Data.BlobStorage
{
	public sealed class BlobStorageContainer : IBlobStorageContainer
	{
		private readonly IBlobContainerClient _containerClient;

		public BlobStorageContainer(BlobServiceClient blobServiceClient, string name)
        {
			_containerClient = blobServiceClient.CreateIBlobContainer(name);
        }

		public bool Delete(string fileName, string path = "")
        {
			string filePath = Path.Combine(path, fileName);
			IBlobClient client = _containerClient.GetBlobClient(filePath);
			return client.DeleteIfExists().Value;
		}

		public Stream Download(string fileName, string path = "", CancellationToken cancellationToken = default)
        {
			string filePath = Path.Combine(path, fileName);

			IBlobClient client = _containerClient.GetBlobClient(filePath);

			var result = client.DownloadStreaming();
			var response = result.GetRawResponse();

			if (response.IsError)
            {
				return new MemoryStream();
            }

			return result.Value.Content ?? new MemoryStream();
		}

		public byte[] DownloadBytes(string fileName, string path = "", CancellationToken cancellationToken = default)
		{
			Stream body = Download(fileName, path);

            using var memoryStream = new MemoryStream();
            body.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

		public string DownloadBase64(string fileName, string path = "", CancellationToken cancellationToken = default)
		{
			byte[] body = DownloadBytes(fileName, path);
			return Convert.ToBase64String(body);
		}

		public string DownloadString(string fileName, string path = "", CancellationToken cancellationToken = default)
        {
			byte[] body = DownloadBytes(fileName, path);
			return Encoding.Default.GetString(body);
		}

		public bool Upload(string fileName, Stream body, string contentType, string path = "")
        {
			string filePath = Path.Combine(path, fileName);

			IBlobClient client = _containerClient.GetBlobClient(filePath);

			BlobHttpHeaders blobHttpHeader = new()
			{
				ContentType = contentType
			};

			var result = client.Upload(body, blobHttpHeader);
			var response = result.GetRawResponse();
			return !response.IsError;
		}

		public bool Upload(string fileName, byte[] body, string contentType, string path = "")
        {
			return Upload(fileName, new MemoryStream(body), contentType, path);
        }

		public bool Upload(string fileName, string body, string contentType, string path = "")
		{
			byte[] bodyBytes = Encoding.ASCII.GetBytes(body);
			return Upload(fileName, bodyBytes, contentType, path);
		}

		public bool UploadBase64(string fileName, string body, string contentType, string path = "")
		{
			byte[] bodyBytes = Convert.FromBase64String(body);
			return Upload(fileName, bodyBytes, contentType, path);
		}
	}
}

