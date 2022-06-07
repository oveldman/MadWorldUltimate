using System;
using Azure;
using MadWorld.Data.TableStorage.Context.Interfaces;
using MadWorld.Data.TableStorage.Info;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries
{
	public class LinkQueries : ILinkQueries
	{
        private readonly ITableContext _context;

        public LinkQueries(ITableStorageFactory tableStorageFactory)
        {
            _context = tableStorageFactory.CreateLinkContext();
        }

        public bool AddLink(Link link)
        {
            Response response = _context.AddEntity(link);
            return response.IsError;
        }

        public bool AddLinkGroup(LinkGroup linkGroup)
        {
            Response response = _context.AddEntity(linkGroup);
            return response.IsError;
        }

        public Link GetLink(string linkId)
        {
            var link = _context.Query<Link>(g => g.PartitionKey == PartitionKeys.LinkGroup
                                            && g.RowKey == linkId).ToList() ?? new();
            return link.FirstOrDefault();
        }

        public LinkGroup GetLinkGroup(string linkGroupId)
        {
            var linkGroups = _context.Query<LinkGroup>(g => g.PartitionKey == PartitionKeys.LinkGroup
                                                        && g.RowKey == linkGroupId).ToList() ?? new();
            return linkGroups.FirstOrDefault();
        }

        public List<LinkGroup> GetLinkGroups()
        {
            var linkGroups = _context.Query<LinkGroup>(g => g.PartitionKey == PartitionKeys.LinkGroup).ToList() ?? new();
            return linkGroups.Where(g => !g.IsDeleted).ToList();
        }

        public List<Link> GetLinks(string linkGroupId)
        {
            var links = _context.Query<Link>(l => l.PartitionKey == PartitionKeys.Link
                                            && l.LinkGroupId == linkGroupId).ToList() ?? new();
            return links.Where(l => !l.IsDeleted).ToList();
        }

        public bool UpdateLink(Link link)
        {
            Response response = _context.UpdateEntity(link, ETag.All);
            return response.IsError;
        }

        public bool UpdateLinkGroup(LinkGroup linkGroup)
        {
            Response response = _context.UpdateEntity(linkGroup, ETag.All);
            return response.IsError;
        }
    }
}

