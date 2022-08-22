using MadWorld.Shared.Constants;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Managers;

public class FeetConverter : IMeasurementConverter
{
    public double ConvertToMeter(double startValue)
    {
        return startValue / MeasurementConstants.MeterToFeetConversion;
    }

    public double ConvertToFeet(double startValue)
    {
        return startValue;
    }

    public double ConvertToMile(double startValue)
    {
        return ConvertToKilometers(startValue) / MeasurementConstants.KilometersToMileConversion;
    }

    public double ConvertToKilometers(double startValue)
    {
        return ConvertToMeter(startValue) / MeasurementConstants.KilometersToMeterConversion;
    }
}