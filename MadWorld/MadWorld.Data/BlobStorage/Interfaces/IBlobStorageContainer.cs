using System;
namespace MadWorld.Data.BlobStorage.Interfaces
{
	public interface IBlobStorageContainer
	{
		bool Delete(string fileName, string path = "");
		Stream Download(string fileName, string path = "", CancellationToken cancellationToken = default);
		byte[] DownloadBytes(string fileName, string path = "", CancellationToken cancellationToken = default);
		string DownloadBase64(string fileName, string path = "", CancellationToken cancellationToken = default);
		string DownloadString(string fileName, string path = "", CancellationToken cancellationToken = default);
		bool Upload(string fileName, Stream body, string contentType, string path = "");
		bool Upload(string fileName, byte[] body, string contentType, string path = "");
		bool Upload(string fileName, string body, string contentType, string path = "");
		bool UploadBase64(string fileName, string body, string contentType, string path = "");
	}
}

