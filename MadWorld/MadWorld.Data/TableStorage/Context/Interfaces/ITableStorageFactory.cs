using System;
namespace MadWorld.Data.TableStorage.Context.Interfaces
{
	public interface ITableStorageFactory
	{
		ITableContext CreateResumeContext();
		ITableContext CreateUserContext();
	}
}

