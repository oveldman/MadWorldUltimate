using Azure;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Info;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries;

public class StoryQueries : IStoryQueries
{
    private readonly ITableContext _context;

    public StoryQueries(ITableStorageFactory tableStorageFactory)
    {
        _context = tableStorageFactory.CreateStoryContext();
    }

    public Option<Story> GetConcept()
    {
        return Get(true);
    }

    public Option<Story> GetFinal()
    {
        return Get(false);
    }

    private Option<Story> Get(bool isConcept)
    {
        var stories = _context.Query<Story>(s => s.PartitionKey == PartitionKeys.Story && s.IsConcept == isConcept);
        return stories.FirstOrNone();
    }
}