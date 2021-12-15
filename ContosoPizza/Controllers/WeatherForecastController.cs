using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

//The following 2 lines are attributes applied to the WeatherForcastController
[ApiController] //enables opinionated behaviors that make it easier to build web APIs.
[Route("[controller]")] //defines the routing pattern [controller]. The [controller] token is replaced by the controller's name (case-insensitive, without the Controller suffix). Requests to https://localhost:{PORT}/weatherforecast are handled by this controller.
public class WeatherForecastController : ControllerBase // Weather Controller is inheriting from the ControllerBase class.  If this were a MVC app, we would inherit from Controller (which itself inherits from ControllerBase)
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    }; // This creates an array with 10 strings stored in the constant Summaries

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")] //This attribute routes HTTP GET requests to the public IEnumerable<WeatherForecast> Get() method
    public IEnumerable<WeatherForecast> Get() // a method called 'Get', that takes in no arguments and returns a
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
