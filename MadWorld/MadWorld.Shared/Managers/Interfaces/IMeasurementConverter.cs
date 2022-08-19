using MadWorld.Shared.Enums;

namespace MadWorld.Shared.Managers.Interfaces;

public interface IMeasurementConverter
{
    double Convert(double startValue, MeasurementType measurementTypeTo);
}