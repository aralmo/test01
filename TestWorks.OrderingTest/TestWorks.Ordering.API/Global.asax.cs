using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestWorks.Ordering.API.OrderingMethods;
using TestWorks.Ordering.API.TextAnalysis;

namespace TestWorks.Ordering.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(cfg => cfg.MapHttpAttributeRoutes());

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            builder
                .RegisterType<TextAnalyzer>()
                .SingleInstance()
                .As<ITextAnalyzer>();

            builder
                .RegisterType<OrderingMethodsRegistry>()
                .SingleInstance()
                .As<IOrderingMethodsRegistry>();

            builder
                .RegisterType<AlphabeticAscOrderingMethod>()
                .SingleInstance()
                .As<IOrderingMethod>();

            builder
                .RegisterType<AlphabeticDescOrderingMethod>()
                .SingleInstance()
                .As<IOrderingMethod>();

            builder
                .RegisterType<LengthAscOrderingMethod>()
                .SingleInstance()
                .As<IOrderingMethod>();

            GlobalConfiguration.Configuration.DependencyResolver =
               new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}
