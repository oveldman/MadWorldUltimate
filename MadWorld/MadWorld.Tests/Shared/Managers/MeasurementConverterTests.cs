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
        [AutoDomainInlineData(1.0)]
        [AutoDomainInlineData(10.0)]
        public void ConvertLength_DoubleFeetToFeet_double(double startValue, MeasurementManager manager)
        {
            // Test data
            const MeasurementType measureFrom = MeasurementType.Feet;
            const MeasurementType measureTo = MeasurementType.Feet;

            // No Setup

            // Act
            double result = manager.ConvertLength(startValue, measureFrom, measureTo);

            // Assert
            Assert.Equal(startValue, result);

            // No Teardown
        }
    }
}

