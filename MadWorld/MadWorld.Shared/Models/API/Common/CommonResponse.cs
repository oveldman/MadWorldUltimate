using System;
using System.Text.Json.Serialization;

namespace MadWorld.Shared.Models.API.Common
{
	public class CommonResponse
	{
		public bool Succeed { get; set; }
		public List<string> ErrorMessages { get; set; } = new();
		[JsonIgnore]
		public string ErrorMessage
        {
			get
            {
				return ErrorMessages.Any() ? ErrorMessages.First() : string.Empty;
            }
			set
            {
				ErrorMessages = new();
				ErrorMessages.Add(value);
            }
        }
	}
}

