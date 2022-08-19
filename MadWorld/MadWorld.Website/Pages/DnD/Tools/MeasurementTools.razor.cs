using System;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.DnD.Tools
{
	public partial class MeasurementTools
	{
		[Inject]
		private IMeasurementConverter Converter { get; set; } = null!;

        private double StartLengthValue { get; set; } = 1.0;
		private double EndLengthValue { get; set; } = 0.0;

		private MeasurementType LengthTypeFrom { get; set; } = MeasurementType.Feet;
        private MeasurementType LengthTypeTo { get; set; } = MeasurementType.Meter;

        protected override void OnInitialized()
        {
			ConvertLength();

            base.OnInitialized();
        }

        private void SwapLength()
        {
	        (LengthTypeFrom, LengthTypeTo) = (LengthTypeTo, LengthTypeFrom);
	        ConvertLength();
        } 

        private void ConvertLength()
		{
			EndLengthValue = Converter.ConvertLength(StartLengthValue, LengthTypeFrom, LengthTypeTo);
        }
	}
}

