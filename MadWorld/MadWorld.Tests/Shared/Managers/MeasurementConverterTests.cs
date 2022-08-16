using System;
using MadWorld.Shared.Common;
using System.IO;
using MadWorld.Shared.Managers;
using MadWorld.Shared.Enums;
using Microsoft.Azure.WebJobs;

namespace MadWorld.Tests.Shared.Managers
{
	public class MeasurementConverterTests
	{
        [Theory]
        [AutoDomainInlineData(1.0, 0.30480370641307)]
        [AutoDomainInlineData(3.2808, 1.0)]
        public void ConvertLength_DoubleFeetToMeter_double(double startValue, double expectedResult, MeasurementConverter converter)
        {
            // No Test data
            MeasurementType measureFrom = MeasurementType.Feet;
            MeasurementType measureTo = MeasurementType.Meter;

            // No Setup

            // Act
            double result = converter.ConvertLength(startValue, measureFrom, measureTo);

            // Assert
            Assert.Equal(expectedResult, result);

            // No Teardown
        }

        [Theory]
        [AutoDomainInlineData(1.0, 3.2808)]
        [AutoDomainInlineData(0.30480370641307, 1.0)]
        public void ConvertLength_DoubleMeterToFeet_double(double startValue, double expectedResult, MeasurementConverter converter)
        {
            // No Test data
            MeasurementType measureFrom = MeasurementType.Meter;
            MeasurementType measureTo = MeasurementType.Feet;

            // No Setup

            // Act
            double result = converter.ConvertLength(startValue, measureFrom, measureTo);

            // Assert
            Assert.Equal(expectedResult, result);

            // No Teardown
        }
    }
}

