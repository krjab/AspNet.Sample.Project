using System.Runtime.CompilerServices;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

[assembly: InternalsVisibleTo("Ref.WebApi.Starter.Test")]

namespace Ref.WebApi.Starter.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, _, configuration) => configuration
                    .ReadFrom.Configuration(context.Configuration))
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())

                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}