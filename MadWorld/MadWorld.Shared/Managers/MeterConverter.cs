using MadWorld.Shared.Constants;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Managers;

public class MeterConverter : IMeasurementConverter
{
    public double Convert(double startValue, MeasurementType measurementTypeTo)
    {
        return measurementTypeTo switch
        {
            MeasurementType.Feet => ConvertToFeet(startValue),
            MeasurementType.Meter => startValue,
            MeasurementType.Unknown => throw new NotImplementedException(),
            _ => throw new NotImplementedException()
        };
    }
    
    private static double ConvertToFeet(double startValue)
    {
        return startValue * MeasurementConstants.MeterToFeetConversion;
    }
}