using System;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries.Interfaces
{
	public interface IResumeQueries
	{
		Option<Resume> GetLast();
	}
}

