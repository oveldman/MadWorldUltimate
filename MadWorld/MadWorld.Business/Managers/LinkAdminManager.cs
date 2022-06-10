using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Extentions;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Links;

namespace MadWorld.Business.Managers
{
	public class LinkAdminManager : ILinkAdminManager
	{
		private readonly ILinkQueries _linkQueries;
        private readonly ILinkMapper _mapper;

		public LinkAdminManager(ILinkMapper mapper, ILinkQueries linkQueries)
		{
			_linkQueries = linkQueries;
            _mapper = mapper;
		}

        public ResponseLinkGroups GetLinkGroups()
        {
            List<LinkGroup> linkGroups = _linkQueries.GetLinkGroups();
            List<LinkGroupAdminDto> linkGroupsDto = _mapper.Translate<List<LinkGroup>, List<LinkGroupAdminDto>>(linkGroups);
            return new()
            {
                LinkGroups = linkGroupsDto
            };
        }

        public ResponseLinks TryGetLinks(string linkGroupId)
        {
            Option<LinkGroup> linkGroup = _linkQueries.GetLinkGroup(linkGroupId);

            if (linkGroup.HasValue)
            {
                return GetLinks(linkGroup.ValueOr(new LinkGroup()));
            }

            return new();
        }

        private ResponseLinks GetLinks(LinkGroup linkGroup)
        {
            List<Link> links = _linkQueries.GetLinks(linkGroup.RowKey);

            LinkGroupAdminDto linkGroupDto = _mapper.Translate<LinkGroup, LinkGroupAdminDto>(linkGroup);
            linkGroupDto.Links = _mapper.Translate<List<Link>, List<LinkAdminDto>>(links);

            return new()
            {
                LinkGroupFound = true,
                LinkGroup = linkGroupDto
            };
        }

        public CommonResponse SaveLinkGroups(List<LinkGroupAdminDto> linkGroups)
        {
            var succeed = true;

            foreach (var linkGroup in linkGroups)
            {
                succeed = SaveLinkGroup(linkGroup);

                if (!succeed) break;
            }

            return new()
            {
                Succeed = succeed
            };
        }

        private bool SaveLinkGroup(LinkGroupAdminDto linkGroup)
        {
            if (linkGroup.IsNew && linkGroup.IsDeleted)
            {
                return true;
            }

            if (linkGroup.IsNew)
            {
                return AddLinkGroup(linkGroup);
            }
            else
            {
                return EditLinkGroup(linkGroup);
            }
        }

        private bool AddLinkGroup(LinkGroupAdminDto linkGroupDto)
        {
            LinkGroup linkGroup = _mapper.Translate<LinkGroupAdminDto, LinkGroup>(linkGroupDto);
            linkGroup.RowKey = Guid.NewGuid().ToString();
            return !_linkQueries.AddLinkGroup(linkGroup);
        }

        private bool EditLinkGroup(LinkGroupAdminDto linkGroupDto)
        {
            Option<LinkGroup> linkGroupOption = _linkQueries.GetLinkGroup(linkGroupDto.Id.ToString());

            if (linkGroupOption.HasValue)
            {
                LinkGroup linkGroup = _mapper.Translate(linkGroupDto, linkGroupOption.ValueOr(new LinkGroup()));
                return !_linkQueries.UpdateLinkGroup(linkGroup);
            }

            return false;
        }

        public CommonResponse SaveLinks(LinkGroupAdminDto linkGroupDto)
        {
            var succeed = false;
            Option<LinkGroup> linkGroup = _linkQueries.GetLinkGroup(linkGroupDto.Id.ToString());

            if (linkGroup.HasValue && (linkGroupDto.Links?.Any() ?? false))
            {
                succeed = true;

                foreach (LinkAdminDto link in linkGroupDto.Links)
                {
                    succeed = SaveLink(link, linkGroupDto.Id);

                    if (!succeed) break;
                }
            }

            return new()
            {
                Succeed = succeed
            };
        }

        private bool SaveLink(LinkAdminDto link, Guid linkGroupId)
        {
            if (link.IsNew && link.IsDeleted)
            {
                return true;
            }

            if (link.IsNew)
            {
                return AddLink(link, linkGroupId);
            }
            else
            {
                return EditLink(link);
            }
        }

        private bool AddLink(LinkAdminDto linkDto, Guid linkGroupId)
        {
            Link link = _mapper.Translate<LinkAdminDto, Link>(linkDto);
            link.RowKey = Guid.NewGuid().ToString();
            link.LinkGroupId = linkGroupId.ToString();
            return !_linkQueries.AddLink(link);
        }

        private bool EditLink(LinkAdminDto linkDto)
        {
            Option<Link> linkOption = _linkQueries.GetLink(linkDto.Id.ToString());

            if (linkOption.HasValue)
            {
                Link link = _mapper.Translate(linkDto, linkOption.ValueOr(new Link()));
                return !_linkQueries.UpdateLink(link);
            }

            return false;
        }
    }
}

