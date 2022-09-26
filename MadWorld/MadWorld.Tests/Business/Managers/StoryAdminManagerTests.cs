using System.Threading;
using MadWorld.Business.Managers;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.BlobStorage.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Stories;
using Shouldly;

namespace MadWorld.Tests.Business.Managers;

public class StoryAdminManagerTests
{
    [Theory]
    [AutoDomainData]
    public void GetConcept_NotFound_EmptyResponse(
        [Frozen] Mock<IStoryQueries> storyQueries,
        StoryAdminManager manager
        )
    {
        // No Test data

        // Setup
        storyQueries.Setup(s => s.GetConcept(It.IsAny<CancellationToken>())).Returns(Option.None<Story>());

        // Act
        var result = manager.GetConcept(default);

        // Assert
        result.IsConcept.ShouldBe(true);
        result.Found.ShouldBe(false);
        result.BodyBase64.ShouldBe(string.Empty);
        
        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public void GetConcept_FoundStory_NormalResponse(
        [Frozen] Mock<IBlobStorageContainer> container,
        [Frozen] Mock<IStoryMapper> mapper,
        [Frozen] Mock<IStoryQueries> storyQueries,
        StoryAdminManager manager,
        string base64Test,
        Story story
    )
    {
        // Test data
        story.IsConcept = true;
        var mockResponse = new ResponseStory()
        {
            Id = story.RowKey,
            Comment = story.Comment,
            IsConcept = story.IsConcept,
            BodyBase64 = string.Empty
        };

        // Setup
        container.Setup(c => 
            c.DownloadBase64(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(base64Test);
        mapper.Setup(m => 
                m.Translate<Story, ResponseStory>(It.IsAny<Story>()))
            .Returns(mockResponse);
        storyQueries.Setup(s => s.GetConcept(It.IsAny<CancellationToken>())).Returns(story.Some());

        // Act
        var result = manager.GetConcept(default);

        // Assert
        result.Id.ShouldBe(story.RowKey);
        result.Comment.ShouldBe(story.Comment);
        result.IsConcept.ShouldBe(true);
        result.Found.ShouldBe(true);
        result.BodyBase64.ShouldBe(base64Test);
        
        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public void GetFinal_NotFound_EmptyResponse(
        [Frozen] Mock<IStoryQueries> storyQueries,
        StoryAdminManager manager
    )
    {
        // No Test data

        // Setup
        storyQueries.Setup(s => s.GetFinal(It.IsAny<CancellationToken>())).Returns(Option.None<Story>());

        // Act
        var result = manager.GetFinal(default);

        // Assert
        result.IsConcept.ShouldBe(false);
        result.Found.ShouldBe(false);
        result.BodyBase64.ShouldBe(string.Empty);
        
        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public void GetFinal_FoundStory_NormalResponse(
        [Frozen] Mock<IBlobStorageContainer> container,
        [Frozen] Mock<IStoryMapper> mapper,
        [Frozen] Mock<IStoryQueries> storyQueries,
        StoryAdminManager manager,
        string base64Test,
        Story story
    )
    {
        // Test data
        story.IsConcept = false;
        var mockResponse = new ResponseStory()
        {
            Id = story.RowKey,
            Comment = story.Comment,
            IsConcept = story.IsConcept,
            BodyBase64 = string.Empty
        };

        // Setup
        container.Setup(c => 
                c.DownloadBase64(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .Returns(base64Test);
        mapper.Setup(m => 
                m.Translate<Story, ResponseStory>(It.IsAny<Story>()))
            .Returns(mockResponse);
        storyQueries.Setup(s => s.GetConcept(It.IsAny<CancellationToken>())).Returns(story.Some());

        // Act
        var result = manager.GetConcept(default);

        // Assert
        result.Id.ShouldBe(story.RowKey);
        result.Comment.ShouldBe(story.Comment);
        result.IsConcept.ShouldBe(false);
        result.Found.ShouldBe(true);
        result.BodyBase64.ShouldBe(base64Test);
        
        // No Teardown
    }
}