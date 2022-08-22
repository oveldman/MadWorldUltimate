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

        // No Setup

        // Act
        var result = converter.ConvertToFeet(startValue);
        
        // Assert
        Assert.Equal(startValue, result);

        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public void ConvertLength_DoubleUnknownToMeter_Double(UnknownConverter converter)
    {
        // Test data
        const double startValue = 1.0;

        // No Setup

        // Act
        var result = converter.ConvertToMeter(startValue);
        
        // Assert
        Assert.Equal(startValue, result);

        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public void ConvertLength_DoubleUnknownToFeet_Double(UnknownConverter converter)
    {
        // Test data
        const double startValue = 1.0;

        // No Setup

        // Act
        var result = converter.ConvertToFeet(startValue);
        
        // Assert
        Assert.Equal(startValue, result);

        // No Teardown
    }
}