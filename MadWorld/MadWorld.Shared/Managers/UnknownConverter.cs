using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Managers;

public class UnknownConverter : IMeasurementConverter
{
    public double Convert(double startValue, MeasurementType measurementType)
    {
        return startValue;
    }
}