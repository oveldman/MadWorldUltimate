using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers;

namespace MadWorld.Tests.Shared.Managers;

public class FeetConverterTests
{
    [Theory]
    [AutoDomainInlineData(1.0, 0.30480370641307)]
    [AutoDomainInlineData(3.2808, 1.0)]
    public void Convert_DoubleFeetToMeter_double(double startValue, double expectedResult, FeetConverter converter)
    {
        // Test data
        const MeasurementType measureTo = MeasurementType.Meter;

        // No Setup

        // Act
        var result = converter.ConvertToMeter(startValue);

        // Assert
        Assert.Equal(expectedResult, result);

        // No Teardown
    }
    
    [Theory]
    [AutoDomainInlineData(1.0, 1.0)]
    [AutoDomainInlineData(3.2808, 3.2808)]
    public void Convert_DoubleFeetToFeet_double(double startValue, double expectedResult, FeetConverter converter)
    {
        // Test data
        const MeasurementType measureTo = MeasurementType.Meter;

        // No Setup

        // Act
        var result = converter.ConvertToFeet(startValue);

        // Assert
        Assert.Equal(expectedResult, result);

        // No Teardown
    }
}