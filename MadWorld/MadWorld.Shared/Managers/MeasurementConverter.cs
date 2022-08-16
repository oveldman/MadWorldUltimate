using System;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Managers
{
    public class MeasurementConverter : IMeasurementConverter
    {
        private const double _meterToFeetConversion = 3.2808;

        public double ConvertLength(double startValue, MeasurementType lengthTypeFrom, MeasurementType lengthTypeTo)
        {
            if (lengthTypeFrom == lengthTypeTo)
            {
                return startValue;
            }

            switch (lengthTypeFrom)
            {
                case MeasurementType.Feet:
                    return ConvertFeet(startValue, lengthTypeTo);
                case MeasurementType.Meter:
                    return ConvertMeter(startValue, lengthTypeTo);
                default:
                    throw new NotImplementedException();
            }
        }

        private static double ConvertFeet(double startValue, MeasurementType lengthTypeTo)
        {
            switch (lengthTypeTo)
            {
                case MeasurementType.Feet:
                    return startValue;
                case MeasurementType.Meter:
                    return ConvertFeetToMeter(startValue);
                default:
                    throw new NotImplementedException();
            }
        }

        private static double ConvertMeter(double startValue, MeasurementType lengthTypeTo)
        {
            switch (lengthTypeTo)
            {
                case MeasurementType.Feet:
                    return ConvertMeterToFeet(startValue);
                case MeasurementType.Meter:
                    return startValue;
                default:
                    throw new NotImplementedException();
            }
        }

        private static double ConvertFeetToMeter(double startValue)
        {
            return startValue / _meterToFeetConversion;
        }

        private static double ConvertMeterToFeet(double startValue)
        {
            return startValue * _meterToFeetConversion;
        }
    }
}

