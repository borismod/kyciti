using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;

namespace kyciti
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = DependencyResolverConfig.ConfigureContainer();

            GlobalConfiguration.Configure(configuration => WebApiConfig.Register(configuration, container));
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var valuationInitializer = container.Resolve<IValuationInitializer>();
            valuationInitializer.Initialize();
        }
    }
}
