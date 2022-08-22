using MadWorld.Shared.Constants;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Managers;

public class MileConverter : IMeasurementConverter
{
    public double ConvertToMeter(double startValue)
    {
        return ConvertToKilometers(startValue) * MeasurementConstants.KilometersToMeterConversion;
    }

    public double ConvertToFeet(double startValue)
    {
        return ConvertToMeter(startValue) * MeasurementConstants.MeterToFeetConversion;
    }

    public double ConvertToMile(double startValue)
    {
        return startValue;
    }

    public double ConvertToKilometers(double startValue)
    {
        return startValue * MeasurementConstants.KilometersToMileConversion;
    }
}