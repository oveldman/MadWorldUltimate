using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries.Interfaces;

public interface IStoryQueries
{
    Option<Story> GetConcept(CancellationToken cancellationToken);
    Option<Story> GetFinal(CancellationToken cancellationToken);
}