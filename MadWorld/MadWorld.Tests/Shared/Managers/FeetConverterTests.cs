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
        var result = converter.Convert(startValue, measureTo);

        // Assert
        Assert.Equal(expectedResult, result);

        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public void Convert_DoubleFeetToUnknown(FeetConverter converter)
    {
        // Test data
        const double startValue = 1.0;
        const MeasurementType measureTo = MeasurementType.Unknown;

        // No Setup

        // Act & Assert
        Assert.Throws<NotImplementedException>(() => converter.Convert(startValue, measureTo));

        // No Teardown
    }
}