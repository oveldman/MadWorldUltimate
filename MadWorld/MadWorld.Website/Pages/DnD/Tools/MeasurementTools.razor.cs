using System;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.DnD.Tools
{
	public partial class MeasurementTools
	{
		[Inject]
		private IMeasurementConverter _converter { get; set; } = null!;

        public double _startLengthValue { get; set; } = 1.0;
		public double _endLengthValue { get; set; } = 0.0;

		public MeasurementType _lengthTypeFrom { get; set; } = MeasurementType.Feet;
        public MeasurementType _lengthTypeTo { get; set; } = MeasurementType.Meter;

        protected override void OnInitialized()
        {
			ConvertLength();

            base.OnInitialized();
        }

        public void ConvertLength()
		{
			_endLengthValue = _converter.ConvertLength(_startLengthValue, _lengthTypeFrom, _lengthTypeTo);
        }
	}
}

