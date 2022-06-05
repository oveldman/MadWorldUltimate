using System;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Links;

namespace MadWorld.Business.Managers.Interfaces
{
	public interface ILinkAdminManager
	{
		ResponseLinkGroups GetLinkGroups();
		ResponseLinks TryGetLinks(string linkGroupId);
		CommonResponse SaveLinks(LinkGroupAdminDto linkGroup);
		CommonResponse SaveLinkGroups(List<LinkGroupAdminDto> linkGroups);
	}
}

