using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Testing;

var builder = WebApplication.CreateBuilder(args);

// Реєструємо сервіс
builder.Services.AddScoped<IWeatherService, WeatherService>();

// Додаємо контролери
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
