using System;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Managers
{
    public class MeasurementConverter : IMeasurementConverter
    {
        private const double MeterToFeetConversion = 3.2808;

        public double ConvertLength(double startValue, MeasurementType lengthTypeFrom, MeasurementType lengthTypeTo)
        {
            if (lengthTypeFrom == lengthTypeTo)
            {
                return startValue;
            }

            return lengthTypeFrom switch
            {
                MeasurementType.Feet => ConvertFeet(startValue, lengthTypeTo),
                MeasurementType.Meter => ConvertMeter(startValue, lengthTypeTo),
                MeasurementType.Unknown => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };
        }

        private static double ConvertFeet(double startValue, MeasurementType lengthTypeTo)
        {
            return lengthTypeTo switch
            {
                MeasurementType.Feet => startValue,
                MeasurementType.Meter => ConvertFeetToMeter(startValue),
                MeasurementType.Unknown => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };
        }

        private static double ConvertMeter(double startValue, MeasurementType lengthTypeTo)
        {
            return lengthTypeTo switch
            {
                MeasurementType.Feet => ConvertMeterToFeet(startValue),
                MeasurementType.Meter => startValue,
                MeasurementType.Unknown => throw new NotImplementedException(),
                _ => throw new NotImplementedException()
            };
        }

        private static double ConvertFeetToMeter(double startValue)
        {
            return startValue / MeterToFeetConversion;
        }

        private static double ConvertMeterToFeet(double startValue)
        {
            return startValue * MeterToFeetConversion;
        }
    }
}

