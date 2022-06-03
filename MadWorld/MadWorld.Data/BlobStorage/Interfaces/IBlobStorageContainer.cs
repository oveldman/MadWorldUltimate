using System;
namespace MadWorld.Data.BlobStorage.Interfaces
{
	public interface IBlobStorageContainer
	{
		Stream Download(string fileName);
		byte[] DownloadBytes(string fileName);
		string DownloadString(string fileName);
		bool Upload(string fileName, Stream body);
		bool Upload(string fileName, byte[] body);
		bool Upload(string fileName, string body);
	}
}

