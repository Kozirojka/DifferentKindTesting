using Microsoft.AspNetCore.Mvc;
using Moq;
using Testing;

namespace Е;

public class WeatherControllerTests
{
    private readonly Mock<IWeatherService> _weatherServiceMock;
    private readonly WeatherController _controller;

    public WeatherControllerTests()
    {
        _weatherServiceMock = new Mock<IWeatherService>();
        _controller = new WeatherController(_weatherServiceMock.Object);
    }

    [Fact]
    public async Task GetWeather_ReturnsOk_WithWeatherData()
    {
        // Arrange
        string city = "Kyiv";
        string expectedWeather = $"Sunny in Kyi v";
        _weatherServiceMock
            .Setup(service => service.GetWeatherAsync(city))
            .ReturnsAsync(expectedWeather);

        // Act
        var result = await _controller.GetWeather(city);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedWeather, okResult.Value);
    }
}