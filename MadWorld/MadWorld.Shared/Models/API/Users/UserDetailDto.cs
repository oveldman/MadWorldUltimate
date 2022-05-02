using System;
namespace MadWorld.Shared.Models.API.Users
{
	public class UserDetailDto : UserDto
	{
		public bool IsAdminstrator { get; set; }
		public bool IsViewer { get; set; }
	}
}

