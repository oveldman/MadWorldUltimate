using System.Diagnostics.Metrics;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharpWrappers;
using Bunit;
using MadWorld.Shared.Enums;
using MadWorld.Shared.Managers;
using MadWorld.Shared.Managers.Interfaces;
using MadWorld.Website.Pages.DnD.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.Tests.Website.Pages.DnD.Tools;

public class MeasurementToolsTests
{
    [Theory]
    [AutoDomainData]
    public void SwapLength_PressSwapButton_SwappedLengthLists(Mock<IMeasurementManager> measurementManager)
    {
        // Arrange
        using var ctx = new TestContext();
        measurementManager.Setup(mm =>
                mm.ConvertLength(It.IsAny<double>(),
                    It.IsAny<MeasurementType>(),
                    It.IsAny<MeasurementType>()))
            .Returns(1.0);
        ctx.Services.AddScoped(_ => measurementManager.Object);

        var cutComponent = ctx.RenderComponent<MeasurementTools>();
        cutComponent.Instance.LengthTypeFrom = MeasurementType.Feet;
        cutComponent.Instance.LengthTypeTo = MeasurementType.Meter;

        // Act
        cutComponent.Find("#swap-length-btn").Click();

        // Assert
        Assert.Equal(MeasurementType.Meter, cutComponent.Instance.LengthTypeFrom);
        Assert.Equal(MeasurementType.Feet, cutComponent.Instance.LengthTypeTo);
    }

    [Theory]
    [AutoDomainData]
    public void StartLengthValue_UpdateStartLength_UpdatedEndLength(Mock<IMeasurementManager> measurementManager)
    {
        // Arrange
        using var ctx = new TestContext();
        measurementManager.SetupSequence(mm =>
                mm.ConvertLength(It.IsAny<double>(),
                    It.IsAny<MeasurementType>(),
                    It.IsAny<MeasurementType>()))
            .Returns(2.0)
            .Returns(3.0)
            .Returns(4.0);

        ctx.Services.AddScoped(_ => measurementManager.Object);

        var cutComponent = ctx.RenderComponent<MeasurementTools>();
        cutComponent.Instance.LengthTypeFrom = MeasurementType.Feet;
        cutComponent.Instance.LengthTypeTo = MeasurementType.Feet;
        
        // Act
        cutComponent.Find("#lengthFrom").Change(3.0);

        // Assert
        var lengthToInput = cutComponent.Find("#lengthTo").Unwrap() as IHtmlInputElement;
        Assert.Equal("3", lengthToInput?.Value);
    }
}