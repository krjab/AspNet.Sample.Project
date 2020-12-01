using Autofac;
using Ref.WebApi.Starter.Web.Services.RequestContext;

namespace Ref.WebApi.Starter.Web.CompositionRoot
{
    internal class StartupModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrentTimeStampResolver>().SingleInstance();
            builder.Register(c => c.Resolve<CurrentTimeStampResolver>().Resolve())
                .InstancePerLifetimeScope();
        }
    }
}