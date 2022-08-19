using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers;

namespace MadWorld.Tests.Shared.Managers;

public class UnknownConverterTests
{
    [Theory]
    [AutoDomainData]
    public void ConvertLength_DoubleUnknownToFeet(UnknownConverter converter)
    {
        // Test data
        const double startValue = 1.0;
        const MeasurementType measureTo = MeasurementType.Feet;

        // No Setup

        // Act
        var result = converter.Convert(startValue, measureTo);
        
        // Assert
        Assert.Equal(startValue, result);

        // No Teardown
    }
}