using System;
namespace MadWorld.Data.BlobStorage.Interfaces
{
	public interface IBlobContainerClient
	{
		IBlobClient GetBlobClient(string blobName);
	}
}

