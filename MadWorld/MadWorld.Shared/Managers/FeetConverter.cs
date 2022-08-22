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
        throw new NotImplementedException();
    }

    public double ConvertToKilometers(double startValue)
    {
        throw new NotImplementedException();
    }
}