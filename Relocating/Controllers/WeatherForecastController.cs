using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Relocating.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    

    private readonly ILoggerManager _loggerManager;
    private readonly IRepositoryWrapper _repository;

    //public WeatherForecastController(ILoggerManager loggerManager)
    //{
    //    _loggerManager= loggerManager;
    //}

    public WeatherForecastController(IRepositoryWrapper repositoryWrapper)
    {
        _repository = repositoryWrapper;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult GetAll()
    {
        var persons = _repository.Address.FindAll();

        return Ok(persons);
    }

    
}