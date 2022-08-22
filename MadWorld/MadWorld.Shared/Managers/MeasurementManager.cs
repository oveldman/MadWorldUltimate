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
            return lengthTypeTo switch
            {
                MeasurementType.Feet => converter.ConvertToFeet(startValue),
                MeasurementType.Kilometers => converter.ConvertToKilometers(startValue),
                MeasurementType.Meter => converter.ConvertToMeter(startValue),
                MeasurementType.Mile => converter.ConvertToMile(startValue),
                MeasurementType.Unknown => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };
        }
    }
}

