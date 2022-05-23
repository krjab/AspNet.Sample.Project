using System;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using NUnit.Framework;
using Moq;
using Newtonsoft.Json;
using Ref.WebApi.Starter.Web.Models;
using Ref.WebApi.Starter.Web.Services;

namespace Ref.WebApi.WebTest;

[Obsolete("Only as example")]
public class SampleControllerTest
{
	
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public async Task Call_Get_Method()
	{
		// Setup
		
		var fakeService = new Mock<IForecastService>();
		WeatherForecast forecastEntry = new WeatherForecast(new DateTime(2022, 5, 23, 9, 10, 11),
			38,
			"Some summary");
		fakeService.Setup(x => x.FetchForecast()).ReturnsAsync(new[]
		{
			forecastEntry
		});
		
		// Run
		
		var response = await TestWebApplicationFactory.CreateClientForWithMockedServices(b =>
		{
			b.Register(c => fakeService.Object).As<IForecastService>();
		}).GetAsync("/WeatherForecast");
		
		// Verify
		
		response.EnsureSuccessStatusCode();
		var responseString = await response.Content.ReadAsStringAsync();

		var result =JsonConvert.DeserializeObject<WeatherForecast[]>(responseString);

		result.Length.Should().Be(1);
		result[0].Should().Be(forecastEntry);

	}
}