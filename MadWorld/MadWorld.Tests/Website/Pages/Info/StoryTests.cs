using Bunit;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using MadWorld.Website.Pages.Info;
using MadWorld.Website.Services.Info.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.Tests.Website.Pages.Info;

public class StoryTests
{
    [Theory]
    [AutoDomainData]
    public void OnInitializedAsync_None_ShowStoryOnPage(Mock<IStoryService> storyService)
    {
        // Arrange
        const string testText = "<b>Random Test</b>";
        
        using var ctx = new TestContext();
        ResponseStory responseStory = new()
        {
            Body = testText
        };
        
        storyService.Setup(ss => ss.Get()).ReturnsAsync(responseStory);
        ctx.Services.AddScoped(_ => storyService.Object);
        
        // Act
        var cutComponent = ctx.RenderComponent<Story>();

        // Assert
        cutComponent.Find("#telling-story").InnerHtml.MarkupMatches(testText);
    }
}