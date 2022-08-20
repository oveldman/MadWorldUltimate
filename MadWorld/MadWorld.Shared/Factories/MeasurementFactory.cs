using MadWorld.Shared.Enums;
using MadWorld.Shared.Factories.Interfaces;
using MadWorld.Shared.Managers;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Factories;

public class MeasurementFactory : IMeasurementFactory
{
    public IMeasurementConverter GetMeasurementConverter(MeasurementType measurementType)
    {
        return measurementType switch
        {
            MeasurementType.Feet => new FeetConverter(),
            MeasurementType.Meter => new MeterConverter(),
            MeasurementType.Unknown => new UnknownConverter(),
            _ => throw new ArgumentOutOfRangeException(nameof(measurementType), measurementType, "Measure")
        };
    }
}