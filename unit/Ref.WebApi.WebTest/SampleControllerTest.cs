using System;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using Ref.WebApi.Starter.Web;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace Ref.WebApi.WebTest;

[Obsolete("Only as example")]
public class SampleControllerTest
{
	private TestServer _hostServer;
	private HttpClient _client;
	
	[SetUp]
	public void Setup()
	{
		var application = new WebApplicationFactory<Program>()
			.WithWebHostBuilder(builder =>
			{
				builder.ConfigureServices(s => s.AddAutofac());
				// ... Configure test services
			});
		
		// _hostServer = new TestServer(new WebHostBuilder()
		// 	.ConfigureServices(s=>s.Us)
		// 	
		// 	//.UseServiceProviderFactory(new AutofacServiceProviderFactory())
		// 	.UseStartup<Startup>(ctx=>ctx.HostingEnv)
		// 	
		// );

		_client = application.CreateClient();
	}

	[Test]
	public async Task Call_Get_Method()
	{
		var response = await _client.GetAsync("/WeatherForecast");
		
		response.EnsureSuccessStatusCode();
		var responseString = await response.Content.ReadAsStringAsync();

		responseString.Should().NotBeEmpty();


	}
}