using System;
using MadWorld.Shared.Models.AnonymousAPI.Info;

namespace MadWorld.Business.Managers.Interfaces
{
	public interface ILinkManager
	{
		List<LinkGroupDto> GetLinks();
	}
}

