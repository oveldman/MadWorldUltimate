using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.TableStorage.Queries.Interfaces
{
	public interface ILinkQueries
	{
		bool AddLink(Link link);
		bool AddLinkGroup(LinkGroup linkGroup);
		Option<Link> GetLink(string linkId);
		List<Link> GetLinks(string linkGroupId);
		List<LinkGroup> GetLinkGroups();
		Option<LinkGroup> GetLinkGroup(string linkGroupId);
		bool UpdateLink(Link link);
		bool UpdateLinkGroup(LinkGroup linkGroup);
	}
}

