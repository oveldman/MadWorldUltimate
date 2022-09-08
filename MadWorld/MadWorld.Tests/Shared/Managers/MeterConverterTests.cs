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
        // No Test data
        // No Setup

        // Act
        var result = converter.ConvertToFeet(startValue);

        // Assert
        Assert.Equal(expectedResult, result);

        // No Teardown
    }
    
    [Theory]
    [AutoDomainInlineData(1.0, 1.0)]
    [AutoDomainInlineData(0.30480370641307, 0.30480370641307)]
    public void ConvertLength_DoubleMeterToMeter_double(double startValue, double expectedResult, MeterConverter converter)
    {
        // No Test data
        // No Setup

        // Act
        var result = converter.ConvertToMeter(startValue);

        // Assert
        Assert.Equal(expectedResult, result);

        // No Teardown
    }
}