using Microsoft.AspNetCore.Mvc;
using SlottetBackend.Services;
using SlottetDomain.Entity;

namespace SlottetBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IResidentSchemaRepo _repo;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IResidentSchemaRepo schemaRepo)
        {
            _logger = logger;
            _repo = schemaRepo;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("studiecafe")]
        public async Task<string> GetCafe()
        {
            await _repo.GetAllAsync();
            return "studiecafe";
        }
    }
}
