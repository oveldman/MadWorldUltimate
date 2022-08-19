using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers.Interfaces;

namespace MadWorld.Shared.Factories.Interfaces;

public interface IMeasurementFactory
{
    IMeasurementConverter GetMeasurementConverter(MeasurementType measurementType);
}