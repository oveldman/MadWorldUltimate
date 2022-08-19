using System;
using MadWorld.Shared.Constants;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Factories.Interfaces;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Managers
{
    public class MeasurementManager : IMeasurementManager
    {
        private readonly IMeasurementFactory _measurementFactory;
        public MeasurementManager(IMeasurementFactory measurementFactory)
        {
            _measurementFactory = measurementFactory;
        }
        
        public double ConvertLength(double startValue, MeasurementType lengthTypeFrom, MeasurementType lengthTypeTo)
        {
            if (lengthTypeFrom == lengthTypeTo)
            {
                return startValue;
            }

            var converter = _measurementFactory.GetMeasurementConverter(lengthTypeFrom);
            return converter.Convert(startValue, lengthTypeTo);
        }
    }
}

