using System;
using System.Net.Http;
using Autofac;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Ref.WebApi.Starter.Web;

namespace Ref.WebApi.WebTest;

public class TestWebApplicationFactory : WebApplicationFactory<Startup>
{
	private Action<ContainerBuilder> _setupMockServicesAction = _ => { };
	
	public TestWebApplicationFactory WithMockServices(Action<ContainerBuilder> setupMockServices)
	{
		_setupMockServicesAction = setupMockServices;
		return this;
	}
	
	protected override IHost CreateHost(IHostBuilder builder)
	{
		builder.ConfigureContainer<ContainerBuilder>(b => { _setupMockServicesAction?.Invoke(b); });
		return base.CreateHost(builder);
	}

	public static WebApplicationFactory<Startup> Create(Action<ContainerBuilder> setupMockServices)
	{
		return  new TestWebApplicationFactory()
				.WithMockServices(setupMockServices)
				.WithWebHostBuilder(builder =>
				{
					// ... Configure test services
				})
			;
	}

	public static HttpClient CreateClientForWithMockedServices(Action<ContainerBuilder> setupMockServices)
	{
		return Create(setupMockServices).CreateClient();
	}
}