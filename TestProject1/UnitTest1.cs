using Microsoft.AspNetCore.Mvc;
using Testing;
using Xunit;

namespace TestProject1;

public class WeatherControllerTests
{
    [Fact]
    public async Task GetWeather_ReturnsCorrectResult()
    {
        // Arrange
        var mockService = new Mock<IWeatherService>();
        mockService.Setup(service => service.GetWeatherAsync("Kyiv"))
            .ReturnsAsync("Sunny in Kyiv");

        var controller = new WeatherController(mockService.Object);

        // Act
        var result = await controller.GetWeather("Kyiv");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<string>(okResult.Value);
        Assert.Equal("Sunny in Kyiv", returnValue);
    }
}