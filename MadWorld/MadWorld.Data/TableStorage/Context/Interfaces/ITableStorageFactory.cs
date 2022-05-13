using System;
namespace MadWorld.Data.TableStorage.Context.Interfaces
{
	public interface ITableStorageFactory
	{
		IResumeContext CreateResumeContext();
		IUserContext CreateUserContext();
	}
}

