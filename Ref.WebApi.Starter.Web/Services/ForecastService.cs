using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ref.WebApi.Starter.Contracts.RequestContext;
using Ref.WebApi.Starter.Web.Models;

namespace Ref.WebApi.Starter.Web.Services;

[Obsolete("Serves only as example")]
public interface IForecastService
{
	Task<IReadOnlyList<WeatherForecast>> FetchForecast();
}

[Obsolete("Serves only as example")]
internal class ForecastService : IForecastService
{
	private static readonly string[] _summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};
	
	private readonly CurrentTimeStamp _currentTime;

	public ForecastService(CurrentTimeStamp currentTime)
	{
		_currentTime = currentTime;
	}

	public async Task<IReadOnlyList<WeatherForecast>> FetchForecast()
	{
		var rng = new Random();
		return Enumerable.Range(1, 5).Select(index => new WeatherForecast(_currentTime.TimeStamp.AddDays(index),
			rng.Next(-20, 55),
			_summaries[rng.Next(_summaries.Length)]
		)).ToArray();
	}
}