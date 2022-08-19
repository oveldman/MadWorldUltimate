using MadWorld.Shared.Enums;
using MadWorld.Shared.Factories;
using MadWorld.Shared.Managers;

namespace MadWorld.Tests.Shared.Factories;

public class MeasurementFactoryTests
{
    [Theory]
    [AutoDomainInlineData(MeasurementType.Feet, typeof(FeetConverter))]
    [AutoDomainInlineData(MeasurementType.Meter, typeof(MeterConverter))]
    [AutoDomainInlineData(MeasurementType.Unknown, typeof(UnknownConverter))]
    public void GetMeasurementConverter_MeasurementType_GetMeasurementClass(MeasurementType measurementType,
        Type expectedType, 
        MeasurementFactory factory)
    {
        // No Test data

        // No Setup

        // Act
        var result = factory.GetMeasurementConverter(measurementType);

        // Assert
        Assert.IsType(expectedType, result);

        // No Teardown
    }
}