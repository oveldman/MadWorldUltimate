using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries.Interfaces;

public interface IStoryQueries
{
    Option<Story> GetConcept();
    Option<Story> GetFinal();
}