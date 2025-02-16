namespace Testing;

public class WeatherService : IWeatherService
{
    public async Task<string> GetWeatherAsync(string city)
    {
        await Task.Delay(500);
        return $"Sunny in {city}";
    }
}