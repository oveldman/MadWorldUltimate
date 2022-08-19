using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers;

namespace MadWorld.Tests.Shared.Managers;

public class MeterConverterTests
{
    [Theory]
    [AutoDomainInlineData(1.0, 3.2808)]
    [AutoDomainInlineData(0.30480370641307, 1.0)]
    public void ConvertLength_DoubleMeterToFeet_double(double startValue, double expectedResult, MeterConverter converter)
    {
        // Test data
        const MeasurementType measureTo = MeasurementType.Feet;

        // No Setup

        // Act
        var result = converter.Convert(startValue, measureTo);

        // Assert
        Assert.Equal(expectedResult, result);

        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public void Convert_DoubleMeterToUnknown(MeterConverter converter)
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