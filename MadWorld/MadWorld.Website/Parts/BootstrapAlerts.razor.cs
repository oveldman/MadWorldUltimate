using System;
using MadWorld.Website.Parts.Models;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Parts
{
	public partial class BootstrapAlerts
	{
		[Parameter]
		public AlertStatus Status { get; set; } = new();

		[Parameter]
		public EventCallback<AlertStatus> StatusChanged { get; set; }

		public void Reset()
        {
			Status.ShowMessage = false;
			Status.ErrorMessage = string.Empty;
			Status.SucceedMessage = string.Empty;
		}
	}
}

