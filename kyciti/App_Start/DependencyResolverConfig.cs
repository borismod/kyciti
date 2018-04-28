using Autofac;
using Autofac.Integration.WebApi;
using kyciti.Controllers;
using kyciti.Engine;

namespace kyciti
{
    public static class DependencyResolverConfig
    {
        public static IContainer ConfigureContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterAssemblyTypes(typeof(HtmlSanitizer).Assembly)
                .AsImplementedInterfaces();

            containerBuilder.RegisterType<CashedValuationService>()
                .AsImplementedInterfaces()
                .SingleInstance();

            containerBuilder.RegisterType<CashedCompanyDataRetriever>()
                .AsImplementedInterfaces()
                .SingleInstance();

            containerBuilder.RegisterModule<LoggingModule>();

            containerBuilder.RegisterApiControllers(typeof(ValuationController).Assembly);

            return containerBuilder.Build();
        }
    }
}