using MadWorld.Shared.Enums;

namespace MadWorld.Shared.Managers.Interfaces;

public interface IMeasurementConverter
{
    double ConvertToMeter(double startValue);
    double ConvertToFeet(double startValue);
    double ConvertToMile(double startValue);
    double ConvertToKilometers(double startValue);
}