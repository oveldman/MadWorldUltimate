using System;
using System.ComponentModel.DataAnnotations;

namespace MadWorld.Shared.Models.API.Users
{
	public class UserDto
	{
		[Required]
		public string ID { get; set; } = string.Empty;
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
	}
}

