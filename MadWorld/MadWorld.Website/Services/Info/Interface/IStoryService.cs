using System;
using MadWorld.Shared.Models.AnonymousAPI.Info;

namespace MadWorld.Website.Services.Info.Interface
{
	public interface IStoryService
	{
        Task<ResponseStory> Get();
    }
}

