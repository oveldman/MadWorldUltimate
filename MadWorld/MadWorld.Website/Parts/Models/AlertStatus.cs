using System;
namespace MadWorld.Website.Parts.Models
{
	public class AlertStatus
	{
		public bool ShowMessage { get; set; } = false;
		public string ErrorMessage { get; set; } = string.Empty;
		public string SucceedMessage { get; set; } = string.Empty;
	}
}

