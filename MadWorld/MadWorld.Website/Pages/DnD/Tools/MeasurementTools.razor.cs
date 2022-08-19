using System;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MadWorld.Website.Pages.DnD.Tools
{
	public partial class MeasurementTools
	{
		[Inject]
		private IMeasurementManager Manager { get; set; } = null!;

		private double StartLengthValue
		{
			get => StartLengthValueLazy;
			set
			{
				StartLengthValueLazy = value;
				ConvertLength();
			}
		}

        private double StartLengthValueLazy { get; set; } = 1.0;
        private double EndLengthValue { get; set; }

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
			EndLengthValue = Manager.ConvertLength(StartLengthValue, LengthTypeFrom, LengthTypeTo);
        }

        private List<MeasurementType> GetMeasureTypeValues()
        {
	        return Enum.GetValues<MeasurementType>()
						.Where(mt => mt != MeasurementType.Unknown)
						.ToList();
        }
	}
}

