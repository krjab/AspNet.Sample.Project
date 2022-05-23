using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ref.WebApi.Starter.Web.Models;
using Ref.WebApi.Starter.Web.Services;

namespace Ref.WebApi.Starter.Web.Controllers
{
    [Obsolete("Serves only as an example")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IForecastService _forecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IForecastService forecastService)
        {
            _logger = logger;
            _forecastService = forecastService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            _logger.LogInformation($"called {nameof(WeatherForecastController)}.{nameof(WeatherForecastController.Get)}");

            return await _forecastService.FetchForecast();
        }
    }
}