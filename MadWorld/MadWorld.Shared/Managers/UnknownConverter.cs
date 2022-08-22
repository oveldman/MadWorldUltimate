using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Managers;

public class UnknownConverter : IMeasurementConverter
{
    public double ConvertToMeter(double startValue)
    {
        return ReturnStartValue(startValue);
    }

    public double ConvertToFeet(double startValue)
    {
        return ReturnStartValue(startValue);
    }

    public double ConvertToMile(double startValue)
    {
        return ReturnStartValue(startValue);
    }

    public double ConvertToKilometers(double startValue)
    {
        return ReturnStartValue(startValue);
    }

    private static double ReturnStartValue(double startValue)
    {
        return startValue;
    }
}