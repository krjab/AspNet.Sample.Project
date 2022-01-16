using Autofac;
using Ref.WebApi.Starter.Contracts.RequestContext;
using Ref.WebApi.Starter.Web.Services.RequestContext;

namespace Ref.WebApi.Starter.Web.CompositionRoot
{
    internal class StartupModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrentTimeStampResolver>().As<ICurrentTimeStampResolver>().SingleInstance();
            builder.Register(c => c.Resolve<ICurrentTimeStampResolver>().Resolve())
                .InstancePerLifetimeScope();
        }
    }
}