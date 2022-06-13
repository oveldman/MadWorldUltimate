using System;
namespace MadWorld.Data.TableStorage.Context.Interfaces
{
	public interface ITableStorageFactory
	{
		ITableContext CreateDownloadContext();
		ITableContext CreateLinkContext();
		ITableContext CreateResumeContext();
		ITableContext CreateUserContext();
	}
}

