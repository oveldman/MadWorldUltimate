using MadWorld.Shared.Models.API.Stories;

namespace MadWorld.Business.Managers.Interfaces;

public interface IStoryAdminManager
{
    ResponseStory GetConcept();
    ResponseStory GetFinal();
}