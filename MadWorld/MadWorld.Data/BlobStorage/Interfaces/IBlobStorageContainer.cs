using System;
namespace MadWorld.Data.BlobStorage.Interfaces
{
	public interface IBlobStorageContainer
	{
		Stream Download(string fileName, string path = "");
		byte[] DownloadBytes(string fileName, string path = "");
		string DownloadString(string fileName, string path = "");
		bool Upload(string fileName, Stream body, string path = "");
		bool Upload(string fileName, byte[] body, string path = "");
		bool Upload(string fileName, string body, string path = "");
	}
}

