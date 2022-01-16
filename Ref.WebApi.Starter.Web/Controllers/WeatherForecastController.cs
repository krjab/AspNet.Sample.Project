using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ref.WebApi.Starter.Web.Models;
using Ref.WebApi.Starter.Web.Models.Business;

namespace Ref.WebApi.Starter.Web.Controllers
{
    [Obsolete("Serves only as an example")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CurrentTimeStamp _currentTime;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CurrentTimeStamp currentTime)
        {
            _logger = logger;
            _currentTime = currentTime;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogDebug($"called {nameof(WeatherForecastController)}.{nameof(WeatherForecastController.Get)}");
            
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast(_currentTime.TimeStamp.AddDays(index),
                    rng.Next(-20, 55),
                    Summaries[rng.Next(Summaries.Length)]
                )).ToArray();
        }
    }
}