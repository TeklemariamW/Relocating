using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Relocating.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILoggerManager _loggerManager;

        public WeatherForecastController(ILoggerManager loggerManager)
        {
            _loggerManager= loggerManager;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<string> Get()
        {
            _loggerManager.LogInfo("Here is info message from the controller.");
            _loggerManager.LogDebug("Here is debug message from the controller.");
            _loggerManager.LogWarn("Here is warn message from the controller.");
            _loggerManager.LogError("Here is error message from the controller.");

            return new string[] { "value1", "value2" };
        }
    }
}