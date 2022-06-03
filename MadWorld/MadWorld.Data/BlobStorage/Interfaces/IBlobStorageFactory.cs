using System;
namespace MadWorld.Data.BlobStorage.Interfaces
{
	public interface IBlobStorageFactory
	{
		IBlobStorageContainer CreateContainer();
	}
}

