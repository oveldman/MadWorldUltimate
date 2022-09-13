using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.AnonymousAPI.Info;

namespace MadWorld.Business.Managers
{
	public sealed class LinkManager : ILinkManager
	{
		private readonly ILinkQueries _linkQueries;
		private readonly ILinkMapper _mapper;

		public LinkManager(ILinkMapper mapper, ILinkQueries linkQueries)
		{
			_linkQueries = linkQueries;
			_mapper = mapper;
		}

        public List<LinkGroupDto> GetLinks()
        {
	        List<LinkGroup> linkGroups = _linkQueries.GetLinkGroups();
	        return linkGroups.Select(linkGroup => BuildGroupAndLinks(linkGroup)).ToList();
        }

		private LinkGroupDto BuildGroupAndLinks(LinkGroup linkGroup)
        {
			List<Link> links = _linkQueries.GetLinks(linkGroup.RowKey);

			LinkGroupDto linkGroupDto = _mapper.Translate<LinkGroup, LinkGroupDto>(linkGroup);
			linkGroupDto.Links = _mapper.Translate<List<Link>, List<LinkDto>>(links);
			return linkGroupDto;
		}
    }
}

