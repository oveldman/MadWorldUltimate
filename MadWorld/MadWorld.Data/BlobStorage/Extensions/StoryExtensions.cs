using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.BlobStorage.Extensions;

public static class StoryExtensions
{
    public static string GetBlobFileName(this Story story)
    {
        var fileName = story.IsConcept ? "concept" : "final";
        return $"{fileName}.html";
    }
}