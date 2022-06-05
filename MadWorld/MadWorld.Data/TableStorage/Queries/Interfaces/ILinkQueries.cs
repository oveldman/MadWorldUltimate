using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries.Interfaces
{
	public interface ILinkQueries
	{
		bool AddLink(Link link);
		bool AddLinkGroup(LinkGroup linkGroup);
		Link GetLink(string linkId);
		List<Link> GetLinks(string linkGroupId);
		List<LinkGroup> GetLinkGroups();
		LinkGroup GetLinkGroup(string linkGroupId);
		bool UpdateLink(Link link);
		bool UpdateLinkGroup(LinkGroup linkGroup);
	}
}

