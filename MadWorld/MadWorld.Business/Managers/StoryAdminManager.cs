using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.BlobStorage;
using MadWorld.Data.BlobStorage.Extensions;
using MadWorld.Data.BlobStorage.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Stories;

namespace MadWorld.Business.Managers;

public class StoryAdminManager : IStoryAdminManager
{
    private readonly IBlobStorageContainer _blobContainer;
    private readonly IStoryQueries _storyQueries;
    private readonly IStoryMapper _storyMapper;
    
    public StoryAdminManager(IBlobStorageContainer blobContainer, IStoryMapper storyMapper, IStoryQueries storyQueries)
    {
        _blobContainer = blobContainer;
        _storyMapper = storyMapper;
        _storyQueries = storyQueries;
    }
    
    public ResponseStory GetConcept()
    {
        var story = _storyQueries.GetConcept();
        return Translate(story, true);
    }
    
    public ResponseStory GetFinal()
    {
        var story = _storyQueries.GetFinal();
        return Translate(story, false);
    }

    private ResponseStory Translate(Option<Story> storyOption, bool isConcept)
    {
        if (!storyOption.HasValue)
        {
            return new ResponseStory()
            {
                IsConcept = isConcept
            };   
        }

        var story = storyOption.ValueOr(new Story());
        var responseStory = _storyMapper.Translate<Story, ResponseStory>(story);
        responseStory.Found = true;
        responseStory.BodyBase64 = _blobContainer.DownloadBase64(story.GetBlobFileName(), BlobPathNames.Stories);

        return responseStory;
    }
}