using MadWorld.Shared.Constants;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Managers;

public class FeetConverter : IMeasurementConverter
{
    public double Convert(double startValue, MeasurementType measurementTypeTo)
    {
        return measurementTypeTo switch
        {
            MeasurementType.Feet => startValue,
            MeasurementType.Meter => ConvertToMeter(startValue),
            MeasurementType.Unknown => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };
    }

    private static double ConvertToMeter(double startValue)
    {
        return startValue / MeasurementConstants.MeterToFeetConversion;
    }
}