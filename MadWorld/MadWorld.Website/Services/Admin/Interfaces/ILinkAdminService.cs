using System;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Links;

namespace MadWorld.Website.Services.Admin.Interfaces
{
	public interface ILinkAdminService
	{
		Task<LinkGroupAdminDto> GetLinkFromGroup(string id);
		Task<List<LinkGroupAdminDto>> GetLinkGroups();
		Task<CommonResponse> SaveGroupLinks(List<LinkGroupAdminDto> linkGroups);
		Task<CommonResponse> SaveLinks(LinkGroupAdminDto linkGroup);
	}
}

